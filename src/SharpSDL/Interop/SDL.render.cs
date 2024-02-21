using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpSDL.Interop
{
    [Flags]
    public enum RendererFlags : uint
    {
        SOFTWARE = 0x00000001,
        ACCELERATED = 0x00000002,
        PRESENTVSYNC = 0x00000004,
        TARGETTEXTURE = 0x00000008,
    }

    public unsafe partial struct RendererInfo
    {
        [NativeTypeName("const char *")]
        public byte* name;

        public RendererFlags flags;

        public uint num_texture_formats;

        [NativeTypeName("[16]")]
        public _texture_formats_e__FixedBuffer texture_formats;

        public int max_texture_width;

        public int max_texture_height;

        [InlineArray(16)]
        public partial struct _texture_formats_e__FixedBuffer
        {
            public uint e0;
        }
    }

    public partial struct Vertex
    {
        public FPoint position;

        public Color color;

        public FPoint tex_coord;
    }

    public enum ScaleMode
    {
        Nearest,
        Linear,
        Best,
    }

    public enum TextureAccess
    {
        STATIC,
        STREAMING,
        TARGET,
    }

    public enum TextureModulate
    {
        NONE = 0x00000000,
        COLOR = 0x00000001,
        ALPHA = 0x00000002,
    }

    public enum RendererFlip
    {
        NONE = 0x00000000,
        HORIZONTAL = 0x00000001,
        VERTICAL = 0x00000002,
    }

    public partial struct Renderer
    {
    }

    public partial struct Texture
    {
    }

    public static unsafe partial class SDL
    {
        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetNumRenderDrivers", ExactSpelling = true)]
        public static extern int GetNumRenderDrivers();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRenderDriverInfo", ExactSpelling = true)]
        public static extern int GetRenderDriverInfo(int index, RendererInfo* info);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateWindowAndRenderer", ExactSpelling = true)]
        public static extern int CreateWindowAndRenderer(int width, int height, WindowFlags window_flags, Window** window, Renderer** renderer);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateRenderer", ExactSpelling = true)]
        public static extern Renderer* CreateRenderer(Window* window, int index, RendererFlags flags);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateSoftwareRenderer", ExactSpelling = true)]
        public static extern Renderer* CreateSoftwareRenderer(Surface* surface);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRenderer", ExactSpelling = true)]
        public static extern Renderer* GetRenderer(Window* window);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderGetWindow", ExactSpelling = true)]
        public static extern Window* RenderGetWindow(Renderer* renderer);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRendererInfo", ExactSpelling = true)]
        public static extern int GetRendererInfo(Renderer* renderer, RendererInfo* info);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRendererOutputSize", ExactSpelling = true)]
        public static extern int GetRendererOutputSize(Renderer* renderer, int* w, int* h);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateTexture", ExactSpelling = true)]
        public static extern Texture* CreateTexture(Renderer* renderer, uint format, int access, int w, int h);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateTextureFromSurface", ExactSpelling = true)]
        public static extern Texture* CreateTextureFromSurface(Renderer* renderer, Surface* surface);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_QueryTexture", ExactSpelling = true)]
        public static extern int QueryTexture(Texture* texture, [NativeTypeName(" *")] uint* format, int* access, int* w, int* h);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetTextureColorMod", ExactSpelling = true)]
        public static extern int SetTextureColorMod(Texture* texture, byte r, byte g, byte b);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetTextureColorMod", ExactSpelling = true)]
        public static extern int GetTextureColorMod(Texture* texture, [NativeTypeName(" *")] byte* r, [NativeTypeName(" *")] byte* g, [NativeTypeName(" *")] byte* b);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetTextureAlphaMod", ExactSpelling = true)]
        public static extern int SetTextureAlphaMod(Texture* texture, byte alpha);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetTextureAlphaMod", ExactSpelling = true)]
        public static extern int GetTextureAlphaMod(Texture* texture, [NativeTypeName(" *")] byte* alpha);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetTextureBlendMode", ExactSpelling = true)]
        public static extern int SetTextureBlendMode(Texture* texture, BlendMode blendMode);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetTextureBlendMode", ExactSpelling = true)]
        public static extern int GetTextureBlendMode(Texture* texture, BlendMode* blendMode);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetTextureScaleMode", ExactSpelling = true)]
        public static extern int SetTextureScaleMode(Texture* texture, ScaleMode scaleMode);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetTextureScaleMode", ExactSpelling = true)]
        public static extern int GetTextureScaleMode(Texture* texture, ScaleMode* scaleMode);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetTextureUserData", ExactSpelling = true)]
        public static extern int SetTextureUserData(Texture* texture, void* userdata);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetTextureUserData", ExactSpelling = true)]
        public static extern void* GetTextureUserData(Texture* texture);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpdateTexture", ExactSpelling = true)]
        public static extern int UpdateTexture(Texture* texture, [NativeTypeName("const Rect *")] Rect* rect, [NativeTypeName("const void *")] void* pixels, int pitch);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpdateYUVTexture", ExactSpelling = true)]
        public static extern int UpdateYUVTexture(Texture* texture, [NativeTypeName("const Rect *")] Rect* rect, [NativeTypeName("const  *")] byte* Yplane, int Ypitch, [NativeTypeName("const  *")] byte* Uplane, int Upitch, [NativeTypeName("const  *")] byte* Vplane, int Vpitch);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpdateNVTexture", ExactSpelling = true)]
        public static extern int UpdateNVTexture(Texture* texture, [NativeTypeName("const Rect *")] Rect* rect, [NativeTypeName("const  *")] byte* Yplane, int Ypitch, [NativeTypeName("const  *")] byte* UVplane, int UVpitch);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LockTexture", ExactSpelling = true)]
        public static extern int LockTexture(Texture* texture, [NativeTypeName("const Rect *")] Rect* rect, void** pixels, int* pitch);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LockTextureToSurface", ExactSpelling = true)]
        public static extern int LockTextureToSurface(Texture* texture, [NativeTypeName("const Rect *")] Rect* rect, Surface** surface);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UnlockTexture", ExactSpelling = true)]
        public static extern void UnlockTexture(Texture* texture);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderTargetSupported", ExactSpelling = true)]
        public static extern CBool RenderTargetSupported(Renderer* renderer);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetRenderTarget", ExactSpelling = true)]
        public static extern int SetRenderTarget(Renderer* renderer, Texture* texture);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRenderTarget", ExactSpelling = true)]
        public static extern Texture* GetRenderTarget(Renderer* renderer);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderSetLogicalSize", ExactSpelling = true)]
        public static extern int RenderSetLogicalSize(Renderer* renderer, int w, int h);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderGetLogicalSize", ExactSpelling = true)]
        public static extern void RenderGetLogicalSize(Renderer* renderer, int* w, int* h);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderSetIntegerScale", ExactSpelling = true)]
        public static extern int RenderSetIntegerScale(Renderer* renderer, CBool enable);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderGetIntegerScale", ExactSpelling = true)]
        public static extern CBool RenderGetIntegerScale(Renderer* renderer);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderSetViewport", ExactSpelling = true)]
        public static extern int RenderSetViewport(Renderer* renderer, [NativeTypeName("const Rect *")] Rect* rect);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderGetViewport", ExactSpelling = true)]
        public static extern void RenderGetViewport(Renderer* renderer, Rect* rect);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderSetClipRect", ExactSpelling = true)]
        public static extern int RenderSetClipRect(Renderer* renderer, [NativeTypeName("const Rect *")] Rect* rect);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderGetClipRect", ExactSpelling = true)]
        public static extern void RenderGetClipRect(Renderer* renderer, Rect* rect);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderIsClipEnabled", ExactSpelling = true)]
        public static extern CBool RenderIsClipEnabled(Renderer* renderer);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderSetScale", ExactSpelling = true)]
        public static extern int RenderSetScale(Renderer* renderer, float scaleX, float scaleY);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderGetScale", ExactSpelling = true)]
        public static extern void RenderGetScale(Renderer* renderer, float* scaleX, float* scaleY);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderWindowToLogical", ExactSpelling = true)]
        public static extern void RenderWindowToLogical(Renderer* renderer, int windowX, int windowY, float* logicalX, float* logicalY);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderLogicalToWindow", ExactSpelling = true)]
        public static extern void RenderLogicalToWindow(Renderer* renderer, float logicalX, float logicalY, int* windowX, int* windowY);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetRenderDrawColor", ExactSpelling = true)]
        public static extern int SetRenderDrawColor(Renderer* renderer, byte r, byte g, byte b, byte a);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRenderDrawColor", ExactSpelling = true)]
        public static extern int GetRenderDrawColor(Renderer* renderer, [NativeTypeName(" *")] byte* r, [NativeTypeName(" *")] byte* g, [NativeTypeName(" *")] byte* b, [NativeTypeName(" *")] byte* a);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetRenderDrawBlendMode", ExactSpelling = true)]
        public static extern int SetRenderDrawBlendMode(Renderer* renderer, BlendMode blendMode);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRenderDrawBlendMode", ExactSpelling = true)]
        public static extern int GetRenderDrawBlendMode(Renderer* renderer, BlendMode* blendMode);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderClear", ExactSpelling = true)]
        public static extern int RenderClear(Renderer* renderer);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawPoint", ExactSpelling = true)]
        public static extern int RenderDrawPoint(Renderer* renderer, int x, int y);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawPoints", ExactSpelling = true)]
        public static extern int RenderDrawPoints(Renderer* renderer, [NativeTypeName("const Point *")] Point* points, int count);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawLine", ExactSpelling = true)]
        public static extern int RenderDrawLine(Renderer* renderer, int x1, int y1, int x2, int y2);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawLines", ExactSpelling = true)]
        public static extern int RenderDrawLines(Renderer* renderer, [NativeTypeName("const Point *")] Point* points, int count);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawRect", ExactSpelling = true)]
        public static extern int RenderDrawRect(Renderer* renderer, [NativeTypeName("const Rect *")] Rect* rect);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawRects", ExactSpelling = true)]
        public static extern int RenderDrawRects(Renderer* renderer, [NativeTypeName("const Rect *")] Rect* rects, int count);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderFillRect", ExactSpelling = true)]
        public static extern int RenderFillRect(Renderer* renderer, [NativeTypeName("const Rect *")] Rect* rect);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderFillRects", ExactSpelling = true)]
        public static extern int RenderFillRects(Renderer* renderer, [NativeTypeName("const Rect *")] Rect* rects, int count);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderCopy", ExactSpelling = true)]
        public static extern int RenderCopy(Renderer* renderer, Texture* texture, [NativeTypeName("const Rect *")] Rect* srcrect, [NativeTypeName("const Rect *")] Rect* dstrect);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderCopyEx", ExactSpelling = true)]
        public static extern int RenderCopyEx(Renderer* renderer, Texture* texture, [NativeTypeName("const Rect *")] Rect* srcrect, [NativeTypeName("const Rect *")] Rect* dstrect, [NativeTypeName("const double")] double angle, [NativeTypeName("const Point *")] Point* center, [NativeTypeName("const RendererFlip")] RendererFlip flip);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawPointF", ExactSpelling = true)]
        public static extern int RenderDrawPointF(Renderer* renderer, float x, float y);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawPointsF", ExactSpelling = true)]
        public static extern int RenderDrawPointsF(Renderer* renderer, [NativeTypeName("const FPoint *")] FPoint* points, int count);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawLineF", ExactSpelling = true)]
        public static extern int RenderDrawLineF(Renderer* renderer, float x1, float y1, float x2, float y2);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawLinesF", ExactSpelling = true)]
        public static extern int RenderDrawLinesF(Renderer* renderer, [NativeTypeName("const FPoint *")] FPoint* points, int count);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawRectF", ExactSpelling = true)]
        public static extern int RenderDrawRectF(Renderer* renderer, [NativeTypeName("const FRect *")] FRect* rect);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawRectsF", ExactSpelling = true)]
        public static extern int RenderDrawRectsF(Renderer* renderer, [NativeTypeName("const FRect *")] FRect* rects, int count);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderFillRectF", ExactSpelling = true)]
        public static extern int RenderFillRectF(Renderer* renderer, [NativeTypeName("const FRect *")] FRect* rect);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderFillRectsF", ExactSpelling = true)]
        public static extern int RenderFillRectsF(Renderer* renderer, [NativeTypeName("const FRect *")] FRect* rects, int count);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderCopyF", ExactSpelling = true)]
        public static extern int RenderCopyF(Renderer* renderer, Texture* texture, [NativeTypeName("const Rect *")] Rect* srcrect, [NativeTypeName("const FRect *")] FRect* dstrect);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderCopyExF", ExactSpelling = true)]
        public static extern int RenderCopyExF(Renderer* renderer, Texture* texture, [NativeTypeName("const Rect *")] Rect* srcrect, [NativeTypeName("const FRect *")] FRect* dstrect, [NativeTypeName("const double")] double angle, [NativeTypeName("const FPoint *")] FPoint* center, [NativeTypeName("const RendererFlip")] RendererFlip flip);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderGeometry", ExactSpelling = true)]
        public static extern int RenderGeometry(Renderer* renderer, Texture* texture, [NativeTypeName("const Vertex *")] Vertex* vertices, int num_vertices, [NativeTypeName("const int *")] int* indices, int num_indices);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderGeometryRaw", ExactSpelling = true)]
        public static extern int RenderGeometryRaw(Renderer* renderer, Texture* texture, [NativeTypeName("const float *")] float* xy, int xy_stride, [NativeTypeName("const Color *")] Color* color, int color_stride, [NativeTypeName("const float *")] float* uv, int uv_stride, int num_vertices, [NativeTypeName("const void *")] void* indices, int num_indices, int size_indices);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderReadPixels", ExactSpelling = true)]
        public static extern int RenderReadPixels(Renderer* renderer, [NativeTypeName("const Rect *")] Rect* rect, uint format, void* pixels, int pitch);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderPresent", ExactSpelling = true)]
        public static extern void RenderPresent(Renderer* renderer);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_DestroyTexture", ExactSpelling = true)]
        public static extern void DestroyTexture(Texture* texture);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_DestroyRenderer", ExactSpelling = true)]
        public static extern void DestroyRenderer(Renderer* renderer);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderFlush", ExactSpelling = true)]
        public static extern int RenderFlush(Renderer* renderer);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_BindTexture", ExactSpelling = true)]
        public static extern int GL_BindTexture(Texture* texture, float* texw, float* texh);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_UnbindTexture", ExactSpelling = true)]
        public static extern int GL_UnbindTexture(Texture* texture);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderGetMetalLayer", ExactSpelling = true)]
        public static extern void* RenderGetMetalLayer(Renderer* renderer);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderGetMetalCommandEncoder", ExactSpelling = true)]
        public static extern void* RenderGetMetalCommandEncoder(Renderer* renderer);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderSetVSync", ExactSpelling = true)]
        public static extern int RenderSetVSync(Renderer* renderer, int vsync);
    }
}
