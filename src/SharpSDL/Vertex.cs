namespace SharpSDL;

public readonly record struct Vertex(PointF Position, ColorRgba Color, PointF TexCoord)
{
    public readonly PointF Position = Position;
    public readonly ColorRgba Color = Color;
    public readonly PointF TexCoord = TexCoord;
}