namespace SharpSDL;

[Flags]
public enum RendererFlags
{
    Software = SDL_RendererFlags.SDL_RENDERER_SOFTWARE,
    Accelerated = SDL_RendererFlags.SDL_RENDERER_ACCELERATED,
    PresentVSync = SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC,
    TargetTexture = SDL_RendererFlags.SDL_RENDERER_TARGETTEXTURE,
}

public sealed class Renderer : IDisposable
{
    internal readonly nint _renderer;

    public Renderer(Window window, int index, RendererFlags flags)
    {
        _renderer = SDL.CreateRenderer(window._window, index, (uint)flags);
        if (_renderer == 0)
            SdlException.ThrowLastError();
    }

    public Color Color
    {
        get
        {
            unsafe
            {
                Unsafe.SkipInit(out Color c);
                if (SDL.GetRenderDrawColor(_renderer, &c.R, &c.G, &c.B, &c.A) != 0)
                    SdlException.ThrowLastError();
                return c;
            }
        }
        set
        {
            if (SDL.SetRenderDrawColor(_renderer, value.R, value.G, value.B, value.A) != 0)
                SdlException.ThrowLastError();
        }
    }

    public void Clear()
    {
        if (SDL.RenderClear(_renderer) != 0)
            SdlException.ThrowLastError();
    }

    public void Present()
    {
        SDL.RenderPresent(_renderer);
    }

    public void FillRect(Rect rect)
    {
        unsafe
        {
            if (SDL.RenderFillRect(_renderer, (SDL_Rect*)Unsafe.AsPointer(ref rect)) != 0)
                SdlException.ThrowLastError();
        }
    }

    public void Dispose()
    {
        if (_renderer != 0)
        {
            SDL.DestroyRenderer(_renderer);
            ref var ptr = ref Unsafe.AsRef(in _renderer);
            ptr = 0;
        }
    }
}
