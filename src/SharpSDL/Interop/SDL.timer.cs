using System.Runtime.InteropServices;

namespace SharpSDL.Interop;

public static unsafe partial class SDL
{
    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetTicks", ExactSpelling = true)]
    public static extern uint GetTicks();

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetTicks64", ExactSpelling = true)]
    public static extern ulong GetTicks64();

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetPerformanceCounter", ExactSpelling = true)]
    public static extern ulong GetPerformanceCounter();

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetPerformanceFrequency", ExactSpelling = true)]
    public static extern ulong GetPerformanceFrequency();

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_Delay", ExactSpelling = true)]
    public static extern void Delay(uint ms);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_AddTimer", ExactSpelling = true)]
    [return: NativeTypeName("SDL_TimerID")]
    public static extern int AddTimer(uint interval, [NativeTypeName("SDL_TimerCallback")] delegate* unmanaged[Cdecl]<uint, void*, uint> callback, void* param2);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RemoveTimer", ExactSpelling = true)]
    public static extern CBool RemoveTimer([NativeTypeName("SDL_TimerID")] int id);
}
