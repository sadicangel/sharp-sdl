using System.Runtime.InteropServices;

namespace SharpSDL.Interop
{
    [Flags]
    public enum SurfaceFlags : uint
    {
        [NativeTypeName("#define SDL_SWSURFACE 0")]
        SWSURFACE = 0,
        [NativeTypeName("#define SDL_PREALLOC 0x00000001")]
        PREALLOC = 0x00000001,
        [NativeTypeName("#define SDL_RLEACCEL 0x00000002")]
        RLEACCEL = 0x00000002,
        [NativeTypeName("#define SDL_DONTFREE 0x00000004")]
        DONTFREE = 0x00000004,
        [NativeTypeName("#define SDL_SIMD_ALIGNED 0x00000008")]
        SIMD_ALIGNED = 0x00000008,
    }

    public partial struct BlitMap
    {
    }

    public unsafe partial struct Surface
    {
        public SurfaceFlags flags;

        public PixelFormat* format;

        public int w;

        public int h;

        public int pitch;

        public void* pixels;

        public void* userdata;

        public int locked;

        public void* list_blitmap;

        public Rect clip_rect;

        public BlitMap* map;

        public int refcount;
    }

    public enum YUV_CONVERSION_MODE
    {
        JPEG,
        BT601,
        BT709,
        AUTOMATIC,
    }

    public static unsafe partial class SDL
    {
        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateRGBSurface", ExactSpelling = true)]
        public static extern Surface* CreateRGBSurface(SurfaceFlags flags, int width, int height, int depth, uint Rmask, uint Gmask, uint Bmask, uint Amask);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateRGBSurfaceWithFormat", ExactSpelling = true)]
        public static extern Surface* CreateRGBSurfaceWithFormat(SurfaceFlags flags, int width, int height, int depth, uint format);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateRGBSurfaceFrom", ExactSpelling = true)]
        public static extern Surface* CreateRGBSurfaceFrom(void* pixels, int width, int height, int depth, int pitch, uint Rmask, uint Gmask, uint Bmask, uint Amask);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateRGBSurfaceWithFormatFrom", ExactSpelling = true)]
        public static extern Surface* CreateRGBSurfaceWithFormatFrom(void* pixels, int width, int height, int depth, int pitch, uint format);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FreeSurface", ExactSpelling = true)]
        public static extern void FreeSurface(Surface* surface);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetSurfacePalette", ExactSpelling = true)]
        public static extern int SetSurfacePalette(Surface* surface, Palette* palette);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LockSurface", ExactSpelling = true)]
        public static extern int LockSurface(Surface* surface);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UnlockSurface", ExactSpelling = true)]
        public static extern void UnlockSurface(Surface* surface);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LoadBMP_RW", ExactSpelling = true)]
        public static extern Surface* LoadBMP_RW(RWops* src, int freesrc);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SaveBMP_RW", ExactSpelling = true)]
        public static extern int SaveBMP_RW(Surface* surface, RWops* dst, int freedst);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetSurfaceRLE", ExactSpelling = true)]
        public static extern int SetSurfaceRLE(Surface* surface, int flag);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasSurfaceRLE", ExactSpelling = true)]
        public static extern CBool HasSurfaceRLE(Surface* surface);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetColorKey", ExactSpelling = true)]
        public static extern int SetColorKey(Surface* surface, int flag, uint key);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasColorKey", ExactSpelling = true)]
        public static extern CBool HasColorKey(Surface* surface);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetColorKey", ExactSpelling = true)]
        public static extern int GetColorKey(Surface* surface, [NativeTypeName(" *")] uint* key);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetSurfaceColorMod", ExactSpelling = true)]
        public static extern int SetSurfaceColorMod(Surface* surface, byte r, byte g, byte b);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetSurfaceColorMod", ExactSpelling = true)]
        public static extern int GetSurfaceColorMod(Surface* surface, [NativeTypeName(" *")] byte* r, [NativeTypeName(" *")] byte* g, [NativeTypeName(" *")] byte* b);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetSurfaceAlphaMod", ExactSpelling = true)]
        public static extern int SetSurfaceAlphaMod(Surface* surface, byte alpha);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetSurfaceAlphaMod", ExactSpelling = true)]
        public static extern int GetSurfaceAlphaMod(Surface* surface, [NativeTypeName(" *")] byte* alpha);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetSurfaceBlendMode", ExactSpelling = true)]
        public static extern int SetSurfaceBlendMode(Surface* surface, BlendMode blendMode);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetSurfaceBlendMode", ExactSpelling = true)]
        public static extern int GetSurfaceBlendMode(Surface* surface, BlendMode* blendMode);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetClipRect", ExactSpelling = true)]
        public static extern CBool SetClipRect(Surface* surface, [NativeTypeName("const Rect *")] Rect* rect);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetClipRect", ExactSpelling = true)]
        public static extern void GetClipRect(Surface* surface, Rect* rect);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_DuplicateSurface", ExactSpelling = true)]
        public static extern Surface* DuplicateSurface(Surface* surface);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ConvertSurface", ExactSpelling = true)]
        public static extern Surface* ConvertSurface(Surface* src, [NativeTypeName("const PixelFormat *")] PixelFormat* fmt, SurfaceFlags flags);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ConvertSurfaceFormat", ExactSpelling = true)]
        public static extern Surface* ConvertSurfaceFormat(Surface* src, uint pixel_format, SurfaceFlags flags);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ConvertPixels", ExactSpelling = true)]
        public static extern int ConvertPixels(int width, int height, uint src_format, [NativeTypeName("const void *")] void* src, int src_pitch, uint dst_format, void* dst, int dst_pitch);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_PremultiplyAlpha", ExactSpelling = true)]
        public static extern int PremultiplyAlpha(int width, int height, uint src_format, [NativeTypeName("const void *")] void* src, int src_pitch, uint dst_format, void* dst, int dst_pitch);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FillRect", ExactSpelling = true)]
        public static extern int FillRect(Surface* dst, [NativeTypeName("const Rect *")] Rect* rect, uint color);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FillRects", ExactSpelling = true)]
        public static extern int FillRects(Surface* dst, [NativeTypeName("const Rect *")] Rect* rects, int count, uint color);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpperBlit", ExactSpelling = true)]
        public static extern int UpperBlit(Surface* src, [NativeTypeName("const Rect *")] Rect* srcrect, Surface* dst, Rect* dstrect);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LowerBlit", ExactSpelling = true)]
        public static extern int LowerBlit(Surface* src, Rect* srcrect, Surface* dst, Rect* dstrect);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SoftStretch", ExactSpelling = true)]
        public static extern int SoftStretch(Surface* src, [NativeTypeName("const Rect *")] Rect* srcrect, Surface* dst, [NativeTypeName("const Rect *")] Rect* dstrect);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SoftStretchLinear", ExactSpelling = true)]
        public static extern int SoftStretchLinear(Surface* src, [NativeTypeName("const Rect *")] Rect* srcrect, Surface* dst, [NativeTypeName("const Rect *")] Rect* dstrect);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpperBlitScaled", ExactSpelling = true)]
        public static extern int UpperBlitScaled(Surface* src, [NativeTypeName("const Rect *")] Rect* srcrect, Surface* dst, Rect* dstrect);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LowerBlitScaled", ExactSpelling = true)]
        public static extern int LowerBlitScaled(Surface* src, Rect* srcrect, Surface* dst, Rect* dstrect);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetYUVConversionMode", ExactSpelling = true)]
        public static extern void SetYUVConversionMode(YUV_CONVERSION_MODE mode);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetYUVConversionMode", ExactSpelling = true)]
        public static extern YUV_CONVERSION_MODE GetYUVConversionMode();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetYUVConversionModeForResolution", ExactSpelling = true)]
        public static extern YUV_CONVERSION_MODE GetYUVConversionModeForResolution(int width, int height);

        [NativeTypeName("#define SDL_BlitSurface SDL_UpperBlit")]
        public static delegate*<Surface*, Rect*, Surface*, Rect*, int> SDL_BlitSurface => &UpperBlit;

        [NativeTypeName("#define SDL_BlitScaled SDL_UpperBlitScaled")]
        public static delegate*<Surface*, Rect*, Surface*, Rect*, int> SDL_BlitScaled => &UpperBlitScaled;
    }
}
