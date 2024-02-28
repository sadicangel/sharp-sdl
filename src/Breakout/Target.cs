namespace Breakout;

public record struct Target(Rect Rect)
{
    public Rect Rect = Rect;
    public Color Color = new(0xFF30FF30);
    public bool Dead;
}
