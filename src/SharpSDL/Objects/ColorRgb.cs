namespace SharpSDL.Objects;

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