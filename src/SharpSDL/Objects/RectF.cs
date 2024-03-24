namespace SharpSDL.Objects;

public record struct RectF(float X, float Y, float Width, float Height)
{
    public float X = X;
    public float Y = Y;
    public float Width = Width;
    public float Height = Height;

    public readonly bool IsEmpty { get => Width <= 0 || Height <= 0; }

    public readonly bool Contains(Point point)
    {
        return point.X >= X && point.X < X + Width
            && point.Y >= Y && point.Y < Y + Height;
    }

    public bool IntersectsWith(RectF other)
    {
        unsafe
        {
            return SDL.HasIntersectionF((SDL_FRect*)Unsafe.AsPointer(ref this), (SDL_FRect*)Unsafe.AsPointer(ref other));
        }
    }

    public bool IntersectsWith(RectF other, out RectF result)
    {
        unsafe
        {
            Unsafe.SkipInit(out RectF rect);
            result = default;
            var intersects = SDL.IntersectFRect((SDL_FRect*)Unsafe.AsPointer(ref this), (SDL_FRect*)Unsafe.AsPointer(ref other), (SDL_FRect*)&rect);
            if (intersects)
                result = rect;
            return intersects;
        }
    }

    public bool IntersectsWith(LineF other)
    {
        unsafe
        {
            return SDL.IntersectFRectAndLine((SDL_FRect*)Unsafe.AsPointer(ref this), &other.P1.X, &other.P1.Y, &other.P2.X, &other.P2.Y);
        }
    }

    public bool IntersectsWith(LineF other, out LineF result)
    {
        unsafe
        {
            var intersects = SDL.IntersectFRectAndLine((SDL_FRect*)Unsafe.AsPointer(ref this), &other.P1.X, &other.P1.Y, &other.P2.X, &other.P2.Y);
            result = other;
            return intersects;
        }
    }

    public RectF UnionWith(RectF other)
    {
        Unsafe.SkipInit(out RectF rect);
        unsafe
        {
            SDL.UnionFRect((SDL_FRect*)Unsafe.AsPointer(ref this), (SDL_FRect*)Unsafe.AsPointer(ref other), (SDL_FRect*)&rect);
        }
        return rect;
    }

    public static RectF EnclosePoints(ReadOnlySpan<PointF> points)
    {
        unsafe
        {
            Unsafe.SkipInit(out RectF rect);
            fixed (PointF* ptr = points)
            {
                SDL.EncloseFPoints((SDL_FPoint*)ptr, points.Length, null, (SDL_FRect*)&rect);
            }
            return rect;
        }
    }

    public static RectF EnclosePoints(ReadOnlySpan<PointF> points, RectF clip, out bool pointsEnclosed)
    {
        unsafe
        {
            Unsafe.SkipInit(out RectF rect);
            fixed (PointF* ptr = points)
            {
                pointsEnclosed = SDL.EncloseFPoints((SDL_FPoint*)ptr, points.Length, (SDL_FRect*)&clip, (SDL_FRect*)&rect);
            }
            return rect;
        }
    }
}