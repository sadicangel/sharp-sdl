namespace SharpSDL;

[Flags]
public enum SubSystem : uint
{
    Timer = SDL2.SDL_INIT_TIMER,
    Audio = SDL2.SDL_INIT_AUDIO,
    Video = SDL2.SDL_INIT_VIDEO,
    Joystick = SDL2.SDL_INIT_JOYSTICK,
    Haptic = SDL2.SDL_INIT_HAPTIC,
    GameController = SDL2.SDL_INIT_GAMECONTROLLER,
    Events = SDL2.SDL_INIT_EVENTS,
    Sensor = SDL2.SDL_INIT_SENSOR,
    NoParachute = SDL2.SDL_INIT_NOPARACHUTE,
    Everything = SDL2.SDL_INIT_EVERYTHING,
}

public sealed class SdlContext : IDisposable
{
    private static readonly object Mutex = new();
    private static bool Initialized;

    public SdlContext(SubSystem subsystems)
    {
        lock (Mutex)
        {
            if (Initialized)
                throw new SdlException("SDL already initialized");
            Initialized = true;
            if (SDL2.Init((uint)subsystems) != 0)
                SdlException.ThrowLastError();
        }
    }

    public void Dispose()
    {
        lock (Mutex)
        {
            if (Initialized)
            {

                Initialized = false;
                SDL2.Quit();
            }
        }
    }
}

