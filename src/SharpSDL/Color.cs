namespace SharpSDL;

[StructLayout(LayoutKind.Explicit)]
public record struct Color(byte R, byte G, byte B, byte A)
{
    [FieldOffset(0)]
    public byte R = R;
    [FieldOffset(1)]
    public byte G = G;
    [FieldOffset(2)]
    public byte B = B;
    [FieldOffset(3)]
    public byte A = A;
    [FieldOffset(0)]
    public uint Rgba;
    [FieldOffset(0)]
    public ColorRgb Rbg;

    public Color(uint rgba) : this(0, 0, 0, 0) => Rgba = rgba;
}

[StructLayout(LayoutKind.Explicit)]
public record struct ColorRgb(byte R, byte G, byte B)
{
    [FieldOffset(0)]
    public byte R = R;
    [FieldOffset(1)]
    public byte G = G;
    [FieldOffset(2)]
    public byte B = B;
}