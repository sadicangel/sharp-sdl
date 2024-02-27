namespace SharpSDL.Interop;

internal enum SDL_RendererFlags
{
    SDL_RENDERER_SOFTWARE = 0x00000001,
    SDL_RENDERER_ACCELERATED = 0x00000002,
    SDL_RENDERER_PRESENTVSYNC = 0x00000004,
    SDL_RENDERER_TARGETTEXTURE = 0x00000008,
}

internal unsafe partial struct SDL_RendererInfo
{
    [NativeTypeName("const char *")]
    public byte* name;

    public uint flags;

    public uint num_texture_formats;

    [NativeTypeName("[16]")]
    public _texture_formats_e__FixedBuffer texture_formats;

    public int max_texture_width;

    public int max_texture_height;

    [InlineArray(16)]
    internal partial struct _texture_formats_e__FixedBuffer
    {
        public uint e0;
    }
}

internal partial struct SDL_Vertex
{
    public SDL_FPoint position;

    public SDL_Color color;

    public SDL_FPoint tex_coord;
}

internal enum SDL_ScaleMode
{
    SDL_ScaleModeNearest,
    SDL_ScaleModeLinear,
    SDL_ScaleModeBest,
}

internal enum SDL_TextureAccess
{
    SDL_TEXTUREACCESS_STATIC,
    SDL_TEXTUREACCESS_STREAMING,
    SDL_TEXTUREACCESS_TARGET,
}

internal enum SDL_TextureModulate
{
    SDL_TEXTUREMODULATE_NONE = 0x00000000,
    SDL_TEXTUREMODULATE_COLOR = 0x00000001,
    SDL_TEXTUREMODULATE_ALPHA = 0x00000002,
}

internal enum SDL_RendererFlip
{
    SDL_FLIP_NONE = 0x00000000,
    SDL_FLIP_HORIZONTAL = 0x00000001,
    SDL_FLIP_VERTICAL = 0x00000002,
}

internal static unsafe partial class SDL
{
    [LibraryImport("SDL2", EntryPoint = "SDL_GetNumRenderDrivers")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetNumRenderDrivers();

    [LibraryImport("SDL2", EntryPoint = "SDL_GetRenderDriverInfo")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetRenderDriverInfo(int index, SDL_RendererInfo* info);

    [LibraryImport("SDL2", EntryPoint = "SDL_CreateWindowAndRenderer")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int CreateWindowAndRenderer(int width, int height, uint window_flags, [NativeTypeName("SDL_Window **")] nint* window, [NativeTypeName("SDL_Renderer **")] nint* renderer);

    [LibraryImport("SDL2", EntryPoint = "SDL_CreateRenderer")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_Renderer*")]
    public static partial nint CreateRenderer([NativeTypeName("SDL_Window*")] nint window, int index, uint flags);

    [LibraryImport("SDL2", EntryPoint = "SDL_CreateSoftwareRenderer")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_Renderer*")]
    public static partial nint CreateSoftwareRenderer(SDL_Surface* surface);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetRenderer")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_Renderer*")]
    public static partial nint GetRenderer([NativeTypeName("SDL_Window*")] nint window);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderGetWindow")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_Window*")]
    public static partial nint RenderGetWindow([NativeTypeName("SDL_Renderer*")] nint renderer);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetRendererInfo")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetRendererInfo([NativeTypeName("SDL_Renderer*")] nint renderer, SDL_RendererInfo* info);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetRendererOutputSize")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetRendererOutputSize([NativeTypeName("SDL_Renderer*")] nint renderer, int* w, int* h);

    [LibraryImport("SDL2", EntryPoint = "SDL_CreateTexture")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_Texture*")]
    public static partial nint CreateTexture([NativeTypeName("SDL_Renderer*")] nint renderer, uint format, int access, int w, int h);

    [LibraryImport("SDL2", EntryPoint = "SDL_CreateTextureFromSurface")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_Texture*")]
    public static partial nint CreateTextureFromSurface([NativeTypeName("SDL_Renderer*")] nint renderer, SDL_Surface* surface);

    [LibraryImport("SDL2", EntryPoint = "SDL_QueryTexture")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int QueryTexture([NativeTypeName("SDL_Texture*")] nint texture, [NativeTypeName(" *")] uint* format, int* access, int* w, int* h);

    [LibraryImport("SDL2", EntryPoint = "SDL_SetTextureColorMod")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SetTextureColorMod([NativeTypeName("SDL_Texture*")] nint texture, byte r, byte g, byte b);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetTextureColorMod")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetTextureColorMod([NativeTypeName("SDL_Texture*")] nint texture, [NativeTypeName(" *")] byte* r, [NativeTypeName(" *")] byte* g, [NativeTypeName(" *")] byte* b);

    [LibraryImport("SDL2", EntryPoint = "SDL_SetTextureAlphaMod")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SetTextureAlphaMod([NativeTypeName("SDL_Texture*")] nint texture, byte alpha);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetTextureAlphaMod")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetTextureAlphaMod([NativeTypeName("SDL_Texture*")] nint texture, [NativeTypeName(" *")] byte* alpha);

    [LibraryImport("SDL2", EntryPoint = "SDL_SetTextureBlendMode")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SetTextureBlendMode([NativeTypeName("SDL_Texture*")] nint texture, SDL_BlendMode blendMode);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetTextureBlendMode")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetTextureBlendMode([NativeTypeName("SDL_Texture*")] nint texture, SDL_BlendMode* blendMode);

    [LibraryImport("SDL2", EntryPoint = "SDL_SetTextureScaleMode")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SetTextureScaleMode([NativeTypeName("SDL_Texture*")] nint texture, SDL_ScaleMode scaleMode);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetTextureScaleMode")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetTextureScaleMode([NativeTypeName("SDL_Texture*")] nint texture, SDL_ScaleMode* scaleMode);

    [LibraryImport("SDL2", EntryPoint = "SDL_SetTextureUserData")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SetTextureUserData([NativeTypeName("SDL_Texture*")] nint texture, void* userdata);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetTextureUserData")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void* GetTextureUserData([NativeTypeName("SDL_Texture*")] nint texture);

    [LibraryImport("SDL2", EntryPoint = "SDL_UpdateTexture")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int UpdateTexture([NativeTypeName("SDL_Texture*")] nint texture, [NativeTypeName("const SDL_Rect *")] SDL_Rect* rect, [NativeTypeName("const void *")] void* pixels, int pitch);

    [LibraryImport("SDL2", EntryPoint = "SDL_UpdateYUVTexture")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int UpdateYUVTexture([NativeTypeName("SDL_Texture*")] nint texture, [NativeTypeName("const SDL_Rect *")] SDL_Rect* rect, [NativeTypeName(" *")] byte* Yplane, int Ypitch, [NativeTypeName(" *")] byte* Uplane, int Upitch, [NativeTypeName(" *")] byte* Vplane, int Vpitch);

    [LibraryImport("SDL2", EntryPoint = "SDL_UpdateNVTexture")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int UpdateNVTexture([NativeTypeName("SDL_Texture*")] nint texture, [NativeTypeName("const SDL_Rect *")] SDL_Rect* rect, [NativeTypeName(" *")] byte* Yplane, int Ypitch, [NativeTypeName(" *")] byte* UVplane, int UVpitch);

    [LibraryImport("SDL2", EntryPoint = "SDL_LockTexture")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int LockTexture([NativeTypeName("SDL_Texture*")] nint texture, [NativeTypeName("const SDL_Rect *")] SDL_Rect* rect, void** pixels, int* pitch);

    [LibraryImport("SDL2", EntryPoint = "SDL_LockTextureToSurface")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int LockTextureToSurface([NativeTypeName("SDL_Texture*")] nint texture, [NativeTypeName("const SDL_Rect *")] SDL_Rect* rect, SDL_Surface** surface);

    [LibraryImport("SDL2", EntryPoint = "SDL_UnlockTexture")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void UnlockTexture([NativeTypeName("SDL_Texture*")] nint texture);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderTargetSupported")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool RenderTargetSupported([NativeTypeName("SDL_Renderer*")] nint renderer);

    [LibraryImport("SDL2", EntryPoint = "SDL_SetRenderTarget")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SetRenderTarget([NativeTypeName("SDL_Renderer*")] nint renderer, [NativeTypeName("SDL_Texture*")] nint texture);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetRenderTarget")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_Texture*")]
    public static partial nint GetRenderTarget([NativeTypeName("SDL_Renderer*")] nint renderer);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderSetLogicalSize")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int RenderSetLogicalSize([NativeTypeName("SDL_Renderer*")] nint renderer, int w, int h);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderGetLogicalSize")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void RenderGetLogicalSize([NativeTypeName("SDL_Renderer*")] nint renderer, int* w, int* h);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderSetIntegerScale")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int RenderSetIntegerScale([NativeTypeName("SDL_Renderer*")] nint renderer, [NativeTypeName("SDL_bool")] CBool enable);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderGetIntegerScale")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool RenderGetIntegerScale([NativeTypeName("SDL_Renderer*")] nint renderer);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderSetViewport")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int RenderSetViewport([NativeTypeName("SDL_Renderer*")] nint renderer, [NativeTypeName("const SDL_Rect *")] SDL_Rect* rect);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderGetViewport")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void RenderGetViewport([NativeTypeName("SDL_Renderer*")] nint renderer, SDL_Rect* rect);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderSetClipRect")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int RenderSetClipRect([NativeTypeName("SDL_Renderer*")] nint renderer, [NativeTypeName("const SDL_Rect *")] SDL_Rect* rect);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderGetClipRect")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void RenderGetClipRect([NativeTypeName("SDL_Renderer*")] nint renderer, SDL_Rect* rect);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderIsClipEnabled")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool RenderIsClipEnabled([NativeTypeName("SDL_Renderer*")] nint renderer);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderSetScale")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int RenderSetScale([NativeTypeName("SDL_Renderer*")] nint renderer, float scaleX, float scaleY);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderGetScale")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void RenderGetScale([NativeTypeName("SDL_Renderer*")] nint renderer, float* scaleX, float* scaleY);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderWindowToLogical")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void RenderWindowToLogical([NativeTypeName("SDL_Renderer*")] nint renderer, int windowX, int windowY, float* logicalX, float* logicalY);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderLogicalToWindow")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void RenderLogicalToWindow([NativeTypeName("SDL_Renderer*")] nint renderer, float logicalX, float logicalY, int* windowX, int* windowY);

    [LibraryImport("SDL2", EntryPoint = "SDL_SetRenderDrawColor")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SetRenderDrawColor([NativeTypeName("SDL_Renderer*")] nint renderer, byte r, byte g, byte b, byte a);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetRenderDrawColor")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetRenderDrawColor([NativeTypeName("SDL_Renderer*")] nint renderer, [NativeTypeName(" *")] byte* r, [NativeTypeName(" *")] byte* g, [NativeTypeName(" *")] byte* b, [NativeTypeName(" *")] byte* a);

    [LibraryImport("SDL2", EntryPoint = "SDL_SetRenderDrawBlendMode")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SetRenderDrawBlendMode([NativeTypeName("SDL_Renderer*")] nint renderer, SDL_BlendMode blendMode);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetRenderDrawBlendMode")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetRenderDrawBlendMode([NativeTypeName("SDL_Renderer*")] nint renderer, SDL_BlendMode* blendMode);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderClear")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int RenderClear([NativeTypeName("SDL_Renderer*")] nint renderer);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderDrawPoint")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int RenderDrawPoint([NativeTypeName("SDL_Renderer*")] nint renderer, int x, int y);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderDrawPoints")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int RenderDrawPoints([NativeTypeName("SDL_Renderer*")] nint renderer, [NativeTypeName("const SDL_Point *")] SDL_Point* points, int count);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderDrawLine")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int RenderDrawLine([NativeTypeName("SDL_Renderer*")] nint renderer, int x1, int y1, int x2, int y2);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderDrawLines")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int RenderDrawLines([NativeTypeName("SDL_Renderer*")] nint renderer, [NativeTypeName("const SDL_Point *")] SDL_Point* points, int count);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderDrawRect")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int RenderDrawRect([NativeTypeName("SDL_Renderer*")] nint renderer, [NativeTypeName("const SDL_Rect *")] SDL_Rect* rect);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderDrawRects")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int RenderDrawRects([NativeTypeName("SDL_Renderer*")] nint renderer, [NativeTypeName("const SDL_Rect *")] SDL_Rect* rects, int count);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderFillRect")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int RenderFillRect([NativeTypeName("SDL_Renderer*")] nint renderer, [NativeTypeName("const SDL_Rect *")] SDL_Rect* rect);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderFillRects")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int RenderFillRects([NativeTypeName("SDL_Renderer*")] nint renderer, [NativeTypeName("const SDL_Rect *")] SDL_Rect* rects, int count);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderCopy")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int RenderCopy([NativeTypeName("SDL_Renderer*")] nint renderer, [NativeTypeName("SDL_Texture*")] nint texture, [NativeTypeName("const SDL_Rect *")] SDL_Rect* srcrect, [NativeTypeName("const SDL_Rect *")] SDL_Rect* dstrect);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderCopyEx")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int RenderCopyEx([NativeTypeName("SDL_Renderer*")] nint renderer, [NativeTypeName("SDL_Texture*")] nint texture, [NativeTypeName("const SDL_Rect *")] SDL_Rect* srcrect, [NativeTypeName("const SDL_Rect *")] SDL_Rect* dstrect, [NativeTypeName("const double")] double angle, [NativeTypeName("const SDL_Point *")] SDL_Point* center, [NativeTypeName("const SDL_RendererFlip")] SDL_RendererFlip flip);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderDrawPointF")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int RenderDrawPointF([NativeTypeName("SDL_Renderer*")] nint renderer, float x, float y);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderDrawPointsF")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int RenderDrawPointsF([NativeTypeName("SDL_Renderer*")] nint renderer, [NativeTypeName("const SDL_FPoint *")] SDL_FPoint* points, int count);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderDrawLineF")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int RenderDrawLineF([NativeTypeName("SDL_Renderer*")] nint renderer, float x1, float y1, float x2, float y2);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderDrawLinesF")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int RenderDrawLinesF([NativeTypeName("SDL_Renderer*")] nint renderer, [NativeTypeName("const SDL_FPoint *")] SDL_FPoint* points, int count);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderDrawRectF")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int RenderDrawRectF([NativeTypeName("SDL_Renderer*")] nint renderer, [NativeTypeName("const SDL_FRect *")] SDL_FRect* rect);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderDrawRectsF")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int RenderDrawRectsF([NativeTypeName("SDL_Renderer*")] nint renderer, [NativeTypeName("const SDL_FRect *")] SDL_FRect* rects, int count);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderFillRectF")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int RenderFillRectF([NativeTypeName("SDL_Renderer*")] nint renderer, [NativeTypeName("const SDL_FRect *")] SDL_FRect* rect);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderFillRectsF")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int RenderFillRectsF([NativeTypeName("SDL_Renderer*")] nint renderer, [NativeTypeName("const SDL_FRect *")] SDL_FRect* rects, int count);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderCopyF")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int RenderCopyF([NativeTypeName("SDL_Renderer*")] nint renderer, [NativeTypeName("SDL_Texture*")] nint texture, [NativeTypeName("const SDL_Rect *")] SDL_Rect* srcrect, [NativeTypeName("const SDL_FRect *")] SDL_FRect* dstrect);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderCopyExF")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int RenderCopyExF([NativeTypeName("SDL_Renderer*")] nint renderer, [NativeTypeName("SDL_Texture*")] nint texture, [NativeTypeName("const SDL_Rect *")] SDL_Rect* srcrect, [NativeTypeName("const SDL_FRect *")] SDL_FRect* dstrect, [NativeTypeName("const double")] double angle, [NativeTypeName("const SDL_FPoint *")] SDL_FPoint* center, [NativeTypeName("const SDL_RendererFlip")] SDL_RendererFlip flip);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderGeometry")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int RenderGeometry([NativeTypeName("SDL_Renderer*")] nint renderer, [NativeTypeName("SDL_Texture*")] nint texture, [NativeTypeName("const SDL_Vertex *")] SDL_Vertex* vertices, int num_vertices, [NativeTypeName("const int *")] int* indices, int num_indices);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderGeometryRaw")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int RenderGeometryRaw([NativeTypeName("SDL_Renderer*")] nint renderer, [NativeTypeName("SDL_Texture*")] nint texture, [NativeTypeName("const float *")] float* xy, int xy_stride, [NativeTypeName("const SDL_Color *")] SDL_Color* color, int color_stride, [NativeTypeName("const float *")] float* uv, int uv_stride, int num_vertices, [NativeTypeName("const void *")] void* indices, int num_indices, int size_indices);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderReadPixels")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int RenderReadPixels([NativeTypeName("SDL_Renderer*")] nint renderer, [NativeTypeName("const SDL_Rect *")] SDL_Rect* rect, uint format, void* pixels, int pitch);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderPresent")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void RenderPresent([NativeTypeName("SDL_Renderer*")] nint renderer);

    [LibraryImport("SDL2", EntryPoint = "SDL_DestroyTexture")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void DestroyTexture([NativeTypeName("SDL_Texture*")] nint texture);

    [LibraryImport("SDL2", EntryPoint = "SDL_DestroyRenderer")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void DestroyRenderer([NativeTypeName("SDL_Renderer*")] nint renderer);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderFlush")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int RenderFlush([NativeTypeName("SDL_Renderer*")] nint renderer);

    [LibraryImport("SDL2", EntryPoint = "SDL_GL_BindTexture")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GL_BindTexture([NativeTypeName("SDL_Texture*")] nint texture, float* texw, float* texh);

    [LibraryImport("SDL2", EntryPoint = "SDL_GL_UnbindTexture")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GL_UnbindTexture([NativeTypeName("SDL_Texture*")] nint texture);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderGetMetalLayer")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void* RenderGetMetalLayer([NativeTypeName("SDL_Renderer*")] nint renderer);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderGetMetalCommandEncoder")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void* RenderGetMetalCommandEncoder([NativeTypeName("SDL_Renderer*")] nint renderer);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderSetVSync")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int RenderSetVSync([NativeTypeName("SDL_Renderer*")] nint renderer, int vsync);
}
