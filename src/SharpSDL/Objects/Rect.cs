namespace SharpSDL.Objects;

public record struct Rect(int X, int Y, int Width, int Height)
{
    public int X = X;
    public int Y = Y;
    public int Width = Width;
    public int Height = Height;

    public readonly bool IsEmpty { get => Width <= 0 || Height <= 0; }

    public readonly bool Contains(Point point)
    {
        return point.X >= X && point.X < X + Width
            && point.Y >= Y && point.Y < Y + Height;
    }

    public bool IntersectsWith(Rect other)
    {
        unsafe
        {
            return SDL.HasIntersection((SDL_Rect*)Unsafe.AsPointer(ref this), (SDL_Rect*)Unsafe.AsPointer(ref other));
        }
    }

    public bool IntersectsWith(Rect other, out Rect result)
    {
        unsafe
        {
            Unsafe.SkipInit(out Rect rect);
            result = default;
            var intersects = SDL.IntersectRect((SDL_Rect*)Unsafe.AsPointer(ref this), (SDL_Rect*)Unsafe.AsPointer(ref other), (SDL_Rect*)&rect);
            if (intersects)
                result = rect;
            return intersects;
        }
    }

    public bool IntersectsWith(Line other)
    {
        unsafe
        {
            return SDL.IntersectRectAndLine((SDL_Rect*)Unsafe.AsPointer(ref this), &other.P1.X, &other.P1.Y, &other.P2.X, &other.P2.Y);
        }
    }

    public bool IntersectsWith(Line other, out Line result)
    {
        unsafe
        {
            var intersects = SDL.IntersectRectAndLine((SDL_Rect*)Unsafe.AsPointer(ref this), &other.P1.X, &other.P1.Y, &other.P2.X, &other.P2.Y);
            result = other;
            return intersects;
        }
    }

    public Rect UnionWith(Rect other)
    {
        Unsafe.SkipInit(out Rect rect);
        unsafe
        {
            SDL.UnionRect((SDL_Rect*)Unsafe.AsPointer(ref this), (SDL_Rect*)Unsafe.AsPointer(ref other), (SDL_Rect*)&rect);
        }
        return rect;
    }

    public static Rect EnclosePoints(ReadOnlySpan<Point> points)
    {
        unsafe
        {
            Unsafe.SkipInit(out Rect rect);
            fixed (Point* ptr = points)
            {
                SDL.EnclosePoints((SDL_Point*)ptr, points.Length, null, (SDL_Rect*)&rect);
            }
            return rect;
        }
    }

    public static Rect EnclosePoints(ReadOnlySpan<Point> points, Rect clip, out bool pointsEnclosed)
    {
        unsafe
        {
            Unsafe.SkipInit(out Rect rect);
            fixed (Point* ptr = points)
            {
                pointsEnclosed = SDL.EnclosePoints((SDL_Point*)ptr, points.Length, (SDL_Rect*)&clip, (SDL_Rect*)&rect);
            }
            return rect;
        }
    }
}
