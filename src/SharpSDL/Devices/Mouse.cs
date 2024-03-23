using SharpSDL.Objects;

namespace SharpSDL.Devices;

public sealed class Mouse
{
    private MouseState _state;
    private Point _location;
    private Point _globalLocation;
    private Point _relativeLocation;

    public MouseState State { get { Update(); return _state; } }

    public Point Location { get { Update(); return _location; } }
    public Point GlobalLocation { get { UpdateGlobal(); return _globalLocation; } }
    public Point RelativeLocation { get { UpdateRelative(); return _relativeLocation; } }

    public static bool IsRelativeModeEnabled
    {
        get => SDL.GetRelativeMouseMode();
        set
        {
            if (SDL.SetRelativeMouseMode(value) != 0)
                SdlException.ThrowLastError();
        }
    }

    private void Update()
    {
        unsafe
        {
            var point = new Point();
            var state = (MouseState)SDL.GetMouseState(&point.X, &point.Y);
            _location = point;
            _state = state;
        }
    }

    private void UpdateGlobal()
    {
        unsafe
        {
            var point = new Point();
            var state = (MouseState)SDL.GetGlobalMouseState(&point.X, &point.Y);
            _globalLocation = point;
            _state = state;
        }
    }

    private void UpdateRelative()
    {
        unsafe
        {
            var point = new Point();
            var state = (MouseState)SDL.GetRelativeMouseState(&point.X, &point.Y);
            _relativeLocation = point;
            _state = state;
        }
    }

    public static void WarpInWindow(Point point, Window? window = null) =>
        SDL.WarpMouseInWindow(window?._window ?? 0, point.X, point.Y);

    public static void WarpGlobal(Point point)
    {
        if (SDL.WarpMouseGlobal(point.X, point.Y) != 0)
            SdlException.ThrowLastError();
    }

    public static void Capture(bool enable)
    {
        if (SDL.CaptureMouse(enable) != 0)
            SdlException.ThrowLastError();
    }
}

[Flags]
public enum MouseState : uint
{
    Left = 1 << 0,
    Middle = 1 << 1,
    Right = 1 << 2,
    X1 = 1 << 3,
    X2 = 1 << 4,
}

public enum MouseWheelDirection
{
    Normal = SDL_MouseWheelDirection.SDL_MOUSEWHEEL_NORMAL,
    Flipped = SDL_MouseWheelDirection.SDL_MOUSEWHEEL_FLIPPED,
}
