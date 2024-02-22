using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpSDL.Interop;

internal enum SDL_PixelType
{
    SDL_PIXELTYPE_UNKNOWN,
    SDL_PIXELTYPE_INDEX1,
    SDL_PIXELTYPE_INDEX4,
    SDL_PIXELTYPE_INDEX8,
    SDL_PIXELTYPE_PACKED8,
    SDL_PIXELTYPE_PACKED16,
    SDL_PIXELTYPE_PACKED32,
    SDL_PIXELTYPE_ARRAYU8,
    SDL_PIXELTYPE_ARRAYU16,
    SDL_PIXELTYPE_ARRAYU32,
    SDL_PIXELTYPE_ARRAYF16,
    SDL_PIXELTYPE_ARRAYF32,
    SDL_PIXELTYPE_INDEX2,
}

internal enum SDL_BitmapOrder
{
    SDL_BITMAPORDER_NONE,
    SDL_BITMAPORDER_4321,
    SDL_BITMAPORDER_1234,
}

internal enum SDL_PackedOrder
{
    SDL_PACKEDORDER_NONE,
    SDL_PACKEDORDER_XRGB,
    SDL_PACKEDORDER_RGBX,
    SDL_PACKEDORDER_ARGB,
    SDL_PACKEDORDER_RGBA,
    SDL_PACKEDORDER_XBGR,
    SDL_PACKEDORDER_BGRX,
    SDL_PACKEDORDER_ABGR,
    SDL_PACKEDORDER_BGRA,
}

internal enum SDL_ArrayOrder
{
    SDL_ARRAYORDER_NONE,
    SDL_ARRAYORDER_RGB,
    SDL_ARRAYORDER_RGBA,
    SDL_ARRAYORDER_ARGB,
    SDL_ARRAYORDER_BGR,
    SDL_ARRAYORDER_BGRA,
    SDL_ARRAYORDER_ABGR,
}

internal enum SDL_PackedLayout
{
    SDL_PACKEDLAYOUT_NONE,
    SDL_PACKEDLAYOUT_332,
    SDL_PACKEDLAYOUT_4444,
    SDL_PACKEDLAYOUT_1555,
    SDL_PACKEDLAYOUT_5551,
    SDL_PACKEDLAYOUT_565,
    SDL_PACKEDLAYOUT_8888,
    SDL_PACKEDLAYOUT_2101010,
    SDL_PACKEDLAYOUT_1010102,
}

internal enum SDL_PixelFormatEnum : uint
{
    SDL_PIXELFORMAT_UNKNOWN,
    SDL_PIXELFORMAT_INDEX1LSB = ((1 << 28) | ((SDL_PixelType.SDL_PIXELTYPE_INDEX1) << 24) | ((SDL_BitmapOrder.SDL_BITMAPORDER_4321) << 20) | ((0) << 16) | ((1) << 8) | ((0) << 0)),
    SDL_PIXELFORMAT_INDEX1MSB = ((1 << 28) | ((SDL_PixelType.SDL_PIXELTYPE_INDEX1) << 24) | ((SDL_BitmapOrder.SDL_BITMAPORDER_1234) << 20) | ((0) << 16) | ((1) << 8) | ((0) << 0)),
    SDL_PIXELFORMAT_INDEX2LSB = ((1 << 28) | ((SDL_PixelType.SDL_PIXELTYPE_INDEX2) << 24) | ((SDL_BitmapOrder.SDL_BITMAPORDER_4321) << 20) | ((0) << 16) | ((2) << 8) | ((0) << 0)),
    SDL_PIXELFORMAT_INDEX2MSB = ((1 << 28) | ((SDL_PixelType.SDL_PIXELTYPE_INDEX2) << 24) | ((SDL_BitmapOrder.SDL_BITMAPORDER_1234) << 20) | ((0) << 16) | ((2) << 8) | ((0) << 0)),
    SDL_PIXELFORMAT_INDEX4LSB = ((1 << 28) | ((SDL_PixelType.SDL_PIXELTYPE_INDEX4) << 24) | ((SDL_BitmapOrder.SDL_BITMAPORDER_4321) << 20) | ((0) << 16) | ((4) << 8) | ((0) << 0)),
    SDL_PIXELFORMAT_INDEX4MSB = ((1 << 28) | ((SDL_PixelType.SDL_PIXELTYPE_INDEX4) << 24) | ((SDL_BitmapOrder.SDL_BITMAPORDER_1234) << 20) | ((0) << 16) | ((4) << 8) | ((0) << 0)),
    SDL_PIXELFORMAT_INDEX8 = ((1 << 28) | ((SDL_PixelType.SDL_PIXELTYPE_INDEX8) << 24) | ((0) << 20) | ((0) << 16) | ((8) << 8) | ((1) << 0)),
    SDL_PIXELFORMAT_RGB332 = ((1 << 28) | ((SDL_PixelType.SDL_PIXELTYPE_PACKED8) << 24) | ((SDL_PackedOrder.SDL_PACKEDORDER_XRGB) << 20) | ((SDL_PackedLayout.SDL_PACKEDLAYOUT_332) << 16) | ((8) << 8) | ((1) << 0)),
    SDL_PIXELFORMAT_XRGB4444 = ((1 << 28) | ((SDL_PixelType.SDL_PIXELTYPE_PACKED16) << 24) | ((SDL_PackedOrder.SDL_PACKEDORDER_XRGB) << 20) | ((SDL_PackedLayout.SDL_PACKEDLAYOUT_4444) << 16) | ((12) << 8) | ((2) << 0)),
    SDL_PIXELFORMAT_RGB444 = SDL_PIXELFORMAT_XRGB4444,
    SDL_PIXELFORMAT_XBGR4444 = ((1 << 28) | ((SDL_PixelType.SDL_PIXELTYPE_PACKED16) << 24) | ((SDL_PackedOrder.SDL_PACKEDORDER_XBGR) << 20) | ((SDL_PackedLayout.SDL_PACKEDLAYOUT_4444) << 16) | ((12) << 8) | ((2) << 0)),
    SDL_PIXELFORMAT_BGR444 = SDL_PIXELFORMAT_XBGR4444,
    SDL_PIXELFORMAT_XRGB1555 = ((1 << 28) | ((SDL_PixelType.SDL_PIXELTYPE_PACKED16) << 24) | ((SDL_PackedOrder.SDL_PACKEDORDER_XRGB) << 20) | ((SDL_PackedLayout.SDL_PACKEDLAYOUT_1555) << 16) | ((15) << 8) | ((2) << 0)),
    SDL_PIXELFORMAT_RGB555 = SDL_PIXELFORMAT_XRGB1555,
    SDL_PIXELFORMAT_XBGR1555 = ((1 << 28) | ((SDL_PixelType.SDL_PIXELTYPE_PACKED16) << 24) | ((SDL_PackedOrder.SDL_PACKEDORDER_XBGR) << 20) | ((SDL_PackedLayout.SDL_PACKEDLAYOUT_1555) << 16) | ((15) << 8) | ((2) << 0)),
    SDL_PIXELFORMAT_BGR555 = SDL_PIXELFORMAT_XBGR1555,
    SDL_PIXELFORMAT_ARGB4444 = ((1 << 28) | ((SDL_PixelType.SDL_PIXELTYPE_PACKED16) << 24) | ((SDL_PackedOrder.SDL_PACKEDORDER_ARGB) << 20) | ((SDL_PackedLayout.SDL_PACKEDLAYOUT_4444) << 16) | ((16) << 8) | ((2) << 0)),
    SDL_PIXELFORMAT_RGBA4444 = ((1 << 28) | ((SDL_PixelType.SDL_PIXELTYPE_PACKED16) << 24) | ((SDL_PackedOrder.SDL_PACKEDORDER_RGBA) << 20) | ((SDL_PackedLayout.SDL_PACKEDLAYOUT_4444) << 16) | ((16) << 8) | ((2) << 0)),
    SDL_PIXELFORMAT_ABGR4444 = ((1 << 28) | ((SDL_PixelType.SDL_PIXELTYPE_PACKED16) << 24) | ((SDL_PackedOrder.SDL_PACKEDORDER_ABGR) << 20) | ((SDL_PackedLayout.SDL_PACKEDLAYOUT_4444) << 16) | ((16) << 8) | ((2) << 0)),
    SDL_PIXELFORMAT_BGRA4444 = ((1 << 28) | ((SDL_PixelType.SDL_PIXELTYPE_PACKED16) << 24) | ((SDL_PackedOrder.SDL_PACKEDORDER_BGRA) << 20) | ((SDL_PackedLayout.SDL_PACKEDLAYOUT_4444) << 16) | ((16) << 8) | ((2) << 0)),
    SDL_PIXELFORMAT_ARGB1555 = ((1 << 28) | ((SDL_PixelType.SDL_PIXELTYPE_PACKED16) << 24) | ((SDL_PackedOrder.SDL_PACKEDORDER_ARGB) << 20) | ((SDL_PackedLayout.SDL_PACKEDLAYOUT_1555) << 16) | ((16) << 8) | ((2) << 0)),
    SDL_PIXELFORMAT_RGBA5551 = ((1 << 28) | ((SDL_PixelType.SDL_PIXELTYPE_PACKED16) << 24) | ((SDL_PackedOrder.SDL_PACKEDORDER_RGBA) << 20) | ((SDL_PackedLayout.SDL_PACKEDLAYOUT_5551) << 16) | ((16) << 8) | ((2) << 0)),
    SDL_PIXELFORMAT_ABGR1555 = ((1 << 28) | ((SDL_PixelType.SDL_PIXELTYPE_PACKED16) << 24) | ((SDL_PackedOrder.SDL_PACKEDORDER_ABGR) << 20) | ((SDL_PackedLayout.SDL_PACKEDLAYOUT_1555) << 16) | ((16) << 8) | ((2) << 0)),
    SDL_PIXELFORMAT_BGRA5551 = ((1 << 28) | ((SDL_PixelType.SDL_PIXELTYPE_PACKED16) << 24) | ((SDL_PackedOrder.SDL_PACKEDORDER_BGRA) << 20) | ((SDL_PackedLayout.SDL_PACKEDLAYOUT_5551) << 16) | ((16) << 8) | ((2) << 0)),
    SDL_PIXELFORMAT_RGB565 = ((1 << 28) | ((SDL_PixelType.SDL_PIXELTYPE_PACKED16) << 24) | ((SDL_PackedOrder.SDL_PACKEDORDER_XRGB) << 20) | ((SDL_PackedLayout.SDL_PACKEDLAYOUT_565) << 16) | ((16) << 8) | ((2) << 0)),
    SDL_PIXELFORMAT_BGR565 = ((1 << 28) | ((SDL_PixelType.SDL_PIXELTYPE_PACKED16) << 24) | ((SDL_PackedOrder.SDL_PACKEDORDER_XBGR) << 20) | ((SDL_PackedLayout.SDL_PACKEDLAYOUT_565) << 16) | ((16) << 8) | ((2) << 0)),
    SDL_PIXELFORMAT_RGB24 = ((1 << 28) | ((SDL_PixelType.SDL_PIXELTYPE_ARRAYU8) << 24) | ((SDL_ArrayOrder.SDL_ARRAYORDER_RGB) << 20) | ((0) << 16) | ((24) << 8) | ((3) << 0)),
    SDL_PIXELFORMAT_BGR24 = ((1 << 28) | ((SDL_PixelType.SDL_PIXELTYPE_ARRAYU8) << 24) | ((SDL_ArrayOrder.SDL_ARRAYORDER_BGR) << 20) | ((0) << 16) | ((24) << 8) | ((3) << 0)),
    SDL_PIXELFORMAT_XRGB8888 = ((1 << 28) | ((SDL_PixelType.SDL_PIXELTYPE_PACKED32) << 24) | ((SDL_PackedOrder.SDL_PACKEDORDER_XRGB) << 20) | ((SDL_PackedLayout.SDL_PACKEDLAYOUT_8888) << 16) | ((24) << 8) | ((4) << 0)),
    SDL_PIXELFORMAT_RGB888 = SDL_PIXELFORMAT_XRGB8888,
    SDL_PIXELFORMAT_RGBX8888 = ((1 << 28) | ((SDL_PixelType.SDL_PIXELTYPE_PACKED32) << 24) | ((SDL_PackedOrder.SDL_PACKEDORDER_RGBX) << 20) | ((SDL_PackedLayout.SDL_PACKEDLAYOUT_8888) << 16) | ((24) << 8) | ((4) << 0)),
    SDL_PIXELFORMAT_XBGR8888 = ((1 << 28) | ((SDL_PixelType.SDL_PIXELTYPE_PACKED32) << 24) | ((SDL_PackedOrder.SDL_PACKEDORDER_XBGR) << 20) | ((SDL_PackedLayout.SDL_PACKEDLAYOUT_8888) << 16) | ((24) << 8) | ((4) << 0)),
    SDL_PIXELFORMAT_BGR888 = SDL_PIXELFORMAT_XBGR8888,
    SDL_PIXELFORMAT_BGRX8888 = ((1 << 28) | ((SDL_PixelType.SDL_PIXELTYPE_PACKED32) << 24) | ((SDL_PackedOrder.SDL_PACKEDORDER_BGRX) << 20) | ((SDL_PackedLayout.SDL_PACKEDLAYOUT_8888) << 16) | ((24) << 8) | ((4) << 0)),
    SDL_PIXELFORMAT_ARGB8888 = ((1 << 28) | ((SDL_PixelType.SDL_PIXELTYPE_PACKED32) << 24) | ((SDL_PackedOrder.SDL_PACKEDORDER_ARGB) << 20) | ((SDL_PackedLayout.SDL_PACKEDLAYOUT_8888) << 16) | ((32) << 8) | ((4) << 0)),
    SDL_PIXELFORMAT_RGBA8888 = ((1 << 28) | ((SDL_PixelType.SDL_PIXELTYPE_PACKED32) << 24) | ((SDL_PackedOrder.SDL_PACKEDORDER_RGBA) << 20) | ((SDL_PackedLayout.SDL_PACKEDLAYOUT_8888) << 16) | ((32) << 8) | ((4) << 0)),
    SDL_PIXELFORMAT_ABGR8888 = ((1 << 28) | ((SDL_PixelType.SDL_PIXELTYPE_PACKED32) << 24) | ((SDL_PackedOrder.SDL_PACKEDORDER_ABGR) << 20) | ((SDL_PackedLayout.SDL_PACKEDLAYOUT_8888) << 16) | ((32) << 8) | ((4) << 0)),
    SDL_PIXELFORMAT_BGRA8888 = ((1 << 28) | ((SDL_PixelType.SDL_PIXELTYPE_PACKED32) << 24) | ((SDL_PackedOrder.SDL_PACKEDORDER_BGRA) << 20) | ((SDL_PackedLayout.SDL_PACKEDLAYOUT_8888) << 16) | ((32) << 8) | ((4) << 0)),
    SDL_PIXELFORMAT_ARGB2101010 = ((1 << 28) | ((SDL_PixelType.SDL_PIXELTYPE_PACKED32) << 24) | ((SDL_PackedOrder.SDL_PACKEDORDER_ARGB) << 20) | ((SDL_PackedLayout.SDL_PACKEDLAYOUT_2101010) << 16) | ((32) << 8) | ((4) << 0)),
    SDL_PIXELFORMAT_RGBA32 = SDL_PIXELFORMAT_ABGR8888,
    SDL_PIXELFORMAT_ARGB32 = SDL_PIXELFORMAT_BGRA8888,
    SDL_PIXELFORMAT_BGRA32 = SDL_PIXELFORMAT_ARGB8888,
    SDL_PIXELFORMAT_ABGR32 = SDL_PIXELFORMAT_RGBA8888,
    SDL_PIXELFORMAT_RGBX32 = SDL_PIXELFORMAT_XBGR8888,
    SDL_PIXELFORMAT_XRGB32 = SDL_PIXELFORMAT_BGRX8888,
    SDL_PIXELFORMAT_BGRX32 = SDL_PIXELFORMAT_XRGB8888,
    SDL_PIXELFORMAT_XBGR32 = SDL_PIXELFORMAT_RGBX8888,
    SDL_PIXELFORMAT_YV12 = unchecked((((uint)(((byte)(('Y'))))) << 0) | (((uint)(((byte)(('V'))))) << 8) | (((uint)(((byte)(('1'))))) << 16) | (((uint)(((byte)(('2'))))) << 24)),
    SDL_PIXELFORMAT_IYUV = unchecked((((uint)(((byte)(('I'))))) << 0) | (((uint)(((byte)(('Y'))))) << 8) | (((uint)(((byte)(('U'))))) << 16) | (((uint)(((byte)(('V'))))) << 24)),
    SDL_PIXELFORMAT_YUY2 = unchecked((((uint)(((byte)(('Y'))))) << 0) | (((uint)(((byte)(('U'))))) << 8) | (((uint)(((byte)(('Y'))))) << 16) | (((uint)(((byte)(('2'))))) << 24)),
    SDL_PIXELFORMAT_UYVY = unchecked((((uint)(((byte)(('U'))))) << 0) | (((uint)(((byte)(('Y'))))) << 8) | (((uint)(((byte)(('V'))))) << 16) | (((uint)(((byte)(('Y'))))) << 24)),
    SDL_PIXELFORMAT_YVYU = unchecked((((uint)(((byte)(('Y'))))) << 0) | (((uint)(((byte)(('V'))))) << 8) | (((uint)(((byte)(('Y'))))) << 16) | (((uint)(((byte)(('U'))))) << 24)),
    SDL_PIXELFORMAT_NV12 = unchecked((((uint)(((byte)(('N'))))) << 0) | (((uint)(((byte)(('V'))))) << 8) | (((uint)(((byte)(('1'))))) << 16) | (((uint)(((byte)(('2'))))) << 24)),
    SDL_PIXELFORMAT_NV21 = unchecked((((uint)(((byte)(('N'))))) << 0) | (((uint)(((byte)(('V'))))) << 8) | (((uint)(((byte)(('2'))))) << 16) | (((uint)(((byte)(('1'))))) << 24)),
    SDL_PIXELFORMAT_EXTERNAL_OES = unchecked((((uint)(((byte)(('O'))))) << 0) | (((uint)(((byte)(('E'))))) << 8) | (((uint)(((byte)(('S'))))) << 16) | (((uint)(((byte)((' '))))) << 24)),
}

internal partial struct SDL_Color
{
    public byte r;

    public byte g;

    public byte b;

    public byte a;
}

internal unsafe partial struct SDL_Palette
{
    public int ncolors;

    public SDL_Color* colors;

    public uint version;

    public int refcount;
}

internal unsafe partial struct SDL_PixelFormat
{
    public uint format;

    public SDL_Palette* palette;

    public byte BitsPerPixel;

    public byte BytesPerPixel;

    [NativeTypeName("[2]")]
    public _padding_e__FixedBuffer padding;

    public uint Rmask;

    public uint Gmask;

    public uint Bmask;

    public uint Amask;

    public byte Rloss;

    public byte Gloss;

    public byte Bloss;

    public byte Aloss;

    public byte Rshift;

    public byte Gshift;

    public byte Bshift;

    public byte Ashift;

    public int refcount;

    [NativeTypeName("struct SDL_PixelFormat *")]
    public SDL_PixelFormat* next;

    [InlineArray(2)]
    internal partial struct _padding_e__FixedBuffer
    {
        public byte e0;
    }
}

internal static unsafe partial class SDL
{
    [LibraryImport("SDL2", EntryPoint = "SDL_GetPixelFormatName")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("const char *")]
    public static partial byte* GetPixelFormatName(uint format);

    [LibraryImport("SDL2", EntryPoint = "SDL_PixelFormatEnumToMasks")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool PixelFormatEnumToMasks(uint format, int* bpp, [NativeTypeName(" *")] uint* Rmask, [NativeTypeName(" *")] uint* Gmask, [NativeTypeName(" *")] uint* Bmask, [NativeTypeName(" *")] uint* Amask);

    [LibraryImport("SDL2", EntryPoint = "SDL_MasksToPixelFormatEnum")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint MasksToPixelFormatEnum(int bpp, uint Rmask, uint Gmask, uint Bmask, uint Amask);

    [LibraryImport("SDL2", EntryPoint = "SDL_AllocFormat")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SDL_PixelFormat* AllocFormat(uint pixel_format);

    [LibraryImport("SDL2", EntryPoint = "SDL_FreeFormat")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void FreeFormat(SDL_PixelFormat* format);

    [LibraryImport("SDL2", EntryPoint = "SDL_AllocPalette")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SDL_Palette* AllocPalette(int ncolors);

    [LibraryImport("SDL2", EntryPoint = "SDL_SetPixelFormatPalette")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SetPixelFormatPalette(SDL_PixelFormat* format, SDL_Palette* palette);

    [LibraryImport("SDL2", EntryPoint = "SDL_SetPaletteColors")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SetPaletteColors(SDL_Palette* palette, [NativeTypeName("const SDL_Color *")] SDL_Color* colors, int firstcolor, int ncolors);

    [LibraryImport("SDL2", EntryPoint = "SDL_FreePalette")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void FreePalette(SDL_Palette* palette);

    [LibraryImport("SDL2", EntryPoint = "SDL_MapRGB")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint MapRGB([NativeTypeName("const SDL_PixelFormat *")] SDL_PixelFormat* format, byte r, byte g, byte b);

    [LibraryImport("SDL2", EntryPoint = "SDL_MapRGBA")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint MapRGBA([NativeTypeName("const SDL_PixelFormat *")] SDL_PixelFormat* format, byte r, byte g, byte b, byte a);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetRGB")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void GetRGB(uint pixel, [NativeTypeName("const SDL_PixelFormat *")] SDL_PixelFormat* format, [NativeTypeName(" *")] byte* r, [NativeTypeName(" *")] byte* g, [NativeTypeName(" *")] byte* b);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetRGBA")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void GetRGBA(uint pixel, [NativeTypeName("const SDL_PixelFormat *")] SDL_PixelFormat* format, [NativeTypeName(" *")] byte* r, [NativeTypeName(" *")] byte* g, [NativeTypeName(" *")] byte* b, [NativeTypeName(" *")] byte* a);

    [LibraryImport("SDL2", EntryPoint = "SDL_CalculateGammaRamp")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void CalculateGammaRamp(float gamma, [NativeTypeName(" *")] ushort* ramp);

    [NativeTypeName("#define SDL_ALPHA_OPAQUE 255")]
    public const int SDL_ALPHA_OPAQUE = 255;

    [NativeTypeName("#define SDL_ALPHA_TRANSPARENT 0")]
    public const int SDL_ALPHA_TRANSPARENT = 0;
}
