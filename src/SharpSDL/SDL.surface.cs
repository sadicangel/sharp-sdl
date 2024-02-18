using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpSDL;
internal static partial class SDL
{
    public const uint SDL_SWSURFACE = 0x00000000;
    public const uint SDL_PREALLOC = 0x00000001;
    public const uint SDL_RLEACCEL = 0x00000002;
    public const uint SDL_DONTFREE = 0x00000004;

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_Surface
    {
        public uint flags;
        public nint format; // SDL_PixelFormat*
        public int w;
        public int h;
        public int pitch;
        public nint pixels; // void*
        public nint userdata; // void*
        public int locked;
        public nint list_blitmap; // void*
        public SDL_Rect clip_rect;
        public nint map; // SDL_BlitMap*
        public int refcount;
    }

    public static unsafe bool SDL_MUSTLOCK(/*SDL_Surface*/ nint surface)
    {
        var ptr = (SDL_Surface*)surface;
        return (ptr->flags & SDL_RLEACCEL) != 0;
    }

    [LibraryImport(DllName, EntryPoint = "SDL_UpperBlit")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial int SDL_BlitSurface(
        /*SDL_Surface*/ nint src,
        SDL_Rect* srcrect,
        /*SDL_Surface*/ nint dst,
        SDL_Rect* dstrect
    );

    [LibraryImport(DllName, EntryPoint = "SDL_UpperBlitScaled")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial int SDL_BlitScaled(/*SDL_Surface*/ nint src, SDL_Rect* srcrect, /*SDL_Surface*/ nint dst, SDL_Rect* dstrect);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_ConvertPixels(
        int width,
        int height,
        uint src_format,
        nint src,
        int src_pitch,
        uint dst_format,
        nint dst,
        int dst_pitch
    );

    // 2.0.18 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_PremultiplyAlpha(
        int width,
        int height,
        uint src_format,
        nint src,
        int src_pitch,
        uint dst_format,
        nint dst,
        int dst_pitch
    );

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial /*SDL_Surface*/ nint SDL_ConvertSurface(/*SDL_Surface*/ nint src, /*SDL_PixelFormat*/ nint fmt, uint flags);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial /*SDL_Surface*/ nint SDL_ConvertSurfaceFormat(/*SDL_Surface*/ nint src, uint pixel_format, uint flags);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial /*SDL_Surface*/ nint SDL_CreateRGBSurface(
        uint flags,
        int width,
        int height,
        int depth,
        uint Rmask,
        uint Gmask,
        uint Bmask,
        uint Amask
    );

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial /*SDL_Surface*/ nint SDL_CreateRGBSurfaceFrom(
        nint pixels,
        int width,
        int height,
        int depth,
        int pitch,
        uint Rmask,
        uint Gmask,
        uint Bmask,
        uint Amask
    );

    // 2.0.5 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial /*SDL_Surface*/ nint SDL_CreateRGBSurfaceWithFormat(
        uint flags,
        int width,
        int height,
        int depth,
        uint format
    );

    // 2.0.5 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial /*SDL_Surface*/ nint SDL_CreateRGBSurfaceWithFormatFrom(
        nint pixels,
        int width,
        int height,
        int depth,
        int pitch,
        uint format
    );

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial int SDL_FillRect(/*SDL_Surface*/ nint dst, SDL_Rect* rect, uint color);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial int SDL_FillRects(/*SDL_Surface*/ nint dst, SDL_Rect* rects, int count, uint color);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_FreeSurface(/*SDL_Surface*/ nint surface);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_GetClipRect(/*SDL_Surface*/ nint surface, out SDL_Rect rect);

    // 2.0.9 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SDL_bool SDL_HasColorKey(nint surface);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_GetColorKey(/*SDL_Surface*/ nint surface, out uint key);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_GetSurfaceAlphaMod(/*SDL_Surface*/ nint surface, out byte alpha);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_GetSurfaceBlendMode(/*SDL_Surface*/ nint surface, out SDL_BlendMode blendMode);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_GetSurfaceColorMod(/*SDL_Surface*/ nint surface, out byte r, out byte g, out byte b);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial /*SDL_Surface*/ nint SDL_LoadBMP_RW(byte* src, int freesrc);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_LockSurface(/*SDL_Surface*/ nint surface);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_LowerBlit(/*SDL_Surface*/ nint src, ref SDL_Rect srcrect, /*SDL_Surface*/ nint dst, ref SDL_Rect dstrect);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_LowerBlitScaled(/*SDL_Surface*/ nint src, ref SDL_Rect srcrect, /*SDL_Surface*/ nint dst, ref SDL_Rect dstrect);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial int SDL_SaveBMP_RW(/*SDL_Surface*/ nint surface, byte* src, int freesrc);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SDL_bool SDL_SetClipRect(/*SDL_Surface*/ nint surface, ref SDL_Rect rect);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_SetColorKey(/*SDL_Surface*/ nint surface, int flag, uint key);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_SetSurfaceAlphaMod(/*SDL_Surface*/ nint surface, byte alpha);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_SetSurfaceBlendMode(/*SDL_Surface*/ nint surface, SDL_BlendMode blendMode);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_SetSurfaceColorMod(/*SDL_Surface*/ nint surface, byte r, byte g, byte b);

    /* surface refers to an SDL_Surface*, palette to an SDL_Palette* */
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_SetSurfacePalette(/*SDL_Surface*/ nint surface, /*SDL_Palette*/ nint palette);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_SetSurfaceRLE(/*SDL_Surface*/ nint surface, int flag);

    // 2.0.14 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SDL_bool SDL_HasSurfaceRLE(/*SDL_Surface*/ nint surface);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_SoftStretch(/*SDL_Surface*/ nint src, ref SDL_Rect srcrect, /*SDL_Surface*/ nint dst, ref SDL_Rect dstrect);

    // 2.0.16 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_SoftStretchLinear(/*SDL_Surface*/ nint src, ref SDL_Rect srcrect, /*SDL_Surface*/ nint dst, ref SDL_Rect dstrect);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_UnlockSurface(/*SDL_Surface*/ nint surface);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_UpperBlit(/*SDL_Surface*/ nint src, ref SDL_Rect srcrect, /*SDL_Surface*/ nint dst, ref SDL_Rect dstrect);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_UpperBlitScaled(/*SDL_Surface*/ nint src, ref SDL_Rect srcrect, /*SDL_Surface*/ nint dst, ref SDL_Rect dstrect);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial /*SDL_Surface*/ nint SDL_DuplicateSurface(/*SDL_Surface*/ nint surface);
}
