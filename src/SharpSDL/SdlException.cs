using System.Text;

namespace SharpSDL;

public sealed class SdlException(string? message) : Exception(message)
{
    internal static void ThrowLastError()
    {
        unsafe
        {
            var bytes = MemoryMarshal.CreateReadOnlySpanFromNullTerminated(SDL.GetError());
            var chars = Encoding.UTF8.GetString(bytes);
            throw new SdlException(chars);
        }
    }
}