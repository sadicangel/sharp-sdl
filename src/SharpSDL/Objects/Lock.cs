using SharpSDL.Graphics;

namespace SharpSDL.Objects;

public sealed class Lock(Action unlock) : IDisposable
{
    public static Lock Audio()
    {
        SDL2.LockAudio();
        return new Lock(SDL2.UnlockAudio);
    }

    public static Lock Joysticks()
    {
        SDL2.LockJoysticks();
        return new Lock(SDL2.UnlockJoysticks);
    }

    public static Lock Sensors()
    {
        SDL2.LockSensors();
        return new Lock(SDL2.UnlockSensors);
    }

    public static Lock Audio(uint device)
    {
        SDL2.LockAudioDevice(device);
        return new Lock(() => SDL2.UnlockAudioDevice(device));
    }

    public static Lock Surface(Surface surface)
    {
        unsafe
        {
            if (SDL2.LockSurface(surface._surface) != 0)
                SdlException.ThrowLastError();
            return new Lock(() => SDL2.UnlockSurface(surface._surface));
        }
    }

    public static Lock Texture(Texture texture, Rect rect, out nint pixels, out int pitch)
    {
        unsafe
        {
            nint px = default;
            int pt = default;
            if (SDL2.LockTexture(texture._texture, (SDL_Rect*)&rect, (void**)&px, &pt) != 0)
                SdlException.ThrowLastError();

            pixels = px;
            pitch = pt;

            return new Lock(() => SDL2.UnlockTexture(texture._texture));
        }
    }

    public static Lock Texture(Texture texture, Rect rect, out Surface surface)
    {
        unsafe
        {
            SDL_Surface* s = default;
            if (SDL2.LockTextureToSurface(texture._texture, (SDL_Rect*)&rect, &s) != 0)
                SdlException.ThrowLastError();
            surface = new Surface(s);
            return new Lock(() => SDL2.UnlockTexture(texture._texture));
        }
    }

    public void Unlock() => unlock();

    void IDisposable.Dispose() => Unlock();
}
