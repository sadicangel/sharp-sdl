namespace SharpSDL;

public static class Events
{
    public static bool PollEvent(out Event @event)
    {
        Unsafe.SkipInit(out @event);
        unsafe
        {
            fixed (Event* ptr = &@event)
            {
                return SDL.PollEvent((SDL_Event*)ptr) != 0;
            }
        }
    }
}
