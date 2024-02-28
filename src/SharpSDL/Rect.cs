namespace SharpSDL;
public struct Point(int X, int Y)
{
    public int X = X;
    public int Y = Y;
}

public struct PointF(float X, float Y)
{
    public float X = X;
    public float Y = Y;
}

public struct Rect(int X, int Y, int Width, int Height)
{
    public int X = X;
    public int Y = Y;
    public int Width = Width;
    public int Height = Height;
}

public struct RectF(float X, float Y, float Width, float Height)
{
    public float X = X;
    public float Y = Y;
    public float Width = Width;
    public float Height = Height;
}