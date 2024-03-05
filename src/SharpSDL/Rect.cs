namespace SharpSDL;

public record struct Rect(int X, int Y, int Width, int Height)
{
    public int X = X;
    public int Y = Y;
    public int Width = Width;
    public int Height = Height;
}
