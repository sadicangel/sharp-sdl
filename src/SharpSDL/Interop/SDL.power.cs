using System.Runtime.InteropServices;

namespace SharpSDL.Interop;

public enum PowerState
{
    UNKNOWN,
    ON_BATTERY,
    NO_BATTERY,
    CHARGING,
    CHARGED,
}

public static unsafe partial class SDL
{
    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetPowerInfo", ExactSpelling = true)]
    public static extern PowerState GetPowerInfo(int* seconds, int* percent);
}
