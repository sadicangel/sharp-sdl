using System.Runtime.InteropServices;

namespace SharpSDL.Interop;

internal unsafe partial struct SDL_Surface
{
    public uint flags;

    public SDL_PixelFormat* format;

    public int w;

    public int h;

    public int pitch;

    public void* pixels;

    public void* userdata;

    public int locked;

    public void* list_blitmap;

    public SDL_Rect clip_rect;

    [NativeTypeName("SDL_BlitMap*")]
    public nint map;

    public int refcount;
}

internal enum SDL_YUV_CONVERSION_MODE
{
    SDL_YUV_CONVERSION_JPEG,
    SDL_YUV_CONVERSION_BT601,
    SDL_YUV_CONVERSION_BT709,
    SDL_YUV_CONVERSION_AUTOMATIC,
}

internal static unsafe partial class SDL
{
    [LibraryImport("SDL2", EntryPoint = "SDL_CreateRGBSurface")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial SDL_Surface* CreateRGBSurface(uint flags, int width, int height, int depth, uint Rmask, uint Gmask, uint Bmask, uint Amask);

    [LibraryImport("SDL2", EntryPoint = "SDL_CreateRGBSurfaceWithFormat")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial SDL_Surface* CreateRGBSurfaceWithFormat(uint flags, int width, int height, int depth, uint format);

    [LibraryImport("SDL2", EntryPoint = "SDL_CreateRGBSurfaceFrom")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial SDL_Surface* CreateRGBSurfaceFrom(void* pixels, int width, int height, int depth, int pitch, uint Rmask, uint Gmask, uint Bmask, uint Amask);

    [LibraryImport("SDL2", EntryPoint = "SDL_CreateRGBSurfaceWithFormatFrom")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial SDL_Surface* CreateRGBSurfaceWithFormatFrom(void* pixels, int width, int height, int depth, int pitch, uint format);

    [LibraryImport("SDL2", EntryPoint = "SDL_FreeSurface")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void FreeSurface(SDL_Surface* surface);

    [LibraryImport("SDL2", EntryPoint = "SDL_SetSurfacePalette")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int SetSurfacePalette(SDL_Surface* surface, SDL_Palette* palette);

    [LibraryImport("SDL2", EntryPoint = "SDL_LockSurface")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int LockSurface(SDL_Surface* surface);

    [LibraryImport("SDL2", EntryPoint = "SDL_UnlockSurface")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void UnlockSurface(SDL_Surface* surface);

    [LibraryImport("SDL2", EntryPoint = "SDL_LoadBMP_RW")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial SDL_Surface* LoadBMP_RW(SDL_RWops* src, int freesrc);

    [LibraryImport("SDL2", EntryPoint = "SDL_SaveBMP_RW")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int SaveBMP_RW(SDL_Surface* surface, SDL_RWops* dst, int freedst);

    [LibraryImport("SDL2", EntryPoint = "SDL_SetSurfaceRLE")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int SetSurfaceRLE(SDL_Surface* surface, int flag);

    [LibraryImport("SDL2", EntryPoint = "SDL_HasSurfaceRLE")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool HasSurfaceRLE(SDL_Surface* surface);

    [LibraryImport("SDL2", EntryPoint = "SDL_SetColorKey")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int SetColorKey(SDL_Surface* surface, int flag, uint key);

    [LibraryImport("SDL2", EntryPoint = "SDL_HasColorKey")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool HasColorKey(SDL_Surface* surface);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetColorKey")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int GetColorKey(SDL_Surface* surface, [NativeTypeName(" *")] uint* key);

    [LibraryImport("SDL2", EntryPoint = "SDL_SetSurfaceColorMod")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int SetSurfaceColorMod(SDL_Surface* surface, byte r, byte g, byte b);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetSurfaceColorMod")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int GetSurfaceColorMod(SDL_Surface* surface, [NativeTypeName(" *")] byte* r, [NativeTypeName(" *")] byte* g, [NativeTypeName(" *")] byte* b);

    [LibraryImport("SDL2", EntryPoint = "SDL_SetSurfaceAlphaMod")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int SetSurfaceAlphaMod(SDL_Surface* surface, byte alpha);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetSurfaceAlphaMod")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int GetSurfaceAlphaMod(SDL_Surface* surface, [NativeTypeName(" *")] byte* alpha);

    [LibraryImport("SDL2", EntryPoint = "SDL_SetSurfaceBlendMode")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int SetSurfaceBlendMode(SDL_Surface* surface, SDL_BlendMode blendMode);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetSurfaceBlendMode")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int GetSurfaceBlendMode(SDL_Surface* surface, SDL_BlendMode* blendMode);

    [LibraryImport("SDL2", EntryPoint = "SDL_SetClipRect")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool SetClipRect(SDL_Surface* surface, [NativeTypeName("const SDL_Rect *")] SDL_Rect* rect);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetClipRect")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void GetClipRect(SDL_Surface* surface, SDL_Rect* rect);

    [LibraryImport("SDL2", EntryPoint = "SDL_DuplicateSurface")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial SDL_Surface* DuplicateSurface(SDL_Surface* surface);

    [LibraryImport("SDL2", EntryPoint = "SDL_ConvertSurface")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial SDL_Surface* ConvertSurface(SDL_Surface* src, [NativeTypeName("const SDL_PixelFormat *")] SDL_PixelFormat* fmt, uint flags);

    [LibraryImport("SDL2", EntryPoint = "SDL_ConvertSurfaceFormat")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial SDL_Surface* ConvertSurfaceFormat(SDL_Surface* src, uint pixel_format, uint flags);

    [LibraryImport("SDL2", EntryPoint = "SDL_ConvertPixels")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int ConvertPixels(int width, int height, uint src_format, [NativeTypeName("const void *")] void* src, int src_pitch, uint dst_format, void* dst, int dst_pitch);

    [LibraryImport("SDL2", EntryPoint = "SDL_PremultiplyAlpha")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int PremultiplyAlpha(int width, int height, uint src_format, [NativeTypeName("const void *")] void* src, int src_pitch, uint dst_format, void* dst, int dst_pitch);

    [LibraryImport("SDL2", EntryPoint = "SDL_FillRect")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int FillRect(SDL_Surface* dst, [NativeTypeName("const SDL_Rect *")] SDL_Rect* rect, uint color);

    [LibraryImport("SDL2", EntryPoint = "SDL_FillRects")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int FillRects(SDL_Surface* dst, [NativeTypeName("const SDL_Rect *")] SDL_Rect* rects, int count, uint color);

    [LibraryImport("SDL2", EntryPoint = "SDL_UpperBlit")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int UpperBlit(SDL_Surface* src, [NativeTypeName("const SDL_Rect *")] SDL_Rect* srcrect, SDL_Surface* dst, SDL_Rect* dstrect);

    [LibraryImport("SDL2", EntryPoint = "SDL_LowerBlit")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int LowerBlit(SDL_Surface* src, SDL_Rect* srcrect, SDL_Surface* dst, SDL_Rect* dstrect);

    [LibraryImport("SDL2", EntryPoint = "SDL_SoftStretch")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int SoftStretch(SDL_Surface* src, [NativeTypeName("const SDL_Rect *")] SDL_Rect* srcrect, SDL_Surface* dst, [NativeTypeName("const SDL_Rect *")] SDL_Rect* dstrect);

    [LibraryImport("SDL2", EntryPoint = "SDL_SoftStretchLinear")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int SoftStretchLinear(SDL_Surface* src, [NativeTypeName("const SDL_Rect *")] SDL_Rect* srcrect, SDL_Surface* dst, [NativeTypeName("const SDL_Rect *")] SDL_Rect* dstrect);

    [LibraryImport("SDL2", EntryPoint = "SDL_UpperBlitScaled")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int UpperBlitScaled(SDL_Surface* src, [NativeTypeName("const SDL_Rect *")] SDL_Rect* srcrect, SDL_Surface* dst, SDL_Rect* dstrect);

    [LibraryImport("SDL2", EntryPoint = "SDL_LowerBlitScaled")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int LowerBlitScaled(SDL_Surface* src, SDL_Rect* srcrect, SDL_Surface* dst, SDL_Rect* dstrect);

    [LibraryImport("SDL2", EntryPoint = "SDL_SetYUVConversionMode")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void SetYUVConversionMode(SDL_YUV_CONVERSION_MODE mode);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetYUVConversionMode")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial SDL_YUV_CONVERSION_MODE GetYUVConversionMode();

    [LibraryImport("SDL2", EntryPoint = "SDL_GetYUVConversionModeForResolution")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial SDL_YUV_CONVERSION_MODE GetYUVConversionModeForResolution(int width, int height);

    [NativeTypeName("#define SDL_SWSURFACE 0")]
    public const int SDL_SWSURFACE = 0;

    [NativeTypeName("#define SDL_PREALLOC 0x00000001")]
    public const int SDL_PREALLOC = 0x00000001;

    [NativeTypeName("#define SDL_RLEACCEL 0x00000002")]
    public const int SDL_RLEACCEL = 0x00000002;

    [NativeTypeName("#define SDL_DONTFREE 0x00000004")]
    public const int SDL_DONTFREE = 0x00000004;

    [NativeTypeName("#define SDL_SIMD_ALIGNED 0x00000008")]
    public const int SDL_SIMD_ALIGNED = 0x00000008;

    [NativeTypeName("#define SDL_BlitSurface SDL_UpperBlit")]
    public static delegate*<SDL_Surface*, SDL_Rect*, SDL_Surface*, SDL_Rect*, int> SDL_BlitSurface => &UpperBlit;

    [NativeTypeName("#define SDL_BlitScaled SDL_UpperBlitScaled")]
    public static delegate*<SDL_Surface*, SDL_Rect*, SDL_Surface*, SDL_Rect*, int> SDL_BlitScaled => &UpperBlitScaled;
}
