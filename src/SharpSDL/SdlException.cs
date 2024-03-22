using System.Text;

namespace SharpSDL;

public sealed class SdlException(string? message) : Exception(message)
{
    internal static void ThrowLastError() => ThrowLastError<object>();

    internal static T ThrowLastError<T>()
    {
        unsafe
        {
            var bytes = MemoryMarshal.CreateReadOnlySpanFromNullTerminated(SDL.GetError());
            var chars = Encoding.UTF8.GetString(bytes);
            throw new SdlException(chars);
        }
    }
}