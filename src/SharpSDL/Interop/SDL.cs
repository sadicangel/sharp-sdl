using System.Runtime.InteropServices;

namespace SharpSDL.Interop;

internal static partial class SDL
{
    [LibraryImport("SDL2", EntryPoint = "SDL_Init")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int Init(uint flags);

    [LibraryImport("SDL2", EntryPoint = "SDL_InitSubSystem")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int InitSubSystem(uint flags);

    [LibraryImport("SDL2", EntryPoint = "SDL_QuitSubSystem")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void QuitSubSystem(uint flags);

    [LibraryImport("SDL2", EntryPoint = "SDL_WasInit")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial uint WasInit(uint flags);

    [LibraryImport("SDL2", EntryPoint = "SDL_Quit")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void Quit();

    [NativeTypeName("#define SDL_INIT_TIMER 0x00000001u")]
    public const uint SDL_INIT_TIMER = 0x00000001U;

    [NativeTypeName("#define SDL_INIT_AUDIO 0x00000010u")]
    public const uint SDL_INIT_AUDIO = 0x00000010U;

    [NativeTypeName("#define SDL_INIT_VIDEO 0x00000020u")]
    public const uint SDL_INIT_VIDEO = 0x00000020U;

    [NativeTypeName("#define SDL_INIT_JOYSTICK 0x00000200u")]
    public const uint SDL_INIT_JOYSTICK = 0x00000200U;

    [NativeTypeName("#define SDL_INIT_HAPTIC 0x00001000u")]
    public const uint SDL_INIT_HAPTIC = 0x00001000U;

    [NativeTypeName("#define SDL_INIT_GAMECONTROLLER 0x00002000u")]
    public const uint SDL_INIT_GAMECONTROLLER = 0x00002000U;

    [NativeTypeName("#define SDL_INIT_EVENTS 0x00004000u")]
    public const uint SDL_INIT_EVENTS = 0x00004000U;

    [NativeTypeName("#define SDL_INIT_SENSOR 0x00008000u")]
    public const uint SDL_INIT_SENSOR = 0x00008000U;

    [NativeTypeName("#define SDL_INIT_NOPARACHUTE 0x00100000u")]
    public const uint SDL_INIT_NOPARACHUTE = 0x00100000U;

    [NativeTypeName("#define SDL_INIT_EVERYTHING ( \\\r\n                SDL_INIT_TIMER | SDL_INIT_AUDIO | SDL_INIT_VIDEO | SDL_INIT_EVENTS | \\\r\n                SDL_INIT_JOYSTICK | SDL_INIT_HAPTIC | SDL_INIT_GAMECONTROLLER | SDL_INIT_SENSOR \\\r\n            )")]
    public const uint SDL_INIT_EVERYTHING = (0x00000001U | 0x00000010U | 0x00000020U | 0x00004000U | 0x00000200U | 0x00001000U | 0x00002000U | 0x00008000U);
}