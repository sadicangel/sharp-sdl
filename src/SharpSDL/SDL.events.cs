using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using unsafe SDL_EventFilter = delegate*<nint, nint, int>;

namespace SharpSDL;
internal static partial class SDL
{
    // General keyboard/mouse state definitions.
    public const byte SDL_PRESSED = 1;
    public const byte SDL_RELEASED = 0;

    // Default size is according to SDL2 default.
    public const int SDL_TEXTEDITINGEVENT_TEXT_SIZE = 32;
    public const int SDL_TEXTINPUTEVENT_TEXT_SIZE = 32;

    /// <summary>
    /// The types of events that can be delivered. 
    /// </summary>
    public enum SDL_EventType : uint
    {
        SDL_FIRSTEVENT = 0,

        /* Application events */
        SDL_QUIT = 0x100,

        /* iOS/Android/WinRT app events */
        SDL_APP_TERMINATING,
        SDL_APP_LOWMEMORY,
        SDL_APP_WILLENTERBACKGROUND,
        SDL_APP_DIDENTERBACKGROUND,
        SDL_APP_WILLENTERFOREGROUND,
        SDL_APP_DIDENTERFOREGROUND,

        // 2.0.14 and above.
        SDL_LOCALECHANGED,

        /* Display events */
        // 2.0.9 and above.
        SDL_DISPLAYEVENT = 0x150,

        /* Window events */
        SDL_WINDOWEVENT = 0x200,
        SDL_SYSWMEVENT,

        /* Keyboard events */
        SDL_KEYDOWN = 0x300,
        SDL_KEYUP,
        SDL_TEXTEDITING,
        SDL_TEXTINPUT,
        SDL_KEYMAPCHANGED,
        SDL_TEXTEDITING_EXT,

        /* Mouse events */
        SDL_MOUSEMOTION = 0x400,
        SDL_MOUSEBUTTONDOWN,
        SDL_MOUSEBUTTONUP,
        SDL_MOUSEWHEEL,

        /* Joystick events */
        SDL_JOYAXISMOTION = 0x600,
        SDL_JOYBALLMOTION,
        SDL_JOYHATMOTION,
        SDL_JOYBUTTONDOWN,
        SDL_JOYBUTTONUP,
        SDL_JOYDEVICEADDED,
        SDL_JOYDEVICEREMOVED,

        /* Game controller events */
        SDL_CONTROLLERAXISMOTION = 0x650,
        SDL_CONTROLLERBUTTONDOWN,
        SDL_CONTROLLERBUTTONUP,
        SDL_CONTROLLERDEVICEADDED,
        SDL_CONTROLLERDEVICEREMOVED,
        SDL_CONTROLLERDEVICEREMAPPED,
        // 2.0.14 and above.
        SDL_CONTROLLERTOUCHPADDOWN,
        SDL_CONTROLLERTOUCHPADMOTION,
        SDL_CONTROLLERTOUCHPADUP,
        SDL_CONTROLLERSENSORUPDATE,

        /* Touch events */
        SDL_FINGERDOWN = 0x700,
        SDL_FINGERUP,
        SDL_FINGERMOTION,

        /* Gesture events */
        SDL_DOLLARGESTURE = 0x800,
        SDL_DOLLARRECORD,
        SDL_MULTIGESTURE,

        /* Clipboard events */
        SDL_CLIPBOARDUPDATE = 0x900,

        /* Drag and drop events */
        SDL_DROPFILE = 0x1000,
        // 2.0.4 and above.
        SDL_DROPTEXT,
        SDL_DROPBEGIN,
        SDL_DROPCOMPLETE,

        /* Audio hot-plug events */
        // 2.0.4 and above.
        SDL_AUDIODEVICEADDED = 0x1100,
        SDL_AUDIODEVICEREMOVED,

        /* Sensor events */
        // 2.0.9 and above.
        SDL_SENSORUPDATE = 0x1200,

        /* Render events */
        // 2.0.2 and above.
        SDL_RENDER_TARGETS_RESET = 0x2000,
        // 2.0.4 and above.
        SDL_RENDER_DEVICE_RESET,

        /* Internal events */
        // 2.0.18 and above.
        SDL_POLLSENTINEL = 0x7F00,

        /// <summary>
        /// Events starting at <see cref="SDL_USEREVENT"/> up to <see cref="SDL_LASTEVENT"/> are for
        /// application use. The should be allocated with <see cref="SDL_RegisterEvents(int)"/>
        /// </summary>
        SDL_USEREVENT = 0x8000,

        // The last event, used for bounding arrays.
        SDL_LASTEVENT = 0xFFFF
    }

    // 2.0.4 and above.
    public enum SDL_MouseWheelDirection : uint
    {
        SDL_MOUSEWHEEL_NORMAL,
        SDL_MOUSEWHEEL_FLIPPED
    }

    // Common fields shared by every event.
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_GenericEvent
    {
        public SDL_EventType type;
        public uint timestamp;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_DisplayEvent
    {
        public SDL_EventType type;
        public uint timestamp;
        public /*SDL_DisplayID*/ uint display;
        public SDL_DisplayEventID @event;
        internal byte _padding1;
        internal byte _padding2;
        internal byte _padding3;
        public int data1;
    }

    // Window state change event data (event.window.*).
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_WindowEvent
    {
        public SDL_EventType type;
        public uint timestamp;
        public /*SDL_WindowID*/ uint windowID;
        public SDL_WindowEventID @event;
        internal byte _padding1;
        internal byte _padding2;
        internal byte _padding3;
        public int data1;
        public int data2;
    }

    // Keyboard button event structure (event.key.*).
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_KeyboardEvent
    {
        public SDL_EventType type;
        public uint timestamp;
        public /*SDL_WindowID*/ uint windowID;
        public byte state;
        public byte repeat;
        internal byte _padding2;
        internal byte _padding3;
        public SDL_Keysym keysym;
    }

    [InlineArray(SDL_TEXTEDITINGEVENT_TEXT_SIZE)]
    public struct SDL_TextEditingEventText
    {
        internal byte element0;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct SDL_TextEditingEvent
    {
        public SDL_EventType type;
        public uint timestamp;
        public /*SDL_WindowID*/ uint windowID;
        public SDL_TextEditingEventText text;
        public int start;
        public int length;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct SDL_TextEditingExtEvent
    {
        public SDL_EventType type;
        public uint timestamp;
        public /*SDL_WindowID*/ uint windowID;
        /// <summary>
        /// Requires freeing with <see cref="SDL_free"/>.
        /// </summary>
        public byte* text;
        public int start;
        public int length;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct SDL_TextInputEvent
    {
        public SDL_EventType type;
        public uint timestamp;
        public /*SDL_WindowID*/ uint windowID;
        public fixed byte text[SDL_TEXTINPUTEVENT_TEXT_SIZE];
    }

    /* Mouse motion event structure (event.motion.*) */
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_MouseMotionEvent
    {
        public SDL_EventType type;
        public uint timestamp;
        public /*SDL_WindowID*/ uint windowID;
        public /*SDL_MouseID*/ uint which;
        public byte state; /* bitmask of buttons */
        internal byte _padding1;
        internal byte _padding2;
        internal byte _padding3;
        public int x;
        public int y;
        public int xrel;
        public int yrel;
    }

    /* Mouse button event structure (event.button.*) */
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_MouseButtonEvent
    {
        public SDL_EventType type;
        public uint timestamp;
        public /*SDL_WindowID*/ uint windowID;
        public /*SDL_MouseID*/ uint which;
        public byte button; /* button id */
        public byte state; /* SDL_PRESSED or SDL_RELEASED */
        public byte clicks; /* 1 for single-click, 2 for double-click, etc. */
        internal byte _padding1;
        public int x;
        public int y;
    }

    // Mouse wheel event structure (event.wheel.*).
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_MouseWheelEvent
    {
        public SDL_EventType type;
        public uint timestamp;
        public /*SDL_WindowID*/ uint windowID;
        public /*SDL_MouseID*/ uint which;
        public int x; /* amount scrolled horizontally */
        public int y; /* amount scrolled vertically */
        public uint direction; /* Set to one of the SDL_MOUSEWHEEL_* defines */
        public float preciseX; /* Requires >= 2.0.18 */
        public float preciseY; /* Requires >= 2.0.18 */
    }

    // Joystick axis motion event structure (event.jaxis.*).
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_JoyAxisEvent
    {
        public SDL_EventType type;
        public uint timestamp;
        public /*SDL_JoystickID*/ int which;
        public byte axis;
        internal byte _padding1;
        internal byte _padding2;
        internal byte _padding3;
        public short value;
        public ushort _padding4;
    }

    // Joystick trackball motion event structure (event.jball.*).
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_JoyBallEvent
    {
        public SDL_EventType type;
        public uint timestamp;
        public /*SDL_JoystickID*/ int which;
        public byte ball;
        internal byte _padding1;
        internal byte _padding2;
        internal byte _padding3;
        public short xrel;
        public short yrel;
    }

    // Joystick hat position change event struct (event.jhat.*).
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_JoyHatEvent
    {
        public SDL_EventType type;
        public uint timestamp;
        public /*SDL_JoystickID*/ int which;
        public byte hat;
        public byte value;
        internal byte _padding1;
        internal byte _padding2;
    }

    // Joystick button event structure (event.jbutton.*).
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_JoyButtonEvent
    {
        public SDL_EventType type;
        public uint timestamp;
        public /*SDL_JoystickID*/ int which;
        public byte button;
        public /*SDL_PRESSED or SDL_RELEASED*/ byte state;
        internal byte _padding1;
        internal byte _padding2;
    }

    // Joystick device event structure (event.jdevice.*).
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_JoyDeviceEvent
    {
        public SDL_EventType type;
        public uint timestamp;
        public /*SDL_JoystickID*/ int which;
    }

    /* Game controller axis motion event (event.caxis.*) */
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_ControllerAxisEvent
    {
        public SDL_EventType type;
        public uint timestamp;
        public /*SDL_JoystickID*/ int which;
        public byte axis;
        internal byte _padding1;
        internal byte _padding2;
        internal byte _padding3;
        public short value;
        internal ushort _padding4;
    }

    /* Game controller button event (event.cbutton.*) */
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_ControllerButtonEvent
    {
        public SDL_EventType type;
        public uint timestamp;
        public /*SDL_JoystickID*/ int which;
        public byte button;
        public byte state;
        internal byte _padding1;
        internal byte _padding2;
    }

    // Game controller device event (event.cdevice.*).
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_ControllerDeviceEvent
    {
        public SDL_EventType type;
        public uint timestamp;
        public /*SDL_JoystickID or instance id*/int which;
    }

    //Game controller touchpad event structure (event.ctouchpad.*).
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_ControllerTouchpadEvent
    {
        public SDL_EventType type;
        public uint timestamp;
        public /*SDL_JoystickID*/ int which;
        public int touchpad;
        public int finger;
        public float x;
        public float y;
        public float pressure;
    }

    // Game controller sensor event structure (event.csensor.*).
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_ControllerSensorEvent
    {
        public SDL_EventType type;
        public uint timestamp;
        public /*SDL_JoystickID*/ int which;
        public int sensor;
        public float data1;
        public float data2;
        public float data3;
    }

    // Audio device event (event.adevice.*).
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_AudioDeviceEvent
    {
        public SDL_EventType type;
        public uint timestamp;
        public uint which;
        public byte iscapture;
        internal byte _padding1;
        internal byte _padding2;
        internal byte _padding3;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_TouchFingerEvent
    {
        public SDL_EventType type;
        public uint timestamp;
        public /*SDL_TouchID*/ long touchId;
        public /*SDL_GestureID*/ long fingerId;
        public float x;
        public float y;
        public float dx;
        public float dy;
        public float pressure;
        public uint windowID;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_MultiGestureEvent
    {
        public SDL_EventType type;
        public uint timestamp;
        public /*SDL_TouchID*/ long touchId;
        public float dTheta;
        public float dDist;
        public float x;
        public float y;
        public ushort numFingers;
        public ushort _padding;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_DollarGestureEvent
    {
        public SDL_EventType type;
        public uint timestamp;
        public /*SDL_TouchID*/ long touchId;
        public /*SDL_GestureID*/ long gestureId;
        public uint numFingers;
        public float error;
        public float x;
        public float y;
    }

    // File open request by system (event.drop.*), enabled by default.
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct SDL_DropEvent
    {
        public SDL_EventType type;
        public uint timestamp;
        /// <summary>
        /// Requires freeing with <see cref="SDL_free"/>.
        /// </summary>
        public byte* file;
        public uint windowID;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct SDL_SensorEvent
    {
        public SDL_EventType type;
        public uint timestamp;
        public int which;
        public fixed float data[6];
    }

    // The "quit requested" event.
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_QuitEvent
    {
        public SDL_EventType type;
        public uint timestamp;
    }

    // A user defined event (event.user.*).
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_UserEvent
    {
        public SDL_EventType type;
        public uint timestamp;
        public uint windowID;
        public int code;
        public /*user-defined*/ nint data1;
        public /*user-defined*/ nint data2;
    }

    // A video driver dependent event (event.syswm.*), disabled.
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_SysWMEvent
    {
        public SDL_EventType type;
        public uint timestamp;
        public /*SDL_SysWMmsg*/ nint msg; // System dependent.
    }

    // General event structure.
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct SDL_Event
    {
        [FieldOffset(0)]
        public SDL_EventType type;
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
        internal Padding __padding;
    }

    [InlineArray(56)]
    internal struct Padding
    {
        internal byte element0;
    }

    /* Pump the event loop, getting events from the input devices*/
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_PumpEvents();

    public enum SDL_eventaction
    {
        SDL_ADDEVENT,
        SDL_PEEKEVENT,
        SDL_GETEVENT
    }

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial int SDL_PeepEvents(
        SDL_Event* events,
        int numevents,
        SDL_eventaction action,
        SDL_EventType minType,
        SDL_EventType maxType
    );

    // Checks to see if certain events are in the event queue.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SDL_bool SDL_HasEvent(SDL_EventType type);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SDL_bool SDL_HasEvents(SDL_EventType minType, SDL_EventType maxType);

    // Clears events from the event queue.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_FlushEvent(SDL_EventType type);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_FlushEvents(SDL_EventType min, SDL_EventType max);

    // Polls for currently pending events.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_PollEvent(out SDL_Event @event);

    // Waits indefinitely for the next event.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_WaitEvent(out SDL_Event @event);

    // Waits until the specified timeout (in ms) for the next event.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_WaitEventTimeout(out SDL_Event @event, int timeout);

    // Adds an event to the event queue.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_PushEvent(ref SDL_Event @event);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial void SDL_SetEventFilter(SDL_EventFilter filter, nint userdata);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial SDL_bool SDL_GetEventFilter(out SDL_EventFilter filter, out nint userdata);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial void SDL_AddEventWatch(SDL_EventFilter filter, nint userdata);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial void SDL_DelEventWatch(SDL_EventFilter filter, nint userdata);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial void SDL_FilterEvents(SDL_EventFilter filter, nint userdata);

    public const int SDL_QUERY = -1;
    public const int SDL_IGNORE = 0;
    public const int SDL_DISABLE = 0;
    public const int SDL_ENABLE = 1;

    // This function allows you to enable, disable or query events.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial byte SDL_EventState(SDL_EventType type, int state);

    // Allocate a set of user-defined events.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint SDL_RegisterEvents(int numevents);
}
