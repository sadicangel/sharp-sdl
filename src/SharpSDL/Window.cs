namespace SharpSDL;

public sealed class Window : IDisposable
{
    internal readonly nint _window;

    private Window(nint window) => _window = window;

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

    public unsafe void* SetData(byte* name, void* data) => SDL.SetWindowData(_window, name, data);
    public unsafe void* GetData(byte* name) => SDL.GetWindowData(_window, name);

    public void Show() => SDL.ShowWindow(_window);
    public void Hide() => SDL.HideWindow(_window);
    public void Raise() => SDL.RaiseWindow(_window);
    public void Maximize() => SDL.MaximizeWindow(_window);
    public void Minimize() => SDL.MinimizeWindow(_window);
    public void Restore() => SDL.RestoreWindow(_window);

    public void Dispose()
    {
        if (_window != 0)
        {
            SDL.DestroyWindow(_window);
            ref var ptr = ref Unsafe.AsRef(in _window);
            ptr = 0;
        }
    }

    public static Window FromWindowId(uint id)
    {
        var window = SDL.GetWindowFromID(id);
        if (window == 0)
            SdlException.ThrowLastError();
        return new Window(window);
    }
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