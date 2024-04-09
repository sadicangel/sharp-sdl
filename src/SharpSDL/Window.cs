using SharpSDL.Graphics;
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
            _window = title.AsUtf8((p, _) => SDL2.CreateWindow(p, position.X, position.Y, size.Width, size.Height, (uint)flags));
        }
        if (_window == 0)
            SdlException.ThrowLastError();
    }

    public uint WindowId { get => SDL2.GetWindowID(_window); }

    public WindowFlags Flags { get => (WindowFlags)SDL2.GetWindowFlags(_window); }

    public string Title
    {
        get
        {
            unsafe
            {
                return StringHelper.ToUtf16(SDL2.GetWindowTitle(_window));
            }
        }
        set
        {
            unsafe
            {
                value.AsUtf8((p, _) => SDL2.SetWindowTitle(_window, p));
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
                SDL2.GetWindowPosition(_window, &pos.X, &pos.Y);
                return pos;
            }
        }
        set
        {
            unsafe
            {
                SDL2.SetWindowPosition(_window, value.X, value.Y);
            }
        }
    }

    public bool IsResizable { get => Flags.HasFlag(WindowFlags.Resizable); set => SDL2.SetWindowResizable(_window, value); }

    public Size Size
    {
        get
        {
            unsafe
            {
                Unsafe.SkipInit(out Size pos);
                SDL2.GetWindowSize(_window, &pos.Width, &pos.Height);
                return pos;
            }
        }
        set
        {
            unsafe
            {
                SDL2.SetWindowSize(_window, value.Width, value.Height);
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
                SDL2.GetWindowSizeInPixels(_window, &pos.Width, &pos.Height);
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
                SDL2.GetWindowMinimumSize(_window, &pos.Width, &pos.Height);
                return pos;
            }
        }
        set
        {
            unsafe
            {
                SDL2.SetWindowMinimumSize(_window, value.Width, value.Height);
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
                SDL2.GetWindowMaximumSize(_window, &pos.Width, &pos.Height);
                return pos;
            }
        }
        set
        {
            unsafe
            {
                SDL2.SetWindowMaximumSize(_window, value.Width, value.Height);
            }
        }
    }

    public bool IsBordered { get => !Flags.HasFlag(WindowFlags.Borderless); set => SDL2.SetWindowBordered(_window, value); }

    public Thickness BorderSize
    {
        get
        {
            unsafe
            {
                Unsafe.SkipInit(out Thickness t);
                if (SDL2.GetWindowBordersSize(_window, &t.Top, &t.Left, &t.Bottom, &t.Right) == -1)
                    throw new SdlException("Window has not been initialized yet");
                return t;
            }
        }
    }

    public bool IsAlwaysOnTop { get => Flags.HasFlag(WindowFlags.AlwaysOnTop); set => SDL2.SetWindowAlwaysOnTop(_window, value); }

    public bool HasSurface { get => SDL2.HasWindowSurface(_window); }

    public bool IsInputGrabbed { get => SDL2.GetWindowGrab(_window); set => SDL2.SetWindowGrab(_window, value); }

    public bool IsMouseGrabbed { get => SDL2.GetWindowMouseGrab(_window); set => SDL2.SetWindowMouseGrab(_window, value); }

    public bool IsKeyboardGrabbed { get => SDL2.GetWindowKeyboardGrab(_window); set => SDL2.SetWindowKeyboardGrab(_window, value); }

    public Rect? MouseRect
    {
        get
        {
            unsafe
            {
                var rect = (Rect*)SDL2.GetWindowMouseRect(_window);
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

                if (SDL2.SetWindowMouseRect(_window, rect) != 0)
                    SdlException.ThrowLastError();
            }
        }
    }

    public float Brightness
    {
        get => SDL2.GetWindowBrightness(_window);
        set
        {
            if (SDL2.SetWindowBrightness(_window, value) != 0)
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
                if (SDL2.GetWindowOpacity(_window, &opacity) != 0)
                    SdlException.ThrowLastError();
                return opacity;
            }
        }
        set
        {
            if (SDL2.SetWindowOpacity(_window, value) != 0)
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
                if (SDL2.GetWindowGammaRamp(_window, (ushort*)&r, (ushort*)&g, (ushort*)&b) != 0)
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
                    if (SDL2.SetWindowGammaRamp(_window, (ushort*)r, (ushort*)g, (ushort*)b) != 0)
                        SdlException.ThrowLastError();
                }
            }
        }
    }

    public bool IsShapedWindow { get => SDL2.IsShapedWindow(_window); }

    public bool IsScreenKeyboardVisible { get => SDL2.IsScreenKeyboardShown(_window); }

    public static bool IsScreenSaverEnabled { get => SDL2.IsScreenSaverEnabled(); set { if (value) SDL2.EnableScreenSaver(); else SDL2.DisableScreenSaver(); } }

    public static bool HasScreenKeyboardSupport { get => SDL2.HasScreenKeyboardSupport(); }

    // Display related.

    public void SetIcon(Surface icon)
    {
        unsafe
        {
            SDL2.SetWindowIcon(_window, icon._surface);
        }
    }

    public unsafe void* SetData(byte* name, void* data) => SDL2.SetWindowData(_window, name, data);

    public unsafe void* GetData(byte* name) => SDL2.GetWindowData(_window, name);

    public void SetFullscreenMode(FullscreenMode mode)
    {
        if (SDL2.SetWindowFullscreen(_window, (uint)mode) != 0)
            SdlException.ThrowLastError();
    }

    public nint GetSurface()
    {
        unsafe
        {
            var ptr = SDL2.GetWindowSurface(_window);
            if (ptr is null)
                SdlException.ThrowLastError();
            return (nint)ptr;
        }
    }

    public void UpdateSurface()
    {
        unsafe
        {
            if (SDL2.UpdateWindowSurface(_window) != 0)
                SdlException.ThrowLastError();
        }
    }

    public void UpdateSurfaceRects(ReadOnlySpan<Rect> rects)
    {
        unsafe
        {
            fixed (Rect* ptr = rects)
                if (SDL2.UpdateWindowSurfaceRects(_window, (SDL_Rect*)ptr, rects.Length) != 0)
                    SdlException.ThrowLastError();
        }
    }

    public void DestroySurface()
    {
        if (SDL2.DestroyWindowSurface(_window) != 0)
            SdlException.ThrowLastError();
    }

    public void Show() => SDL2.ShowWindow(_window);
    public void Hide() => SDL2.HideWindow(_window);
    public void Raise() => SDL2.RaiseWindow(_window);
    public void Maximize() => SDL2.MaximizeWindow(_window);
    public void Minimize() => SDL2.MinimizeWindow(_window);
    public void Restore() => SDL2.RestoreWindow(_window);
    public void Flash(FlashOperation operation)
    {
        if (SDL2.FlashWindow(_window, (SDL_FlashOperation)operation) != 0)
            SdlException.ThrowLastError();
    }

    public void SetModalFor(Window parent)
    {
        if (SDL2.SetWindowModalFor(_window, parent._window) != 0)
            SdlException.ThrowLastError();
    }

    public void SetInputFocus()
    {
        if (SDL2.SetWindowInputFocus(_window) != 0)
            SdlException.ThrowLastError();
    }

    public void SetShape(Surface shape, WindowShapeMode mode)
    {
        unsafe
        {
            var result = SDL2.SetWindowShape(_window, shape._surface, (SDL_WindowShapeMode*)Unsafe.AsPointer(ref mode));

            switch (result)
            {
                case SDL2.SDL_NONSHAPEABLE_WINDOW:
                    throw new SdlException("Window is not a valid shaped window");
                case SDL2.SDL_INVALID_SHAPE_ARGUMENT:
                    throw new SdlException("Invalid shape argument");
            }
        }
    }

    public WindowShapeMode GetShapeMode()
    {
        Unsafe.SkipInit(out WindowShapeMode mode);
        unsafe
        {
            var result = SDL2.GetShapedWindowMode(_window, (SDL_WindowShapeMode*)&mode);
            switch (result)
            {
                case SDL2.SDL_NONSHAPEABLE_WINDOW:
                    throw new SdlException("Window is not a valid shaped window");
                case SDL2.SDL_WINDOW_LACKS_SHAPE:
                    throw new SdlException("Window does not have a shape");
            }
        }
        return mode;
    }

    public IDisposable SetHitTest<TState>(Func<Window, Point, TState, HitTestResult> hitTest, TState state) =>
        new WindowHitTest<TState>(this, hitTest, state);

    public void Dispose()
    {
        if (_window != 0)
        {
            SDL2.DestroyWindow(_window);
            ref var ptr = ref Unsafe.AsRef(in _window);
            ptr = 0;
        }
    }

    public static Window CreateShaped(string title, Point position, Size size, WindowFlags flags)
    {
        unsafe
        {
            var window = title.AsUtf8((p, _) => SDL2.CreateWindow(p, position.X, position.Y, size.Width, size.Height, (uint)flags));
            if (window == 0)
                SdlException.ThrowLastError();
            return new Window(window);
        }
    }

    public static Window FromWindowId(uint id)
    {
        var window = SDL2.GetWindowFromID(id);
        if (window == 0)
            SdlException.ThrowLastError();
        return new Window(window);
    }

    public static Window? GetWindowWithInputGrabbed()
    {
        var window = SDL2.GetGrabbedWindow();
        if (window is 0)
            return null;
        return new Window(window);
    }

    public static Window? GetWindowWithMouseFocus() =>
        SDL2.GetMouseFocus() is var window and not 0 ? new Window(window) : null;

    public static Window? GetWindowWithKeyboardFocus() =>
        SDL2.GetKeyboardFocus() is var window and not 0 ? new Window(window) : null;
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

internal sealed class WindowHitTest<TState> : IDisposable
{
    private readonly Window _window;
    private readonly Func<Window, Point, TState, HitTestResult> _callback;
    private readonly TState _callbackState;
    private readonly HitTestCallbackUnmanaged _nativeCallback;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private unsafe delegate HitTestResult HitTestCallbackUnmanaged(nint window, Point* point, void* data);

    public WindowHitTest(Window window, Func<Window, Point, TState, HitTestResult> hitTest, TState state)
    {
        _window = window;
        _callback = hitTest;
        _callbackState = state;

        unsafe
        {
            _nativeCallback = new HitTestCallbackUnmanaged((_, point, _) => _callback.Invoke(_window, *point, _callbackState));
            var fPtr = (delegate* unmanaged[Cdecl]<nint, SDL_Point*, void*, SDL_HitTestResult>)Marshal.GetFunctionPointerForDelegate(_nativeCallback);
            if (SDL2.SetWindowHitTest(_window._window, fPtr, null) != 0)
                SdlException.ThrowLastError();
        }
    }

    public void Dispose()
    {
        unsafe
        {
            _ = SDL2.SetWindowHitTest(_window._window, null, null);
        }
    }
}