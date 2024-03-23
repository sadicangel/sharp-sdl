using SharpSDL.Objects;

namespace SharpSDL;

public readonly struct PixelFormat
{
    public readonly PixelFormatEnum Format;
    public readonly unsafe Palette* Palette;
    public readonly byte BitsPerPixel;
    public readonly byte BytesPerPixel;
    public readonly byte Padding0;
    public readonly byte Padding1;
    public readonly uint RMask;
    public readonly uint GMask;
    public readonly uint BMask;
    public readonly uint AMask;
    public readonly byte RLoss;
    public readonly byte GLoss;
    public readonly byte BLoss;
    public readonly byte ALoss;
    public readonly byte RShift;
    public readonly byte GShift;
    public readonly byte BShift;
    public readonly byte AShift;
    public readonly int RefCount;
    public readonly unsafe PixelFormat* Next;
}


public readonly struct Palette
{
    public readonly int ColorCount;
    public readonly unsafe ColorRgba* Colors;
    public readonly uint Version;
    public readonly int RefCount;
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