namespace SharpSDL.Objects;

public record struct PointF(float X, float Y)
{
    public static readonly PointF Empty = new(Unsafe.BitCast<uint, float>(SDL2.SDL_WINDOWPOS_UNDEFINED), Unsafe.BitCast<uint, float>(SDL2.SDL_WINDOWPOS_UNDEFINED));

    public readonly bool IsEmpty { get => this == Empty; }

    public float X = X;
    public float Y = Y;
}
