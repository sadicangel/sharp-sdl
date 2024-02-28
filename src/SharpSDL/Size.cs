namespace SharpSDL;

public struct Size(int Width, int Height)
{
    public int Width = Width;
    public int Height = Height;
}

public struct SizeF(float Width, float Height)
{
    public float Width = Width;
    public float Height = Height;
}
