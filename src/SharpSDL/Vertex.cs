namespace SharpSDL;

public readonly record struct Vertex(PointF Position, Color Color, PointF TexCoord)
{
    public readonly PointF Position = Position;
    public readonly Color Color = Color;
    public readonly PointF TexCoord = TexCoord;
}