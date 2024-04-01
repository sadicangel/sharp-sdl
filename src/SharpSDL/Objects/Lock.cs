using SharpSDL.Graphics;

namespace SharpSDL.Objects;

public sealed class Lock(Action unlock) : IDisposable
{
    public static Lock Audio()
    {
        SDL.LockAudio();
        return new Lock(SDL.UnlockAudio);
    }

    public static Lock Joysticks()
    {
        SDL.LockJoysticks();
        return new Lock(SDL.UnlockJoysticks);
    }

    public static Lock Sensors()
    {
        SDL.LockSensors();
        return new Lock(SDL.UnlockSensors);
    }

    public static Lock Audio(uint device)
    {
        SDL.LockAudioDevice(device);
        return new Lock(() => SDL.UnlockAudioDevice(device));
    }

    public static Lock Surface(Surface surface)
    {
        unsafe
        {
            if (SDL.LockSurface(surface._surface) != 0)
                SdlException.ThrowLastError();
            return new Lock(() => SDL.UnlockSurface(surface._surface));
        }
    }

    public static Lock Texture(Texture texture, Rect rect, out nint pixels, out int pitch)
    {
        unsafe
        {
            nint px = default;
            int pt = default;
            if (SDL.LockTexture(texture._texture, (SDL_Rect*)&rect, (void**)&px, &pt) != 0)
                SdlException.ThrowLastError();

            pixels = px;
            pitch = pt;

            return new Lock(() => SDL.UnlockTexture(texture._texture));
        }
    }

    public static Lock Texture(Texture texture, Rect rect, out Surface surface)
    {
        unsafe
        {
            SDL_Surface* s = default;
            if (SDL.LockTextureToSurface(texture._texture, (SDL_Rect*)&rect, &s) != 0)
                SdlException.ThrowLastError();
            surface = new Surface(s);
            return new Lock(() => SDL.UnlockTexture(texture._texture));
        }
    }

    public void Unlock() => unlock();

    void IDisposable.Dispose() => Unlock();
}
