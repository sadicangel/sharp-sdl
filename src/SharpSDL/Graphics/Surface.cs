using SharpSDL.IO;
using SharpSDL.Objects;

namespace SharpSDL.Graphics;

public sealed class Surface : IDisposable
{
    internal readonly unsafe SDL_Surface* _surface;
    private readonly bool _owned;
    private PixelFormat? _format;

    internal unsafe Surface(SDL_Surface* surface, bool owned = false)
    {
        _surface = surface;
        _owned = owned;
    }

    public Surface(Size size, int depth, uint rMask, uint gMask, uint bMask, uint aMask)
    {
        unsafe
        {
            _surface = SDL.CreateRGBSurface(flags: 0, size.Width, size.Height, depth, rMask, gMask, bMask, aMask);
            if (_surface is null)
                SdlException.ThrowLastError();
            _owned = true;
        }
    }

    public Surface(Size size, int depth, PixelFormatEnum format)
    {
        unsafe
        {
            _surface = SDL.CreateRGBSurfaceWithFormat(flags: 0, size.Width, size.Height, depth, (uint)format);
            if (_surface is null)
                SdlException.ThrowLastError();
            _owned = true;
        }
    }

    public Surface(nint pixels, Size size, int depth, int pitch, uint rMask, uint gMask, uint bMask, uint aMask)
    {
        unsafe
        {
            _surface = SDL.CreateRGBSurfaceFrom((void*)pixels, size.Width, size.Height, depth, pitch, rMask, gMask, bMask, aMask);
            if (_surface is null)
                SdlException.ThrowLastError();
            _owned = true;
        }
    }

    public Surface(nint pixels, Size size, int depth, int pitch, PixelFormatEnum format)
    {
        unsafe
        {
            _surface = SDL.CreateRGBSurfaceWithFormatFrom((void*)pixels, size.Width, size.Height, depth, pitch, (uint)format);
            if (_surface is null)
                SdlException.ThrowLastError();
            _owned = true;
        }
    }

    public SurfaceFlags Flags { get { unsafe { return (SurfaceFlags)_surface->flags; } } }
    public PixelFormat Format { get { unsafe { return _format ??= new PixelFormat(_surface->format); } } }
    public Size Size { get { unsafe { return new Size(_surface->w, _surface->h); } } }
    public int Pitch { get { unsafe { return _surface->pitch; } } }
    public nint Pixels { get { unsafe { return (nint)_surface->pixels; } } }
    public nint UserData { get { unsafe { return (nint)_surface->userdata; } } }
    public int Locked { get { unsafe { return _surface->locked; } } }
    public nint BlitMap { get { unsafe { return (nint)_surface->list_blitmap; } } }
    public Rect ClipRect
    {
        get
        {
            unsafe
            {
                return Unsafe.BitCast<SDL_Rect, Rect>(_surface->clip_rect);
            }
        }
        set
        {
            unsafe
            {
                SDL.SetClipRect(_surface, !value.IsEmpty ? (SDL_Rect*)&value : null);
            }
        }
    }
    public nint Map { get { unsafe { return _surface->map; } } }

    public bool IsRunLengthEncoded
    {
        get
        {
            unsafe
            {
                return SDL.HasSurfaceRLE(_surface);
            }
        }
        set
        {
            unsafe
            {
                if (SDL.SetSurfaceRLE(_surface, value ? 1 : 0) != 0)
                    SdlException.ThrowLastError();
            }
        }
    }

    public bool HasColorKey
    {
        get
        {
            unsafe
            {
                return SDL.HasColorKey(_surface);
            }
        }
        set
        {
            unsafe
            {
                if (SDL.SetColorKey(_surface, 0, 0) != 0)
                    SdlException.ThrowLastError();
            }
        }
    }

    public uint ColorKey
    {
        get
        {
            unsafe
            {
                uint k = 0;
                if (SDL.GetColorKey(_surface, &k) != 0)
                    SdlException.ThrowLastError();
                return k;
            }
        }
        set
        {
            unsafe
            {
                if (SDL.SetColorKey(_surface, 1, value) != 0)
                    SdlException.ThrowLastError();
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
                if (SDL.GetSurfaceColorMod(_surface, &color.R, &color.G, &color.B) != 0)
                    SdlException.ThrowLastError();
                return color;
            }
        }
        set
        {
            unsafe
            {
                if (SDL.SetSurfaceColorMod(_surface, value.R, value.G, value.B) != 0)
                    SdlException.ThrowLastError();
            }
        }
    }

    public byte AlphaMod
    {
        get
        {
            unsafe
            {
                byte a = default;
                if (SDL.GetSurfaceAlphaMod(_surface, &a) != 0)
                    SdlException.ThrowLastError();
                return a;
            }
        }
        set
        {
            unsafe
            {
                if (SDL.SetSurfaceAlphaMod(_surface, value) != 0)
                    SdlException.ThrowLastError();
            }
        }
    }

    public BlendMode BlendMode
    {
        get
        {
            unsafe
            {
                BlendMode blendMode = default;
                if (SDL.GetSurfaceBlendMode(_surface, (SDL_BlendMode*)&blendMode) != 0)
                    SdlException.ThrowLastError();
                return blendMode;
            }
        }
        set
        {
            unsafe
            {
                if (SDL.SetSurfaceBlendMode(_surface, (SDL_BlendMode)value) != 0)
                    SdlException.ThrowLastError();
            }
        }
    }

    public Surface Clone()
    {
        unsafe
        {
            var surface = SDL.DuplicateSurface(_surface);
            if (surface is null)
                SdlException.ThrowLastError();
            return new Surface(surface, owned: true);
        }
    }

    public Surface Convert(PixelFormat format)
    {
        unsafe
        {
            var surface = SDL.ConvertSurface(_surface, format._format, flags: 0);
            if (surface is null)
                SdlException.ThrowLastError();
            return new Surface(surface, owned: true);
        }
    }

    public Surface Convert(PixelFormatEnum format)
    {
        unsafe
        {
            var surface = SDL.ConvertSurfaceFormat(_surface, (uint)format, flags: 0);
            if (surface is null)
                SdlException.ThrowLastError();
            return new Surface(surface, owned: true);
        }
    }

    public void FillRect(Rect rect, ColorRgba color)
    {
        unsafe
        {
            if (SDL.FillRect(_surface, (SDL_Rect*)&rect, color.Rgba) != 0)
                SdlException.ThrowLastError();
        }
    }

    public void FillRects(ReadOnlySpan<Rect> rects, ColorRgba color)
    {
        unsafe
        {
            fixed (Rect* ptr = rects)
            {
                if (SDL.FillRects(_surface, (SDL_Rect*)ptr, rects.Length, color.Rgba) != 0)
                    SdlException.ThrowLastError();
            }
        }
    }

    public static Surface LoadBmp(RwStream stream)
    {
        unsafe
        {
            var surface = SDL.LoadBMP_RW(stream._stream, freesrc: 0);
            if (surface is null)
                SdlException.ThrowLastError();
            return new Surface(surface);
        }
    }

    public static Surface LoadBmp(ReadOnlySpan<byte> fileName)
    {
        unsafe
        {
            var fileMode = "rb\0"u8;
            SDL_RWops* stream = null;
            fixed (byte* f = fileName, m = fileMode)
                stream = SDL.RWFromFile(f, m);
            if (stream is null)
                SdlException.ThrowLastError();
            var surface = SDL.LoadBMP_RW(stream, freesrc: 1);
            if (surface is null)
                SdlException.ThrowLastError();
            return new Surface(surface);
        }
    }

    public static Surface LoadBmp(string fileName)
    {
        unsafe
        {
            return fileName.AsUtf8(utf8 => LoadBmp(new ReadOnlySpan<byte>(utf8, fileName.Length)));
        }
    }

    public void SaveBmp(RwStream stream)
    {
        unsafe
        {
            if (SDL.SaveBMP_RW(_surface, stream._stream, freedst: 0) != 0)
                SdlException.ThrowLastError();
        }
    }

    public void SaveBmp(ReadOnlySpan<byte> fileName)
    {
        unsafe
        {
            var fileMode = "wb\0"u8;
            SDL_RWops* stream = null;
            fixed (byte* f = fileName, m = fileMode)
                stream = SDL.RWFromFile(f, m);
            if (stream is null)
                SdlException.ThrowLastError();
            if (SDL.SaveBMP_RW(_surface, stream, freedst: 1) != 0)
                SdlException.ThrowLastError();
        }
    }

    public void SaveBmp(string fileName)
    {
        unsafe
        {
            fileName.AsUtf8(utf8 => SaveBmp(new ReadOnlySpan<byte>(utf8, fileName.Length)));
        }
    }

    public static void Blit(Surface src, Rect srcRect, Surface dst, Rect dstRect)
    {
        unsafe
        {
            var sr = srcRect.IsEmpty ? null : (SDL_Rect*)&srcRect;
            var dr = dstRect.IsEmpty ? null : (SDL_Rect*)&dstRect;
            if (SDL.UpperBlit(src._surface, sr, dst._surface, dr) != 0)
                SdlException.ThrowLastError();
        };
    }

    public static void BlitScaled(Surface src, Rect srcRect, Surface dst, Rect dstRect)
    {
        unsafe
        {
            var sr = srcRect.IsEmpty ? null : (SDL_Rect*)&srcRect;
            var dr = dstRect.IsEmpty ? null : (SDL_Rect*)&dstRect;
            if (SDL.UpperBlitScaled(src._surface, sr, dst._surface, dr) != 0)
                SdlException.ThrowLastError();
        };
    }

    public static YuvConversionMode GetYuvConversionMode() =>
        (YuvConversionMode)SDL.GetYUVConversionMode();
    public static YuvConversionMode GetYuvConversionMode(Size size) =>
        (YuvConversionMode)SDL.GetYUVConversionModeForResolution(size.Width, size.Height);
    public static void SetYuvConversionMode(YuvConversionMode mode) =>
        SDL.SetYUVConversionMode((SDL_YUV_CONVERSION_MODE)mode);

    public void Dispose()
    {
        if (_owned)
        {
            unsafe
            {
                if (_surface is not null)
                {
                    _format?.Dispose();
                    SDL.FreeSurface(_surface);
                    fixed (SDL_Surface** ptr = &_surface)
                        *ptr = null;

                }
            }
        }
    }
}

public enum SurfaceFlags : uint
{
    SwCompat = SDL.SDL_SWSURFACE,
    PreAllocated = SDL.SDL_PREALLOC,
    RunLengthEncoded = SDL.SDL_RLEACCEL,
    InternalReference = SDL.SDL_DONTFREE,
    SimdAligned = SDL.SDL_SIMD_ALIGNED,
}

public enum YuvConversionMode
{
    Jpeg = SDL_YUV_CONVERSION_MODE.SDL_YUV_CONVERSION_JPEG,
    Bt601 = SDL_YUV_CONVERSION_MODE.SDL_YUV_CONVERSION_BT601,
    Bt709 = SDL_YUV_CONVERSION_MODE.SDL_YUV_CONVERSION_BT709,
    Automatic = SDL_YUV_CONVERSION_MODE.SDL_YUV_CONVERSION_AUTOMATIC,
}