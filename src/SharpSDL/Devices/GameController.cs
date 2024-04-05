using SharpSDL.Objects;
using System.Text;

namespace SharpSDL.Devices;
public sealed class GameController : IDisposable
{
    internal readonly nint _controller;
    private Joystick? _joystick;

    internal GameController(nint controller) => _controller = controller;

    public ReadOnlySpan<byte> Name
    {
        get
        {
            unsafe
            {
                return MemoryMarshal.CreateReadOnlySpanFromNullTerminated(SDL.GameControllerName(_controller));
            }
        }
    }

    public string NameUtf16 { get => Encoding.UTF8.GetString(Name); }

    public ReadOnlySpan<byte> Path
    {
        get
        {
            unsafe
            {
                return MemoryMarshal.CreateReadOnlySpanFromNullTerminated(SDL.GameControllerPath(_controller));
            }
        }
    }

    public string PathUtf16 { get => Encoding.UTF8.GetString(Path); }

    public GameControllerType Type { get => (GameControllerType)SDL.GameControllerGetType(_controller); }

    public int PlayerIndex { get => SDL.GameControllerGetPlayerIndex(_controller); set => SDL.GameControllerSetPlayerIndex(_controller, value); }

    public ushort Vendor { get => SDL.GameControllerGetVendor(_controller); }

    public ushort Product { get => SDL.GameControllerGetProduct(_controller); }

    public ushort ProductVersion { get => SDL.GameControllerGetProductVersion(_controller); }

    public ushort FirmwareVersion { get => SDL.GameControllerGetProductVersion(_controller); }

    public ReadOnlySpan<byte> SerialNumber
    {
        get
        {
            unsafe
            {
                return MemoryMarshal.CreateReadOnlySpanFromNullTerminated(SDL.JoystickGetSerial(_controller));
            }
        }
    }

    public string SerialNumberUtf16 { get => Encoding.UTF8.GetString(SerialNumber); }

    public ulong SteamHandle { get => SDL.GameControllerGetSteamHandle(_controller); }

    public bool IsAttached { get => SDL.GameControllerGetAttached(_controller); }

    public Joystick Joystick { get => _joystick ??= Joystick.FromGameController(this); }

    public int TouchpadCount { get => SDL.GameControllerGetNumTouchpads(_controller); }

    public bool HasRumble { get => SDL.GameControllerHasRumble(_controller); }

    public bool HasRumbleTriggers { get => SDL.GameControllerHasRumbleTriggers(_controller); }

    public bool HasLed { get => SDL.GameControllerHasLED(_controller); }

    public static bool EnableEvents
    {
        get => SDL.GameControllerEventState(SDL.SDL_QUERY) == SDL.SDL_ENABLE;
        set => _ = SDL.GameControllerEventState(value ? SDL.SDL_ENABLE : SDL.SDL_DISABLE);
    }

    public void Dispose()
    {
        if (_controller is not 0)
        {
            unsafe
            {
                SDL.JoystickClose(_controller);
                ref var ptr = ref Unsafe.AsRef(in _controller);
                ptr = 0;
            }
        }
    }

    public bool HasAxis(GameControllerAxis axis) =>
        SDL.GameControllerHasAxis(_controller, (SDL_GameControllerAxis)axis);

    public short GetAxis(GameControllerAxis axis) =>
        SDL.GameControllerGetAxis(_controller, (SDL_GameControllerAxis)axis);

    public bool HasButton(GameControllerButton button) =>
        SDL.GameControllerHasButton(_controller, (SDL_GameControllerButton)button);

    public short GetButton(GameControllerButton button) =>
        SDL.GameControllerGetButton(_controller, (SDL_GameControllerButton)button);

    public GameControllerBind GetBind(GameControllerAxis axis) =>
        Unsafe.BitCast<SDL_GameControllerButtonBind, GameControllerBind>(SDL.GameControllerGetBindForAxis(_controller, (SDL_GameControllerAxis)axis));

    public GameControllerBind GetBind(GameControllerButton button) =>
        Unsafe.BitCast<SDL_GameControllerButtonBind, GameControllerBind>(SDL.GameControllerGetBindForButton(_controller, (SDL_GameControllerButton)button));

    public int GetTouchpadFingerCount(int touchpadIndex) => SDL.GameControllerGetNumTouchpadFingers(_controller, touchpadIndex);

    public TouchpadFingerValues GetTouchpadFinger(int touchpadIndex, int fingerIndex, out bool isEnabled)
    {
        unsafe
        {
            var finger = new TouchpadFingerValues();
            byte state;
            if (SDL.GameControllerGetTouchpadFinger(_controller, touchpadIndex, fingerIndex, &state, &finger.X, &finger.Y, &finger.Pressure) != 0)
                SdlException.ThrowLastError();
            isEnabled = state is SDL.SDL_ENABLE;
            return finger;
        }
    }

    public bool HasSensor(SensorType sensor) =>
        SDL.GameControllerHasSensor(_controller, (SDL_SensorType)sensor);

    public void ToggleSensor(SensorType sensor, bool enable) =>
        _ = SDL.GameControllerSetSensorEnabled(_controller, (SDL_SensorType)sensor, enable) is 0 ? 0 : SdlException.ThrowLastError<int>();

    public void EnableSensor(SensorType sensor) => ToggleSensor(sensor, enable: true);

    public void DisableSensor(SensorType sensor) => ToggleSensor(sensor, enable: false);

    public float GetSensorDataRate(SensorType sensor) => SDL.GameControllerGetSensorDataRate(_controller, (SDL_SensorType)sensor);


    public void GetData(SensorType type, Span<float> data)
    {
        unsafe
        {
            fixed (float* ptr = data)
            {
                if (SDL.GameControllerGetSensorData(_controller, (SDL_SensorType)type, ptr, data.Length) != 0)
                    throw new SdlException($"Error retrieving data for sensor '{NameUtf16}'");
            }
        }
    }

    public void GetData(SensorType type, Span<float> data, out ulong timestamp)
    {
        unsafe
        {
            fixed (float* ptr = data)
            fixed (ulong* tmp = &timestamp)
            {
                if (SDL.GameControllerGetSensorDataWithTimestamp(_controller, (SDL_SensorType)type, tmp, ptr, data.Length) != 0)
                    throw new SdlException($"Error retrieving data for sensor '{NameUtf16}'");
            }
        }
    }

    public bool Rumble(ushort lowFrequency, ushort highFrequency, TimeSpan duration) =>
        SDL.GameControllerRumble(_controller, lowFrequency, highFrequency, (uint)duration.TotalMilliseconds) is 0;

    public bool RumbleTriggers(ushort leftRumble, ushort rightRumble, TimeSpan duration) =>
        SDL.GameControllerRumbleTriggers(_controller, leftRumble, rightRumble, (uint)duration.TotalMilliseconds) is 0;

    public bool SetLed(ColorRgb color) => SDL.GameControllerSetLED(_controller, color.R, color.G, color.B) == 0;

    public bool SendEffect(ReadOnlySpan<byte> data)
    {
        unsafe
        {
            fixed (byte* ptr = data)
            {
                return SDL.GameControllerSendEffect(_controller, ptr, data.Length) == 0;
            }
        }
    }

    public static void Update() => SDL.GameControllerUpdate();

    public static GameController FromJoystick(Joystick joystick) => FromJoystickDeviceIndex(joystick._deviceIndex);

    public static GameController FromJoystickDeviceIndex(int deviceIndex)
    {
        var controller = SDL.GameControllerOpen(deviceIndex);
        if (controller is 0)
            SdlException.ThrowLastError();
        return new GameController(controller);
    }

    public static GameController FromJoystickInstanceId(int instanceId)
    {
        var controller = SDL.GameControllerFromInstanceID(instanceId);
        if (controller is 0)
            SdlException.ThrowLastError();
        return new GameController(controller);
    }

    public static GameController FromJoystickPlayerIndex(int playerIndex)
    {
        var controller = SDL.GameControllerFromPlayerIndex(playerIndex);
        if (controller is 0)
            SdlException.ThrowLastError();
        return new GameController(controller);
    }
}

public enum GameControllerType
{
    Unknown = SDL_GameControllerType.SDL_CONTROLLER_TYPE_UNKNOWN,
    Xbox360 = SDL_GameControllerType.SDL_CONTROLLER_TYPE_XBOX360,
    XboxOne = SDL_GameControllerType.SDL_CONTROLLER_TYPE_XBOXONE,
    PS3 = SDL_GameControllerType.SDL_CONTROLLER_TYPE_PS3,
    PS4 = SDL_GameControllerType.SDL_CONTROLLER_TYPE_PS4,
    NintendoSwitchPro = SDL_GameControllerType.SDL_CONTROLLER_TYPE_NINTENDO_SWITCH_PRO,
    Virtual = SDL_GameControllerType.SDL_CONTROLLER_TYPE_VIRTUAL,
    PS5 = SDL_GameControllerType.SDL_CONTROLLER_TYPE_PS5,
    AmazonLuna = SDL_GameControllerType.SDL_CONTROLLER_TYPE_AMAZON_LUNA,
    GoogleStadia = SDL_GameControllerType.SDL_CONTROLLER_TYPE_GOOGLE_STADIA,
    NvidiaShield = SDL_GameControllerType.SDL_CONTROLLER_TYPE_NVIDIA_SHIELD,
    NintendoSwitchJoyConLeft = SDL_GameControllerType.SDL_CONTROLLER_TYPE_NINTENDO_SWITCH_JOYCON_LEFT,
    NintendoSwitchJoyConRight = SDL_GameControllerType.SDL_CONTROLLER_TYPE_NINTENDO_SWITCH_JOYCON_RIGHT,
    NintendoSwitchJoyConPair = SDL_GameControllerType.SDL_CONTROLLER_TYPE_NINTENDO_SWITCH_JOYCON_PAIR,
}

public enum GameControllerBindType
{
    None = SDL_GameControllerBindType.SDL_CONTROLLER_BINDTYPE_NONE,
    Button = SDL_GameControllerBindType.SDL_CONTROLLER_BINDTYPE_BUTTON,
    Axis = SDL_GameControllerBindType.SDL_CONTROLLER_BINDTYPE_AXIS,
    Hat = SDL_GameControllerBindType.SDL_CONTROLLER_BINDTYPE_HAT,
}

public readonly struct GameControllerBind
{
    public readonly GameControllerBindType BindType;

    public readonly GameControllerBindUnion As;
}

[StructLayout(LayoutKind.Explicit)]
public readonly struct GameControllerBindUnion
{
    [FieldOffset(0)]
    public readonly GameControllerBindButton Button;

    [FieldOffset(0)]
    public readonly GameControllerBindAxis Axis;

    [FieldOffset(0)]
    public readonly GameControllerBindHat Hat;
}

public readonly struct GameControllerBindButton
{
    public readonly int Value;
}

public readonly struct GameControllerBindAxis
{
    public readonly int Value;
}

public readonly struct GameControllerBindHat
{
    public readonly int Value;
    public readonly int Mask;
}

public enum GameControllerAxis
{
    Invalid = SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_INVALID,
    LeftX = SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_LEFTX,
    LeftY = SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_LEFTY,
    RightX = SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_RIGHTX,
    RightY = SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_RIGHTY,
    TriggerLeft = SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_TRIGGERLEFT,
    TriggerRight = SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_TRIGGERRIGHT,
}

public enum GameControllerButton
{
    Invalid = SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_INVALID,
    A = SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_A,
    B = SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_B,
    X = SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_X,
    Y = SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_Y,
    Back = SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_BACK,
    Guide = SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_GUIDE,
    Start = SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_START,
    LeftStick = SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_LEFTSTICK,
    RightStick = SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_RIGHTSTICK,
    LeftShoulder = SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_LEFTSHOULDER,
    RightShoulder = SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_RIGHTSHOULDER,
    DPadUp = SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_DPAD_UP,
    DPadDown = SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_DPAD_DOWN,
    DPadLeft = SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_DPAD_LEFT,
    DPadRight = SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_DPAD_RIGHT,
    Misc1 = SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_MISC1,
    Paddle1 = SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_PADDLE1,
    Paddle2 = SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_PADDLE2,
    Paddle3 = SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_PADDLE3,
    Paddle4 = SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_PADDLE4,
    Touchpad = SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_TOUCHPAD,
}

public static class GameControllerExtensions
{
    public static string GetAxisName(this GameController _, GameControllerAxis axis)
    {
        unsafe
        {
            return Encoding.UTF8.GetString(MemoryMarshal.CreateReadOnlySpanFromNullTerminated(SDL.GameControllerGetStringForAxis((SDL_GameControllerAxis)axis)));
        }
    }
    public static string GetAxisAppleSFSymbolsName(this GameController controller, GameControllerAxis axis)
    {
        unsafe
        {
            return Encoding.UTF8.GetString(MemoryMarshal.CreateReadOnlySpanFromNullTerminated(SDL.GameControllerGetAppleSFSymbolsNameForAxis(controller._controller, (SDL_GameControllerAxis)axis)));
        }
    }

    public static GameControllerAxis GetControllerAxis(this GameController _, string axis)
    {
        unsafe
        {
            return (GameControllerAxis)axis.AsUtf8((p, _) => SDL.GameControllerGetAxisFromString(p));
        }
    }

    public static string GetButtonName(this GameController _, GameControllerButton axis)
    {
        unsafe
        {
            return Encoding.UTF8.GetString(MemoryMarshal.CreateReadOnlySpanFromNullTerminated(SDL.GameControllerGetStringForButton((SDL_GameControllerButton)axis)));
        }
    }

    public static string GetButtonAppleSFSymbolsName(this GameController controller, GameControllerButton button)
    {
        unsafe
        {
            return Encoding.UTF8.GetString(MemoryMarshal.CreateReadOnlySpanFromNullTerminated(SDL.GameControllerGetAppleSFSymbolsNameForButton(controller._controller, (SDL_GameControllerButton)button)));
        }
    }

    public static GameControllerButton GetControllerButton(this GameController _, string axis)
    {
        unsafe
        {
            return (GameControllerButton)axis.AsUtf8((p, _) => SDL.GameControllerGetButtonFromString(p));
        }
    }
}