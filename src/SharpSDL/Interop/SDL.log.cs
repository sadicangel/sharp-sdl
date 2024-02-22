using System.Runtime.InteropServices;

namespace SharpSDL.Interop;

public enum LogCategory
{
    APPLICATION,
    ERROR,
    ASSERT,
    SYSTEM,
    AUDIO,
    VIDEO,
    RENDER,
    INPUT,
    TEST,
    RESERVED1,
    RESERVED2,
    RESERVED3,
    RESERVED4,
    RESERVED5,
    RESERVED6,
    RESERVED7,
    RESERVED8,
    RESERVED9,
    RESERVED10,
    CUSTOM,
}

public enum LogPriority
{
    VERBOSE = 1,
    DEBUG,
    INFO,
    WARN,
    ERROR,
    CRITICAL,
    CUSTOM,
}

public static unsafe partial class SDL
{
    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogSetAllPriority", ExactSpelling = true)]
    public static extern void LogSetAllPriority(LogPriority priority);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogSetPriority", ExactSpelling = true)]
    public static extern void LogSetPriority(int category, LogPriority priority);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogGetPriority", ExactSpelling = true)]
    public static extern LogPriority LogGetPriority(int category);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogResetPriorities", ExactSpelling = true)]
    public static extern void LogResetPriorities();

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_Log", ExactSpelling = true)]
    public static extern void Log([NativeTypeName("const char *")] byte* fmt, __arglist);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogVerbose", ExactSpelling = true)]
    public static extern void LogVerbose(int category, [NativeTypeName("const char *")] byte* fmt, __arglist);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogDebug", ExactSpelling = true)]
    public static extern void LogDebug(int category, [NativeTypeName("const char *")] byte* fmt, __arglist);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogInfo", ExactSpelling = true)]
    public static extern void LogInfo(int category, [NativeTypeName("const char *")] byte* fmt, __arglist);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogWarn", ExactSpelling = true)]
    public static extern void LogWarn(int category, [NativeTypeName("const char *")] byte* fmt, __arglist);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogError", ExactSpelling = true)]
    public static extern void LogError(int category, [NativeTypeName("const char *")] byte* fmt, __arglist);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogCritical", ExactSpelling = true)]
    public static extern void LogCritical(int category, [NativeTypeName("const char *")] byte* fmt, __arglist);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogMessage", ExactSpelling = true)]
    public static extern void LogMessage(int category, LogPriority priority, [NativeTypeName("const char *")] byte* fmt, __arglist);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogMessageV", ExactSpelling = true)]
    public static extern void LogMessageV(int category, LogPriority priority, [NativeTypeName("const char *")] byte* fmt, [NativeTypeName("va_list")] byte* ap);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogGetOutputFunction", ExactSpelling = true)]
    public static extern void LogGetOutputFunction([NativeTypeName("SDL_LogOutputFunction *")] delegate* unmanaged[Cdecl]<void*, int, LogPriority, byte*, void>* callback, void** userdata);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogSetOutputFunction", ExactSpelling = true)]
    public static extern void LogSetOutputFunction([NativeTypeName("SDL_LogOutputFunction")] delegate* unmanaged[Cdecl]<void*, int, LogPriority, byte*, void> callback, void* userdata);

    [NativeTypeName("#define SDL_MAX_LOG_MESSAGE 4096")]
    public const int SDL_MAX_LOG_MESSAGE = 4096;
}
