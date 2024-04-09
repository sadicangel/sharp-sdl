using System.Text;

namespace SharpSDL.IO;
public static class FileSystem
{
    public static string GetBasePath()
    {
        unsafe
        {
            using var path = SdlPointer.Defer(SDL2.GetBasePath());
            if (path.IsNull)
                SdlException.ThrowLastError();
            return Encoding.UTF8.GetString(MemoryMarshal.CreateReadOnlySpanFromNullTerminated(path));
        }
    }

    private static unsafe string GetPrefPath(byte* org, byte* app)
    {
        using var path = SdlPointer.Defer(SDL2.GetPrefPath(org, app));
        if (path.IsNull)
            SdlException.ThrowLastError();
        return Encoding.UTF8.GetString(MemoryMarshal.CreateReadOnlySpanFromNullTerminated(path));
    }

    public static string GetPrefPath(ReadOnlySpan<byte> org, ReadOnlySpan<byte> app)
    {
        unsafe
        {
            fixed (byte* orgPtr = org, appPtr = app)
            {
                return GetPrefPath(orgPtr, appPtr);
            }
        }
    }

    public static string GetPrefPath(string org, string app)
    {
        unsafe
        {
            return org.AsUtf8((o, _) => app.AsUtf8((a, _) => GetPrefPath(o, a)));
        }
    }
}
