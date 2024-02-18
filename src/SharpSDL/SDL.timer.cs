using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpSDL;
internal static partial class SDL
{
    // /* System timers rely on different OS mechanisms depending on
    //* which operating system SDL2 is compiled against.
    //*/

    // /* Compare tick values, return true if A has passed B. Introduced in SDL 2.0.1,
    //* but does not require it (it was a macro).
    //*/
    // public static bool SDL_TICKS_PASSED(uint A, uint B)
    // {
    //     return (int)(B - A) <= 0;
    // }

    // Delays the thread's processing based on the milliseconds parameter
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_Delay(uint ms);

    // Returns the milliseconds that have passed since SDL was initialized.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint SDL_GetTicks();

    // Returns the milliseconds that have passed since SDL was initialized.
    // 2.0.18 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ulong SDL_GetTicks64();

    // Get the current value of the high resolution counter.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ulong SDL_GetPerformanceCounter();

    // Get the count per second of the high resolution counter.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ulong SDL_GetPerformanceFrequency();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint SDL_TimerCallback(uint interval, nint param);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial /*SDL_TimerID*/ int SDL_AddTimer(uint interval, SDL_TimerCallback callback, nint param);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SDL_bool SDL_RemoveTimer(/*SDL_TimerID*/ int id);
}
