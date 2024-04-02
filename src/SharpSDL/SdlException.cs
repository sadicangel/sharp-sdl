namespace SharpSDL;

public sealed class SdlException(string? message) : Exception(message)
{
    internal static void ThrowLastError() => ThrowLastError<object>();

    internal static T ThrowLastError<T>()
    {
        unsafe
        {
            throw new SdlException(StringHelper.ToUtf16(SDL.GetError()));
        }
    }
}