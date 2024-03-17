namespace SharpSDL;

public sealed class Platform
{
    public static string GetPlatform()
    {
        unsafe
        {
            return MemoryMarshal.CreateReadOnlySpanFromNullTerminated(SDL.GetPlatform()).AsUtf16(utf16 => new string(utf16));
        }
    }
}