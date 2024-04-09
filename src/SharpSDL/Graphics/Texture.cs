using SharpSDL.Objects;

namespace SharpSDL.Graphics;

public sealed class Texture : IDisposable
{
    internal readonly nint _texture;
    private readonly bool _owned;

    internal Texture(nint texture, bool owned)
    {
        _texture = texture;
        _owned = owned;
    }

    public PixelFormatEnum Format
    {
        get
        {
            unsafe
            {
                PixelFormatEnum format = default;
                if (SDL2.QueryTexture(_texture, (uint*)&format, null, null, null) != 0)
                    SdlException.ThrowLastError();
                return format;
            }
        }
    }

    public TextureAccess Access
    {
        get
        {
            unsafe
            {
                TextureAccess access = default;
                if (SDL2.QueryTexture(_texture, null, (int*)&access, null, null) != 0)
                    SdlException.ThrowLastError();
                return access;
            }
        }
    }

    public Size Size
    {
        get
        {
            unsafe
            {
                Size size = default;
                if (SDL2.QueryTexture(_texture, null, null, &size.Width, &size.Height) != 0)
                    SdlException.ThrowLastError();
                return size;
            }
        }
    }

    public ColorRgb ColorMod
    {
        get
        {
            unsafe
            {
                ColorRgb color = default;
                if (SDL2.GetTextureColorMod(_texture, &color.R, &color.G, &color.B) != 0)
                    SdlException.ThrowLastError();
                return color;
            }
        }
        set
        {
            if (SDL2.SetTextureColorMod(_texture, value.R, value.G, value.B) != 0)
                SdlException.ThrowLastError();
        }
    }

    public byte AlphaMod
    {
        get
        {
            unsafe
            {
                byte a = default;
                if (SDL2.GetTextureAlphaMod(_texture, &a) != 0)
                    SdlException.ThrowLastError();
                return a;
            }
        }
        set
        {
            if (SDL2.SetTextureAlphaMod(_texture, value) != 0)
                SdlException.ThrowLastError();
        }
    }

    public BlendMode BlendMode
    {
        get
        {
            unsafe
            {
                BlendMode blendMode = default;
                if (SDL2.GetTextureBlendMode(_texture, (SDL_BlendMode*)&blendMode) != 0)
                    SdlException.ThrowLastError();
                return blendMode;
            }
        }
        set
        {
            if (SDL2.SetTextureBlendMode(_texture, (SDL_BlendMode)value) != 0)
                SdlException.ThrowLastError();
        }
    }

    public ScaleMode ScaleMode
    {
        get
        {
            unsafe
            {
                ScaleMode scaleMode;
                if (SDL2.GetTextureScaleMode(_texture, (SDL_ScaleMode*)&scaleMode) != 0)
                    SdlException.ThrowLastError();
                return scaleMode;
            }
        }
        set
        {
            if (SDL2.SetTextureScaleMode(_texture, (SDL_ScaleMode)value) != 0)
                SdlException.ThrowLastError();
        }
    }

    public nint UserData
    {
        get
        {
            unsafe
            {
                var data = SDL2.GetTextureUserData(_texture);
                if (data is null)
                    SdlException.ThrowLastError();
                return (nint)data;
            }
        }
        set
        {
            unsafe
            {
                if (SDL2.SetTextureUserData(_texture, (void*)value) != 0)
                    SdlException.ThrowLastError();
            }
        }
    }

    public void Update(Rect rect, nint pixels, int pitch)
    {
        unsafe
        {
            if (SDL2.UpdateTexture(_texture, (SDL_Rect*)&rect, (void*)pixels, pitch) != 0)
                SdlException.ThrowLastError();
        }
    }

    public unsafe void UpdateYuv(Rect rect, byte* yPlane, int yPitch, byte* uPlane, int uPitch, byte* vPlane, int vPitch)
    {
        unsafe
        {
            if (SDL2.UpdateYUVTexture(_texture, (SDL_Rect*)&rect, yPlane, yPitch, uPlane, uPitch, vPlane, vPitch) != 0)
                SdlException.ThrowLastError();
        }
    }

    public unsafe void UpdateNv(Rect rect, byte* yPlane, int yPitch, byte* uvPlane, int uvPitch)
    {
        unsafe
        {
            if (SDL2.UpdateNVTexture(_texture, (SDL_Rect*)&rect, yPlane, yPitch, uvPlane, uvPitch) != 0)
                SdlException.ThrowLastError();
        }
    }

    public void Deconstruct(out PixelFormatEnum format, out TextureAccess access, out Size size)
    {
        unsafe
        {
            PixelFormatEnum f = default;
            TextureAccess a = default;
            Size s = default;
            if (SDL2.QueryTexture(_texture, (uint*)&f, (int*)&a, &s.Width, &s.Height) != 0)
                SdlException.ThrowLastError();

            format = f;
            access = a;
            size = s;
        }
    }

    public void Dispose()
    {
        if (_owned)
        {
            if (_texture != 0)
            {
                SDL2.DestroyTexture(_texture);
                ref var ptr = ref Unsafe.AsRef(in _texture);
                ptr = 0;
            }
        }
    }
}

public enum TextureAccess
{
    Static = SDL_TextureAccess.SDL_TEXTUREACCESS_STATIC,
    Streaming = SDL_TextureAccess.SDL_TEXTUREACCESS_STREAMING,
    Target = SDL_TextureAccess.SDL_TEXTUREACCESS_TARGET,
}

public enum ScaleMode
{
    Nearest = SDL_ScaleMode.SDL_ScaleModeNearest,
    Linear = SDL_ScaleMode.SDL_ScaleModeLinear,
    Best = SDL_ScaleMode.SDL_ScaleModeBest,
}
