using SharpSDL.Objects;

namespace Breakout;

public record struct Bar(Rect Rect)
{
    public Rect Rect = Rect;
    public ColorRgba Color = new(0xFF3030FF);
    public float Speed = 350 * 1.5f;
}