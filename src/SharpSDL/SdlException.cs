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

    internal static void WatchError(Action action)
    {
        unsafe
        {
            SDL.ClearError();
            action();
            var _error = MemoryMarshal.CreateReadOnlySpanFromNullTerminated(SDL.GetError());
            if (_error.Length > 0)
                throw new SdlException(StringHelper.ToUtf16(_error));
        }
    }

    internal static T WatchError<T>(Func<T> func)
    {
        unsafe
        {
            SDL.ClearError();
            var result = func();
            var _error = MemoryMarshal.CreateReadOnlySpanFromNullTerminated(SDL.GetError());
            if (_error.Length > 0)
                throw new SdlException(StringHelper.ToUtf16(_error));
            return result;
        }
    }
}