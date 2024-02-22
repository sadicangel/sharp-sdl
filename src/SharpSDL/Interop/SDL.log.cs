using System.Runtime.InteropServices;

namespace SharpSDL.Interop;

internal enum SDL_LogCategory
{
    SDL_LOG_CATEGORY_APPLICATION,
    SDL_LOG_CATEGORY_ERROR,
    SDL_LOG_CATEGORY_ASSERT,
    SDL_LOG_CATEGORY_SYSTEM,
    SDL_LOG_CATEGORY_AUDIO,
    SDL_LOG_CATEGORY_VIDEO,
    SDL_LOG_CATEGORY_RENDER,
    SDL_LOG_CATEGORY_INPUT,
    SDL_LOG_CATEGORY_TEST,
    SDL_LOG_CATEGORY_RESERVED1,
    SDL_LOG_CATEGORY_RESERVED2,
    SDL_LOG_CATEGORY_RESERVED3,
    SDL_LOG_CATEGORY_RESERVED4,
    SDL_LOG_CATEGORY_RESERVED5,
    SDL_LOG_CATEGORY_RESERVED6,
    SDL_LOG_CATEGORY_RESERVED7,
    SDL_LOG_CATEGORY_RESERVED8,
    SDL_LOG_CATEGORY_RESERVED9,
    SDL_LOG_CATEGORY_RESERVED10,
    SDL_LOG_CATEGORY_CUSTOM,
}

internal enum SDL_LogPriority
{
    SDL_LOG_PRIORITY_VERBOSE = 1,
    SDL_LOG_PRIORITY_DEBUG,
    SDL_LOG_PRIORITY_INFO,
    SDL_LOG_PRIORITY_WARN,
    SDL_LOG_PRIORITY_ERROR,
    SDL_LOG_PRIORITY_CRITICAL,
    SDL_NUM_LOG_PRIORITIES,
}

internal static unsafe partial class SDL
{
    [LibraryImport("SDL2", EntryPoint = "SDL_LogSetAllPriority")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void LogSetAllPriority(SDL_LogPriority priority);

    [LibraryImport("SDL2", EntryPoint = "SDL_LogSetPriority")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void LogSetPriority(int category, SDL_LogPriority priority);

    [LibraryImport("SDL2", EntryPoint = "SDL_LogGetPriority")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial SDL_LogPriority LogGetPriority(int category);

    [LibraryImport("SDL2", EntryPoint = "SDL_LogResetPriorities")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void LogResetPriorities();

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
    public static extern void LogMessage(int category, SDL_LogPriority priority, [NativeTypeName("const char *")] byte* fmt, __arglist);

    [LibraryImport("SDL2", EntryPoint = "SDL_LogMessageV")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void LogMessageV(int category, SDL_LogPriority priority, [NativeTypeName("const char *")] byte* fmt, [NativeTypeName("va_list")] byte* ap);

    [LibraryImport("SDL2", EntryPoint = "SDL_LogGetOutputFunction")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void LogGetOutputFunction([NativeTypeName("SDL_LogOutputFunction *")] delegate* unmanaged[Cdecl]<void*, int, SDL_LogPriority, byte*, void>* callback, void** userdata);

    [LibraryImport("SDL2", EntryPoint = "SDL_LogSetOutputFunction")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void LogSetOutputFunction([NativeTypeName("SDL_LogOutputFunction")] delegate* unmanaged[Cdecl]<void*, int, SDL_LogPriority, byte*, void> callback, void* userdata);

    [NativeTypeName("#define SDL_MAX_LOG_MESSAGE 4096")]
    public const int SDL_MAX_LOG_MESSAGE = 4096;
}
