using SharpSDL.Objects;

namespace Breakout;

public record struct Target(Rect Rect)
{
    public Rect Rect = Rect;
    public ColorRgba Color = new(0xFF30FF30);
    public bool Dead;
}
