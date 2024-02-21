using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpSDL.Interop
{
    public enum PixelType
    {
        UNKNOWN,
        INDEX1,
        INDEX4,
        INDEX8,
        PACKED8,
        PACKED16,
        PACKED32,
        ARRAYU8,
        ARRAYU16,
        ARRAYU32,
        ARRAYF16,
        ARRAYF32,
        INDEX2,
    }

    public enum BitmapOrder
    {
        _NONE,
        _4321,
        _1234,
    }

    public enum PackedOrder
    {
        NONE,
        XRGB,
        RGBX,
        ARGB,
        RGBA,
        XBGR,
        BGRX,
        ABGR,
        BGRA,
    }

    public enum ArrayOrder
    {
        NONE,
        RGB,
        RGBA,
        ARGB,
        BGR,
        BGRA,
        ABGR,
    }

    public enum PackedLayout
    {
        _NONE,
        _332,
        _4444,
        _1555,
        _5551,
        _565,
        _8888,
        _2101010,
        _1010102,
    }

    public enum PixelFormatEnum : uint
    {
        UNKNOWN,
        INDEX1LSB = ((1 << 28) | ((PixelType.INDEX1) << 24) | ((BitmapOrder._4321) << 20) | ((0) << 16) | ((1) << 8) | ((0) << 0)),
        INDEX1MSB = ((1 << 28) | ((PixelType.INDEX1) << 24) | ((BitmapOrder._1234) << 20) | ((0) << 16) | ((1) << 8) | ((0) << 0)),
        INDEX2LSB = ((1 << 28) | ((PixelType.INDEX2) << 24) | ((BitmapOrder._4321) << 20) | ((0) << 16) | ((2) << 8) | ((0) << 0)),
        INDEX2MSB = ((1 << 28) | ((PixelType.INDEX2) << 24) | ((BitmapOrder._1234) << 20) | ((0) << 16) | ((2) << 8) | ((0) << 0)),
        INDEX4LSB = ((1 << 28) | ((PixelType.INDEX4) << 24) | ((BitmapOrder._4321) << 20) | ((0) << 16) | ((4) << 8) | ((0) << 0)),
        INDEX4MSB = ((1 << 28) | ((PixelType.INDEX4) << 24) | ((BitmapOrder._1234) << 20) | ((0) << 16) | ((4) << 8) | ((0) << 0)),
        INDEX8 = ((1 << 28) | ((PixelType.INDEX8) << 24) | ((0) << 20) | ((0) << 16) | ((8) << 8) | ((1) << 0)),
        RGB332 = ((1 << 28) | ((PixelType.PACKED8) << 24) | ((PackedOrder.XRGB) << 20) | ((PackedLayout._332) << 16) | ((8) << 8) | ((1) << 0)),
        XRGB4444 = ((1 << 28) | ((PixelType.PACKED16) << 24) | ((PackedOrder.XRGB) << 20) | ((PackedLayout._4444) << 16) | ((12) << 8) | ((2) << 0)),
        RGB444 = XRGB4444,
        XBGR4444 = ((1 << 28) | ((PixelType.PACKED16) << 24) | ((PackedOrder.XBGR) << 20) | ((PackedLayout._4444) << 16) | ((12) << 8) | ((2) << 0)),
        BGR444 = XBGR4444,
        XRGB1555 = ((1 << 28) | ((PixelType.PACKED16) << 24) | ((PackedOrder.XRGB) << 20) | ((PackedLayout._1555) << 16) | ((15) << 8) | ((2) << 0)),
        RGB555 = XRGB1555,
        XBGR1555 = ((1 << 28) | ((PixelType.PACKED16) << 24) | ((PackedOrder.XBGR) << 20) | ((PackedLayout._1555) << 16) | ((15) << 8) | ((2) << 0)),
        BGR555 = XBGR1555,
        ARGB4444 = ((1 << 28) | ((PixelType.PACKED16) << 24) | ((PackedOrder.ARGB) << 20) | ((PackedLayout._4444) << 16) | ((16) << 8) | ((2) << 0)),
        RGBA4444 = ((1 << 28) | ((PixelType.PACKED16) << 24) | ((PackedOrder.RGBA) << 20) | ((PackedLayout._4444) << 16) | ((16) << 8) | ((2) << 0)),
        ABGR4444 = ((1 << 28) | ((PixelType.PACKED16) << 24) | ((PackedOrder.ABGR) << 20) | ((PackedLayout._4444) << 16) | ((16) << 8) | ((2) << 0)),
        BGRA4444 = ((1 << 28) | ((PixelType.PACKED16) << 24) | ((PackedOrder.BGRA) << 20) | ((PackedLayout._4444) << 16) | ((16) << 8) | ((2) << 0)),
        ARGB1555 = ((1 << 28) | ((PixelType.PACKED16) << 24) | ((PackedOrder.ARGB) << 20) | ((PackedLayout._1555) << 16) | ((16) << 8) | ((2) << 0)),
        RGBA5551 = ((1 << 28) | ((PixelType.PACKED16) << 24) | ((PackedOrder.RGBA) << 20) | ((PackedLayout._5551) << 16) | ((16) << 8) | ((2) << 0)),
        ABGR1555 = ((1 << 28) | ((PixelType.PACKED16) << 24) | ((PackedOrder.ABGR) << 20) | ((PackedLayout._1555) << 16) | ((16) << 8) | ((2) << 0)),
        BGRA5551 = ((1 << 28) | ((PixelType.PACKED16) << 24) | ((PackedOrder.BGRA) << 20) | ((PackedLayout._5551) << 16) | ((16) << 8) | ((2) << 0)),
        RGB565 = ((1 << 28) | ((PixelType.PACKED16) << 24) | ((PackedOrder.XRGB) << 20) | ((PackedLayout._565) << 16) | ((16) << 8) | ((2) << 0)),
        BGR565 = ((1 << 28) | ((PixelType.PACKED16) << 24) | ((PackedOrder.XBGR) << 20) | ((PackedLayout._565) << 16) | ((16) << 8) | ((2) << 0)),
        RGB24 = ((1 << 28) | ((PixelType.ARRAYU8) << 24) | ((ArrayOrder.RGB) << 20) | ((0) << 16) | ((24) << 8) | ((3) << 0)),
        BGR24 = ((1 << 28) | ((PixelType.ARRAYU8) << 24) | ((ArrayOrder.BGR) << 20) | ((0) << 16) | ((24) << 8) | ((3) << 0)),
        XRGB8888 = ((1 << 28) | ((PixelType.PACKED32) << 24) | ((PackedOrder.XRGB) << 20) | ((PackedLayout._8888) << 16) | ((24) << 8) | ((4) << 0)),
        RGB888 = XRGB8888,
        RGBX8888 = ((1 << 28) | ((PixelType.PACKED32) << 24) | ((PackedOrder.RGBX) << 20) | ((PackedLayout._8888) << 16) | ((24) << 8) | ((4) << 0)),
        XBGR8888 = ((1 << 28) | ((PixelType.PACKED32) << 24) | ((PackedOrder.XBGR) << 20) | ((PackedLayout._8888) << 16) | ((24) << 8) | ((4) << 0)),
        BGR888 = XBGR8888,
        BGRX8888 = ((1 << 28) | ((PixelType.PACKED32) << 24) | ((PackedOrder.BGRX) << 20) | ((PackedLayout._8888) << 16) | ((24) << 8) | ((4) << 0)),
        ARGB8888 = ((1 << 28) | ((PixelType.PACKED32) << 24) | ((PackedOrder.ARGB) << 20) | ((PackedLayout._8888) << 16) | ((32) << 8) | ((4) << 0)),
        RGBA8888 = ((1 << 28) | ((PixelType.PACKED32) << 24) | ((PackedOrder.RGBA) << 20) | ((PackedLayout._8888) << 16) | ((32) << 8) | ((4) << 0)),
        ABGR8888 = ((1 << 28) | ((PixelType.PACKED32) << 24) | ((PackedOrder.ABGR) << 20) | ((PackedLayout._8888) << 16) | ((32) << 8) | ((4) << 0)),
        BGRA8888 = ((1 << 28) | ((PixelType.PACKED32) << 24) | ((PackedOrder.BGRA) << 20) | ((PackedLayout._8888) << 16) | ((32) << 8) | ((4) << 0)),
        ARGB2101010 = ((1 << 28) | ((PixelType.PACKED32) << 24) | ((PackedOrder.ARGB) << 20) | ((PackedLayout._2101010) << 16) | ((32) << 8) | ((4) << 0)),
        RGBA32 = ABGR8888,
        ARGB32 = BGRA8888,
        BGRA32 = ARGB8888,
        ABGR32 = RGBA8888,
        RGBX32 = XBGR8888,
        XRGB32 = BGRX8888,
        BGRX32 = XRGB8888,
        XBGR32 = RGBX8888,
        YV12 = unchecked((((uint)(((byte)(('Y'))))) << 0) | (((uint)(((byte)(('V'))))) << 8) | (((uint)(((byte)(('1'))))) << 16) | (((uint)(((byte)(('2'))))) << 24)),
        IYUV = unchecked((((uint)(((byte)(('I'))))) << 0) | (((uint)(((byte)(('Y'))))) << 8) | (((uint)(((byte)(('U'))))) << 16) | (((uint)(((byte)(('V'))))) << 24)),
        YUY2 = unchecked((((uint)(((byte)(('Y'))))) << 0) | (((uint)(((byte)(('U'))))) << 8) | (((uint)(((byte)(('Y'))))) << 16) | (((uint)(((byte)(('2'))))) << 24)),
        UYVY = unchecked((((uint)(((byte)(('U'))))) << 0) | (((uint)(((byte)(('Y'))))) << 8) | (((uint)(((byte)(('V'))))) << 16) | (((uint)(((byte)(('Y'))))) << 24)),
        YVYU = unchecked((((uint)(((byte)(('Y'))))) << 0) | (((uint)(((byte)(('V'))))) << 8) | (((uint)(((byte)(('Y'))))) << 16) | (((uint)(((byte)(('U'))))) << 24)),
        NV12 = unchecked((((uint)(((byte)(('N'))))) << 0) | (((uint)(((byte)(('V'))))) << 8) | (((uint)(((byte)(('1'))))) << 16) | (((uint)(((byte)(('2'))))) << 24)),
        NV21 = unchecked((((uint)(((byte)(('N'))))) << 0) | (((uint)(((byte)(('V'))))) << 8) | (((uint)(((byte)(('2'))))) << 16) | (((uint)(((byte)(('1'))))) << 24)),
        EXTERNAL_OES = unchecked((((uint)(((byte)(('O'))))) << 0) | (((uint)(((byte)(('E'))))) << 8) | (((uint)(((byte)(('S'))))) << 16) | (((uint)(((byte)((' '))))) << 24)),
    }

    public partial struct Color
    {
        public byte r;

        public byte g;

        public byte b;

        public byte a;
    }

    public unsafe partial struct Palette
    {
        public int ncolors;

        public Color* colors;

        public uint version;

        public int refcount;
    }

    public unsafe partial struct PixelFormat
    {
        public uint format;

        public Palette* palette;

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

        [NativeTypeName("struct PixelFormat *")]
        public PixelFormat* next;

        [InlineArray(2)]
        public partial struct _padding_e__FixedBuffer
        {
            public byte e0;
        }
    }

    public static unsafe partial class SDL
    {
        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetPixelFormatName", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern byte* GetPixelFormatName(uint format);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "PixelFormatEnumToMasks", ExactSpelling = true)]
        public static extern CBool PixelFormatEnumToMasks(uint format, int* bpp, [NativeTypeName(" *")] uint* Rmask, [NativeTypeName(" *")] uint* Gmask, [NativeTypeName(" *")] uint* Bmask, [NativeTypeName(" *")] uint* Amask);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_MasksToPixelFormatEnum", ExactSpelling = true)]
        public static extern uint MasksToPixelFormatEnum(int bpp, uint Rmask, uint Gmask, uint Bmask, uint Amask);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_AllocFormat", ExactSpelling = true)]
        public static extern PixelFormat* AllocFormat(uint pixel_format);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FreeFormat", ExactSpelling = true)]
        public static extern void FreeFormat(PixelFormat* format);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_AllocPalette", ExactSpelling = true)]
        public static extern Palette* AllocPalette(int ncolors);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetPixelFormatPalette", ExactSpelling = true)]
        public static extern int SetPixelFormatPalette(PixelFormat* format, Palette* palette);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetPaletteColors", ExactSpelling = true)]
        public static extern int SetPaletteColors(Palette* palette, [NativeTypeName("const Color *")] Color* colors, int firstcolor, int ncolors);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FreePalette", ExactSpelling = true)]
        public static extern void FreePalette(Palette* palette);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_MapRGB", ExactSpelling = true)]
        public static extern uint MapRGB([NativeTypeName("const PixelFormat *")] PixelFormat* format, byte r, byte g, byte b);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_MapRGBA", ExactSpelling = true)]
        public static extern uint MapRGBA([NativeTypeName("const PixelFormat *")] PixelFormat* format, byte r, byte g, byte b, byte a);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRGB", ExactSpelling = true)]
        public static extern void GetRGB(uint pixel, [NativeTypeName("const PixelFormat *")] PixelFormat* format, [NativeTypeName(" *")] byte* r, [NativeTypeName(" *")] byte* g, [NativeTypeName(" *")] byte* b);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRGBA", ExactSpelling = true)]
        public static extern void GetRGBA(uint pixel, [NativeTypeName("const PixelFormat *")] PixelFormat* format, [NativeTypeName(" *")] byte* r, [NativeTypeName(" *")] byte* g, [NativeTypeName(" *")] byte* b, [NativeTypeName(" *")] byte* a);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CalculateGammaRamp", ExactSpelling = true)]
        public static extern void CalculateGammaRamp(float gamma, [NativeTypeName(" *")] ushort* ramp);

        [NativeTypeName("#define SDL_ALPHA_OPAQUE 255")]
        public const int SDL_ALPHA_OPAQUE = 255;

        [NativeTypeName("#define SDL_ALPHA_TRANSPARENT 0")]
        public const int SDL_ALPHA_TRANSPARENT = 0;
    }
}
