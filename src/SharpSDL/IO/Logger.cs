using System.Buffers;
using System.Text;

namespace SharpSDL.IO;
public sealed class Logger
{
    private static LoggerOutput? LoggerOutput = null;

    public static void SetLevels(LogLevel level) => SDL.LogSetAllPriority((SDL_LogPriority)level);
    public static void ResetLevels() => SDL.LogResetPriorities();

    public static void SetLevel(LogCategory category, LogLevel level) => SDL.LogSetPriority((int)category, (SDL_LogPriority)level);
    public static LogLevel GetLevel(LogCategory category) => (LogLevel)SDL.LogGetPriority((int)category);

    public static void Log(LogCategory category, LogLevel level, string format, params object?[] args)
    {
        var message = args is [] ? format : string.Format(format, args);
        var utf8Array = ArrayPool<byte>.Shared.Rent(Encoding.UTF8.GetMaxByteCount(message.Length));
        try
        {
            var bytesWritten = Encoding.UTF8.GetBytes(message, utf8Array);
            unsafe
            {
                fixed (byte* utf8 = utf8Array.AsSpan(..bytesWritten))
                    SDL.LogMessage((int)category, (SDL_LogPriority)level, utf8, __arglist());
            }
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(utf8Array, clearArray: true);
        }
    }
    public static void LogCritical(LogCategory category, string format, params object?[] args) => Log(category, LogLevel.Critical, format, args);
    public static void LogCritical(string format, params object?[] args) => Log(LogCategory.Application, LogLevel.Critical, format, args);
    public static void LogError(LogCategory category, string format, params object?[] args) => Log(category, LogLevel.Error, format, args);
    public static void LogError(string format, params object?[] args) => Log(LogCategory.Application, LogLevel.Error, format, args);
    public static void LogWarning(LogCategory category, string format, params object?[] args) => Log(category, LogLevel.Warning, format, args);
    public static void LogWarning(string format, params object?[] args) => Log(LogCategory.Application, LogLevel.Warning, format, args);
    public static void LogInformation(LogCategory category, string format, params object?[] args) => Log(category, LogLevel.Information, format, args);
    public static void LogInformation(string format, params object?[] args) => Log(LogCategory.Application, LogLevel.Information, format, args);
    public static void LogDebug(LogCategory category, string format, params object?[] args) => Log(category, LogLevel.Debug, format, args);
    public static void LogDebug(string format, params object?[] args) => Log(LogCategory.Application, LogLevel.Debug, format, args);
    public static void LogVerbose(LogCategory category, string format, params object?[] args) => Log(category, LogLevel.Verbose, format, args);
    public static void LogVerbose(string format, params object?[] args) => Log(LogCategory.Application, LogLevel.Verbose, format, args);

    public static void SetOutputCallback(LogDelegate log, object? state) =>
        _ = Interlocked.Exchange(ref LoggerOutput, new LoggerOutput(log, state));

    public static LogDelegate? GetOutputCallback(out object? state)
    {
        state = LoggerOutput?.CallbackState;
        return LoggerOutput?.Callback;
    }

    public static void ResetOutputCallback()
    {
        _ = Interlocked.Exchange(ref LoggerOutput, null);
        LoggerOutput.ResetCallback();
    }
}

public enum LogCategory
{
    Application = SDL_LogCategory.SDL_LOG_CATEGORY_APPLICATION,
    Error = SDL_LogCategory.SDL_LOG_CATEGORY_ERROR,
    Assert = SDL_LogCategory.SDL_LOG_CATEGORY_ASSERT,
    System = SDL_LogCategory.SDL_LOG_CATEGORY_SYSTEM,
    Audio = SDL_LogCategory.SDL_LOG_CATEGORY_AUDIO,
    Video = SDL_LogCategory.SDL_LOG_CATEGORY_VIDEO,
    Render = SDL_LogCategory.SDL_LOG_CATEGORY_RENDER,
    Input = SDL_LogCategory.SDL_LOG_CATEGORY_INPUT,
    Test = SDL_LogCategory.SDL_LOG_CATEGORY_TEST,
    Custom = SDL_LogCategory.SDL_LOG_CATEGORY_CUSTOM,
}

public enum LogLevel
{
    Verbose = SDL_LogPriority.SDL_LOG_PRIORITY_VERBOSE,
    Debug = SDL_LogPriority.SDL_LOG_PRIORITY_DEBUG,
    Information = SDL_LogPriority.SDL_LOG_PRIORITY_INFO,
    Warning = SDL_LogPriority.SDL_LOG_PRIORITY_WARN,
    Error = SDL_LogPriority.SDL_LOG_PRIORITY_ERROR,
    Critical = SDL_LogPriority.SDL_LOG_PRIORITY_CRITICAL,
}

public delegate void LogDelegate(LogCategory category, LogLevel level, ReadOnlySpan<char> message, object? state);

internal sealed class LoggerOutput
{
    private static readonly unsafe delegate* unmanaged[Cdecl]<void*, int, SDL_LogPriority, byte*, void> DefaultCallback;
    private static readonly object Mutex = new();

    public readonly LogDelegate Callback;
    public readonly object? CallbackState;
    private readonly LogCallback _nativeCallback;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private unsafe delegate void LogCallback(void* userData, int category, SDL_LogPriority priority, byte* message);

    unsafe static LoggerOutput()
    {
        delegate* unmanaged[Cdecl]<void*, int, SDL_LogPriority, byte*, void> callback = null;
        void* userData = null;
        SDL.LogGetOutputFunction(&callback, &userData);
        DefaultCallback = callback;
    }

    public LoggerOutput(LogDelegate log, object? state)
    {
        Callback = log;
        CallbackState = state;

        unsafe
        {
            _nativeCallback = new LogCallback((_, category, priority, message) =>
            {
                var msgSpan = MemoryMarshal.CreateReadOnlySpanFromNullTerminated(message);
                var array = ArrayPool<char>.Shared.Rent(Encoding.UTF8.GetMaxCharCount(msgSpan.Length));
                try
                {
                    var charsWritten = Encoding.UTF8.GetChars(msgSpan, array);
                    Callback.Invoke((LogCategory)category, (LogLevel)priority, array.AsSpan(..charsWritten), CallbackState);
                }
                finally
                {
                    ArrayPool<char>.Shared.Return(array);
                }
            });
            var fPtr = (delegate* unmanaged[Cdecl]<void*, int, SDL_LogPriority, byte*, void>)Marshal.GetFunctionPointerForDelegate(_nativeCallback).ToPointer();

            SDL.LogSetOutputFunction(fPtr, null);
        }
    }


    public static void ResetCallback()
    {
        lock (Mutex)
        {
            unsafe
            {
                SDL.LogSetOutputFunction(DefaultCallback, null);
            }
        }
    }
}
