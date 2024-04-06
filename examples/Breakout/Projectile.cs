using SharpSDL.Objects;

namespace Breakout;

public record struct Projectile(Rect Rect)
{
    public Rect Rect = Rect;
    public ColorRgba Color = new(0xFFFFFFFF);
    public float Speed = 350;
}
