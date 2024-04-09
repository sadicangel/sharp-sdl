namespace SharpSDL;

public sealed class SdlException(string? message) : Exception(message)
{
    internal static void ThrowLastError() => ThrowLastError<object>();

    internal static T ThrowLastError<T>()
    {
        unsafe
        {
            throw new SdlException(StringHelper.ToUtf16(SDL2.GetError()));
        }
    }

    internal static void WatchError(Action action)
    {
        unsafe
        {
            SDL2.ClearError();
            action();
            var _error = MemoryMarshal.CreateReadOnlySpanFromNullTerminated(SDL2.GetError());
            if (_error.Length > 0)
                throw new SdlException(StringHelper.ToUtf16(_error));
        }
    }

    internal static T WatchError<T>(Func<T> func)
    {
        unsafe
        {
            SDL2.ClearError();
            var result = func();
            var _error = MemoryMarshal.CreateReadOnlySpanFromNullTerminated(SDL2.GetError());
            if (_error.Length > 0)
                throw new SdlException(StringHelper.ToUtf16(_error));
            return result;
        }
    }
}