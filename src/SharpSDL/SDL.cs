using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpSDL;
internal static partial class SDL
{
    public const string DllName = "SDL2";

    public const uint SDL_INIT_TIMER = 0x00000001;
    public const uint SDL_INIT_AUDIO = 0x00000010;
    public const uint SDL_INIT_VIDEO = 0x00000020;
    public const uint SDL_INIT_JOYSTICK = 0x00000200;
    public const uint SDL_INIT_HAPTIC = 0x00001000;
    public const uint SDL_INIT_GAMECONTROLLER = 0x00002000;
    public const uint SDL_INIT_EVENTS = 0x00004000;
    public const uint SDL_INIT_SENSOR = 0x00008000;
    public const uint SDL_INIT_NOPARACHUTE = 0x00100000;
    public const uint SDL_INIT_EVERYTHING =
        SDL_INIT_TIMER | SDL_INIT_AUDIO | SDL_INIT_VIDEO |
        SDL_INIT_EVENTS | SDL_INIT_JOYSTICK | SDL_INIT_HAPTIC |
        SDL_INIT_GAMECONTROLLER | SDL_INIT_SENSOR
    ;

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_Init(uint flags);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_InitSubSystem(uint flags);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_Quit();

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_QuitSubSystem(uint flags);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint SDL_WasInit(uint flags);
}
