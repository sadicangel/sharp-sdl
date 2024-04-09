using SharpSDL.Graphics;
using SharpSDL.Objects;

namespace SharpSDL;

public sealed class Renderer : IDisposable
{
    internal readonly nint _renderer;
    private readonly Window? _window;

    public Renderer(Window window, int index, RendererFlags flags)
    {
        _renderer = SDL2.CreateRenderer(window._window, index, (uint)flags);
        if (_renderer == 0)
            SdlException.ThrowLastError();
        _window = window;
    }

    public Renderer(int width, int height, WindowFlags flags)
    {
        unsafe
        {
            nint windowPtr = 0;
            nint rendererPtr = 0;

            if (SDL2.CreateWindowAndRenderer(width, height, (uint)flags, &windowPtr, &rendererPtr) != 0)
                SdlException.ThrowLastError();

            _renderer = rendererPtr;
            _window = new Window(windowPtr);
        }
    }

    public unsafe Renderer(Surface surface)
    {
        _renderer = SDL2.CreateSoftwareRenderer(surface._surface);
        if (_renderer == 0)
            SdlException.ThrowLastError();
    }

    public Window Window
    {
        get => SDL2.RenderGetWindow(_renderer) is var window and not 0 ? new Window(window) : SdlException.ThrowLastError<Window>();
    }

    public DriverInfo DriverInfo
    {
        get
        {
            unsafe
            {
                DriverInfo info = default;
                if (SDL2.GetRendererInfo(_renderer, (SDL_RendererInfo*)&info) != 0)
                    SdlException.ThrowLastError();
                return info;
            }
        }
    }

    public Size OutputSize
    {
        get
        {
            unsafe
            {
                Unsafe.SkipInit(out Size size);
                if (SDL2.GetRendererOutputSize(_renderer, &size.Width, &size.Height) != 0)
                    SdlException.ThrowLastError();
                return size;
            }
        }
    }

    public ColorRgba DrawColor
    {
        get
        {
            unsafe
            {
                Unsafe.SkipInit(out ColorRgba c);
                if (SDL2.GetRenderDrawColor(_renderer, &c.R, &c.G, &c.B, &c.A) != 0)
                    SdlException.ThrowLastError();
                return c;
            }
        }
        set
        {
            if (SDL2.SetRenderDrawColor(_renderer, value.R, value.G, value.B, value.A) != 0)
                SdlException.ThrowLastError();
        }
    }

    public BlendMode DrawBlendMode
    {
        get
        {
            unsafe
            {
                Unsafe.SkipInit(out BlendMode mode);
                if (SDL2.GetRenderDrawBlendMode(_renderer, (SDL_BlendMode*)&mode) != 0)
                    SdlException.ThrowLastError();
                return mode;
            }
        }
        set
        {
            unsafe
            {
                if (SDL2.SetRenderDrawBlendMode(_renderer, (SDL_BlendMode)value) != 0)
                    SdlException.ThrowLastError();
            }
        }
    }

    public bool IsRenderTargetSupported { get => SDL2.RenderTargetSupported(_renderer); }

    public Texture? RenderTarget
    {
        get => SDL2.GetRenderTarget(_renderer) is var t && t != 0 ? new Texture(t, owned: false) : null;
        set
        {
            if (SDL2.SetRenderTarget(_renderer, value?._texture ?? 0) != 0)
                SdlException.ThrowLastError();
        }
    }

    public Size LogicalSize
    {
        get
        {
            unsafe
            {
                Size size = default;
                SDL2.RenderGetLogicalSize(_renderer, &size.Width, &size.Height);
                return size;
            }
        }
        set
        {
            if (SDL2.RenderSetLogicalSize(_renderer, value.Width, value.Height) != 0)
                SdlException.ThrowLastError();
        }
    }

    public Texture CreateTexture(PixelFormatEnum format, TextureAccess access, Size size)
    {
        var texture = SDL2.CreateTexture(_renderer, (uint)format, (int)access, size.Width, size.Height);
        if (texture == 0)
            SdlException.ThrowLastError();
        return new Texture(texture, owned: true);
    }

    public bool IsIntegerScale
    {
        get => SDL2.RenderGetIntegerScale(_renderer);
        set
        {
            if (SDL2.RenderSetIntegerScale(_renderer, value) != 0)
                SdlException.ThrowLastError();
        }
    }

    public Rect Viewport
    {
        get
        {
            unsafe
            {
                Rect rect = default;
                SDL2.RenderGetViewport(_renderer, (SDL_Rect*)&rect);
                return rect;
            }
        }
        set
        {
            unsafe
            {
                if (SDL2.RenderSetViewport(_renderer, (value.Width != 0 || value.Height != 0) ? (SDL_Rect*)&value : null) != 0)
                    SdlException.ThrowLastError();
            }
        }
    }

    public bool IsClipEnabled { get => SDL2.RenderIsClipEnabled(_renderer); }

    public Rect? ClipRect
    {
        get
        {
            unsafe
            {
                Rect rect = default;
                SDL2.RenderGetClipRect(_renderer, (SDL_Rect*)&rect);
                return rect;
            }
        }
        set
        {
            unsafe
            {
                Rect rect = value.GetValueOrDefault();
                if (SDL2.RenderSetClipRect(_renderer, value.HasValue ? (SDL_Rect*)&rect : null) != 0)
                    SdlException.ThrowLastError();
            }
        }
    }

    public Scale Scale
    {
        get
        {
            unsafe
            {
                Scale scale = default;
                SDL2.RenderGetScale(_renderer, &scale.X, &scale.Y);
                return scale;
            }
        }
        set
        {
            unsafe
            {
                if (SDL2.RenderSetScale(_renderer, value.X, value.Y) != 0)
                    SdlException.ThrowLastError();
            }
        }
    }

    public nint GetMetalLayer()
    {
        unsafe
        {
            return (nint)SDL2.RenderGetMetalLayer(_renderer);
        }
    }

    public nint GetMetalCommandEncoder()
    {
        unsafe
        {
            return (nint)SDL2.RenderGetMetalCommandEncoder(_renderer);
        }
    }

    public void SetVSync(bool enable)
    {
        if (SDL2.RenderSetVSync(_renderer, enable ? 1 : 0) != 0)
            SdlException.ThrowLastError();
    }

    public Texture CreateTexture(Surface surface)
    {
        unsafe
        {
            var texture = SDL2.CreateTextureFromSurface(_renderer, surface._surface);
            if (texture == 0)
                SdlException.ThrowLastError();
            return new Texture(texture, owned: true);
        }
    }

    public void Clear()
    {
        if (SDL2.RenderClear(_renderer) != 0)
            SdlException.ThrowLastError();
    }

    public PointF WindowToLogical(Point point)
    {
        unsafe
        {
            PointF result = default;
            SDL2.RenderWindowToLogical(_renderer, point.X, point.Y, &result.X, &result.Y);
            return result;
        }
    }

    public Point LogicalToWindow(PointF point)
    {
        unsafe
        {
            Point result = default;
            SDL2.RenderLogicalToWindow(_renderer, point.X, point.Y, &result.X, &result.Y);
            return result;
        }
    }

    public void DrawPoint(Point point)
    {
        if (SDL2.RenderDrawPoint(_renderer, point.X, point.Y) != 0)
            SdlException.ThrowLastError();
    }

    public void DrawPoint(PointF point)
    {
        if (SDL2.RenderDrawPointF(_renderer, point.X, point.Y) != 0)
            SdlException.ThrowLastError();
    }

    public void DrawPoints(ReadOnlySpan<Point> points)
    {
        unsafe
        {
            fixed (Point* ptr = points)
            {
                if (SDL2.RenderDrawPoints(_renderer, (SDL_Point*)ptr, points.Length) != 0)
                    SdlException.ThrowLastError();
            }
        }
    }

    public void DrawPoints(ReadOnlySpan<PointF> points)
    {
        unsafe
        {
            fixed (PointF* ptr = points)
            {
                if (SDL2.RenderDrawPointsF(_renderer, (SDL_FPoint*)ptr, points.Length) != 0)
                    SdlException.ThrowLastError();
            }
        }
    }

    public void DrawLine(Line line)
    {
        if (SDL2.RenderDrawLine(_renderer, line.P1.X, line.P1.Y, line.P2.X, line.P2.Y) != 0)
            SdlException.ThrowLastError();
    }

    public void DrawLine(LineF line)
    {
        if (SDL2.RenderDrawLineF(_renderer, line.P1.X, line.P1.Y, line.P2.X, line.P2.Y) != 0)
            SdlException.ThrowLastError();
    }

    public void DrawLines(ReadOnlySpan<Point> points)
    {
        unsafe
        {
            fixed (Point* ptr = points)
            {
                if (SDL2.RenderDrawLines(_renderer, (SDL_Point*)ptr, points.Length) != 0)
                    SdlException.ThrowLastError();
            }
        }
    }

    public void DrawLines(ReadOnlySpan<PointF> points)
    {
        unsafe
        {
            fixed (PointF* ptr = points)
            {
                if (SDL2.RenderDrawLinesF(_renderer, (SDL_FPoint*)ptr, points.Length) != 0)
                    SdlException.ThrowLastError();
            }
        }
    }

    public void DrawRect(Rect rect)
    {
        unsafe
        {
            if (SDL2.RenderDrawRect(_renderer, (SDL_Rect*)&rect) != 0)
                SdlException.ThrowLastError();
        }
    }

    public void DrawRect(RectF rect)
    {
        unsafe
        {
            if (SDL2.RenderDrawRectF(_renderer, (SDL_FRect*)&rect) != 0)
                SdlException.ThrowLastError();
        }
    }

    public void DrawRects(ReadOnlySpan<Rect> rects)
    {
        unsafe
        {
            fixed (Rect* ptr = rects)
            {
                if (SDL2.RenderDrawRects(_renderer, (SDL_Rect*)ptr, rects.Length) != 0)
                    SdlException.ThrowLastError();
            }
        }
    }

    public void DrawRects(ReadOnlySpan<RectF> rects)
    {
        unsafe
        {
            fixed (RectF* ptr = rects)
            {
                if (SDL2.RenderDrawRectsF(_renderer, (SDL_FRect*)ptr, rects.Length) != 0)
                    SdlException.ThrowLastError();
            }
        }
    }

    public void FillRect(Rect rect)
    {
        unsafe
        {
            if (SDL2.RenderFillRect(_renderer, (SDL_Rect*)Unsafe.AsPointer(ref rect)) != 0)
                SdlException.ThrowLastError();
        }
    }

    public void FillRect(RectF rect)
    {
        unsafe
        {
            if (SDL2.RenderFillRectF(_renderer, (SDL_FRect*)Unsafe.AsPointer(ref rect)) != 0)
                SdlException.ThrowLastError();
        }
    }

    public void FillRects(ReadOnlySpan<Rect> rects)
    {
        unsafe
        {
            fixed (Rect* ptr = rects)
            {
                if (SDL2.RenderFillRects(_renderer, (SDL_Rect*)ptr, rects.Length) != 0)
                    SdlException.ThrowLastError();
            }
        }
    }

    public void FillRects(ReadOnlySpan<RectF> rects)
    {
        unsafe
        {
            fixed (RectF* ptr = rects)
            {
                if (SDL2.RenderFillRectsF(_renderer, (SDL_FRect*)ptr, rects.Length) != 0)
                    SdlException.ThrowLastError();
            }
        }
    }

    public void Copy(Texture texture, Rect srcRect, Rect dstRect)
    {
        unsafe
        {
            var src = srcRect.IsEmpty ? null : (SDL_Rect*)&srcRect;
            var dst = dstRect.IsEmpty ? null : (SDL_Rect*)&dstRect;
            if (SDL2.RenderCopy(_renderer, texture._texture, src, dst) != 0)
                SdlException.ThrowLastError();
        }
    }

    public void Copy(Texture texture, Rect srcRect, RectF dstRect)
    {
        unsafe
        {
            var src = srcRect.IsEmpty ? null : (SDL_Rect*)&srcRect;
            var dst = dstRect.IsEmpty ? null : (SDL_FRect*)&dstRect;
            if (SDL2.RenderCopyF(_renderer, texture._texture, src, dst) != 0)
                SdlException.ThrowLastError();
        }
    }

    public void Copy(Texture texture, Rect srcRect, Rect dstRect, double angle, Point center, FlipMode flip)
    {
        unsafe
        {
            var src = srcRect.IsEmpty ? null : (SDL_Rect*)&srcRect;
            var dst = dstRect.IsEmpty ? null : (SDL_Rect*)&dstRect;
            var cpt = center.IsEmpty ? null : (SDL_Point*)&center;
            if (SDL2.RenderCopyEx(_renderer, texture._texture, src, dst, angle, cpt, (SDL_RendererFlip)flip) != 0)
                SdlException.ThrowLastError();
        }
    }

    public void Copy(Texture texture, Rect srcRect, RectF dstRect, double angle, PointF center, FlipMode flip)
    {
        unsafe
        {
            var src = srcRect.IsEmpty ? null : (SDL_Rect*)&srcRect;
            var dst = dstRect.IsEmpty ? null : (SDL_FRect*)&dstRect;
            var cpt = center.IsEmpty ? null : (SDL_FPoint*)&center;
            if (SDL2.RenderCopyExF(_renderer, texture._texture, src, dst, angle, cpt, (SDL_RendererFlip)flip) != 0)
                SdlException.ThrowLastError();
        }
    }

    public void DrawGeometry(ReadOnlySpan<Vertex> vertices, ReadOnlySpan<int> indices = default, Texture? texture = default)
    {
        unsafe
        {
            fixed (Vertex* v = vertices)
            fixed (int* i = indices)
            {
                if (SDL2.RenderGeometry(_renderer, texture?._texture ?? 0, (SDL_Vertex*)v, vertices.Length, indices.Length > 0 ? i : null, indices.Length) != 0)
                    SdlException.ThrowLastError();
            }
        }
    }

    public void DrawGeometry(
        int vertexCount,
        ReadOnlySpan<float> xy,
        int xyStride,
        ReadOnlySpan<ColorRgba> colors,
        int colorStride,
        ReadOnlySpan<float> uv,
        int uvStride,
        ReadOnlySpan<byte> indices = default,
        Texture? texture = default)
    {
        DrawGeometry<byte>(vertexCount, xy, xyStride, colors, colorStride, uv, uvStride, indices, texture);
    }

    public void DrawGeometry(
        int vertexCount,
        ReadOnlySpan<float> xy,
        int xyStride,
        ReadOnlySpan<ColorRgba> colors,
        int colorStride,
        ReadOnlySpan<float> uv,
        int uvStride,
        ReadOnlySpan<short> indices = default,
        Texture? texture = default)
    {
        DrawGeometry<short>(vertexCount, xy, xyStride, colors, colorStride, uv, uvStride, indices, texture);
    }

    public void DrawGeometry(
        int vertexCount,
        ReadOnlySpan<float> xy,
        int xyStride,
        ReadOnlySpan<ColorRgba> colors,
        int colorStride,
        ReadOnlySpan<float> uv,
        int uvStride,
        ReadOnlySpan<int> indices = default,
        Texture? texture = default)
    {
        DrawGeometry<int>(vertexCount, xy, xyStride, colors, colorStride, uv, uvStride, indices, texture);
    }

    private void DrawGeometry<T>(
        int vertexCount,
        ReadOnlySpan<float> xy,
        int xyStride,
        ReadOnlySpan<ColorRgba> colors,
        int colorStride,
        ReadOnlySpan<float> uv,
        int uvStride,
        ReadOnlySpan<T> indices = default,
        Texture? texture = default)
        where T : unmanaged
    {
        unsafe
        {
            fixed (float* xy_p = xy)
            fixed (ColorRgba* colors_p = colors)
            fixed (float* uv_p = uv)
            fixed (T* indices_p = indices)
            {
                var result = SDL2.RenderGeometryRaw(
                    _renderer,
                    texture?._texture ?? 0,
                    xy_p,
                    xyStride,
                    (SDL_Color*)colors_p,
                    colorStride,
                    uv_p,
                    uvStride,
                    vertexCount,
                    indices.Length > 0 ? indices_p : null,
                    indices.Length,
                    Unsafe.SizeOf<T>());

                if (result != 0)
                    SdlException.ThrowLastError();
            }
        }
    }

    public void ReadPixels(Rect rect, PixelFormatEnum format, nint pixels, int pitch)
    {
        unsafe
        {
            if (SDL2.RenderReadPixels(_renderer, (SDL_Rect*)&rect, (uint)format, (void*)pixels, pitch) != 0)
                SdlException.ThrowLastError();
        }
    }

    public void Present() => SDL2.RenderPresent(_renderer);

    public void Flush()
    {
        if (SDL2.RenderFlush(_renderer) != 0)
            SdlException.ThrowLastError();
    }

    public void Dispose()
    {
        if (_renderer != 0)
        {
            _window?.Dispose();
            SDL2.DestroyRenderer(_renderer);
            ref var ptr = ref Unsafe.AsRef(in _renderer);
            ptr = 0;
        }
    }

    public static int GetDriverCount()
    {
        var count = SDL2.GetNumRenderDrivers();
        if (count < 0)
            SdlException.ThrowLastError();
        return count;
    }

    public static DriverInfo GetDriverInfo(int index)
    {
        unsafe
        {
            Unsafe.SkipInit(out DriverInfo info);
            if (SDL2.GetRenderDriverInfo(index, (SDL_RendererInfo*)&info) != 0)
                SdlException.ThrowLastError();
            return info;
        }
    }
}

[Flags]
public enum RendererFlags : uint
{
    Software = SDL_RendererFlags.SDL_RENDERER_SOFTWARE,
    Accelerated = SDL_RendererFlags.SDL_RENDERER_ACCELERATED,
    PresentVSync = SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC,
    TargetTexture = SDL_RendererFlags.SDL_RENDERER_TARGETTEXTURE,
}

public readonly struct DriverInfo
{
    public unsafe readonly byte* NameUtf8;
    public readonly RendererFlags SupportedFlags;
    public readonly uint TextureFormatsCount;
    public readonly TextureFormats TextureFormats;
    public readonly int MaxTextureWidth;
    public readonly int MaxTextureHeight;

    public string NameUtf16
    {
        get
        {
            unsafe
            {
                return StringHelper.ToUtf16(NameUtf8);
            }
        }
    }
}

[InlineArray(16)]
public struct TextureFormats
{
    public uint e0;
}

public enum FlipMode
{
    None = SDL_RendererFlip.SDL_FLIP_NONE,
    Horizontal = SDL_RendererFlip.SDL_FLIP_HORIZONTAL,
    Vertical = SDL_RendererFlip.SDL_FLIP_VERTICAL,
}