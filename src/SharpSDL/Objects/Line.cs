namespace SharpSDL.Objects;

public record struct Line(Point P1, Point P2)
{
    public Point P1 = P1;
    public Point P2 = P2;

    public Line(int X1, int Y1, int X2, int Y2) : this(new(X1, Y1), new(X2, Y2))
    {

    }
}