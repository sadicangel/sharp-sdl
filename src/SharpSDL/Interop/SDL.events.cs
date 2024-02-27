namespace SharpSDL.Interop;

internal enum SDL_EventType
{
    SDL_FIRSTEVENT = 0,
    SDL_QUIT = 0x100,
    SDL_APP_TERMINATING,
    SDL_APP_LOWMEMORY,
    SDL_APP_WILLENTERBACKGROUND,
    SDL_APP_DIDENTERBACKGROUND,
    SDL_APP_WILLENTERFOREGROUND,
    SDL_APP_DIDENTERFOREGROUND,
    SDL_LOCALECHANGED,
    SDL_DISPLAYEVENT = 0x150,
    SDL_WINDOWEVENT = 0x200,
    SDL_SYSWMEVENT,
    SDL_KEYDOWN = 0x300,
    SDL_KEYUP,
    SDL_TEXTEDITING,
    SDL_TEXTINPUT,
    SDL_KEYMAPCHANGED,
    SDL_TEXTEDITING_EXT,
    SDL_MOUSEMOTION = 0x400,
    SDL_MOUSEBUTTONDOWN,
    SDL_MOUSEBUTTONUP,
    SDL_MOUSEWHEEL,
    SDL_JOYAXISMOTION = 0x600,
    SDL_JOYBALLMOTION,
    SDL_JOYHATMOTION,
    SDL_JOYBUTTONDOWN,
    SDL_JOYBUTTONUP,
    SDL_JOYDEVICEADDED,
    SDL_JOYDEVICEREMOVED,
    SDL_JOYBATTERYUPDATED,
    SDL_CONTROLLERAXISMOTION = 0x650,
    SDL_CONTROLLERBUTTONDOWN,
    SDL_CONTROLLERBUTTONUP,
    SDL_CONTROLLERDEVICEADDED,
    SDL_CONTROLLERDEVICEREMOVED,
    SDL_CONTROLLERDEVICEREMAPPED,
    SDL_CONTROLLERTOUCHPADDOWN,
    SDL_CONTROLLERTOUCHPADMOTION,
    SDL_CONTROLLERTOUCHPADUP,
    SDL_CONTROLLERSENSORUPDATE,
    SDL_CONTROLLERUPDATECOMPLETE_RESERVED_FOR_SDL3,
    SDL_CONTROLLERSTEAMHANDLEUPDATED,
    SDL_FINGERDOWN = 0x700,
    SDL_FINGERUP,
    SDL_FINGERMOTION,
    SDL_DOLLARGESTURE = 0x800,
    SDL_DOLLARRECORD,
    SDL_MULTIGESTURE,
    SDL_CLIPBOARDUPDATE = 0x900,
    SDL_DROPFILE = 0x1000,
    SDL_DROPTEXT,
    SDL_DROPBEGIN,
    SDL_DROPCOMPLETE,
    SDL_AUDIODEVICEADDED = 0x1100,
    SDL_AUDIODEVICEREMOVED,
    SDL_SENSORUPDATE = 0x1200,
    SDL_RENDER_TARGETS_RESET = 0x2000,
    SDL_RENDER_DEVICE_RESET,
    SDL_POLLSENTINEL = 0x7F00,
    SDL_USEREVENT = 0x8000,
    SDL_LASTEVENT = 0xFFFF,
}

internal partial struct SDL_CommonEvent
{
    public uint type;

    public uint timestamp;
}

internal partial struct SDL_DisplayEvent
{
    public uint type;

    public uint timestamp;

    public uint display;

    public byte @event;

    public byte padding1;

    public byte padding2;

    public byte padding3;

    public int data1;
}

internal partial struct SDL_WindowEvent
{
    public uint type;

    public uint timestamp;

    public uint windowID;

    public byte @event;

    public byte padding1;

    public byte padding2;

    public byte padding3;

    public int data1;

    public int data2;
}

internal partial struct SDL_KeyboardEvent
{
    public uint type;

    public uint timestamp;

    public uint windowID;

    public byte state;

    public byte repeat;

    public byte padding2;

    public byte padding3;

    public SDL_Keysym keysym;
}

internal partial struct SDL_TextEditingEvent
{
    public uint type;

    public uint timestamp;

    public uint windowID;

    [NativeTypeName("char[32]")]
    public _text_e__FixedBuffer text;

    public int start;

    public int length;

    [InlineArray(32)]
    internal partial struct _text_e__FixedBuffer
    {
        public byte e0;
    }
}

internal unsafe partial struct SDL_TextEditingExtEvent
{
    public uint type;

    public uint timestamp;

    public uint windowID;

    [NativeTypeName("char *")]
    public byte* text;

    public int start;

    public int length;
}

internal partial struct SDL_TextInputEvent
{
    public uint type;

    public uint timestamp;

    public uint windowID;

    [NativeTypeName("char[32]")]
    public _text_e__FixedBuffer text;

    [InlineArray(32)]
    internal partial struct _text_e__FixedBuffer
    {
        public byte e0;
    }
}

internal partial struct SDL_MouseMotionEvent
{
    public uint type;

    public uint timestamp;

    public uint windowID;

    public uint which;

    public uint state;

    public int x;

    public int y;

    public int xrel;

    public int yrel;
}

internal partial struct SDL_MouseButtonEvent
{
    public uint type;

    public uint timestamp;

    public uint windowID;

    public uint which;

    public byte button;

    public byte state;

    public byte clicks;

    public byte padding1;

    public int x;

    public int y;
}

internal partial struct SDL_MouseWheelEvent
{
    public uint type;

    public uint timestamp;

    public uint windowID;

    public uint which;

    public int x;

    public int y;

    public uint direction;

    public float preciseX;

    public float preciseY;

    public int mouseX;

    public int mouseY;
}

internal partial struct SDL_JoyAxisEvent
{
    public uint type;

    public uint timestamp;

    [NativeTypeName("SDL_JoystickID")]
    public int which;

    public byte axis;

    public byte padding1;

    public byte padding2;

    public byte padding3;

    public short value;

    public ushort padding4;
}

internal partial struct SDL_JoyBallEvent
{
    public uint type;

    public uint timestamp;

    [NativeTypeName("SDL_JoystickID")]
    public int which;

    public byte ball;

    public byte padding1;

    public byte padding2;

    public byte padding3;

    public short xrel;

    public short yrel;
}

internal partial struct SDL_JoyHatEvent
{
    public uint type;

    public uint timestamp;

    [NativeTypeName("SDL_JoystickID")]
    public int which;

    public byte hat;

    public byte value;

    public byte padding1;

    public byte padding2;
}

internal partial struct SDL_JoyButtonEvent
{
    public uint type;

    public uint timestamp;

    [NativeTypeName("SDL_JoystickID")]
    public int which;

    public byte button;

    public byte state;

    public byte padding1;

    public byte padding2;
}

internal partial struct SDL_JoyDeviceEvent
{
    public uint type;

    public uint timestamp;

    public int which;
}

internal partial struct SDL_JoyBatteryEvent
{
    public uint type;

    public uint timestamp;

    [NativeTypeName("SDL_JoystickID")]
    public int which;

    public SDL_JoystickPowerLevel level;
}

internal partial struct SDL_ControllerAxisEvent
{
    public uint type;

    public uint timestamp;

    [NativeTypeName("SDL_JoystickID")]
    public int which;

    public byte axis;

    public byte padding1;

    public byte padding2;

    public byte padding3;

    public short value;

    public ushort padding4;
}

internal partial struct SDL_ControllerButtonEvent
{
    public uint type;

    public uint timestamp;

    [NativeTypeName("SDL_JoystickID")]
    public int which;

    public byte button;

    public byte state;

    public byte padding1;

    public byte padding2;
}

internal partial struct SDL_ControllerDeviceEvent
{
    public uint type;

    public uint timestamp;

    public int which;
}

internal partial struct SDL_ControllerTouchpadEvent
{
    public uint type;

    public uint timestamp;

    [NativeTypeName("SDL_JoystickID")]
    public int which;

    public int touchpad;

    public int finger;

    public float x;

    public float y;

    public float pressure;
}

internal partial struct SDL_ControllerSensorEvent
{
    public uint type;

    public uint timestamp;

    [NativeTypeName("SDL_JoystickID")]
    public int which;

    public int sensor;

    [NativeTypeName("float[3]")]
    public _data_e__FixedBuffer data;

    public ulong timestamp_us;

    [InlineArray(3)]
    internal partial struct _data_e__FixedBuffer
    {
        public float e0;
    }
}

internal partial struct SDL_AudioDeviceEvent
{
    public uint type;

    public uint timestamp;

    public uint which;

    public byte iscapture;

    public byte padding1;

    public byte padding2;

    public byte padding3;
}

internal partial struct SDL_TouchFingerEvent
{
    public uint type;

    public uint timestamp;

    [NativeTypeName("SDL_TouchID")]
    public long touchId;

    [NativeTypeName("SDL_FingerID")]
    public long fingerId;

    public float x;

    public float y;

    public float dx;

    public float dy;

    public float pressure;

    public uint windowID;
}

internal partial struct SDL_MultiGestureEvent
{
    public uint type;

    public uint timestamp;

    [NativeTypeName("SDL_TouchID")]
    public long touchId;

    public float dTheta;

    public float dDist;

    public float x;

    public float y;

    public ushort numFingers;

    public ushort padding;
}

internal partial struct SDL_DollarGestureEvent
{
    public uint type;

    public uint timestamp;

    [NativeTypeName("SDL_TouchID")]
    public long touchId;

    [NativeTypeName("SDL_GestureID")]
    public long gestureId;

    public uint numFingers;

    public float error;

    public float x;

    public float y;
}

internal unsafe partial struct SDL_DropEvent
{
    public uint type;

    public uint timestamp;

    [NativeTypeName("char *")]
    public byte* file;

    public uint windowID;
}

internal partial struct SDL_SensorEvent
{
    public uint type;

    public uint timestamp;

    public int which;

    [NativeTypeName("float[6]")]
    public _data_e__FixedBuffer data;

    public ulong timestamp_us;

    [InlineArray(6)]
    internal partial struct _data_e__FixedBuffer
    {
        public float e0;
    }
}

internal partial struct SDL_QuitEvent
{
    public uint type;

    public uint timestamp;
}

internal unsafe partial struct SDL_UserEvent
{
    public uint type;

    public uint timestamp;

    public uint windowID;

    public int code;

    public void* data1;

    public void* data2;
}

internal unsafe partial struct SDL_SysWMEvent
{
    public uint type;

    public uint timestamp;

    public SDL_SysWMmsg* msg;
}

[StructLayout(LayoutKind.Explicit)]
internal partial struct SDL_Event
{
    [FieldOffset(0)]
    public uint type;

    [FieldOffset(0)]
    public SDL_CommonEvent common;

    [FieldOffset(0)]
    public SDL_DisplayEvent display;

    [FieldOffset(0)]
    public SDL_WindowEvent window;

    [FieldOffset(0)]
    public SDL_KeyboardEvent key;

    [FieldOffset(0)]
    public SDL_TextEditingEvent edit;

    [FieldOffset(0)]
    public SDL_TextEditingExtEvent editExt;

    [FieldOffset(0)]
    public SDL_TextInputEvent text;

    [FieldOffset(0)]
    public SDL_MouseMotionEvent motion;

    [FieldOffset(0)]
    public SDL_MouseButtonEvent button;

    [FieldOffset(0)]
    public SDL_MouseWheelEvent wheel;

    [FieldOffset(0)]
    public SDL_JoyAxisEvent jaxis;

    [FieldOffset(0)]
    public SDL_JoyBallEvent jball;

    [FieldOffset(0)]
    public SDL_JoyHatEvent jhat;

    [FieldOffset(0)]
    public SDL_JoyButtonEvent jbutton;

    [FieldOffset(0)]
    public SDL_JoyDeviceEvent jdevice;

    [FieldOffset(0)]
    public SDL_JoyBatteryEvent jbattery;

    [FieldOffset(0)]
    public SDL_ControllerAxisEvent caxis;

    [FieldOffset(0)]
    public SDL_ControllerButtonEvent cbutton;

    [FieldOffset(0)]
    public SDL_ControllerDeviceEvent cdevice;

    [FieldOffset(0)]
    public SDL_ControllerTouchpadEvent ctouchpad;

    [FieldOffset(0)]
    public SDL_ControllerSensorEvent csensor;

    [FieldOffset(0)]
    public SDL_AudioDeviceEvent adevice;

    [FieldOffset(0)]
    public SDL_SensorEvent sensor;

    [FieldOffset(0)]
    public SDL_QuitEvent quit;

    [FieldOffset(0)]
    public SDL_UserEvent user;

    [FieldOffset(0)]
    public SDL_SysWMEvent syswm;

    [FieldOffset(0)]
    public SDL_TouchFingerEvent tfinger;

    [FieldOffset(0)]
    public SDL_MultiGestureEvent mgesture;

    [FieldOffset(0)]
    public SDL_DollarGestureEvent dgesture;

    [FieldOffset(0)]
    public SDL_DropEvent drop;

    [FieldOffset(0)]
    [NativeTypeName("[56]")]
    public _padding_e__FixedBuffer padding;

    [InlineArray(56)]
    internal partial struct _padding_e__FixedBuffer
    {
        public byte e0;
    }
}

internal enum SDL_eventaction
{
    SDL_ADDEVENT,
    SDL_PEEKEVENT,
    SDL_GETEVENT,
}

internal static unsafe partial class SDL
{
    [LibraryImport("SDL2", EntryPoint = "SDL_PumpEvents")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void PumpEvents();

    [LibraryImport("SDL2", EntryPoint = "SDL_PeepEvents")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int PeepEvents(SDL_Event* events, int numevents, SDL_eventaction action, uint minType, uint maxType);

    [LibraryImport("SDL2", EntryPoint = "SDL_HasEvent")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool HasEvent(uint type);

    [LibraryImport("SDL2", EntryPoint = "SDL_HasEvents")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool HasEvents(uint minType, uint maxType);

    [LibraryImport("SDL2", EntryPoint = "SDL_FlushEvent")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void FlushEvent(uint type);

    [LibraryImport("SDL2", EntryPoint = "SDL_FlushEvents")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void FlushEvents(uint minType, uint maxType);

    [LibraryImport("SDL2", EntryPoint = "SDL_PollEvent")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int PollEvent(SDL_Event* @event);

    [LibraryImport("SDL2", EntryPoint = "SDL_WaitEvent")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int WaitEvent(SDL_Event* @event);

    [LibraryImport("SDL2", EntryPoint = "SDL_WaitEventTimeout")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int WaitEventTimeout(SDL_Event* @event, int timeout);

    [LibraryImport("SDL2", EntryPoint = "SDL_PushEvent")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int PushEvent(SDL_Event* @event);

    [LibraryImport("SDL2", EntryPoint = "SDL_SetEventFilter")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SetEventFilter([NativeTypeName("SDL_EventFilter")] delegate* unmanaged[Cdecl]<void*, SDL_Event*, int> filter, void* userdata);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetEventFilter")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool GetEventFilter([NativeTypeName("SDL_EventFilter *")] delegate* unmanaged[Cdecl]<void*, SDL_Event*, int>* filter, void** userdata);

    [LibraryImport("SDL2", EntryPoint = "SDL_AddEventWatch")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void AddEventWatch([NativeTypeName("SDL_EventFilter")] delegate* unmanaged[Cdecl]<void*, SDL_Event*, int> filter, void* userdata);

    [LibraryImport("SDL2", EntryPoint = "SDL_DelEventWatch")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void DelEventWatch([NativeTypeName("SDL_EventFilter")] delegate* unmanaged[Cdecl]<void*, SDL_Event*, int> filter, void* userdata);

    [LibraryImport("SDL2", EntryPoint = "SDL_FilterEvents")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void FilterEvents([NativeTypeName("SDL_EventFilter")] delegate* unmanaged[Cdecl]<void*, SDL_Event*, int> filter, void* userdata);

    [LibraryImport("SDL2", EntryPoint = "SDL_EventState")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial byte EventState(uint type, int state);

    [LibraryImport("SDL2", EntryPoint = "SDL_RegisterEvents")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint RegisterEvents(int numevents);

    [NativeTypeName("#define SDL_RELEASED 0")]
    public const int SDL_RELEASED = 0;

    [NativeTypeName("#define SDL_PRESSED 1")]
    public const int SDL_PRESSED = 1;

    [NativeTypeName("#define SDL_TEXTEDITINGEVENT_TEXT_SIZE (32)")]
    public const int SDL_TEXTEDITINGEVENT_TEXT_SIZE = (32);

    [NativeTypeName("#define SDL_TEXTINPUTEVENT_TEXT_SIZE (32)")]
    public const int SDL_TEXTINPUTEVENT_TEXT_SIZE = (32);

    [NativeTypeName("#define SDL_QUERY -1")]
    public const int SDL_QUERY = -1;

    [NativeTypeName("#define SDL_IGNORE 0")]
    public const int SDL_IGNORE = 0;

    [NativeTypeName("#define SDL_DISABLE 0")]
    public const int SDL_DISABLE = 0;

    [NativeTypeName("#define SDL_ENABLE 1")]
    public const int SDL_ENABLE = 1;
}
