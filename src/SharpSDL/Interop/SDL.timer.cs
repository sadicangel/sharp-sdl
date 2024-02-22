using System.Runtime.InteropServices;

namespace SharpSDL.Interop;

internal static unsafe partial class SDL
{
    [LibraryImport("SDL2", EntryPoint = "SDL_GetTicks")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial uint GetTicks();

    [LibraryImport("SDL2", EntryPoint = "SDL_GetTicks64")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial ulong GetTicks64();

    [LibraryImport("SDL2", EntryPoint = "SDL_GetPerformanceCounter")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial ulong GetPerformanceCounter();

    [LibraryImport("SDL2", EntryPoint = "SDL_GetPerformanceFrequency")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial ulong GetPerformanceFrequency();

    [LibraryImport("SDL2", EntryPoint = "SDL_Delay")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void Delay(uint ms);

    [LibraryImport("SDL2", EntryPoint = "SDL_AddTimer")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("SDL_TimerID")]
    public static partial int AddTimer(uint interval, [NativeTypeName("SDL_TimerCallback")] delegate* unmanaged[Cdecl]<uint, void*, uint> callback, void* param2);

    [LibraryImport("SDL2", EntryPoint = "SDL_RemoveTimer")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool RemoveTimer([NativeTypeName("SDL_TimerID")] int id);
}
