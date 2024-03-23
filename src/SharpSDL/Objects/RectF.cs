namespace SharpSDL.Objects;

public record struct RectF(float X, float Y, float Width, float Height)
{
    public float X = X;
    public float Y = Y;
    public float Width = Width;
    public float Height = Height;

    public bool IntersectsWith(RectF target)
    {
        unsafe
        {
            return SDL.HasIntersectionF((SDL_FRect*)Unsafe.AsPointer(ref this), (SDL_FRect*)Unsafe.AsPointer(ref target));
        }
    }
}