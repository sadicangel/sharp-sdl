using SharpSDL.Objects;

namespace SharpSDL.Graphics;

public sealed class PixelFormat : IDisposable
{
    internal readonly unsafe SDL_PixelFormat* _format;
    private readonly bool _owned;
    private Palette? _palette;

    internal unsafe PixelFormat(SDL_PixelFormat* format) => _format = format;

    public PixelFormat(PixelFormatEnum format)
    {
        unsafe
        {
            _format = SDL2.AllocFormat((uint)format);
            if (_format is null)
                SdlException.ThrowLastError();
            _owned = true;
        }
    }

    public PixelFormatEnum Format { get { unsafe { return (PixelFormatEnum)_format->format; } } }
    public Palette Palette
    {
        get
        {
            unsafe
            {
                return _palette ??= new Palette(_format->palette);
            }
        }
        set
        {
            _palette = value;
            unsafe
            {
                if (SDL2.SetPixelFormatPalette(_format, _palette._palette) != 0)
                    SdlException.ThrowLastError();
            }
        }
    }
    public ReadOnlySpan<ColorRgba> PaletteColors
    {
        get
        {
            unsafe
            {
                return new ReadOnlySpan<ColorRgba>(_format->palette->colors, _format->palette->ncolors);
            }
        }
        set
        {
            unsafe
            {
                fixed (ColorRgba* colors = value)
                {
                    if (SDL2.SetPaletteColors(_format->palette, (SDL_Color*)colors, firstcolor: 0, value.Length) != 0)
                        SdlException.ThrowLastError();
                }
            }
        }
    }
    public byte BitsPerPixel { get { unsafe { return _format->BitsPerPixel; } } }
    public byte BytesPerPixel { get { unsafe { return _format->BytesPerPixel; } } }
    public uint RMask { get { unsafe { return _format->Rmask; } } }
    public uint GMask { get { unsafe { return _format->Gmask; } } }
    public uint BMask { get { unsafe { return _format->Bmask; } } }
    public uint AMask { get { unsafe { return _format->Amask; } } }
    public byte RLoss { get { unsafe { return _format->Rloss; } } }
    public byte GLoss { get { unsafe { return _format->Gloss; } } }
    public byte BLoss { get { unsafe { return _format->Bloss; } } }
    public byte ALoss { get { unsafe { return _format->Aloss; } } }
    public byte RShift { get { unsafe { return _format->Rshift; } } }
    public byte GShift { get { unsafe { return _format->Gshift; } } }
    public byte BShift { get { unsafe { return _format->Bshift; } } }
    public byte AShift { get { unsafe { return _format->Ashift; } } }

    public ReadOnlySpan<byte> Name
    {
        get
        {
            unsafe
            {
                return MemoryMarshal.CreateReadOnlySpanFromNullTerminated(SDL2.GetPixelFormatName(_format->format));
            }
        }
    }

    public uint RgbToPixel(ColorRgb color)
    {
        unsafe
        {
            return SDL2.MapRGB(_format, color.R, color.G, color.B);
        }
    }

    public uint RgbaToPixel(ColorRgba color)
    {
        unsafe
        {
            return SDL2.MapRGBA(_format, color.R, color.G, color.B, color.A);
        }
    }

    public ColorRgb PixelToRgb(uint pixel)
    {
        unsafe
        {
            Unsafe.SkipInit(out ColorRgb c);
            SDL2.GetRGB(pixel, _format, &c.R, &c.G, &c.B);
            return c;
        }
    }

    public ColorRgba PixelToRgba(uint pixel)
    {
        unsafe
        {
            Unsafe.SkipInit(out ColorRgba c);
            SDL2.GetRGBA(pixel, _format, &c.R, &c.G, &c.B, &c.A);
            return c;
        }
    }

    public static RgbaMask PixelFormatEnumToRgbaMask(PixelFormatEnum format)
    {
        Unsafe.SkipInit(out RgbaMask mask);
        unsafe
        {
            if (!SDL2.PixelFormatEnumToMasks((uint)format, &mask.BitsPerPixel, &mask.RMask, &mask.GMask, &mask.BMask, &mask.AMask))
                SdlException.ThrowLastError();
        }
        return mask;
    }

    public static PixelFormatEnum RgbaMaskToPixelFormatEnum(RgbaMask mask)
        => (PixelFormatEnum)SDL2.MasksToPixelFormatEnum(mask.BitsPerPixel, mask.RMask, mask.GMask, mask.BMask, mask.AMask);

    public static void ConvertPixels(Size size, nint src, PixelFormatEnum srcFormat, int srcPitch, nint dst, PixelFormatEnum dstFormat, int dstPitch)
    {
        unsafe
        {
            if (SDL2.ConvertPixels(size.Width, size.Height, (uint)srcFormat, (void*)src, srcPitch, (uint)dstFormat, (void*)dst, dstPitch) != 0)
                SdlException.ThrowLastError();
        }
    }

    public static void PreMultiplyAlpha(Size size, nint src, PixelFormatEnum srcFormat, int srcPitch, nint dst, PixelFormatEnum dstFormat, int dstPitch)
    {
        unsafe
        {
            if (SDL2.PremultiplyAlpha(size.Width, size.Height, (uint)srcFormat, (void*)src, srcPitch, (uint)dstFormat, (void*)dst, dstPitch) != 0)
                SdlException.ThrowLastError();
        }
    }

    public void Dispose()
    {
        if (_owned)
        {
            unsafe
            {
                if (_format is not null)
                {
                    SDL2.FreeFormat(_format);
                    fixed (SDL_PixelFormat** ptr = &_format)
                        *ptr = null;
                    _palette?.Dispose();
                }
            }
        }
    }
}

public readonly struct RgbaMask
{
    public readonly int BitsPerPixel;
    public readonly uint RMask;
    public readonly uint GMask;
    public readonly uint BMask;
    public readonly uint AMask;
}

public sealed class Palette : IDisposable
{
    internal readonly unsafe SDL_Palette* _palette;
    private readonly bool _owned;
    internal unsafe Palette(SDL_Palette* palette) => _palette = palette;

    public Palette(int colors)
    {
        unsafe
        {
            _palette = SDL2.AllocPalette(colors);
            if (_palette is null)
                SdlException.ThrowLastError();
            _owned = true;
        }
    }
    public ReadOnlySpan<ColorRgba> PaletteColors
    {
        get
        {
            unsafe
            {
                return new ReadOnlySpan<ColorRgba>(_palette->colors, _palette->ncolors);
            }
        }
        set
        {
            unsafe
            {
                fixed (ColorRgba* colors = value)
                {
                    if (SDL2.SetPaletteColors(_palette, (SDL_Color*)colors, firstcolor: 0, value.Length) != 0)
                        SdlException.ThrowLastError();
                }
            }
        }
    }

    public void SetColors(ReadOnlySpan<ColorRgba> colors, int index, int count)
    {
        unsafe
        {
            fixed (ColorRgba* ptr = colors)
                if (SDL2.SetPaletteColors(_palette, (SDL_Color*)ptr, index, count) != 0)
                    SdlException.ThrowLastError();
        }
    }

    public void Dispose()
    {
        if (_owned)
        {
            unsafe
            {
                SDL2.FreePalette(_palette);
                fixed (SDL_Palette** ptr = &_palette)
                    *ptr = null;
            }
        }
    }
}

public enum PixelFormatEnum : uint
{
    Unknown = SDL_PixelFormatEnum.SDL_PIXELFORMAT_UNKNOWN,
    Index1lsb = SDL_PixelFormatEnum.SDL_PIXELFORMAT_INDEX1LSB,
    Index1msb = SDL_PixelFormatEnum.SDL_PIXELFORMAT_INDEX1MSB,
    Index2lsb = SDL_PixelFormatEnum.SDL_PIXELFORMAT_INDEX2LSB,
    Index2msb = SDL_PixelFormatEnum.SDL_PIXELFORMAT_INDEX2MSB,
    Index4lsb = SDL_PixelFormatEnum.SDL_PIXELFORMAT_INDEX4LSB,
    Index4msb = SDL_PixelFormatEnum.SDL_PIXELFORMAT_INDEX4MSB,
    Index8 = SDL_PixelFormatEnum.SDL_PIXELFORMAT_INDEX8,
    Rgb332 = SDL_PixelFormatEnum.SDL_PIXELFORMAT_RGB332,
    Xrgb4444 = SDL_PixelFormatEnum.SDL_PIXELFORMAT_XRGB4444,
    Rgb444 = SDL_PixelFormatEnum.SDL_PIXELFORMAT_RGB444,
    Xbgr4444 = SDL_PixelFormatEnum.SDL_PIXELFORMAT_XBGR4444,
    Bgr444 = SDL_PixelFormatEnum.SDL_PIXELFORMAT_BGR444,
    Xrgb1555 = SDL_PixelFormatEnum.SDL_PIXELFORMAT_XRGB1555,
    Rgb555 = SDL_PixelFormatEnum.SDL_PIXELFORMAT_RGB555,
    Xbgr1555 = SDL_PixelFormatEnum.SDL_PIXELFORMAT_XBGR1555,
    Bgr555 = SDL_PixelFormatEnum.SDL_PIXELFORMAT_BGR555,
    Argb4444 = SDL_PixelFormatEnum.SDL_PIXELFORMAT_ARGB4444,
    Rgba4444 = SDL_PixelFormatEnum.SDL_PIXELFORMAT_RGBA4444,
    Abgr4444 = SDL_PixelFormatEnum.SDL_PIXELFORMAT_ABGR4444,
    Bgra4444 = SDL_PixelFormatEnum.SDL_PIXELFORMAT_BGRA4444,
    Argb1555 = SDL_PixelFormatEnum.SDL_PIXELFORMAT_ARGB1555,
    Rgba5551 = SDL_PixelFormatEnum.SDL_PIXELFORMAT_RGBA5551,
    Abgr1555 = SDL_PixelFormatEnum.SDL_PIXELFORMAT_ABGR1555,
    Bgra5551 = SDL_PixelFormatEnum.SDL_PIXELFORMAT_BGRA5551,
    Rgb565 = SDL_PixelFormatEnum.SDL_PIXELFORMAT_RGB565,
    Bgr565 = SDL_PixelFormatEnum.SDL_PIXELFORMAT_BGR565,
    Rgb24 = SDL_PixelFormatEnum.SDL_PIXELFORMAT_RGB24,
    Bgr24 = SDL_PixelFormatEnum.SDL_PIXELFORMAT_BGR24,
    Xrgb8888 = SDL_PixelFormatEnum.SDL_PIXELFORMAT_XRGB8888,
    Rgb888 = SDL_PixelFormatEnum.SDL_PIXELFORMAT_RGB888,
    Rgbx8888 = SDL_PixelFormatEnum.SDL_PIXELFORMAT_RGBX8888,
    Xbgr8888 = SDL_PixelFormatEnum.SDL_PIXELFORMAT_XBGR8888,
    Bgr888 = SDL_PixelFormatEnum.SDL_PIXELFORMAT_BGR888,
    Bgrx8888 = SDL_PixelFormatEnum.SDL_PIXELFORMAT_BGRX8888,
    Argb8888 = SDL_PixelFormatEnum.SDL_PIXELFORMAT_ARGB8888,
    Rgba8888 = SDL_PixelFormatEnum.SDL_PIXELFORMAT_RGBA8888,
    Abgr8888 = SDL_PixelFormatEnum.SDL_PIXELFORMAT_ABGR8888,
    Bgra8888 = SDL_PixelFormatEnum.SDL_PIXELFORMAT_BGRA8888,
    Argb2101010 = SDL_PixelFormatEnum.SDL_PIXELFORMAT_ARGB2101010,
    Rgba32 = SDL_PixelFormatEnum.SDL_PIXELFORMAT_RGBA32,
    Argb32 = SDL_PixelFormatEnum.SDL_PIXELFORMAT_ARGB32,
    Bgra32 = SDL_PixelFormatEnum.SDL_PIXELFORMAT_BGRA32,
    Abgr32 = SDL_PixelFormatEnum.SDL_PIXELFORMAT_ABGR32,
    Rgbx32 = SDL_PixelFormatEnum.SDL_PIXELFORMAT_RGBX32,
    Xrgb32 = SDL_PixelFormatEnum.SDL_PIXELFORMAT_XRGB32,
    Bgrx32 = SDL_PixelFormatEnum.SDL_PIXELFORMAT_BGRX32,
    Xbgr32 = SDL_PixelFormatEnum.SDL_PIXELFORMAT_XBGR32,
    Yv12 = SDL_PixelFormatEnum.SDL_PIXELFORMAT_YV12,
    Iyuv = SDL_PixelFormatEnum.SDL_PIXELFORMAT_IYUV,
    Yuy2 = SDL_PixelFormatEnum.SDL_PIXELFORMAT_YUY2,
    Uyvy = SDL_PixelFormatEnum.SDL_PIXELFORMAT_UYVY,
    Yvyu = SDL_PixelFormatEnum.SDL_PIXELFORMAT_YVYU,
    Nv12 = SDL_PixelFormatEnum.SDL_PIXELFORMAT_NV12,
    Nv21 = SDL_PixelFormatEnum.SDL_PIXELFORMAT_NV21,
    ExternalOes = SDL_PixelFormatEnum.SDL_PIXELFORMAT_EXTERNAL_OES,
}