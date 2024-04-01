using SharpSDL.Objects;

namespace SharpSDL.Graphics;

public sealed class Texture(nint texture) : IDisposable
{
    internal readonly nint _texture = texture;

    public PixelFormatEnum Format
    {
        get
        {
            unsafe
            {
                PixelFormatEnum format = default;
                if (SDL.QueryTexture(_texture, (uint*)&format, null, null, null) != 0)
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
                if (SDL.QueryTexture(_texture, null, (int*)&access, null, null) != 0)
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
                if (SDL.QueryTexture(_texture, null, null, &size.Width, &size.Height) != 0)
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
                if (SDL.GetTextureColorMod(_texture, &color.R, &color.G, &color.B) != 0)
                    SdlException.ThrowLastError();
                return color;
            }
        }
        set
        {
            if (SDL.SetTextureColorMod(_texture, value.R, value.G, value.B) != 0)
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
                if (SDL.GetTextureAlphaMod(_texture, &a) != 0)
                    SdlException.ThrowLastError();
                return a;
            }
        }
        set
        {
            if (SDL.SetTextureAlphaMod(_texture, value) != 0)
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
                if (SDL.GetTextureBlendMode(_texture, (SDL_BlendMode*)&blendMode) != 0)
                    SdlException.ThrowLastError();
                return blendMode;
            }
        }
        set
        {
            if (SDL.SetTextureBlendMode(_texture, (SDL_BlendMode)value) != 0)
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
                if (SDL.GetTextureScaleMode(_texture, (SDL_ScaleMode*)&scaleMode) != 0)
                    SdlException.ThrowLastError();
                return scaleMode;
            }
        }
        set
        {
            if (SDL.SetTextureScaleMode(_texture, (SDL_ScaleMode)value) != 0)
                SdlException.ThrowLastError();
        }
    }

    public nint UserData
    {
        get
        {
            unsafe
            {
                var data = SDL.GetTextureUserData(_texture);
                if (data is null)
                    SdlException.ThrowLastError();
                return (nint)data;
            }
        }
        set
        {
            unsafe
            {
                if (SDL.SetTextureUserData(_texture, (void*)value) != 0)
                    SdlException.ThrowLastError();
            }
        }
    }

    public void Update(Rect rect, nint pixels, int pitch)
    {
        unsafe
        {
            if (SDL.UpdateTexture(_texture, (SDL_Rect*)&rect, (void*)pixels, pitch) != 0)
                SdlException.ThrowLastError();
        }
    }

    public unsafe void UpdateYuv(Rect rect, byte* yPlane, int yPitch, byte* uPlane, int uPitch, byte* vPlane, int vPitch)
    {
        unsafe
        {
            if (SDL.UpdateYUVTexture(_texture, (SDL_Rect*)&rect, yPlane, yPitch, uPlane, uPitch, vPlane, vPitch) != 0)
                SdlException.ThrowLastError();
        }
    }

    public unsafe void UpdateNv(Rect rect, byte* yPlane, int yPitch, byte* uvPlane, int uvPitch)
    {
        unsafe
        {
            if (SDL.UpdateNVTexture(_texture, (SDL_Rect*)&rect, yPlane, yPitch, uvPlane, uvPitch) != 0)
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
            if (SDL.QueryTexture(_texture, (uint*)&f, (int*)&a, &s.Width, &s.Height) != 0)
                SdlException.ThrowLastError();

            format = f;
            access = a;
            size = s;
        }
    }

    public void Dispose()
    {
        if (_texture != 0)
        {
            SDL.DestroyTexture(_texture);
            ref var ptr = ref Unsafe.AsRef(in _texture);
            ptr = 0;
        }
    }
}

public enum TextureAccess
{
    Static = SDL_TextureAccess.SDL_TEXTUREACCESS_STATIC,
    Streaming = SDL_TextureAccess.SDL_TEXTUREACCESS_STREAMING,
    Target = SDL_TextureAccess.SDL_TEXTUREACCESS_TARGET,
}

public enum BlendMode
{
    None = SDL_BlendMode.SDL_BLENDMODE_NONE,
    Blend = SDL_BlendMode.SDL_BLENDMODE_BLEND,
    Add = SDL_BlendMode.SDL_BLENDMODE_ADD,
    Mod = SDL_BlendMode.SDL_BLENDMODE_MOD,
    Mul = SDL_BlendMode.SDL_BLENDMODE_MUL,
    Invalid = SDL_BlendMode.SDL_BLENDMODE_INVALID,
}

public enum ScaleMode
{
    Nearest = SDL_ScaleMode.SDL_ScaleModeNearest,
    Linear = SDL_ScaleMode.SDL_ScaleModeLinear,
    Best = SDL_ScaleMode.SDL_ScaleModeBest,
}
