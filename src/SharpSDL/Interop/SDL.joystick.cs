using System.Runtime.InteropServices;

namespace SharpSDL.Interop;

internal enum SDL_JoystickType
{
    SDL_JOYSTICK_TYPE_UNKNOWN,
    SDL_JOYSTICK_TYPE_GAMECONTROLLER,
    SDL_JOYSTICK_TYPE_WHEEL,
    SDL_JOYSTICK_TYPE_ARCADE_STICK,
    SDL_JOYSTICK_TYPE_FLIGHT_STICK,
    SDL_JOYSTICK_TYPE_DANCE_PAD,
    SDL_JOYSTICK_TYPE_GUITAR,
    SDL_JOYSTICK_TYPE_DRUM_KIT,
    SDL_JOYSTICK_TYPE_ARCADE_PAD,
    SDL_JOYSTICK_TYPE_THROTTLE,
}

internal enum SDL_JoystickPowerLevel
{
    SDL_JOYSTICK_POWER_UNKNOWN = -1,
    SDL_JOYSTICK_POWER_EMPTY,
    SDL_JOYSTICK_POWER_LOW,
    SDL_JOYSTICK_POWER_MEDIUM,
    SDL_JOYSTICK_POWER_FULL,
    SDL_JOYSTICK_POWER_WIRED,
    SDL_JOYSTICK_POWER_MAX,
}

internal unsafe partial struct SDL_VirtualJoystickDesc
{
    public ushort version;

    public ushort type;

    public ushort naxes;

    public ushort nbuttons;

    public ushort nhats;

    public ushort vendor_id;

    public ushort product_id;

    public ushort padding;

    public uint button_mask;

    public uint axis_mask;

    [NativeTypeName("const char *")]
    public byte* name;

    public void* userdata;

    [NativeTypeName("void (*)(void *) __attribute__((cdecl))")]
    public delegate* unmanaged[Cdecl]<void*, void> Update;

    [NativeTypeName("void (*)(void *, int) __attribute__((cdecl))")]
    public delegate* unmanaged[Cdecl]<void*, int, void> SetPlayerIndex;

    [NativeTypeName("int (*)(void *, , ) __attribute__((cdecl))")]
    public delegate* unmanaged[Cdecl]<void*, ushort, ushort, int> Rumble;

    [NativeTypeName("int (*)(void *, , ) __attribute__((cdecl))")]
    public delegate* unmanaged[Cdecl]<void*, ushort, ushort, int> RumbleTriggers;

    [NativeTypeName("int (*)(void *, , , ) __attribute__((cdecl))")]
    public delegate* unmanaged[Cdecl]<void*, byte, byte, byte, int> SetLED;

    [NativeTypeName("int (*)(void *, const void *, int) __attribute__((cdecl))")]
    public delegate* unmanaged[Cdecl]<void*, void*, int, int> SendEffect;
}

internal static unsafe partial class SDL
{
    [LibraryImport("SDL2", EntryPoint = "SDL_LockJoysticks")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void LockJoysticks();

    [LibraryImport("SDL2", EntryPoint = "SDL_UnlockJoysticks")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void UnlockJoysticks();

    [LibraryImport("SDL2", EntryPoint = "SDL_NumJoysticks")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int NumJoysticks();

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickNameForIndex")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("const char *")]
    public static partial byte* JoystickNameForIndex(int device_index);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickPathForIndex")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("const char *")]
    public static partial byte* JoystickPathForIndex(int device_index);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickGetDevicePlayerIndex")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int JoystickGetDevicePlayerIndex(int device_index);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickGetDeviceGUID")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("SDL_JoystickGUID")]
    public static partial SDL_GUID JoystickGetDeviceGUID(int device_index);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickGetDeviceVendor")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial ushort JoystickGetDeviceVendor(int device_index);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickGetDeviceProduct")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial ushort JoystickGetDeviceProduct(int device_index);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickGetDeviceProductVersion")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial ushort JoystickGetDeviceProductVersion(int device_index);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickGetDeviceType")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial SDL_JoystickType JoystickGetDeviceType(int device_index);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickGetDeviceInstanceID")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("SDL_JoystickID")]
    public static partial int JoystickGetDeviceInstanceID(int device_index);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickOpen")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("SDL_Joystick *")]
    public static partial nint JoystickOpen(int device_index);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickFromInstanceID")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("SDL_Joystick *")]
    public static partial nint JoystickFromInstanceID([NativeTypeName("SDL_JoystickID")] int instance_id);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickFromPlayerIndex")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("SDL_Joystick *")]
    public static partial nint JoystickFromPlayerIndex(int player_index);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickAttachVirtual")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int JoystickAttachVirtual(SDL_JoystickType type, int naxes, int nbuttons, int nhats);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickAttachVirtualEx")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int JoystickAttachVirtualEx([NativeTypeName("const SDL_VirtualJoystickDesc *")] SDL_VirtualJoystickDesc* desc);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickDetachVirtual")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int JoystickDetachVirtual(int device_index);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickIsVirtual")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool JoystickIsVirtual(int device_index);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickSetVirtualAxis")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int JoystickSetVirtualAxis([NativeTypeName("SDL_Joystick *")] nint joystick, int axis, short value);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickSetVirtualButton")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int JoystickSetVirtualButton([NativeTypeName("SDL_Joystick *")] nint joystick, int button, byte value);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickSetVirtualHat")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int JoystickSetVirtualHat([NativeTypeName("SDL_Joystick *")] nint joystick, int hat, byte value);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickName")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("const char *")]
    public static partial byte* JoystickName([NativeTypeName("SDL_Joystick *")] nint joystick);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickPath")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("const char *")]
    public static partial byte* JoystickPath([NativeTypeName("SDL_Joystick *")] nint joystick);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickGetPlayerIndex")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int JoystickGetPlayerIndex([NativeTypeName("SDL_Joystick *")] nint joystick);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickSetPlayerIndex")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void JoystickSetPlayerIndex([NativeTypeName("SDL_Joystick *")] nint joystick, int player_index);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickGetGUID")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("SDL_JoystickGUID")]
    public static partial SDL_GUID JoystickGetGUID([NativeTypeName("SDL_Joystick *")] nint joystick);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickGetVendor")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial ushort JoystickGetVendor([NativeTypeName("SDL_Joystick *")] nint joystick);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickGetProduct")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial ushort JoystickGetProduct([NativeTypeName("SDL_Joystick *")] nint joystick);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickGetProductVersion")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial ushort JoystickGetProductVersion([NativeTypeName("SDL_Joystick *")] nint joystick);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickGetFirmwareVersion")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial ushort JoystickGetFirmwareVersion([NativeTypeName("SDL_Joystick *")] nint joystick);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickGetSerial")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("const char *")]
    public static partial byte* JoystickGetSerial([NativeTypeName("SDL_Joystick *")] nint joystick);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickGetType")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial SDL_JoystickType JoystickGetType([NativeTypeName("SDL_Joystick *")] nint joystick);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickGetGUIDString")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void JoystickGetGUIDString([NativeTypeName("SDL_JoystickGUID")] SDL_GUID guid, [NativeTypeName("char *")] byte* pszGUID, int cbGUID);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickGetGUIDFromString")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("SDL_JoystickGUID")]
    public static partial SDL_GUID JoystickGetGUIDFromString([NativeTypeName("const char *")] byte* pchGUID);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetJoystickGUIDInfo")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void GetJoystickGUIDInfo([NativeTypeName("SDL_JoystickGUID")] SDL_GUID guid, [NativeTypeName(" *")] ushort* vendor, [NativeTypeName(" *")] ushort* product, [NativeTypeName(" *")] ushort* version, [NativeTypeName(" *")] ushort* crc16);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickGetAttached")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool JoystickGetAttached([NativeTypeName("SDL_Joystick *")] nint joystick);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickInstanceID")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("SDL_JoystickID")]
    public static partial int JoystickInstanceID([NativeTypeName("SDL_Joystick *")] nint joystick);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickNumAxes")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int JoystickNumAxes([NativeTypeName("SDL_Joystick *")] nint joystick);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickNumBalls")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int JoystickNumBalls([NativeTypeName("SDL_Joystick *")] nint joystick);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickNumHats")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int JoystickNumHats([NativeTypeName("SDL_Joystick *")] nint joystick);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickNumButtons")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int JoystickNumButtons([NativeTypeName("SDL_Joystick *")] nint joystick);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickUpdate")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void JoystickUpdate();

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickEventState")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int JoystickEventState(int state);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickGetAxis")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial short JoystickGetAxis([NativeTypeName("SDL_Joystick *")] nint joystick, int axis);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickGetAxisInitialState")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool JoystickGetAxisInitialState([NativeTypeName("SDL_Joystick *")] nint joystick, int axis, [NativeTypeName(" *")] short* state);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickGetHat")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial byte JoystickGetHat([NativeTypeName("SDL_Joystick *")] nint joystick, int hat);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickGetBall")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int JoystickGetBall([NativeTypeName("SDL_Joystick *")] nint joystick, int ball, int* dx, int* dy);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickGetButton")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial byte JoystickGetButton([NativeTypeName("SDL_Joystick *")] nint joystick, int button);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickRumble")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int JoystickRumble([NativeTypeName("SDL_Joystick *")] nint joystick, ushort low_frequency_rumble, ushort high_frequency_rumble, uint duration_ms);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickRumbleTriggers")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int JoystickRumbleTriggers([NativeTypeName("SDL_Joystick *")] nint joystick, ushort left_rumble, ushort right_rumble, uint duration_ms);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickHasLED")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool JoystickHasLED([NativeTypeName("SDL_Joystick *")] nint joystick);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickHasRumble")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool JoystickHasRumble([NativeTypeName("SDL_Joystick *")] nint joystick);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickHasRumbleTriggers")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool JoystickHasRumbleTriggers([NativeTypeName("SDL_Joystick *")] nint joystick);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickSetLED")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int JoystickSetLED([NativeTypeName("SDL_Joystick *")] nint joystick, byte red, byte green, byte blue);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickSendEffect")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int JoystickSendEffect([NativeTypeName("SDL_Joystick *")] nint joystick, [NativeTypeName("const void *")] void* data, int size);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickClose")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void JoystickClose([NativeTypeName("SDL_Joystick *")] nint joystick);

    [LibraryImport("SDL2", EntryPoint = "SDL_JoystickCurrentPowerLevel")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial SDL_JoystickPowerLevel JoystickCurrentPowerLevel([NativeTypeName("SDL_Joystick *")] nint joystick);

    [NativeTypeName("#define SDL_IPHONE_MAX_GFORCE 5.0")]
    public const double SDL_IPHONE_MAX_GFORCE = 5.0;

    [NativeTypeName("#define SDL_VIRTUAL_JOYSTICK_DESC_VERSION 1")]
    public const int SDL_VIRTUAL_JOYSTICK_DESC_VERSION = 1;

    [NativeTypeName("#define SDL_JOYSTICK_AXIS_MAX 32767")]
    public const int SDL_JOYSTICK_AXIS_MAX = 32767;

    [NativeTypeName("#define SDL_JOYSTICK_AXIS_MIN -32768")]
    public const int SDL_JOYSTICK_AXIS_MIN = -32768;

    [NativeTypeName("#define SDL_HAT_CENTERED 0x00")]
    public const int SDL_HAT_CENTERED = 0x00;

    [NativeTypeName("#define SDL_HAT_UP 0x01")]
    public const int SDL_HAT_UP = 0x01;

    [NativeTypeName("#define SDL_HAT_RIGHT 0x02")]
    public const int SDL_HAT_RIGHT = 0x02;

    [NativeTypeName("#define SDL_HAT_DOWN 0x04")]
    public const int SDL_HAT_DOWN = 0x04;

    [NativeTypeName("#define SDL_HAT_LEFT 0x08")]
    public const int SDL_HAT_LEFT = 0x08;

    [NativeTypeName("#define SDL_HAT_RIGHTUP (SDL_HAT_RIGHT|SDL_HAT_UP)")]
    public const int SDL_HAT_RIGHTUP = (0x02 | 0x01);

    [NativeTypeName("#define SDL_HAT_RIGHTDOWN (SDL_HAT_RIGHT|SDL_HAT_DOWN)")]
    public const int SDL_HAT_RIGHTDOWN = (0x02 | 0x04);

    [NativeTypeName("#define SDL_HAT_LEFTUP (SDL_HAT_LEFT|SDL_HAT_UP)")]
    public const int SDL_HAT_LEFTUP = (0x08 | 0x01);

    [NativeTypeName("#define SDL_HAT_LEFTDOWN (SDL_HAT_LEFT|SDL_HAT_DOWN)")]
    public const int SDL_HAT_LEFTDOWN = (0x08 | 0x04);
}
