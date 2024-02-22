using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpSDL.Interop;

public enum EventType : uint
{
    FIRSTEVENT = 0,
    QUIT = 0x100,
    APP_TERMINATING,
    APP_LOWMEMORY,
    APP_WILLENTERBACKGROUND,
    APP_DIDENTERBACKGROUND,
    APP_WILLENTERFOREGROUND,
    APP_DIDENTERFOREGROUND,
    LOCALECHANGED,
    DISPLAYEVENT = 0x150,
    WINDOWEVENT = 0x200,
    SYSWMEVENT,
    KEYDOWN = 0x300,
    KEYUP,
    TEXTEDITING,
    TEXTINPUT,
    KEYMAPCHANGED,
    TEXTEDITING_EXT,
    MOUSEMOTION = 0x400,
    MOUSEBUTTONDOWN,
    MOUSEBUTTONUP,
    MOUSEWHEEL,
    JOYAXISMOTION = 0x600,
    JOYBALLMOTION,
    JOYHATMOTION,
    JOYBUTTONDOWN,
    JOYBUTTONUP,
    JOYDEVICEADDED,
    JOYDEVICEREMOVED,
    JOYBATTERYUPDATED,
    CONTROLLERAXISMOTION = 0x650,
    CONTROLLERBUTTONDOWN,
    CONTROLLERBUTTONUP,
    CONTROLLERDEVICEADDED,
    CONTROLLERDEVICEREMOVED,
    CONTROLLERDEVICEREMAPPED,
    CONTROLLERTOUCHPADDOWN,
    CONTROLLERTOUCHPADMOTION,
    CONTROLLERTOUCHPADUP,
    CONTROLLERSENSORUPDATE,
    CONTROLLERUPDATECOMPLETE_RESERVED_FOR_SDL3,
    CONTROLLERSTEAMHANDLEUPDATED,
    FINGERDOWN = 0x700,
    FINGERUP,
    FINGERMOTION,
    DOLLARGESTURE = 0x800,
    DOLLARRECORD,
    MULTIGESTURE,
    CLIPBOARDUPDATE = 0x900,
    DROPFILE = 0x1000,
    DROPTEXT,
    DROPBEGIN,
    DROPCOMPLETE,
    AUDIODEVICEADDED = 0x1100,
    AUDIODEVICEREMOVED,
    SENSORUPDATE = 0x1200,
    RENDER_TARGETS_RESET = 0x2000,
    RENDER_DEVICE_RESET,
    POLLSENTINEL = 0x7F00,
    USEREVENT = 0x8000,
    LASTEVENT = 0xFFFF,
}

public enum ButtonState : byte
{
    [NativeTypeName("#define SDL_RELEASED 0")]
    RELEASED = 0,
    [NativeTypeName("#define SDL_PRESSED 1")]
    PRESSED = 1,
}

public enum EventState : byte
{
    [NativeTypeName("#define SDL_QUERY -1")]
    QUERY = unchecked((byte)-1),
    [NativeTypeName("#define SDL_IGNORE 0")]
    IGNORE = 0,
    [NativeTypeName("#define SDL_DISABLE 0")]
    DISABLE = 0,
    [NativeTypeName("#define SDL_ENABLE 1")]
    ENABLE = 1,
}

public enum EventAction
{
    ADDEVENT,
    PEEKEVENT,
    GETEVENT,
}

public partial struct CommonEvent
{
    public EventType type;

    public uint timestamp;
}

public partial struct DisplayEvent
{
    public EventType type;

    public uint timestamp;

    public uint display;

    public byte @event;

    public byte padding1;

    public byte padding2;

    public byte padding3;

    public int data1;
}

public partial struct WindowEvent
{
    public EventType type;

    public uint timestamp;

    public uint windowID;

    public byte @event;

    public byte padding1;

    public byte padding2;

    public byte padding3;

    public int data1;

    public int data2;
}

public partial struct KeyboardEvent
{
    public EventType type;

    public uint timestamp;

    public uint windowID;

    public ButtonState state;

    public byte repeat;

    public byte padding2;

    public byte padding3;

    public Keysym keysym;
}

public partial struct TextEditingEvent
{
    public EventType type;

    public uint timestamp;

    public uint windowID;

    [NativeTypeName("char[32]")]
    public _text_e__FixedBuffer text;

    public int start;

    public int length;

    [InlineArray(32)]
    public partial struct _text_e__FixedBuffer
    {
        public byte e0;
    }
}

public unsafe partial struct TextEditingExtEvent
{
    public EventType type;

    public uint timestamp;

    public uint windowID;

    [NativeTypeName("char *")]
    public byte* text;

    public int start;

    public int length;
}

public partial struct TextInputEvent
{
    public EventType type;

    public uint timestamp;

    public uint windowID;

    [NativeTypeName("char[32]")]
    public _text_e__FixedBuffer text;

    [InlineArray(32)]
    public partial struct _text_e__FixedBuffer
    {
        public byte e0;
    }
}

public partial struct MouseMotionEvent
{
    public EventType type;

    public uint timestamp;

    public uint windowID;

    public uint which;

    public uint state;

    public int x;

    public int y;

    public int xrel;

    public int yrel;
}

public partial struct MouseButtonEvent
{
    public EventType type;

    public uint timestamp;

    public uint windowID;

    public uint which;

    public byte button;

    public ButtonState state;

    public byte clicks;

    public byte padding1;

    public int x;

    public int y;
}

public partial struct MouseWheelEvent
{
    public EventType type;

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

public partial struct JoyAxisEvent
{
    public EventType type;

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

public partial struct JoyBallEvent
{
    public EventType type;

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

public partial struct JoyHatEvent
{
    public EventType type;

    public uint timestamp;

    [NativeTypeName("SDL_JoystickID")]
    public int which;

    public byte hat;

    public byte value;

    public byte padding1;

    public byte padding2;
}

public partial struct JoyButtonEvent
{
    public EventType type;

    public uint timestamp;

    [NativeTypeName("SDL_JoystickID")]
    public int which;

    public byte button;

    public ButtonState state;

    public byte padding1;

    public byte padding2;
}

public partial struct JoyDeviceEvent
{
    public EventType type;

    public uint timestamp;

    public int which;
}

public partial struct JoyBatteryEvent
{
    public EventType type;

    public uint timestamp;

    [NativeTypeName("SDL_JoystickID")]
    public int which;

    public JoystickPowerLevel level;
}

public partial struct ControllerAxisEvent
{
    public EventType type;

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

public partial struct ControllerButtonEvent
{
    public EventType type;

    public uint timestamp;

    [NativeTypeName("SDL_JoystickID")]
    public int which;

    public byte button;

    public ButtonState state;

    public byte padding1;

    public byte padding2;
}

public partial struct ControllerDeviceEvent
{
    public EventType type;

    public uint timestamp;

    public int which;
}

public partial struct ControllerTouchpadEvent
{
    public EventType type;

    public uint timestamp;

    [NativeTypeName("SDL_JoystickID")]
    public int which;

    public int touchpad;

    public int finger;

    public float x;

    public float y;

    public float pressure;
}

public partial struct ControllerSensorEvent
{
    public EventType type;

    public uint timestamp;

    [NativeTypeName("SDL_JoystickID")]
    public int which;

    public int sensor;

    [NativeTypeName("float[3]")]
    public _data_e__FixedBuffer data;

    public ulong timestamp_us;

    [InlineArray(3)]
    public partial struct _data_e__FixedBuffer
    {
        public float e0;
    }
}

public partial struct AudioDeviceEvent
{
    public EventType type;

    public uint timestamp;

    public uint which;

    public byte iscapture;

    public byte padding1;

    public byte padding2;

    public byte padding3;
}

public partial struct TouchFingerEvent
{
    public EventType type;

    public uint timestamp;

    [NativeTypeName("SDL_TouchID")]
    public long touchId;

    [NativeTypeName("FingerID")]
    public long fingerId;

    public float x;

    public float y;

    public float dx;

    public float dy;

    public float pressure;

    public uint windowID;
}

public partial struct MultiGestureEvent
{
    public EventType type;

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

public partial struct DollarGestureEvent
{
    public EventType type;

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

public unsafe partial struct DropEvent
{
    public EventType type;

    public uint timestamp;

    [NativeTypeName("char *")]
    public byte* file;

    public uint windowID;
}

public partial struct SensorEvent
{
    public EventType type;

    public uint timestamp;

    public int which;

    [NativeTypeName("float[6]")]
    public _data_e__FixedBuffer data;

    public ulong timestamp_us;

    [InlineArray(6)]
    public partial struct _data_e__FixedBuffer
    {
        public float e0;
    }
}

public partial struct QuitEvent
{
    public EventType type;

    public uint timestamp;
}

public unsafe partial struct UserEvent
{
    public EventType type;

    public uint timestamp;

    public uint windowID;

    public int code;

    public void* data1;

    public void* data2;
}

public partial struct SysWMmsg
{
}

public unsafe partial struct SysWMEvent
{
    public EventType type;

    public uint timestamp;

    public SysWMmsg* msg;
}

[StructLayout(LayoutKind.Explicit)]
public partial struct Event
{
    [FieldOffset(0)]
    public EventType type;

    [FieldOffset(0)]
    public CommonEvent common;

    [FieldOffset(0)]
    public DisplayEvent display;

    [FieldOffset(0)]
    public WindowEvent window;

    [FieldOffset(0)]
    public KeyboardEvent key;

    [FieldOffset(0)]
    public TextEditingEvent edit;

    [FieldOffset(0)]
    public TextEditingExtEvent editExt;

    [FieldOffset(0)]
    public TextInputEvent text;

    [FieldOffset(0)]
    public MouseMotionEvent motion;

    [FieldOffset(0)]
    public MouseButtonEvent button;

    [FieldOffset(0)]
    public MouseWheelEvent wheel;

    [FieldOffset(0)]
    public JoyAxisEvent jaxis;

    [FieldOffset(0)]
    public JoyBallEvent jball;

    [FieldOffset(0)]
    public JoyHatEvent jhat;

    [FieldOffset(0)]
    public JoyButtonEvent jbutton;

    [FieldOffset(0)]
    public JoyDeviceEvent jdevice;

    [FieldOffset(0)]
    public JoyBatteryEvent jbattery;

    [FieldOffset(0)]
    public ControllerAxisEvent caxis;

    [FieldOffset(0)]
    public ControllerButtonEvent cbutton;

    [FieldOffset(0)]
    public ControllerDeviceEvent cdevice;

    [FieldOffset(0)]
    public ControllerTouchpadEvent ctouchpad;

    [FieldOffset(0)]
    public ControllerSensorEvent csensor;

    [FieldOffset(0)]
    public AudioDeviceEvent adevice;

    [FieldOffset(0)]
    public SensorEvent sensor;

    [FieldOffset(0)]
    public QuitEvent quit;

    [FieldOffset(0)]
    public UserEvent user;

    [FieldOffset(0)]
    public SysWMEvent syswm;

    [FieldOffset(0)]
    public TouchFingerEvent tfinger;

    [FieldOffset(0)]
    public MultiGestureEvent mgesture;

    [FieldOffset(0)]
    public DollarGestureEvent dgesture;

    [FieldOffset(0)]
    public DropEvent drop;

    [FieldOffset(0)]
    [NativeTypeName("[56]")]
    public _padding_e__FixedBuffer padding;

    [InlineArray(56)]
    public partial struct _padding_e__FixedBuffer
    {
        public byte e0;
    }
}

public static unsafe partial class SDL
{
    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_PumpEvents", ExactSpelling = true)]
    public static extern void PumpEvents();

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_PeepEvents", ExactSpelling = true)]
    public static extern int PeepEvents(Event* events, int numevents, EventAction action, uint minType, uint maxType);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasEvent", ExactSpelling = true)]
    public static extern CBool HasEvent(EventType type);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasEvents", ExactSpelling = true)]
    public static extern CBool HasEvents(uint minType, uint maxType);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FlushEvent", ExactSpelling = true)]
    public static extern void FlushEvent(EventType type);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FlushEvents", ExactSpelling = true)]
    public static extern void FlushEvents(uint minType, uint maxType);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_PollEvent", ExactSpelling = true)]
    public static extern int PollEvent(Event* @event);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WaitEvent", ExactSpelling = true)]
    public static extern int WaitEvent(Event* @event);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WaitEventTimeout", ExactSpelling = true)]
    public static extern int WaitEventTimeout(Event* @event, int timeout);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_PushEvent", ExactSpelling = true)]
    public static extern int PushEvent(Event* @event);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetEventFilter", ExactSpelling = true)]
    public static extern void SetEventFilter([NativeTypeName("EventFilter")] delegate* unmanaged[Cdecl]<void*, Event*, int> filter, void* userdata);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetEventFilter", ExactSpelling = true)]
    public static extern CBool GetEventFilter([NativeTypeName("EventFilter *")] delegate* unmanaged[Cdecl]<void*, Event*, int>* filter, void** userdata);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_AddEventWatch", ExactSpelling = true)]
    public static extern void AddEventWatch([NativeTypeName("EventFilter")] delegate* unmanaged[Cdecl]<void*, Event*, int> filter, void* userdata);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_DelEventWatch", ExactSpelling = true)]
    public static extern void DelEventWatch([NativeTypeName("EventFilter")] delegate* unmanaged[Cdecl]<void*, Event*, int> filter, void* userdata);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FilterEvents", ExactSpelling = true)]
    public static extern void FilterEvents([NativeTypeName("EventFilter")] delegate* unmanaged[Cdecl]<void*, Event*, int> filter, void* userdata);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "EventState", ExactSpelling = true)]
    public static extern EventState EventState(EventType type, EventState state);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RegisterEvents", ExactSpelling = true)]
    public static extern uint RegisterEvents(int numevents);
}