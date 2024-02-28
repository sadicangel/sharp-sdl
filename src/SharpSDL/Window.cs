namespace SharpSDL;

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

public sealed class Window : IDisposable
{
    internal readonly nint _window;

    public Window(string title, Point position, Size size, WindowFlags flags)
    {
        unsafe
        {
            _window = title.AsUtf8(title => SDL.CreateWindow(title, position.X, position.Y, size.Width, size.Height, (uint)flags));
        }
        if (_window == 0)
            SdlException.ThrowLastError();
    }

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


    public Size Size
    {
        get
        {
            unsafe
            {
                Unsafe.SkipInit(out Size pos);
                SDL.GetWindowPosition(_window, &pos.Width, &pos.Height);
                return pos;
            }
        }
        set
        {
            unsafe
            {
                SDL.SetWindowPosition(_window, value.Width, value.Height);
            }
        }
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
}
