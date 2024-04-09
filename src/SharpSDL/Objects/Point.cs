namespace SharpSDL.Objects;

public record struct Point(int X, int Y)
{
    public static readonly Point Empty = new((int)SDL2.SDL_WINDOWPOS_UNDEFINED, (int)SDL2.SDL_WINDOWPOS_UNDEFINED);

    public readonly bool IsEmpty { get => this == Empty; }

    public int X = X;
    public int Y = Y;
}
