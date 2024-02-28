namespace SharpSDL;

[Flags]
public enum SubSystemName : uint
{
    Timer = SDL.SDL_INIT_TIMER,
    Audio = SDL.SDL_INIT_AUDIO,
    Video = SDL.SDL_INIT_VIDEO,
    Joystick = SDL.SDL_INIT_JOYSTICK,
    Haptic = SDL.SDL_INIT_HAPTIC,
    GameController = SDL.SDL_INIT_GAMECONTROLLER,
    Events = SDL.SDL_INIT_EVENTS,
    Sensor = SDL.SDL_INIT_SENSOR,
    NoParachute = SDL.SDL_INIT_NOPARACHUTE,
    Everything = SDL.SDL_INIT_EVERYTHING,
}

public sealed class SubSystem : IDisposable
{
    private static readonly object Mutex = new();
    private static SubSystem? SInstance;

    private SubSystem(SubSystemName flags)
    {
        if (SDL.Init((uint)flags) != 0)
            SdlException.ThrowLastError();
    }

    public static SubSystem Instance { get => SInstance ?? throw new SdlException("SDL not initialized"); }

    public static SubSystem Init(SubSystemName flags)
    {
        lock (Mutex)
        {
            if (SInstance is not null)
                throw new SdlException("SDL already initialized");
            SInstance = new SubSystem(flags);
            return SInstance;
        }
    }

    public void Dispose()
    {
        lock (Mutex)
        {
            if (SInstance is null)
                throw new SdlException("SDL not initialized");

            SInstance = null;
            SDL.Quit();
        }
    }
}

