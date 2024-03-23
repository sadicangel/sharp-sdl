using SharpSDL.Objects;

namespace SharpSDL;

public sealed class Window : IDisposable
{
    internal readonly nint _window;

    internal Window(nint window) => _window = window;

    public Window(string title, Point position, Size size, WindowFlags flags)
    {
        unsafe
        {
            _window = title.AsUtf8(title => SDL.CreateWindow(title, position.X, position.Y, size.Width, size.Height, (uint)flags));
        }
        if (_window == 0)
            SdlException.ThrowLastError();
    }

    public uint WindowId { get => SDL.GetWindowID(_window); }

    public WindowFlags Flags { get => (WindowFlags)SDL.GetWindowFlags(_window); }

    public string Title
    {
        get
        {
            unsafe
            {
                return MemoryMarshal.CreateReadOnlySpanFromNullTerminated(SDL.GetWindowTitle(_window))
                    .AsUtf16(utf16 => new string(utf16));
            }
        }
        set
        {
            unsafe
            {
                value.AsUtf8(utf8 => SDL.SetWindowTitle(_window, utf8));
            }
        }
    }

    public Point Position
    {
        get
        {
            unsafe
            {
                Unsafe.SkipInit(out Point pos);
                SDL.GetWindowPosition(_window, &pos.X, &pos.Y);
                return pos;
            }
        }
        set
        {
            unsafe
            {
                SDL.SetWindowPosition(_window, value.X, value.Y);
            }
        }
    }

    public bool IsResizable { get => Flags.HasFlag(WindowFlags.Resizable); set => SDL.SetWindowResizable(_window, value); }

    public Size Size
    {
        get
        {
            unsafe
            {
                Unsafe.SkipInit(out Size pos);
                SDL.GetWindowSize(_window, &pos.Width, &pos.Height);
                return pos;
            }
        }
        set
        {
            unsafe
            {
                SDL.SetWindowSize(_window, value.Width, value.Height);
            }
        }
    }

    public Size SizeInPixels
    {
        get
        {
            unsafe
            {
                Unsafe.SkipInit(out Size pos);
                SDL.GetWindowSizeInPixels(_window, &pos.Width, &pos.Height);
                return pos;
            }
        }
    }

    public Size MinimumSize
    {
        get
        {
            unsafe
            {
                Unsafe.SkipInit(out Size pos);
                SDL.GetWindowMinimumSize(_window, &pos.Width, &pos.Height);
                return pos;
            }
        }
        set
        {
            unsafe
            {
                SDL.SetWindowMinimumSize(_window, value.Width, value.Height);
            }
        }
    }

    public Size MaximumSize
    {
        get
        {
            unsafe
            {
                Unsafe.SkipInit(out Size pos);
                SDL.GetWindowMaximumSize(_window, &pos.Width, &pos.Height);
                return pos;
            }
        }
        set
        {
            unsafe
            {
                SDL.SetWindowMaximumSize(_window, value.Width, value.Height);
            }
        }
    }

    public bool IsBordered { get => !Flags.HasFlag(WindowFlags.Borderless); set => SDL.SetWindowBordered(_window, value); }

    public Thickness BorderSize
    {
        get
        {
            unsafe
            {
                Unsafe.SkipInit(out Thickness t);
                if (SDL.GetWindowBordersSize(_window, &t.Top, &t.Left, &t.Bottom, &t.Right) == -1)
                    throw new SdlException("Window has not been initialized yet");
                return t;
            }
        }
    }

    public bool IsAlwaysOnTop { get => Flags.HasFlag(WindowFlags.AlwaysOnTop); set => SDL.SetWindowAlwaysOnTop(_window, value); }

    public bool HasSurface { get => SDL.HasWindowSurface(_window); }

    public bool IsInputGrabbed { get => SDL.GetWindowGrab(_window); set => SDL.SetWindowGrab(_window, value); }

    public bool IsMouseGrabbed { get => SDL.GetWindowMouseGrab(_window); set => SDL.SetWindowMouseGrab(_window, value); }

    public bool IsKeyboardGrabbed { get => SDL.GetWindowKeyboardGrab(_window); set => SDL.SetWindowKeyboardGrab(_window, value); }

    public Rect? MouseRect
    {
        get
        {
            unsafe
            {
                var rect = (Rect*)SDL.GetWindowMouseRect(_window);
                return rect is null ? null : *rect;
            }
        }
        set
        {
            unsafe
            {
                Unsafe.SkipInit(out Rect temp);
                SDL_Rect* rect = null;

                if (value.HasValue)
                {
                    temp = value.Value;
                    rect = (SDL_Rect*)&temp;
                }

                if (SDL.SetWindowMouseRect(_window, rect) != 0)
                    SdlException.ThrowLastError();
            }
        }
    }

    public float Brightness
    {
        get => SDL.GetWindowBrightness(_window);
        set
        {
            if (SDL.SetWindowBrightness(_window, value) != 0)
                SdlException.ThrowLastError();
        }
    }

    public float Opacity
    {
        get
        {
            unsafe
            {
                float opacity;
                if (SDL.GetWindowOpacity(_window, &opacity) != 0)
                    SdlException.ThrowLastError();
                return opacity;
            }
        }
        set
        {
            if (SDL.SetWindowOpacity(_window, value) != 0)
                SdlException.ThrowLastError();
        }
    }

    // Display related.

    public GammaRamp DisplayGammaRamp
    {
        get
        {
            unsafe
            {
                var r = new GammaRampArray();
                var g = new GammaRampArray();
                var b = new GammaRampArray();
                if (SDL.GetWindowGammaRamp(_window, (ushort*)&r, (ushort*)&g, (ushort*)&b) != 0)
                    SdlException.ThrowLastError();
                return new GammaRamp(r, g, b);
            }
        }
        set
        {
            unsafe
            {
                fixed (GammaRampArray* r = &value.Red, g = &value.Green, b = &value.Blue)
                {
                    if (SDL.SetWindowGammaRamp(_window, (ushort*)r, (ushort*)g, (ushort*)b) != 0)
                        SdlException.ThrowLastError();
                }
            }
        }
    }

    public bool IsShapedWindow { get => SDL.IsShapedWindow(_window); }

    public static bool IsScreenSaverEnabled { get => SDL.IsScreenSaverEnabled(); set { if (value) SDL.EnableScreenSaver(); else SDL.DisableScreenSaver(); } }

    // Display related.

    public unsafe void* SetData(byte* name, void* data) => SDL.SetWindowData(_window, name, data);

    public unsafe void* GetData(byte* name) => SDL.GetWindowData(_window, name);

    public void SetFullscreenMode(FullscreenMode mode)
    {
        if (SDL.SetWindowFullscreen(_window, (uint)mode) != 0)
            SdlException.ThrowLastError();
    }

    public nint GetSurface()
    {
        unsafe
        {
            var ptr = SDL.GetWindowSurface(_window);
            if (ptr is null)
                SdlException.ThrowLastError();
            return (nint)ptr;
        }
    }

    public void UpdateSurface()
    {
        unsafe
        {
            if (SDL.UpdateWindowSurface(_window) != 0)
                SdlException.ThrowLastError();
        }
    }

    public void UpdateSurfaceRects(ReadOnlySpan<Rect> rects)
    {
        unsafe
        {
            fixed (Rect* ptr = rects)
                if (SDL.UpdateWindowSurfaceRects(_window, (SDL_Rect*)ptr, rects.Length) != 0)
                    SdlException.ThrowLastError();
        }
    }

    public void DestroySurface()
    {
        if (SDL.DestroyWindowSurface(_window) != 0)
            SdlException.ThrowLastError();
    }

    public void Show() => SDL.ShowWindow(_window);
    public void Hide() => SDL.HideWindow(_window);
    public void Raise() => SDL.RaiseWindow(_window);
    public void Maximize() => SDL.MaximizeWindow(_window);
    public void Minimize() => SDL.MinimizeWindow(_window);
    public void Restore() => SDL.RestoreWindow(_window);
    public void Flash(FlashOperation operation)
    {
        if (SDL.FlashWindow(_window, (SDL_FlashOperation)operation) != 0)
            SdlException.ThrowLastError();
    }

    public void SetModalFor(Window parent)
    {
        if (SDL.SetWindowModalFor(_window, parent._window) != 0)
            SdlException.ThrowLastError();
    }

    public void SetInputFocus()
    {
        if (SDL.SetWindowInputFocus(_window) != 0)
            SdlException.ThrowLastError();
    }

    public void SetShape(scoped ref readonly Surface shape, WindowShapeMode mode)
    {
        unsafe
        {
            var result = SDL.SetWindowShape(
                _window,
                (SDL_Surface*)Unsafe.AsPointer(ref Unsafe.AsRef(in shape)),
                (SDL_WindowShapeMode*)Unsafe.AsPointer(ref mode));

            switch (result)
            {
                case SDL.SDL_NONSHAPEABLE_WINDOW:
                    throw new SdlException("Window is not a valid shaped window");
                case SDL.SDL_INVALID_SHAPE_ARGUMENT:
                    throw new SdlException("Invalid shape argument");
            }
        }
    }

    public WindowShapeMode GetShapeMode()
    {
        Unsafe.SkipInit(out WindowShapeMode mode);
        unsafe
        {
            var result = SDL.GetShapedWindowMode(_window, (SDL_WindowShapeMode*)&mode);
            switch (result)
            {
                case SDL.SDL_NONSHAPEABLE_WINDOW:
                    throw new SdlException("Window is not a valid shaped window");
                case SDL.SDL_WINDOW_LACKS_SHAPE:
                    throw new SdlException("Window does not have a shape");
            }
        }
        return mode;
    }

    // Make this more managed-like.
    public unsafe void SetHitTest(delegate* unmanaged[Cdecl]<nint, Point*, void*, HitTestResult> callback, void* state)
    {
        if (SDL.SetWindowHitTest(_window, (delegate* unmanaged[Cdecl]<nint, SDL_Point*, void*, SDL_HitTestResult>)callback, state) != 0)
            SdlException.ThrowLastError();
    }

    public void Dispose()
    {
        if (_window != 0)
        {
            SDL.DestroyWindow(_window);
            ref var ptr = ref Unsafe.AsRef(in _window);
            ptr = 0;
        }
    }

    public static Window CreateShaped(string title, Point position, Size size, WindowFlags flags)
    {
        unsafe
        {
            var window = title.AsUtf8(title => SDL.CreateWindow(title, position.X, position.Y, size.Width, size.Height, (uint)flags));
            if (window == 0)
                SdlException.ThrowLastError();
            return new Window(window);
        }
    }

    public static Window FromWindowId(uint id)
    {
        var window = SDL.GetWindowFromID(id);
        if (window == 0)
            SdlException.ThrowLastError();
        return new Window(window);
    }

    public static Window? GetWindowWithInputGrabbed()
    {
        var window = SDL.GetGrabbedWindow();
        if (window is 0)
            return null;
        return new Window(window);
    }

    public static Window? GetWindowWithMouseFocus() =>
        SDL.GetMouseFocus() is var window and not 0 ? new Window(window) : null;
}


[Flags]
public enum WindowFlags
{
    Fullscreen = SDL_WindowFlags.SDL_WINDOW_FULLSCREEN,
    OpenGL = SDL_WindowFlags.SDL_WINDOW_OPENGL,
    Shown = SDL_WindowFlags.SDL_WINDOW_SHOWN,
    Hidden = SDL_WindowFlags.SDL_WINDOW_HIDDEN,
    Borderless = SDL_WindowFlags.SDL_WINDOW_BORDERLESS,
    Resizable = SDL_WindowFlags.SDL_WINDOW_RESIZABLE,
    Minimized = SDL_WindowFlags.SDL_WINDOW_MINIMIZED,
    Maximized = SDL_WindowFlags.SDL_WINDOW_MAXIMIZED,
    MouseGrabbed = SDL_WindowFlags.SDL_WINDOW_MOUSE_GRABBED,
    InputFocus = SDL_WindowFlags.SDL_WINDOW_INPUT_FOCUS,
    MouseFocus = SDL_WindowFlags.SDL_WINDOW_MOUSE_FOCUS,
    FullscreenDesktop = SDL_WindowFlags.SDL_WINDOW_FULLSCREEN_DESKTOP,
    Foreign = SDL_WindowFlags.SDL_WINDOW_FOREIGN,
    AllowHighDpi = SDL_WindowFlags.SDL_WINDOW_ALLOW_HIGHDPI,
    MouseCapture = SDL_WindowFlags.SDL_WINDOW_MOUSE_CAPTURE,
    AlwaysOnTop = SDL_WindowFlags.SDL_WINDOW_ALWAYS_ON_TOP,
    SkipTaskbar = SDL_WindowFlags.SDL_WINDOW_SKIP_TASKBAR,
    Utility = SDL_WindowFlags.SDL_WINDOW_UTILITY,
    Tooltip = SDL_WindowFlags.SDL_WINDOW_TOOLTIP,
    PopupMenu = SDL_WindowFlags.SDL_WINDOW_POPUP_MENU,
    KeyboardGrabbed = SDL_WindowFlags.SDL_WINDOW_KEYBOARD_GRABBED,
    Vulkan = SDL_WindowFlags.SDL_WINDOW_VULKAN,
    Metal = SDL_WindowFlags.SDL_WINDOW_METAL,
    InputGrabbed = SDL_WindowFlags.SDL_WINDOW_INPUT_GRABBED,
}

public enum FullscreenMode
{
    Windowed = 0,
    Fullscreen = SDL_WindowFlags.SDL_WINDOW_FULLSCREEN,
    FullscreenDesktop = SDL_WindowFlags.SDL_WINDOW_FULLSCREEN_DESKTOP,
}

public sealed record class GammaRamp(GammaRampArray Red, GammaRampArray Green, GammaRampArray Blue)
{
    public readonly GammaRampArray Red = Red;
    public readonly GammaRampArray Green = Green;
    public readonly GammaRampArray Blue = Blue;
}

[InlineArray(256)]
public struct GammaRampArray
{
    internal ushort _e0;
}

public enum HitTestResult
{
    Normal = SDL_HitTestResult.SDL_HITTEST_NORMAL,
    Draggable = SDL_HitTestResult.SDL_HITTEST_DRAGGABLE,
    ResizeTopLeft = SDL_HitTestResult.SDL_HITTEST_RESIZE_TOPLEFT,
    ResizeTop = SDL_HitTestResult.SDL_HITTEST_RESIZE_TOP,
    ResizeTopRight = SDL_HitTestResult.SDL_HITTEST_RESIZE_TOPRIGHT,
    ResizeRight = SDL_HitTestResult.SDL_HITTEST_RESIZE_RIGHT,
    ResizeBottomRight = SDL_HitTestResult.SDL_HITTEST_RESIZE_BOTTOMRIGHT,
    ResizeBottom = SDL_HitTestResult.SDL_HITTEST_RESIZE_BOTTOM,
    ResizeBottomLeft = SDL_HitTestResult.SDL_HITTEST_RESIZE_BOTTOMLEFT,
    ResizeLeft = SDL_HitTestResult.SDL_HITTEST_RESIZE_LEFT,
}

public enum FlashOperation
{
    Cancel = SDL_FlashOperation.SDL_FLASH_CANCEL,
    Briefly = SDL_FlashOperation.SDL_FLASH_BRIEFLY,
    UntilFocused = SDL_FlashOperation.SDL_FLASH_UNTIL_FOCUSED,
}

public enum WindowShapeModeName
{
    Default = SharpSDL.Interop.WindowShapeMode.ShapeModeDefault,
    BinarizeAlpha = SharpSDL.Interop.WindowShapeMode.ShapeModeBinarizeAlpha,
    ReverseBinarizeAlpha = SharpSDL.Interop.WindowShapeMode.ShapeModeReverseBinarizeAlpha,
    ColorKey = SharpSDL.Interop.WindowShapeMode.ShapeModeColorKey,
}

[StructLayout(LayoutKind.Explicit)]
public readonly struct WindowShapeModeParams
{
    [FieldOffset(0)]
    public readonly byte BinarizationCutOff;
    [FieldOffset(0)]
    public readonly ColorRgba ColorKey;
}

public readonly struct WindowShapeMode
{
    public readonly WindowShapeModeName Mode;
    public readonly WindowShapeModeParams Parameters;
}