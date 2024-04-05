using SharpSDL.Devices;

namespace SharpSDL;

[StructLayout(LayoutKind.Explicit, Size = 56)]
public readonly struct Event
{
    [FieldOffset(0)]
    public readonly EventType Type;

    [FieldOffset(4)]
    public readonly uint Timestamp;

    [FieldOffset(0)]
    public readonly EventUnion As;
}

[StructLayout(LayoutKind.Explicit, Size = 56)]
public readonly struct EventUnion
{
    [FieldOffset(0)]
    public readonly DisplayEvent DisplayEvent;

    [FieldOffset(0)]
    public readonly WindowEvent WindowEvent;

    [FieldOffset(0)]
    public readonly KeyboardEvent KeyEvent;

    [FieldOffset(0)]
    public readonly TextEditingEvent EditEvent;

    [FieldOffset(0)]
    public readonly TextEditingExtEvent EditExtEvent;

    [FieldOffset(0)]
    public readonly TextInputEvent TextEvent;

    [FieldOffset(0)]
    public readonly MouseMotionEvent MotionEvent;

    [FieldOffset(0)]
    public readonly MouseButtonEvent ButtonEvent;

    [FieldOffset(0)]
    public readonly MouseWheelEvent WheelEvent;

    [FieldOffset(0)]
    public readonly JoyAxisEvent JoyAxisEvent;

    [FieldOffset(0)]
    public readonly JoyBallEvent JoyBallEvent;

    [FieldOffset(0)]
    public readonly JoyHatEvent JoyHatEvent;

    [FieldOffset(0)]
    public readonly JoyButtonEvent JoyButtonEvent;

    [FieldOffset(0)]
    public readonly JoyDeviceEvent JoyDeviceEvent;

    [FieldOffset(0)]
    public readonly JoyBatteryEvent JoyBatteryEvent;

    [FieldOffset(0)]
    public readonly ControllerAxisEvent ControllerAxisEvent;

    [FieldOffset(0)]
    public readonly ControllerButtonEvent ControllerButtonEvent;

    [FieldOffset(0)]
    public readonly ControllerDeviceEvent ControllerDeviceEvent;

    [FieldOffset(0)]
    public readonly ControllerTouchpadEvent ControllerTouchpadEvent;

    [FieldOffset(0)]
    public readonly ControllerSensorEvent ControllerSensorEvent;

    [FieldOffset(0)]
    public readonly AudioDeviceEvent AudioDeviceEvent;

    [FieldOffset(0)]
    public readonly SensorEvent SensorEvent;

    [FieldOffset(0)]
    public readonly QuitEvent QuitEvent;

    [FieldOffset(0)]
    public readonly UserEvent UserEvent;

    [FieldOffset(0)]
    public readonly SysWmEvent SysWmEvent;

    [FieldOffset(0)]
    public readonly TouchFingerEvent TouchFingerEvent;

    [FieldOffset(0)]
    public readonly MultiGestureEvent MultiGestureEvent;

    [FieldOffset(0)]
    public readonly DollarGestureEvent DollerGestureEvent;

    [FieldOffset(0)]
    public readonly DropEvent DropEvent;
}

public enum EventType : uint
{
    FirstEvent = SDL_EventType.SDL_FIRSTEVENT,
    Quit = SDL_EventType.SDL_QUIT,
    AppTerminating = SDL_EventType.SDL_APP_TERMINATING,
    AppLowMemory = SDL_EventType.SDL_APP_LOWMEMORY,
    AppWillEnterBackground = SDL_EventType.SDL_APP_WILLENTERBACKGROUND,
    AppDidEnterBackground = SDL_EventType.SDL_APP_DIDENTERBACKGROUND,
    AppWillEnterForeground = SDL_EventType.SDL_APP_WILLENTERFOREGROUND,
    AppDidEnterForeground = SDL_EventType.SDL_APP_DIDENTERFOREGROUND,
    LocaleChanged = SDL_EventType.SDL_LOCALECHANGED,
    DisplayEvent = SDL_EventType.SDL_DISPLAYEVENT,
    WindowEvent = SDL_EventType.SDL_WINDOWEVENT,
    SysWmEvent = SDL_EventType.SDL_SYSWMEVENT,
    KeyDown = SDL_EventType.SDL_KEYDOWN,
    KeyUp = SDL_EventType.SDL_KEYUP,
    TextEditing = SDL_EventType.SDL_TEXTEDITING,
    TextInput = SDL_EventType.SDL_TEXTINPUT,
    KeyMapChanged = SDL_EventType.SDL_KEYMAPCHANGED,
    TextEditingExt = SDL_EventType.SDL_TEXTEDITING_EXT,
    MouseMotion = SDL_EventType.SDL_MOUSEMOTION,
    MouseButtonDown = SDL_EventType.SDL_MOUSEBUTTONDOWN,
    MouseButtonUp = SDL_EventType.SDL_MOUSEBUTTONUP,
    MouseWheel = SDL_EventType.SDL_MOUSEWHEEL,
    JoyAxisMotion = SDL_EventType.SDL_JOYAXISMOTION,
    JoyBallMotion = SDL_EventType.SDL_JOYBALLMOTION,
    JoyHatMotion = SDL_EventType.SDL_JOYHATMOTION,
    JoyButtonDown = SDL_EventType.SDL_JOYBUTTONDOWN,
    JoyButtonUp = SDL_EventType.SDL_JOYBUTTONUP,
    JoyDeviceAdded = SDL_EventType.SDL_JOYDEVICEADDED,
    JoyDeviceRemoved = SDL_EventType.SDL_JOYDEVICEREMOVED,
    JoyBatteryUpdated = SDL_EventType.SDL_JOYBATTERYUPDATED,
    ControllerAxisMotion = SDL_EventType.SDL_CONTROLLERAXISMOTION,
    ControllerButtonDown = SDL_EventType.SDL_CONTROLLERBUTTONDOWN,
    ControllerButtonUp = SDL_EventType.SDL_CONTROLLERBUTTONUP,
    ControllerDeviceAdded = SDL_EventType.SDL_CONTROLLERDEVICEADDED,
    ControllerDeviceRemoved = SDL_EventType.SDL_CONTROLLERDEVICEREMOVED,
    ControllerDeviceRemapped = SDL_EventType.SDL_CONTROLLERDEVICEREMAPPED,
    ControllerTouchpadDown = SDL_EventType.SDL_CONTROLLERTOUCHPADDOWN,
    ControllerTouchpadMotion = SDL_EventType.SDL_CONTROLLERTOUCHPADMOTION,
    ControllerTouchpadUp = SDL_EventType.SDL_CONTROLLERTOUCHPADUP,
    ControllerSensorUpdate = SDL_EventType.SDL_CONTROLLERSENSORUPDATE,
    ControllerUpdateComplete_Reserved_SDL3 = SDL_EventType.SDL_CONTROLLERUPDATECOMPLETE_RESERVED_FOR_SDL3,
    ControllerSteamHandleUpdated = SDL_EventType.SDL_CONTROLLERSTEAMHANDLEUPDATED,
    FingerDown = SDL_EventType.SDL_FINGERDOWN,
    FingerUp = SDL_EventType.SDL_FINGERUP,
    FingerMotion = SDL_EventType.SDL_FINGERMOTION,
    DollarGesture = SDL_EventType.SDL_DOLLARGESTURE,
    DollarRecord = SDL_EventType.SDL_DOLLARRECORD,
    MultiGesture = SDL_EventType.SDL_MULTIGESTURE,
    ClipboardUpdate = SDL_EventType.SDL_CLIPBOARDUPDATE,
    DropFile = SDL_EventType.SDL_DROPFILE,
    DropText = SDL_EventType.SDL_DROPTEXT,
    DropBegin = SDL_EventType.SDL_DROPBEGIN,
    DropComplete = SDL_EventType.SDL_DROPCOMPLETE,
    AudioDeviceAdded = SDL_EventType.SDL_AUDIODEVICEADDED,
    AudioDeviceRemoved = SDL_EventType.SDL_AUDIODEVICEREMOVED,
    SensorUpdate = SDL_EventType.SDL_SENSORUPDATE,
    RenderTargetsReset = SDL_EventType.SDL_RENDER_TARGETS_RESET,
    RenderDeviceReset = SDL_EventType.SDL_RENDER_DEVICE_RESET,
    PollSentinel = SDL_EventType.SDL_POLLSENTINEL,
    UserEvent = SDL_EventType.SDL_USEREVENT,
    LastEvent = SDL_EventType.SDL_LASTEVENT,
}

public readonly struct CommonEvent
{
    public readonly uint Type;

    public readonly uint Timestamp;
}

public readonly struct DisplayEvent
{
    public readonly uint Type;

    public readonly uint Timestamp;

    public readonly uint Display;

    public readonly byte @event;

    public readonly byte Padding1;

    public readonly byte Padding2;

    public readonly byte Padding3;

    public readonly int Data1;
}

public readonly struct WindowEvent
{
    public readonly uint Type;

    public readonly uint Timestamp;

    public readonly uint WindowID;

    public readonly byte @event;

    public readonly byte Padding1;

    public readonly byte Padding2;

    public readonly byte Padding3;

    public readonly int Data1;

    public readonly int Data2;
}

public readonly struct KeyboardEvent
{
    public readonly uint Type;

    public readonly uint Timestamp;

    public readonly uint WindowID;

    public readonly byte State;

    public readonly byte Repeat;

    public readonly byte Padding2;

    public readonly byte Padding3;

    public readonly KeySym KeySym;
}

[InlineArray(32)]
public struct EventText
{
    public byte E0;
}

public readonly struct TextEditingEvent
{
    public readonly uint Type;

    public readonly uint Timestamp;

    public readonly uint WindowID;

    public readonly EventText Text;

    public readonly int Start;

    public readonly int Length;
}

public readonly struct TextEditingExtEvent
{
    public readonly uint Type;

    public readonly uint Timestamp;

    public readonly uint WindowID;

    [NativeTypeName("char *")]
    public unsafe readonly byte* Text;

    public readonly int Start;

    public readonly int Length;
}

public readonly struct TextInputEvent
{
    public readonly uint Type;

    public readonly uint Timestamp;

    public readonly uint WindowID;

    public readonly EventText Text;
}

public readonly struct MouseMotionEvent
{
    public readonly uint Type;

    public readonly uint Timestamp;

    public readonly uint WindowID;

    public readonly uint Which;

    public readonly uint State;

    public readonly int X;

    public readonly int Y;

    public readonly int Xrel;

    public readonly int Yrel;
}

public readonly struct MouseButtonEvent
{
    public readonly uint Type;

    public readonly uint Timestamp;

    public readonly uint WindowID;

    public readonly uint Which;

    public readonly byte Button;

    public readonly byte State;

    public readonly byte Clicks;

    public readonly byte Padding1;

    public readonly int X;

    public readonly int Y;
}

public readonly struct MouseWheelEvent
{
    public readonly uint Type;

    public readonly uint Timestamp;

    public readonly uint WindowID;

    public readonly uint Which;

    public readonly int X;

    public readonly int Y;

    public readonly uint Direction;

    public readonly float PreciseX;

    public readonly float PreciseY;

    public readonly int MouseX;

    public readonly int MouseY;
}

public readonly struct JoyAxisEvent
{
    public readonly uint Type;

    public readonly uint Timestamp;

    [NativeTypeName("SDL_JoystickID")]
    public readonly int Which;

    public readonly byte Axis;

    public readonly byte Padding1;

    public readonly byte Padding2;

    public readonly byte Padding3;

    public readonly short Value;

    public readonly ushort Padding4;
}

public readonly struct JoyBallEvent
{
    public readonly uint Type;

    public readonly uint Timestamp;

    [NativeTypeName("SDL_JoystickID")]
    public readonly int Which;

    public readonly byte Ball;

    public readonly byte Padding1;

    public readonly byte Padding2;

    public readonly byte Padding3;

    public readonly short Xrel;

    public readonly short Yrel;
}

public readonly struct JoyHatEvent
{
    public readonly uint Type;

    public readonly uint Timestamp;

    [NativeTypeName("SDL_JoystickID")]
    public readonly int Which;

    public readonly byte Hat;

    public readonly byte Value;

    public readonly byte Padding1;

    public readonly byte Padding2;
}

public readonly struct JoyButtonEvent
{
    public readonly uint Type;

    public readonly uint Timestamp;

    [NativeTypeName("SDL_JoystickID")]
    public readonly int Which;

    public readonly byte Button;

    public readonly byte State;

    public readonly byte Padding1;

    public readonly byte Padding2;
}

public readonly struct JoyDeviceEvent
{
    public readonly uint Type;

    public readonly uint Timestamp;

    public readonly int Which;
}

public readonly struct JoyBatteryEvent
{
    public readonly uint Type;

    public readonly uint Timestamp;

    [NativeTypeName("SDL_JoystickID")]
    public readonly int Which;

    public readonly JoystickPowerLevel Level;
}

public readonly struct ControllerAxisEvent
{
    public readonly uint Type;

    public readonly uint Timestamp;

    [NativeTypeName("SDL_JoystickID")]
    public readonly int Which;

    public readonly byte Axis;

    public readonly byte Padding1;

    public readonly byte Padding2;

    public readonly byte Padding3;

    public readonly short Value;

    public readonly ushort Padding4;
}

public readonly struct ControllerButtonEvent
{
    public readonly uint Type;

    public readonly uint Timestamp;

    [NativeTypeName("SDL_JoystickID")]
    public readonly int Which;

    public readonly byte Button;

    public readonly byte State;

    public readonly byte Padding1;

    public readonly byte Padding2;
}

public readonly struct ControllerDeviceEvent
{
    public readonly uint Type;

    public readonly uint Timestamp;

    public readonly int Which;
}

public readonly struct ControllerTouchpadEvent
{
    public readonly uint Type;

    public readonly uint Timestamp;

    [NativeTypeName("SDL_JoystickID")]
    public readonly int Which;

    public readonly int Touchpad;

    public readonly int Finger;

    public readonly float X;

    public readonly float Y;

    public readonly float Pressure;
}

[InlineArray(3)]
public struct ControllerData
{
    public float E0;
}

public readonly struct ControllerSensorEvent
{
    public readonly uint Type;

    public readonly uint Timestamp;

    [NativeTypeName("SDL_JoystickID")]
    public readonly int Which;

    public readonly int Sensor;

    [NativeTypeName("float[3]")]
    public readonly ControllerData Data;

    public readonly ulong Timestamp_us;
}

public readonly struct AudioDeviceEvent
{
    public readonly uint Type;

    public readonly uint Timestamp;

    public readonly uint Which;

    public readonly byte Iscapture;

    public readonly byte Padding1;

    public readonly byte Padding2;

    public readonly byte Padding3;
}

public readonly struct TouchFingerEvent
{
    public readonly uint Type;

    public readonly uint Timestamp;

    [NativeTypeName("SDL_TouchID")]
    public readonly long TouchId;

    [NativeTypeName("SDL_FingerID")]
    public readonly long FingerId;

    public readonly float X;

    public readonly float Y;

    public readonly float Dx;

    public readonly float Dy;

    public readonly float Pressure;

    public readonly uint WindowID;
}

public readonly struct MultiGestureEvent
{
    public readonly uint Type;

    public readonly uint Timestamp;

    [NativeTypeName("SDL_TouchID")]
    public readonly long TouchId;

    public readonly float DTheta;

    public readonly float DDist;

    public readonly float X;

    public readonly float Y;

    public readonly ushort NumFingers;

    public readonly ushort Padding;
}

public readonly struct DollarGestureEvent
{
    public readonly uint Type;

    public readonly uint Timestamp;

    [NativeTypeName("SDL_TouchID")]
    public readonly long TouchId;

    [NativeTypeName("SDL_GestureID")]
    public readonly long GestureId;

    public readonly uint NumFingers;

    public readonly float Error;

    public readonly float X;

    public readonly float Y;
}

public readonly struct DropEvent
{
    public readonly uint Type;

    public readonly uint Timestamp;

    public unsafe readonly byte* File;

    public readonly uint WindowID;
}

[InlineArray(6)]
public struct SensorData
{
    public float E0;
}

public readonly struct SensorEvent
{
    public readonly uint Type;

    public readonly uint Timestamp;

    public readonly int Which;

    public readonly SensorData Data;

    public readonly ulong Timestamp_us;
}

public readonly struct QuitEvent
{
    public readonly uint Type;

    public readonly uint Timestamp;
}

public readonly struct UserEvent
{
    public readonly uint Type;

    public readonly uint Timestamp;

    public readonly uint WindowID;

    public readonly int Code;

    public unsafe readonly void* Data1;

    public unsafe readonly void* Data2;
}

public enum SysWmType
{
    SDL_SYSWM_UNKNOWN,
    SDL_SYSWM_WINDOWS,
    SDL_SYSWM_X11,
    SDL_SYSWM_DIRECTFB,
    SDL_SYSWM_COCOA,
    SDL_SYSWM_UIKIT,
    SDL_SYSWM_WAYLAND,
    SDL_SYSWM_MIR,
    SDL_SYSWM_WINRT,
    SDL_SYSWM_ANDROID,
    SDL_SYSWM_VIVANTE,
    SDL_SYSWM_OS2,
    SDL_SYSWM_HAIKU,
    SDL_SYSWM_KMSDRM,
    SDL_SYSWM_RISCOS,
}

public readonly struct SysWmMsg
{
    public readonly Version Version;

    public readonly SysWmType Subsystem;
}

public readonly struct SysWmEvent
{
    public readonly uint Type;

    public readonly uint Timestamp;

    public unsafe readonly SysWmMsg* Msg;
}