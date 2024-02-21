using System.Runtime.InteropServices;

namespace SharpSDL.Interop
{
    public partial struct _SDL_GameController
    {
    }

    public enum GameControllerType
    {
        UNKNOWN = 0,
        XBOX360,
        XBOXONE,
        PS3,
        PS4,
        NINTENDO_SWITCH_PRO,
        VIRTUAL,
        PS5,
        AMAZON_LUNA,
        GOOGLE_STADIA,
        NVIDIA_SHIELD,
        NINTENDO_SWITCH_JOYCON_LEFT,
        NINTENDO_SWITCH_JOYCON_RIGHT,
        NINTENDO_SWITCH_JOYCON_PAIR,
        MAX,
    }

    public enum GameControllerBindType
    {
        NONE = 0,
        BUTTON,
        AXIS,
        HAT,
    }

    public partial struct GameControllerButtonBind
    {
        public GameControllerBindType bindType;

        [NativeTypeName("__AnonymousRecord_SDL_gamecontroller_L94_C5")]
        public _value_e__Union value;

        [StructLayout(LayoutKind.Explicit)]
        public partial struct _value_e__Union
        {
            [FieldOffset(0)]
            public int button;

            [FieldOffset(0)]
            public int axis;

            [FieldOffset(0)]
            [NativeTypeName("__AnonymousRecord_SDL_gamecontroller_L98_C9")]
            public _hat_e__Struct hat;

            public partial struct _hat_e__Struct
            {
                public int hat;

                public int hat_mask;
            }
        }
    }

    public enum GameControllerAxis
    {
        INVALID = -1,
        LEFTX,
        LEFTY,
        RIGHTX,
        RIGHTY,
        TRIGGERLEFT,
        TRIGGERRIGHT,
        MAX,
    }

    public enum GameControllerButton
    {
        INVALID = -1,
        A,
        B,
        X,
        Y,
        BACK,
        GUIDE,
        START,
        LEFTSTICK,
        RIGHTSTICK,
        LEFTSHOULDER,
        RIGHTSHOULDER,
        DPAD_UP,
        DPAD_DOWN,
        DPAD_LEFT,
        DPAD_RIGHT,
        MISC1,
        PADDLE1,
        PADDLE2,
        PADDLE3,
        PADDLE4,
        TOUCHPAD,
        MAX,
    }

    public static unsafe partial class SDL
    {
        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerAddMappingsFromRW", ExactSpelling = true)]
        public static extern int GameControllerAddMappingsFromRW(RWops* rw, int freerw);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerAddMapping", ExactSpelling = true)]
        public static extern int GameControllerAddMapping([NativeTypeName("const char *")] byte* mappingString);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerNumMappings", ExactSpelling = true)]
        public static extern int GameControllerNumMappings();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerMappingForIndex", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern byte* GameControllerMappingForIndex(int mapping_index);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerMappingForGUID", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern byte* GameControllerMappingForGUID([NativeTypeName("SDL_JoystickGUID")] GUID guid);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerMapping", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern byte* GameControllerMapping([NativeTypeName("SDL_GameController *")] _SDL_GameController* gamecontroller);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_IsGameController", ExactSpelling = true)]
        public static extern CBool IsGameController(int joystick_index);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerNameForIndex", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern byte* GameControllerNameForIndex(int joystick_index);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerPathForIndex", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern byte* GameControllerPathForIndex(int joystick_index);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GameControllerTypeForIndex", ExactSpelling = true)]
        public static extern GameControllerType GameControllerTypeForIndex(int joystick_index);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerMappingForDeviceIndex", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern byte* GameControllerMappingForDeviceIndex(int joystick_index);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerOpen", ExactSpelling = true)]
        [return: NativeTypeName("SDL_GameController *")]
        public static extern _SDL_GameController* GameControllerOpen(int joystick_index);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerFromInstanceID", ExactSpelling = true)]
        [return: NativeTypeName("SDL_GameController *")]
        public static extern _SDL_GameController* GameControllerFromInstanceID([NativeTypeName("SDL_JoystickID")] int joyid);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerFromPlayerIndex", ExactSpelling = true)]
        [return: NativeTypeName("SDL_GameController *")]
        public static extern _SDL_GameController* GameControllerFromPlayerIndex(int player_index);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerName", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern byte* GameControllerName([NativeTypeName("SDL_GameController *")] _SDL_GameController* gamecontroller);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerPath", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern byte* GameControllerPath([NativeTypeName("SDL_GameController *")] _SDL_GameController* gamecontroller);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetType", ExactSpelling = true)]
        public static extern GameControllerType GameControllerGetType([NativeTypeName("SDL_GameController *")] _SDL_GameController* gamecontroller);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetPlayerIndex", ExactSpelling = true)]
        public static extern int GameControllerGetPlayerIndex([NativeTypeName("SDL_GameController *")] _SDL_GameController* gamecontroller);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerSetPlayerIndex", ExactSpelling = true)]
        public static extern void GameControllerSetPlayerIndex([NativeTypeName("SDL_GameController *")] _SDL_GameController* gamecontroller, int player_index);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetVendor", ExactSpelling = true)]
        public static extern ushort GameControllerGetVendor([NativeTypeName("SDL_GameController *")] _SDL_GameController* gamecontroller);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetProduct", ExactSpelling = true)]
        public static extern ushort GameControllerGetProduct([NativeTypeName("SDL_GameController *")] _SDL_GameController* gamecontroller);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetProductVersion", ExactSpelling = true)]
        public static extern ushort GameControllerGetProductVersion([NativeTypeName("SDL_GameController *")] _SDL_GameController* gamecontroller);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetFirmwareVersion", ExactSpelling = true)]
        public static extern ushort GameControllerGetFirmwareVersion([NativeTypeName("SDL_GameController *")] _SDL_GameController* gamecontroller);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetSerial", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern byte* GameControllerGetSerial([NativeTypeName("SDL_GameController *")] _SDL_GameController* gamecontroller);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetSteamHandle", ExactSpelling = true)]
        public static extern ulong GameControllerGetSteamHandle([NativeTypeName("SDL_GameController *")] _SDL_GameController* gamecontroller);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetAttached", ExactSpelling = true)]
        public static extern CBool GameControllerGetAttached([NativeTypeName("SDL_GameController *")] _SDL_GameController* gamecontroller);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetJoystick", ExactSpelling = true)]
        [return: NativeTypeName("SDL_Joystick *")]
        public static extern _SDL_Joystick* GameControllerGetJoystick([NativeTypeName("SDL_GameController *")] _SDL_GameController* gamecontroller);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerEventState", ExactSpelling = true)]
        public static extern int GameControllerEventState(int state);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerUpdate", ExactSpelling = true)]
        public static extern void GameControllerUpdate();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetAxisFromString", ExactSpelling = true)]
        public static extern GameControllerAxis GameControllerGetAxisFromString([NativeTypeName("const char *")] byte* str);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetStringForAxis", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern byte* GameControllerGetStringForAxis(GameControllerAxis axis);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetBindForAxis", ExactSpelling = true)]
        public static extern GameControllerButtonBind GameControllerGetBindForAxis([NativeTypeName("SDL_GameController *")] _SDL_GameController* gamecontroller, GameControllerAxis axis);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerHasAxis", ExactSpelling = true)]
        public static extern CBool GameControllerHasAxis([NativeTypeName("SDL_GameController *")] _SDL_GameController* gamecontroller, GameControllerAxis axis);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetAxis", ExactSpelling = true)]
        public static extern short GameControllerGetAxis([NativeTypeName("SDL_GameController *")] _SDL_GameController* gamecontroller, GameControllerAxis axis);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetButtonFromString", ExactSpelling = true)]
        public static extern GameControllerButton GameControllerGetButtonFromString([NativeTypeName("const char *")] byte* str);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetStringForButton", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern byte* GameControllerGetStringForButton(GameControllerButton button);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetBindForButton", ExactSpelling = true)]
        public static extern GameControllerButtonBind GameControllerGetBindForButton([NativeTypeName("SDL_GameController *")] _SDL_GameController* gamecontroller, GameControllerButton button);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerHasButton", ExactSpelling = true)]
        public static extern CBool GameControllerHasButton([NativeTypeName("SDL_GameController *")] _SDL_GameController* gamecontroller, GameControllerButton button);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetButton", ExactSpelling = true)]
        public static extern byte GameControllerGetButton([NativeTypeName("SDL_GameController *")] _SDL_GameController* gamecontroller, GameControllerButton button);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetNumTouchpads", ExactSpelling = true)]
        public static extern int GameControllerGetNumTouchpads([NativeTypeName("SDL_GameController *")] _SDL_GameController* gamecontroller);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetNumTouchpadFingers", ExactSpelling = true)]
        public static extern int GameControllerGetNumTouchpadFingers([NativeTypeName("SDL_GameController *")] _SDL_GameController* gamecontroller, int touchpad);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetTouchpadFinger", ExactSpelling = true)]
        public static extern int GameControllerGetTouchpadFinger([NativeTypeName("SDL_GameController *")] _SDL_GameController* gamecontroller, int touchpad, int finger, [NativeTypeName(" *")] byte* state, float* x, float* y, float* pressure);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerHasSensor", ExactSpelling = true)]
        public static extern CBool GameControllerHasSensor([NativeTypeName("SDL_GameController *")] _SDL_GameController* gamecontroller, SensorType type);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerSetSensorEnabled", ExactSpelling = true)]
        public static extern int GameControllerSetSensorEnabled([NativeTypeName("SDL_GameController *")] _SDL_GameController* gamecontroller, SensorType type, CBool enabled);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerIsSensorEnabled", ExactSpelling = true)]
        public static extern CBool GameControllerIsSensorEnabled([NativeTypeName("SDL_GameController *")] _SDL_GameController* gamecontroller, SensorType type);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetSensorDataRate", ExactSpelling = true)]
        public static extern float GameControllerGetSensorDataRate([NativeTypeName("SDL_GameController *")] _SDL_GameController* gamecontroller, SensorType type);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetSensorData", ExactSpelling = true)]
        public static extern int GameControllerGetSensorData([NativeTypeName("SDL_GameController *")] _SDL_GameController* gamecontroller, SensorType type, float* data, int num_values);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetSensorDataWithTimestamp", ExactSpelling = true)]
        public static extern int GameControllerGetSensorDataWithTimestamp([NativeTypeName("SDL_GameController *")] _SDL_GameController* gamecontroller, SensorType type, [NativeTypeName(" *")] ulong* timestamp, float* data, int num_values);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerRumble", ExactSpelling = true)]
        public static extern int GameControllerRumble([NativeTypeName("SDL_GameController *")] _SDL_GameController* gamecontroller, ushort low_frequency_rumble, ushort high_frequency_rumble, uint duration_ms);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerRumbleTriggers", ExactSpelling = true)]
        public static extern int GameControllerRumbleTriggers([NativeTypeName("SDL_GameController *")] _SDL_GameController* gamecontroller, ushort left_rumble, ushort right_rumble, uint duration_ms);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerHasLED", ExactSpelling = true)]
        public static extern CBool GameControllerHasLED([NativeTypeName("SDL_GameController *")] _SDL_GameController* gamecontroller);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerHasRumble", ExactSpelling = true)]
        public static extern CBool GameControllerHasRumble([NativeTypeName("SDL_GameController *")] _SDL_GameController* gamecontroller);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerHasRumbleTriggers", ExactSpelling = true)]
        public static extern CBool GameControllerHasRumbleTriggers([NativeTypeName("SDL_GameController *")] _SDL_GameController* gamecontroller);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerSetLED", ExactSpelling = true)]
        public static extern int GameControllerSetLED([NativeTypeName("SDL_GameController *")] _SDL_GameController* gamecontroller, byte red, byte green, byte blue);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerSendEffect", ExactSpelling = true)]
        public static extern int GameControllerSendEffect([NativeTypeName("SDL_GameController *")] _SDL_GameController* gamecontroller, [NativeTypeName("const void *")] void* data, int size);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerClose", ExactSpelling = true)]
        public static extern void GameControllerClose([NativeTypeName("SDL_GameController *")] _SDL_GameController* gamecontroller);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetAppleSFSymbolsNameForButton", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern byte* GameControllerGetAppleSFSymbolsNameForButton([NativeTypeName("SDL_GameController *")] _SDL_GameController* gamecontroller, GameControllerButton button);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetAppleSFSymbolsNameForAxis", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern byte* GameControllerGetAppleSFSymbolsNameForAxis([NativeTypeName("SDL_GameController *")] _SDL_GameController* gamecontroller, GameControllerAxis axis);
    }
}
