using System.Runtime.InteropServices;

namespace SharpSDL.Interop
{
    public partial struct _SDL_Joystick
    {
    }

    public enum JoystickType
    {
        UNKNOWN,
        GAMECONTROLLER,
        WHEEL,
        ARCADE_STICK,
        FLIGHT_STICK,
        DANCE_PAD,
        GUITAR,
        DRUM_KIT,
        ARCADE_PAD,
        THROTTLE,
    }

    public enum JoystickPowerLevel
    {
        UNKNOWN = -1,
        EMPTY,
        LOW,
        MEDIUM,
        FULL,
        WIRED,
        MAX,
    }

    public unsafe partial struct VirtualJoystickDesc
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

    public static unsafe partial class SDL
    {
        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LockJoysticks", ExactSpelling = true)]
        public static extern void LockJoysticks();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UnlockJoysticks", ExactSpelling = true)]
        public static extern void UnlockJoysticks();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_NumJoysticks", ExactSpelling = true)]
        public static extern int NumJoysticks();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickNameForIndex", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern byte* JoystickNameForIndex(int device_index);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickPathForIndex", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern byte* JoystickPathForIndex(int device_index);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetDevicePlayerIndex", ExactSpelling = true)]
        public static extern int JoystickGetDevicePlayerIndex(int device_index);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetDeviceGUID", ExactSpelling = true)]
        [return: NativeTypeName("SDL_JoystickGUID")]
        public static extern GUID JoystickGetDeviceGUID(int device_index);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetDeviceVendor", ExactSpelling = true)]
        public static extern ushort JoystickGetDeviceVendor(int device_index);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetDeviceProduct", ExactSpelling = true)]
        public static extern ushort JoystickGetDeviceProduct(int device_index);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetDeviceProductVersion", ExactSpelling = true)]
        public static extern ushort JoystickGetDeviceProductVersion(int device_index);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetDeviceType", ExactSpelling = true)]
        public static extern JoystickType JoystickGetDeviceType(int device_index);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetDeviceInstanceID", ExactSpelling = true)]
        [return: NativeTypeName("SDL_JoystickID")]
        public static extern int JoystickGetDeviceInstanceID(int device_index);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickOpen", ExactSpelling = true)]
        [return: NativeTypeName("SDL_Joystick *")]
        public static extern _SDL_Joystick* JoystickOpen(int device_index);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickFromInstanceID", ExactSpelling = true)]
        [return: NativeTypeName("SDL_Joystick *")]
        public static extern _SDL_Joystick* JoystickFromInstanceID([NativeTypeName("SDL_JoystickID")] int instance_id);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickFromPlayerIndex", ExactSpelling = true)]
        [return: NativeTypeName("SDL_Joystick *")]
        public static extern _SDL_Joystick* JoystickFromPlayerIndex(int player_index);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickAttachVirtual", ExactSpelling = true)]
        public static extern int JoystickAttachVirtual(JoystickType type, int naxes, int nbuttons, int nhats);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickAttachVirtualEx", ExactSpelling = true)]
        public static extern int JoystickAttachVirtualEx([NativeTypeName("const VirtualJoystickDesc *")] VirtualJoystickDesc* desc);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickDetachVirtual", ExactSpelling = true)]
        public static extern int JoystickDetachVirtual(int device_index);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickIsVirtual", ExactSpelling = true)]
        public static extern CBool JoystickIsVirtual(int device_index);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickSetVirtualAxis", ExactSpelling = true)]
        public static extern int JoystickSetVirtualAxis([NativeTypeName("SDL_Joystick *")] _SDL_Joystick* joystick, int axis, short value);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickSetVirtualButton", ExactSpelling = true)]
        public static extern int JoystickSetVirtualButton([NativeTypeName("SDL_Joystick *")] _SDL_Joystick* joystick, int button, byte value);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickSetVirtualHat", ExactSpelling = true)]
        public static extern int JoystickSetVirtualHat([NativeTypeName("SDL_Joystick *")] _SDL_Joystick* joystick, int hat, byte value);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickName", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern byte* JoystickName([NativeTypeName("SDL_Joystick *")] _SDL_Joystick* joystick);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickPath", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern byte* JoystickPath([NativeTypeName("SDL_Joystick *")] _SDL_Joystick* joystick);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetPlayerIndex", ExactSpelling = true)]
        public static extern int JoystickGetPlayerIndex([NativeTypeName("SDL_Joystick *")] _SDL_Joystick* joystick);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickSetPlayerIndex", ExactSpelling = true)]
        public static extern void JoystickSetPlayerIndex([NativeTypeName("SDL_Joystick *")] _SDL_Joystick* joystick, int player_index);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetGUID", ExactSpelling = true)]
        [return: NativeTypeName("SDL_JoystickGUID")]
        public static extern GUID JoystickGetGUID([NativeTypeName("SDL_Joystick *")] _SDL_Joystick* joystick);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetVendor", ExactSpelling = true)]
        public static extern ushort JoystickGetVendor([NativeTypeName("SDL_Joystick *")] _SDL_Joystick* joystick);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetProduct", ExactSpelling = true)]
        public static extern ushort JoystickGetProduct([NativeTypeName("SDL_Joystick *")] _SDL_Joystick* joystick);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetProductVersion", ExactSpelling = true)]
        public static extern ushort JoystickGetProductVersion([NativeTypeName("SDL_Joystick *")] _SDL_Joystick* joystick);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetFirmwareVersion", ExactSpelling = true)]
        public static extern ushort JoystickGetFirmwareVersion([NativeTypeName("SDL_Joystick *")] _SDL_Joystick* joystick);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetSerial", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern byte* JoystickGetSerial([NativeTypeName("SDL_Joystick *")] _SDL_Joystick* joystick);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetType", ExactSpelling = true)]
        public static extern JoystickType JoystickGetType([NativeTypeName("SDL_Joystick *")] _SDL_Joystick* joystick);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetGUIDString", ExactSpelling = true)]
        public static extern void JoystickGetGUIDString([NativeTypeName("SDL_JoystickGUID")] GUID guid, [NativeTypeName("char *")] byte* pszGUID, int cbGUID);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetGUIDFromString", ExactSpelling = true)]
        [return: NativeTypeName("SDL_JoystickGUID")]
        public static extern GUID JoystickGetGUIDFromString([NativeTypeName("const char *")] byte* pchGUID);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetJoystickGUIDInfo", ExactSpelling = true)]
        public static extern void GetJoystickGUIDInfo([NativeTypeName("SDL_JoystickGUID")] GUID guid, [NativeTypeName(" *")] ushort* vendor, [NativeTypeName(" *")] ushort* product, [NativeTypeName(" *")] ushort* version, [NativeTypeName(" *")] ushort* crc16);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetAttached", ExactSpelling = true)]
        public static extern CBool JoystickGetAttached([NativeTypeName("SDL_Joystick *")] _SDL_Joystick* joystick);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickInstanceID", ExactSpelling = true)]
        [return: NativeTypeName("SDL_JoystickID")]
        public static extern int JoystickInstanceID([NativeTypeName("SDL_Joystick *")] _SDL_Joystick* joystick);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickNumAxes", ExactSpelling = true)]
        public static extern int JoystickNumAxes([NativeTypeName("SDL_Joystick *")] _SDL_Joystick* joystick);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickNumBalls", ExactSpelling = true)]
        public static extern int JoystickNumBalls([NativeTypeName("SDL_Joystick *")] _SDL_Joystick* joystick);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickNumHats", ExactSpelling = true)]
        public static extern int JoystickNumHats([NativeTypeName("SDL_Joystick *")] _SDL_Joystick* joystick);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickNumButtons", ExactSpelling = true)]
        public static extern int JoystickNumButtons([NativeTypeName("SDL_Joystick *")] _SDL_Joystick* joystick);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickUpdate", ExactSpelling = true)]
        public static extern void JoystickUpdate();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickEventState", ExactSpelling = true)]
        public static extern int JoystickEventState(int state);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetAxis", ExactSpelling = true)]
        public static extern short JoystickGetAxis([NativeTypeName("SDL_Joystick *")] _SDL_Joystick* joystick, int axis);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetAxisInitialState", ExactSpelling = true)]
        public static extern CBool JoystickGetAxisInitialState([NativeTypeName("SDL_Joystick *")] _SDL_Joystick* joystick, int axis, [NativeTypeName(" *")] short* state);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetHat", ExactSpelling = true)]
        public static extern byte JoystickGetHat([NativeTypeName("SDL_Joystick *")] _SDL_Joystick* joystick, int hat);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetBall", ExactSpelling = true)]
        public static extern int JoystickGetBall([NativeTypeName("SDL_Joystick *")] _SDL_Joystick* joystick, int ball, int* dx, int* dy);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetButton", ExactSpelling = true)]
        public static extern byte JoystickGetButton([NativeTypeName("SDL_Joystick *")] _SDL_Joystick* joystick, int button);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickRumble", ExactSpelling = true)]
        public static extern int JoystickRumble([NativeTypeName("SDL_Joystick *")] _SDL_Joystick* joystick, ushort low_frequency_rumble, ushort high_frequency_rumble, uint duration_ms);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickRumbleTriggers", ExactSpelling = true)]
        public static extern int JoystickRumbleTriggers([NativeTypeName("SDL_Joystick *")] _SDL_Joystick* joystick, ushort left_rumble, ushort right_rumble, uint duration_ms);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickHasLED", ExactSpelling = true)]
        public static extern CBool JoystickHasLED([NativeTypeName("SDL_Joystick *")] _SDL_Joystick* joystick);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickHasRumble", ExactSpelling = true)]
        public static extern CBool JoystickHasRumble([NativeTypeName("SDL_Joystick *")] _SDL_Joystick* joystick);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickHasRumbleTriggers", ExactSpelling = true)]
        public static extern CBool JoystickHasRumbleTriggers([NativeTypeName("SDL_Joystick *")] _SDL_Joystick* joystick);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickSetLED", ExactSpelling = true)]
        public static extern int JoystickSetLED([NativeTypeName("SDL_Joystick *")] _SDL_Joystick* joystick, byte red, byte green, byte blue);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickSendEffect", ExactSpelling = true)]
        public static extern int JoystickSendEffect([NativeTypeName("SDL_Joystick *")] _SDL_Joystick* joystick, [NativeTypeName("const void *")] void* data, int size);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickClose", ExactSpelling = true)]
        public static extern void JoystickClose([NativeTypeName("SDL_Joystick *")] _SDL_Joystick* joystick);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickCurrentPowerLevel", ExactSpelling = true)]
        public static extern JoystickPowerLevel JoystickCurrentPowerLevel([NativeTypeName("SDL_Joystick *")] _SDL_Joystick* joystick);

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
}
