using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpSDL;
internal static partial class SDL
{
    [Flags]
    public enum SDL_RendererFlags : uint
    {
        SDL_RENDERER_SOFTWARE = 0x00000001,
        SDL_RENDERER_ACCELERATED = 0x00000002,
        SDL_RENDERER_PRESENTVSYNC = 0x00000004,
        SDL_RENDERER_TARGETTEXTURE = 0x00000008
    }

    [Flags]
    public enum SDL_RendererFlip
    {
        SDL_FLIP_NONE = 0x00000000,
        SDL_FLIP_HORIZONTAL = 0x00000001,
        SDL_FLIP_VERTICAL = 0x00000002
    }

    public enum SDL_TextureAccess
    {
        SDL_TEXTUREACCESS_STATIC,
        SDL_TEXTUREACCESS_STREAMING,
        SDL_TEXTUREACCESS_TARGET
    }

    [Flags]
    public enum SDL_TextureModulate
    {
        SDL_TEXTUREMODULATE_NONE = 0x00000000,
        SDL_TEXTUREMODULATE_HORIZONTAL = 0x00000001,
        SDL_TEXTUREMODULATE_VERTICAL = 0x00000002
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct SDL_RendererInfo
    {
        public nint name; // const char*
        public uint flags;
        public uint num_texture_formats;
        public fixed uint texture_formats[16];
        public int max_texture_width;
        public int max_texture_height;
    }

    /* Only available in 2.0.11 or higher. */
    public enum SDL_ScaleMode
    {
        SDL_ScaleModeNearest,
        SDL_ScaleModeLinear,
        SDL_ScaleModeBest
    }

    /* Only available in 2.0.18 or higher. */
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_Vertex
    {
        public SDL_FPoint position;
        public SDL_Color color;
        public SDL_FPoint tex_coord;
    }

    /* IntPtr refers to an SDL_Renderer*, window to an SDL_Window* */
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial /*SDL_Renderer*/ nint SDL_CreateRenderer(/*SDL_Window*/ nint window, int index, SDL_RendererFlags flags);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial /*SDL_Renderer*/ nint SDL_CreateSoftwareRenderer(/*SDL_Surface*/ nint surface);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial /*SDL_Texture*/ nint SDL_CreateTexture(/*SDL_Renderer*/ nint renderer, uint format, int access, int w, int h);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial nint SDL_CreateTextureFromSurface(/*SDL_Renderer*/ nint renderer, /*SDL_Surface*/ nint surface);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_DestroyRenderer(/*SDL_Renderer*/ nint renderer);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_DestroyTexture(/*SDL_Texture*/ nint texture);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_GetNumRenderDrivers();

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_GetRenderDrawBlendMode(/*SDL_Renderer*/ nint renderer, out SDL_BlendMode blendMode);

    // 2.0.11 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_SetTextureScaleMode(/*SDL_Texture*/ nint texture, SDL_ScaleMode scaleMode);

    // 2.0.11 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_GetTextureScaleMode(/*SDL_Texture*/ nint texture, out SDL_ScaleMode scaleMode);

    // 2.0.18 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_SetTextureUserData(/*SDL_Texture*/ nint texture, nint userdata);

    // 2.0.18 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial nint SDL_GetTextureUserData(/*SDL_Texture*/ nint texture);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_GetRenderDrawColor(/*SDL_Renderer*/ nint renderer, out byte r, out byte g, out byte b, out byte a);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_GetRenderDriverInfo(int index, out SDL_RendererInfo info);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial /*SDL_Renderer*/ nint SDL_GetRenderer(/*SDL_Window*/ nint window);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_GetRendererInfo(/*SDL_Renderer*/ nint renderer, out SDL_RendererInfo info);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_GetRendererOutputSize(/*SDL_Renderer*/ nint renderer, out int w, out int h);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_GetTextureAlphaMod(/*SDL_Texture*/ nint texture, out byte alpha);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_GetTextureBlendMode(/*SDL_Texture*/ nint texture, out SDL_BlendMode blendMode);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_GetTextureColorMod(/*SDL_Texture*/ nint texture, out byte r, out byte g, out byte b);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial int SDL_LockTexture(/*SDL_Texture*/ nint texture, SDL_Rect* rect, out nint pixels, out int pitch);

    // 2.0.11 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial int SDL_LockTextureToSurface(/*SDL_Texture*/ nint texture, SDL_Rect* rect, out nint surface);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_QueryTexture(/*SDL_Texture*/ nint texture, out uint format, out int access, out int w, out int h);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_RenderClear(/*SDL_Renderer*/ nint renderer);

    /* renderer refers to an SDL_Renderer*, texture to an SDL_Texture* */
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial int SDL_RenderCopy(
        /*SDL_Renderer*/ nint renderer,
        /*SDL_Texture*/ nint texture,
        SDL_Rect* srcrect,
        SDL_Rect* dstrect
    );

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial int SDL_RenderCopyEx(
        /*SDL_Renderer*/ nint renderer,
        /*SDL_Texture*/ nint texture,
        SDL_Rect* srcrect,
        SDL_Rect* dstrect,
        double angle,
        SDL_Point* center,
        SDL_RendererFlip flip
    );

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_RenderDrawLine(/*SDL_Renderer*/ nint renderer, int x1, int y1, int x2, int y2);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial int SDL_RenderDrawLines(/*SDL_Renderer*/ nint renderer, SDL_Point* points, int count);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_RenderDrawPoint(/*SDL_Renderer*/ nint renderer, int x, int y);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial int SDL_RenderDrawPoints(/*SDL_Renderer*/ nint renderer, SDL_Point* points, int count);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial int SDL_RenderDrawRect(/*SDL_Renderer*/ nint renderer, SDL_Rect* rect);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial int SDL_RenderDrawRects(/*SDL_Renderer*/ nint renderer, SDL_Rect* rects, int count);

    /* renderer refers to an SDL_Renderer*, rect to an SDL_Rect*.
		 * This overload allows for IntPtr.Zero (null) to be passed for rect.
		 */
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial int SDL_RenderFillRect(/*SDL_Renderer*/ nint renderer, SDL_Rect* rect);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial int SDL_RenderFillRects(/*SDL_Renderer*/ nint renderer, SDL_Rect* rects, int count);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_RenderGetClipRect(/*SDL_Renderer*/ nint renderer, out SDL_Rect rect);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_RenderGetLogicalSize(/*SDL_Renderer*/ nint renderer, out int w, out int h);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_RenderGetScale(/*SDL_Renderer*/ nint renderer, out float scaleX, out float scaleY);

    // 2.0.18 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_RenderWindowToLogical(
        /*SDL_Renderer*/ nint renderer,
        int windowX,
        int windowY,
        out float logicalX,
        out float logicalY
    );

    // 2.0.18 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_RenderLogicalToWindow(
        /*SDL_Renderer*/ nint renderer,
        float logicalX,
        float logicalY,
        out int windowX,
        out int windowY
        );

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_RenderGetViewport(/*SDL_Renderer*/ nint renderer, out SDL_Rect rect);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_RenderPresent(/*SDL_Renderer*/ nint renderer);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_RenderReadPixels(/*SDL_Renderer*/ nint renderer, ref SDL_Rect rect, uint format, nint pixels, int pitch);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial int SDL_RenderSetClipRect(/*SDL_Renderer*/ nint renderer, SDL_Rect* rect);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_RenderSetLogicalSize(/*SDL_Renderer*/ nint renderer, int w, int h);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_RenderSetScale(/*SDL_Renderer*/ nint renderer, float scaleX, float scaleY);

    // 2.0.5 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_RenderSetIntegerScale(/*SDL_Renderer*/ nint renderer, SDL_bool enable);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_RenderSetViewport(/*SDL_Renderer*/ nint renderer, ref SDL_Rect rect);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_SetRenderDrawBlendMode(/*SDL_Renderer*/ nint renderer, SDL_BlendMode blendMode);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_SetRenderDrawColor(/*SDL_Renderer*/ nint renderer, byte r, byte g, byte b, byte a);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_SetRenderTarget(/*SDL_Renderer*/ nint renderer, /*SDL_Texture*/ nint texture);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_SetTextureAlphaMod(/*SDL_Texture*/ nint texture, byte alpha);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_SetTextureBlendMode(/*SDL_Texture*/ nint texture, SDL_BlendMode blendMode);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_SetTextureColorMod(/*SDL_Texture*/ nint texture, byte r, byte g, byte b);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_UnlockTexture(/*SDL_Texture*/ nint texture);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial int SDL_UpdateTexture(/*SDL_Texture*/ nint texture, SDL_Rect* rect, nint pixels, int pitch);

    // 2.0.1 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_UpdateYUVTexture(
        /*SDL_Texture*/ nint texture,
        ref SDL_Rect rect,
        uint yPlane,
        int yPitch,
        nint uPlane,
        int uPitch,
        nint vPlane,
        int vPitch
    );

    // 2.0.16 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial int SDL_UpdateNVTexture(
        /*SDL_Texture*/ nint texture,
        ref SDL_Rect rect,
        uint* yPlane,
        int yPitch,
        uint* uvPlane,
        int uvPitch
    );

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SDL_bool SDL_RenderTargetSupported(/*SDL_Renderer*/ nint renderer);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial /*SDL_Texture*/ nint SDL_GetRenderTarget(/*SDL_Renderer*/ nint renderer);

    // 2.0.8 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial nint SDL_RenderGetMetalLayer(/*SDL_Renderer*/ nint renderer);

    // 2.0.8 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial nint SDL_RenderGetMetalCommandEncoder(/*SDL_Renderer*/ nint renderer);

    // 2.0.18 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_RenderSetVSync(/*SDL_Renderer*/ nint renderer, int vsync);

    // 2.0.4 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SDL_bool SDL_RenderIsClipEnabled(/*SDL_Renderer*/ nint renderer);

    // 2.0.10 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_RenderFlush(/*SDL_Renderer*/ nint renderer);
}
