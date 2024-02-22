using System.Runtime.InteropServices;

namespace SharpSDL.Interop;

internal enum SDL_PowerState
{
    SDL_POWERSTATE_UNKNOWN,
    SDL_POWERSTATE_ON_BATTERY,
    SDL_POWERSTATE_NO_BATTERY,
    SDL_POWERSTATE_CHARGING,
    SDL_POWERSTATE_CHARGED,
}

internal static unsafe partial class SDL
{
    [LibraryImport("SDL2", EntryPoint = "SDL_GetPowerInfo")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial SDL_PowerState GetPowerInfo(int* seconds, int* percent);
}
