using System.Runtime.InteropServices;

namespace SharpSDL.Interop;

[Flags]
public enum InitFlags : uint
{
    [NativeTypeName("#define SDL_INIT_TIMER 0x00000001u")]
    TIMER = 0x00000001U,
    [NativeTypeName("#define SDL_INIT_AUDIO 0x00000010u")]
    AUDIO = 0x00000010U,
    [NativeTypeName("#define SDL_INIT_VIDEO 0x00000020u")]
    VIDEO = 0x00000020U,
    [NativeTypeName("#define SDL_INIT_JOYSTICK 0x00000200u")]
    JOYSTICK = 0x00000200U,
    [NativeTypeName("#define SDL_INIT_HAPTIC 0x00001000u")]
    HAPTIC = 0x00001000U,
    [NativeTypeName("#define SDL_INIT_GAMECONTROLLER 0x00002000u")]
    GAMECONTROLLER = 0x00002000U,
    [NativeTypeName("#define SDL_INIT_EVENTS 0x00004000u")]
    EVENTS = 0x00004000U,
    [NativeTypeName("#define SDL_INIT_SENSOR 0x00008000u")]
    SENSOR = 0x00008000U,
    [NativeTypeName("#define SDL_INIT_NOPARACHUTE 0x00100000u")]
    NOPARACHUTE = 0x00100000U,
    [NativeTypeName("#define SDL_INIT_EVERYTHING ( \\\r\n                SDL_INIT_TIMER | SDL_INIT_AUDIO | SDL_INIT_VIDEO | SDL_INIT_EVENTS | \\\r\n                SDL_INIT_JOYSTICK | SDL_INIT_HAPTIC | SDL_INIT_GAMECONTROLLER | SDL_INIT_SENSOR \\\r\n            )")]
    EVERYTHING = (0x00000001U | 0x00000010U | 0x00000020U | 0x00004000U | 0x00000200U | 0x00001000U | 0x00002000U | 0x00008000U),
}

public static partial class SDL
{
    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_Init", ExactSpelling = true)]
    public static extern int Init(InitFlags flags);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_InitSubSystem", ExactSpelling = true)]
    public static extern int InitSubSystem(InitFlags flags);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_QuitSubSystem", ExactSpelling = true)]
    public static extern void QuitSubSystem(InitFlags flags);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WasInit", ExactSpelling = true)]
    public static extern uint WasInit(InitFlags flags);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_Quit", ExactSpelling = true)]
    public static extern void Quit();
}
