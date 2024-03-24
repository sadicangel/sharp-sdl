namespace SharpSDL.Objects;

public record struct Line(Point P1, Point P2)
{
    public Point P1 = P1;
    public Point P2 = P2;
}