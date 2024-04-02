using SharpSDL.Objects;
using System.Text;

namespace SharpSDL.Devices;

public sealed class Joystick : IDisposable
{
    private readonly nint _joystick;

    internal Joystick(nint joystick) => _joystick = joystick;

    public Guid Guid { get => Unsafe.BitCast<SDL_GUID, Guid>(SDL.JoystickGetGUID(_joystick)); }

    public int InstanceId { get => SDL.JoystickInstanceID(_joystick); }

    public ReadOnlySpan<byte> Name
    {
        get
        {
            unsafe
            {
                return MemoryMarshal.CreateReadOnlySpanFromNullTerminated(SDL.JoystickName(_joystick));
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
                return MemoryMarshal.CreateReadOnlySpanFromNullTerminated(SDL.JoystickPath(_joystick));
            }
        }
    }

    public string PathUtf16 { get => Encoding.UTF8.GetString(Path); }

    public int PlayerIndex { get => SDL.JoystickGetPlayerIndex(_joystick); set => SDL.JoystickSetPlayerIndex(_joystick, value); }

    public ushort Vendor { get => SDL.JoystickGetVendor(_joystick); }

    public ushort Product { get => SDL.JoystickGetProduct(_joystick); }

    public ushort ProductVersion { get => SDL.JoystickGetProductVersion(_joystick); }

    public ushort FirmwareVersion { get => SDL.JoystickGetFirmwareVersion(_joystick); }

    public ReadOnlySpan<byte> SerialNumber
    {
        get
        {
            unsafe
            {
                return MemoryMarshal.CreateReadOnlySpanFromNullTerminated(SDL.JoystickGetSerial(_joystick));
            }
        }
    }

    public string SerialNumberUtf16 { get => Encoding.UTF8.GetString(SerialNumber); }

    public JoystickType Type { get => (JoystickType)SDL.JoystickGetType(_joystick); }

    public bool IsAttached { get => SDL.JoystickGetAttached(_joystick); }

    public int AxisCount { get => SDL.JoystickNumAxes(_joystick); }

    public int TrackBallCount { get => SDL.JoystickNumBalls(_joystick); }

    public int HatCount { get => SDL.JoystickNumHats(_joystick); }

    public int ButtonCount { get => SDL.JoystickNumButtons(_joystick); }

    public bool HasRumble { get => SDL.JoystickHasRumble(_joystick); }

    public bool HasRumbleTriggers { get => SDL.JoystickHasRumbleTriggers(_joystick); }

    public bool HasLed { get => SDL.JoystickHasLED(_joystick); }

    public JoystickPowerLevel PowerLevel { get => (JoystickPowerLevel)SDL.JoystickCurrentPowerLevel(_joystick); }

    public short GetAxisValue(int axis) => SDL.JoystickGetAxis(_joystick, axis);

    public bool TryGetAxisValue(int axis, out short value)
    {
        value = 0;

        short state = 0;
        unsafe
        {
            if (!SDL.JoystickGetAxisInitialState(_joystick, axis, &state))
                return false;
        }
        value = state;
        return true;
    }

    public JoystickHatPosition GetHatPosition(int hat) =>
        (JoystickHatPosition)SDL.JoystickGetHat(_joystick, hat);

    public Point GetTrackball(int trackball)
    {
        var point = new Point();
        unsafe
        {
            if (SDL.JoystickGetBall(_joystick, trackball, &point.X, &point.Y) != 0)
                SdlException.ThrowLastError();
        }
        return point;
    }

    public ButtonState GetButton(int button) =>
        (ButtonState)SDL.JoystickGetButton(_joystick, button);

    public bool Rumble(ushort lowFrequency, ushort highFrequency, TimeSpan duration) =>
        SDL.JoystickRumble(_joystick, lowFrequency, highFrequency, (uint)duration.TotalMilliseconds) == 0;

    public bool RumbleTriggers(ushort leftRumble, ushort rightRumble, TimeSpan duration) =>
        SDL.JoystickRumbleTriggers(_joystick, leftRumble, rightRumble, (uint)duration.TotalMilliseconds) == 0;

    public bool SetLed(ColorRgb color) => SDL.JoystickSetLED(_joystick, color.R, color.G, color.B) == 0;

    public bool SendEffect(ReadOnlySpan<byte> data)
    {
        unsafe
        {
            fixed (byte* ptr = data)
            {
                return SDL.JoystickSendEffect(_joystick, ptr, data.Length) == 0;
            }
        }
    }

    public void Dispose()
    {
        if (_joystick is not 0)
        {
            unsafe
            {
                SDL.JoystickClose(_joystick);
                ref var ptr = ref Unsafe.AsRef(in _joystick);
                ptr = 0;
            }
        }
    }

    public static Joystick FromDeviceIndex(int deviceIndex)
    {
        var joystick = SDL.JoystickOpen(deviceIndex);
        if (joystick is 0)
            SdlException.ThrowLastError();
        return new Joystick(joystick);
    }

    public static Joystick FromInstanceId(int instanceId)
    {
        var joystick = SDL.JoystickFromInstanceID(instanceId);
        if (joystick is 0)
            SdlException.ThrowLastError();
        return new Joystick(joystick);
    }

    public static Joystick FromPlayerIndex(int playerIndex)
    {
        var joystick = SDL.JoystickFromPlayerIndex(playerIndex);
        if (joystick is 0)
            SdlException.ThrowLastError();
        return new Joystick(joystick);
    }

    public static int GetJoystickDeviceCount() => SDL.NumJoysticks();

    public static IReadOnlyList<Joystick> GetJoysticks()
    {
        var devices = new Joystick[GetJoystickDeviceCount()];
        for (int i = 0; i < devices.Length; ++i)
            devices[i] = FromDeviceIndex(i);
        return devices;
    }

    public static void UpdateJoysticks() => SDL.JoystickUpdate();
}

public enum JoystickType
{
    Unknown = SDL_JoystickType.SDL_JOYSTICK_TYPE_UNKNOWN,
    GameController = SDL_JoystickType.SDL_JOYSTICK_TYPE_GAMECONTROLLER,
    Wheel = SDL_JoystickType.SDL_JOYSTICK_TYPE_WHEEL,
    ArcadeStick = SDL_JoystickType.SDL_JOYSTICK_TYPE_ARCADE_STICK,
    FlightStick = SDL_JoystickType.SDL_JOYSTICK_TYPE_FLIGHT_STICK,
    DancePad = SDL_JoystickType.SDL_JOYSTICK_TYPE_DANCE_PAD,
    Guitar = SDL_JoystickType.SDL_JOYSTICK_TYPE_GUITAR,
    DrumKit = SDL_JoystickType.SDL_JOYSTICK_TYPE_DRUM_KIT,
    ArcadePad = SDL_JoystickType.SDL_JOYSTICK_TYPE_ARCADE_PAD,
    Throttle = SDL_JoystickType.SDL_JOYSTICK_TYPE_THROTTLE,
}

public enum JoystickPowerLevel
{
    Unknown = SDL_JoystickPowerLevel.SDL_JOYSTICK_POWER_UNKNOWN,
    Empty = SDL_JoystickPowerLevel.SDL_JOYSTICK_POWER_EMPTY,
    Low = SDL_JoystickPowerLevel.SDL_JOYSTICK_POWER_LOW,
    Medium = SDL_JoystickPowerLevel.SDL_JOYSTICK_POWER_MEDIUM,
    Full = SDL_JoystickPowerLevel.SDL_JOYSTICK_POWER_FULL,
    Wired = SDL_JoystickPowerLevel.SDL_JOYSTICK_POWER_WIRED,
    Max = SDL_JoystickPowerLevel.SDL_JOYSTICK_POWER_MAX,
}

[Flags]
public enum JoystickHatPosition
{
    Centered = SDL.SDL_HAT_CENTERED,
    Up = SDL.SDL_HAT_UP,
    Right = SDL.SDL_HAT_RIGHT,
    Down = SDL.SDL_HAT_DOWN,
    Left = SDL.SDL_HAT_LEFT,
    RightUp = SDL.SDL_HAT_RIGHTUP,
    RightDown = SDL.SDL_HAT_RIGHTDOWN,
    LeftUp = SDL.SDL_HAT_LEFTUP,
    LeftDown = SDL.SDL_HAT_LEFTDOWN,
}
