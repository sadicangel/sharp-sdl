using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpSDL;
internal static partial class SDL
{
    // 2.0.10 and above.

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial int SDL_RenderCopyF(
        /*SDL_Renderer*/ nint renderer,
        /*SDL_Texture*/ nint texture,
        SDL_Rect* srcrect,
        SDL_FRect* dstrect
    );

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial int SDL_RenderCopyEx(
        /*SDL_Renderer*/ nint renderer,
        /*SDL_Texture*/ nint texture,
        SDL_Rect* srcrect,
        SDL_FRect* dstrect,
        double angle,
        SDL_FPoint* center,
        SDL_RendererFlip flip
    );

    // 2.0.18 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial int SDL_RenderGeometry(
        /*SDL_Renderer*/ nint renderer,
        /*SDL_Texture*/ nint texture,
        SDL_Vertex* vertices,
        int num_vertices,
        int* indices,
        int num_indices
    );

    // 2.0.18 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial int SDL_RenderGeometryRaw(
        /*SDL_Renderer*/ nint renderer,
        /*SDL_Texture*/ nint texture,
        float* xy,
        int xy_stride,
        int* color,
        int color_stride,
        float* uv,
        int uv_stride,
        int num_vertices,
        nint indices,
        int num_indices,
        int size_indices
    );

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_RenderDrawPointF(/*SDL_Renderer*/ nint renderer, float x, float y);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial int SDL_RenderDrawPointsF(/*SDL_Renderer*/ nint renderer, SDL_FPoint* points, int count);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_RenderDrawLineF(/*SDL_Renderer*/ nint renderer, float x1, float y1, float x2, float y2);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial int SDL_RenderDrawLinesF(/*SDL_Renderer*/ nint renderer, SDL_FPoint* points, int count);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_RenderDrawRectF(/*SDL_Renderer*/ nint renderer, ref SDL_FRect rect);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial int SDL_RenderDrawRectF(/*SDL_Renderer*/ nint renderer, SDL_Rect* rect);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial int SDL_RenderDrawRectsF(/*SDL_Renderer*/ nint renderer, SDL_FRect* rects, int count);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_RenderFillRectF(/*SDL_Renderer*/ nint renderer, ref SDL_FRect rect);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial int SDL_RenderFillRectF(/*SDL_Renderer*/ nint renderer, SDL_Rect* rect);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial int SDL_RenderFillRectsF(/*SDL_Renderer*/ nint renderer, SDL_FRect* rects, int count);
}
