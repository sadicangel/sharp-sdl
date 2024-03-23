namespace SharpSDL.Objects;

public record struct Rect(int X, int Y, int Width, int Height)
{
    public int X = X;
    public int Y = Y;
    public int Width = Width;
    public int Height = Height;

    public bool IntersectsWith(Rect target)
    {
        unsafe
        {
            return SDL.HasIntersection((SDL_Rect*)Unsafe.AsPointer(ref this), (SDL_Rect*)Unsafe.AsPointer(ref target));
        }
    }
}
