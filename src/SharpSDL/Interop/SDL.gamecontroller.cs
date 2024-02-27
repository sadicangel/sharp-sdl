namespace SharpSDL.Interop;

internal enum SDL_GameControllerType
{
    SDL_CONTROLLER_TYPE_UNKNOWN = 0,
    SDL_CONTROLLER_TYPE_XBOX360,
    SDL_CONTROLLER_TYPE_XBOXONE,
    SDL_CONTROLLER_TYPE_PS3,
    SDL_CONTROLLER_TYPE_PS4,
    SDL_CONTROLLER_TYPE_NINTENDO_SWITCH_PRO,
    SDL_CONTROLLER_TYPE_VIRTUAL,
    SDL_CONTROLLER_TYPE_PS5,
    SDL_CONTROLLER_TYPE_AMAZON_LUNA,
    SDL_CONTROLLER_TYPE_GOOGLE_STADIA,
    SDL_CONTROLLER_TYPE_NVIDIA_SHIELD,
    SDL_CONTROLLER_TYPE_NINTENDO_SWITCH_JOYCON_LEFT,
    SDL_CONTROLLER_TYPE_NINTENDO_SWITCH_JOYCON_RIGHT,
    SDL_CONTROLLER_TYPE_NINTENDO_SWITCH_JOYCON_PAIR,
    SDL_CONTROLLER_TYPE_MAX,
}

internal enum SDL_GameControllerBindType
{
    SDL_CONTROLLER_BINDTYPE_NONE = 0,
    SDL_CONTROLLER_BINDTYPE_BUTTON,
    SDL_CONTROLLER_BINDTYPE_AXIS,
    SDL_CONTROLLER_BINDTYPE_HAT,
}

internal partial struct SDL_GameControllerButtonBind
{
    public SDL_GameControllerBindType bindType;

    [NativeTypeName("__AnonymousRecord_SDL_gamecontroller_L94_C5")]
    public _value_e__Union value;

    [StructLayout(LayoutKind.Explicit)]
    internal partial struct _value_e__Union
    {
        [FieldOffset(0)]
        public int button;

        [FieldOffset(0)]
        public int axis;

        [FieldOffset(0)]
        [NativeTypeName("__AnonymousRecord_SDL_gamecontroller_L98_C9")]
        public _hat_e__Struct hat;

        internal partial struct _hat_e__Struct
        {
            public int hat;

            public int hat_mask;
        }
    }
}

internal enum SDL_GameControllerAxis
{
    SDL_CONTROLLER_AXIS_INVALID = -1,
    SDL_CONTROLLER_AXIS_LEFTX,
    SDL_CONTROLLER_AXIS_LEFTY,
    SDL_CONTROLLER_AXIS_RIGHTX,
    SDL_CONTROLLER_AXIS_RIGHTY,
    SDL_CONTROLLER_AXIS_TRIGGERLEFT,
    SDL_CONTROLLER_AXIS_TRIGGERRIGHT,
    SDL_CONTROLLER_AXIS_MAX,
}

internal enum SDL_GameControllerButton
{
    SDL_CONTROLLER_BUTTON_INVALID = -1,
    SDL_CONTROLLER_BUTTON_A,
    SDL_CONTROLLER_BUTTON_B,
    SDL_CONTROLLER_BUTTON_X,
    SDL_CONTROLLER_BUTTON_Y,
    SDL_CONTROLLER_BUTTON_BACK,
    SDL_CONTROLLER_BUTTON_GUIDE,
    SDL_CONTROLLER_BUTTON_START,
    SDL_CONTROLLER_BUTTON_LEFTSTICK,
    SDL_CONTROLLER_BUTTON_RIGHTSTICK,
    SDL_CONTROLLER_BUTTON_LEFTSHOULDER,
    SDL_CONTROLLER_BUTTON_RIGHTSHOULDER,
    SDL_CONTROLLER_BUTTON_DPAD_UP,
    SDL_CONTROLLER_BUTTON_DPAD_DOWN,
    SDL_CONTROLLER_BUTTON_DPAD_LEFT,
    SDL_CONTROLLER_BUTTON_DPAD_RIGHT,
    SDL_CONTROLLER_BUTTON_MISC1,
    SDL_CONTROLLER_BUTTON_PADDLE1,
    SDL_CONTROLLER_BUTTON_PADDLE2,
    SDL_CONTROLLER_BUTTON_PADDLE3,
    SDL_CONTROLLER_BUTTON_PADDLE4,
    SDL_CONTROLLER_BUTTON_TOUCHPAD,
    SDL_CONTROLLER_BUTTON_MAX,
}

internal static unsafe partial class SDL
{
    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerAddMappingsFromRW")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GameControllerAddMappingsFromRW(SDL_RWops* rw, int freerw);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerAddMapping")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GameControllerAddMapping([NativeTypeName("const char *")] byte* mappingString);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerNumMappings")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GameControllerNumMappings();

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerMappingForIndex")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("char *")]
    public static partial byte* GameControllerMappingForIndex(int mapping_index);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerMappingForGUID")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("char *")]
    public static partial byte* GameControllerMappingForGUID([NativeTypeName("SDL_JoystickGUID")] SDL_GUID guid);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerMapping")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("char *")]
    public static partial byte* GameControllerMapping([NativeTypeName("SDL_GameController *")] nint gamecontroller);

    [LibraryImport("SDL2", EntryPoint = "SDL_IsGameController")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool IsGameController(int joystick_index);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerNameForIndex")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("const char *")]
    public static partial byte* GameControllerNameForIndex(int joystick_index);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerPathForIndex")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("const char *")]
    public static partial byte* GameControllerPathForIndex(int joystick_index);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerTypeForIndex")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SDL_GameControllerType GameControllerTypeForIndex(int joystick_index);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerMappingForDeviceIndex")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("char *")]
    public static partial byte* GameControllerMappingForDeviceIndex(int joystick_index);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerOpen")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_GameController *")]
    public static partial nint GameControllerOpen(int joystick_index);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerFromInstanceID")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_GameController *")]
    public static partial nint GameControllerFromInstanceID([NativeTypeName("SDL_JoystickID")] int joyid);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerFromPlayerIndex")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_GameController *")]
    public static partial nint GameControllerFromPlayerIndex(int player_index);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerName")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("const char *")]
    public static partial byte* GameControllerName([NativeTypeName("SDL_GameController *")] nint gamecontroller);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerPath")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("const char *")]
    public static partial byte* GameControllerPath([NativeTypeName("SDL_GameController *")] nint gamecontroller);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerGetType")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SDL_GameControllerType GameControllerGetType([NativeTypeName("SDL_GameController *")] nint gamecontroller);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerGetPlayerIndex")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GameControllerGetPlayerIndex([NativeTypeName("SDL_GameController *")] nint gamecontroller);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerSetPlayerIndex")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void GameControllerSetPlayerIndex([NativeTypeName("SDL_GameController *")] nint gamecontroller, int player_index);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerGetVendor")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ushort GameControllerGetVendor([NativeTypeName("SDL_GameController *")] nint gamecontroller);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerGetProduct")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ushort GameControllerGetProduct([NativeTypeName("SDL_GameController *")] nint gamecontroller);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerGetProductVersion")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ushort GameControllerGetProductVersion([NativeTypeName("SDL_GameController *")] nint gamecontroller);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerGetFirmwareVersion")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ushort GameControllerGetFirmwareVersion([NativeTypeName("SDL_GameController *")] nint gamecontroller);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerGetSerial")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("const char *")]
    public static partial byte* GameControllerGetSerial([NativeTypeName("SDL_GameController *")] nint gamecontroller);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerGetSteamHandle")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ulong GameControllerGetSteamHandle([NativeTypeName("SDL_GameController *")] nint gamecontroller);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerGetAttached")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool GameControllerGetAttached([NativeTypeName("SDL_GameController *")] nint gamecontroller);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerGetJoystick")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_Joystick *")]
    public static partial nint GameControllerGetJoystick([NativeTypeName("SDL_GameController *")] nint gamecontroller);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerEventState")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GameControllerEventState(int state);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerUpdate")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void GameControllerUpdate();

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerGetAxisFromString")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SDL_GameControllerAxis GameControllerGetAxisFromString([NativeTypeName("const char *")] byte* str);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerGetStringForAxis")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("const char *")]
    public static partial byte* GameControllerGetStringForAxis(SDL_GameControllerAxis axis);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerGetBindForAxis")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SDL_GameControllerButtonBind GameControllerGetBindForAxis([NativeTypeName("SDL_GameController *")] nint gamecontroller, SDL_GameControllerAxis axis);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerHasAxis")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool GameControllerHasAxis([NativeTypeName("SDL_GameController *")] nint gamecontroller, SDL_GameControllerAxis axis);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerGetAxis")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial short GameControllerGetAxis([NativeTypeName("SDL_GameController *")] nint gamecontroller, SDL_GameControllerAxis axis);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerGetButtonFromString")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SDL_GameControllerButton GameControllerGetButtonFromString([NativeTypeName("const char *")] byte* str);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerGetStringForButton")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("const char *")]
    public static partial byte* GameControllerGetStringForButton(SDL_GameControllerButton button);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerGetBindForButton")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SDL_GameControllerButtonBind GameControllerGetBindForButton([NativeTypeName("SDL_GameController *")] nint gamecontroller, SDL_GameControllerButton button);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerHasButton")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool GameControllerHasButton([NativeTypeName("SDL_GameController *")] nint gamecontroller, SDL_GameControllerButton button);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerGetButton")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial byte GameControllerGetButton([NativeTypeName("SDL_GameController *")] nint gamecontroller, SDL_GameControllerButton button);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerGetNumTouchpads")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GameControllerGetNumTouchpads([NativeTypeName("SDL_GameController *")] nint gamecontroller);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerGetNumTouchpadFingers")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GameControllerGetNumTouchpadFingers([NativeTypeName("SDL_GameController *")] nint gamecontroller, int touchpad);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerGetTouchpadFinger")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GameControllerGetTouchpadFinger([NativeTypeName("SDL_GameController *")] nint gamecontroller, int touchpad, int finger, [NativeTypeName(" *")] byte* state, float* x, float* y, float* pressure);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerHasSensor")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool GameControllerHasSensor([NativeTypeName("SDL_GameController *")] nint gamecontroller, SDL_SensorType type);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerSetSensorEnabled")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GameControllerSetSensorEnabled([NativeTypeName("SDL_GameController *")] nint gamecontroller, SDL_SensorType type, [NativeTypeName("SDL_bool")] CBool enabled);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerIsSensorEnabled")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool GameControllerIsSensorEnabled([NativeTypeName("SDL_GameController *")] nint gamecontroller, SDL_SensorType type);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerGetSensorDataRate")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial float GameControllerGetSensorDataRate([NativeTypeName("SDL_GameController *")] nint gamecontroller, SDL_SensorType type);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerGetSensorData")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GameControllerGetSensorData([NativeTypeName("SDL_GameController *")] nint gamecontroller, SDL_SensorType type, float* data, int num_values);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerGetSensorDataWithTimestamp")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GameControllerGetSensorDataWithTimestamp([NativeTypeName("SDL_GameController *")] nint gamecontroller, SDL_SensorType type, [NativeTypeName(" *")] ulong* timestamp, float* data, int num_values);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerRumble")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GameControllerRumble([NativeTypeName("SDL_GameController *")] nint gamecontroller, ushort low_frequency_rumble, ushort high_frequency_rumble, uint duration_ms);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerRumbleTriggers")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GameControllerRumbleTriggers([NativeTypeName("SDL_GameController *")] nint gamecontroller, ushort left_rumble, ushort right_rumble, uint duration_ms);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerHasLED")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool GameControllerHasLED([NativeTypeName("SDL_GameController *")] nint gamecontroller);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerHasRumble")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool GameControllerHasRumble([NativeTypeName("SDL_GameController *")] nint gamecontroller);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerHasRumbleTriggers")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool GameControllerHasRumbleTriggers([NativeTypeName("SDL_GameController *")] nint gamecontroller);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerSetLED")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GameControllerSetLED([NativeTypeName("SDL_GameController *")] nint gamecontroller, byte red, byte green, byte blue);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerSendEffect")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GameControllerSendEffect([NativeTypeName("SDL_GameController *")] nint gamecontroller, [NativeTypeName("const void *")] void* data, int size);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerClose")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void GameControllerClose([NativeTypeName("SDL_GameController *")] nint gamecontroller);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerGetAppleSFSymbolsNameForButton")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("const char *")]
    public static partial byte* GameControllerGetAppleSFSymbolsNameForButton([NativeTypeName("SDL_GameController *")] nint gamecontroller, SDL_GameControllerButton button);

    [LibraryImport("SDL2", EntryPoint = "SDL_GameControllerGetAppleSFSymbolsNameForAxis")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("const char *")]
    public static partial byte* GameControllerGetAppleSFSymbolsNameForAxis([NativeTypeName("SDL_GameController *")] nint gamecontroller, SDL_GameControllerAxis axis);
}
