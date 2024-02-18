using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using unsafe SDL_LogOutputFunction = delegate*<nint, int, SharpSDL.SDL.SDL_LogPriority, byte*, void>;

namespace SharpSDL;

internal static partial class SDL
{
    public enum SDL_LogCategory
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

        // Values starting at SDL_LOG_CATEGORY_CUSTOM are for application use.
        SDL_LOG_CATEGORY_CUSTOM
    }

    public enum SDL_LogPriority
    {
        SDL_LOG_PRIORITY_VERBOSE = 1,
        SDL_LOG_PRIORITY_DEBUG,
        SDL_LOG_PRIORITY_INFO,
        SDL_LOG_PRIORITY_WARN,
        SDL_LOG_PRIORITY_ERROR,
        SDL_LOG_PRIORITY_CRITICAL,
        SDL_NUM_LOG_PRIORITIES
    }

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial void SDL_Log(byte* message);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial void SDL_LogVerbose(int category, byte* message);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial void SDL_LogDebug(int category, byte* message);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial void SDL_LogInfo(int category, byte* message);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial void SDL_LogWarn(int category, byte* message);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial void SDL_LogError(int category, byte* message);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial void SDL_LogCritical(int category, byte* message);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial void SDL_LogMessage(int category, SDL_LogPriority priority, byte* message);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial void SDL_LogMessageV(int category, SDL_LogPriority priority, byte* message);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SDL_LogPriority SDL_LogGetPriority(int category);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_LogSetPriority(int category, SDL_LogPriority priority);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_LogSetAllPriority(SDL_LogPriority priority);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_LogResetPriorities();

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial void SDL_LogGetOutputFunction(out SDL_LogOutputFunction callback, out nint userData);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial void SDL_LogSetOutputFunction(SDL_LogOutputFunction callback, nint userData);
}
