namespace SharpSDL.Objects;

public record struct LineF(PointF P1, PointF P2)
{
    public PointF P1 = P1;
    public PointF P2 = P2;
}
