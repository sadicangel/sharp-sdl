using SharpSDL.Objects;
using System.Collections.Concurrent;
using System.Text;

namespace SharpSDL.Devices;

public sealed class Joystick : IDisposable
{
    internal readonly nint _joystick;
    private readonly int _virtualIndex;

    internal Joystick(nint joystick, int virtualIndex = -1)
    {
        _joystick = joystick;
        _virtualIndex = virtualIndex;
    }

    public int InstanceId { get => SDL.JoystickInstanceID(_joystick); }

    public ReadOnlySpan<byte> Name
    {
        get
        {
            unsafe
            {
                var name = SDL.JoystickName(_joystick);
                if (name is null)
                    SdlException.ThrowLastError();
                return MemoryMarshal.CreateReadOnlySpanFromNullTerminated(name);
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
                var path = SDL.JoystickPath(_joystick);
                if (path is null)
                    SdlException.ThrowLastError();
                return MemoryMarshal.CreateReadOnlySpanFromNullTerminated(path);
            }
        }
    }

    public string PathUtf16 { get => Encoding.UTF8.GetString(Path); }

    public int PlayerIndex { get => SDL.JoystickGetPlayerIndex(_joystick); set => SDL.JoystickSetPlayerIndex(_joystick, value); }

    public Guid Guid
    {
        get
        {
            var guid = Unsafe.BitCast<SDL_GUID, Guid>(SDL.JoystickGetGUID(_joystick));
            if (guid == default)
                SdlException.ThrowLastError();
            return guid;
        }
    }

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

    public bool IsVirtual { get => _virtualIndex != -1; }

    public bool IsHaptic { get => SDL.JoystickIsHaptic(_joystick) == 1; }

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

    public Point GetTrackballPosition(int trackball)
    {
        var point = new Point();
        unsafe
        {
            if (SDL.JoystickGetBall(_joystick, trackball, &point.X, &point.Y) != 0)
                SdlException.ThrowLastError();
        }
        return point;
    }

    public ButtonState GetButtonState(int button) =>
        (ButtonState)SDL.JoystickGetButton(_joystick, button);

    public bool SetVirtualAxisValue(int axis, short value) =>
        _virtualIndex != -1 && SDL.JoystickSetVirtualAxis(_joystick, axis, value) == 0;

    public bool SetVirtualButtonState(int button, ButtonState state) =>
        _virtualIndex != -1 && SDL.JoystickSetVirtualButton(_joystick, button, (byte)state) == 0;

    public bool SetVirtualHatPosition(int hat, JoystickHatPosition position) =>
        _virtualIndex != -1 && SDL.JoystickSetVirtualHat(_joystick, hat, (byte)position) == 0;

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
                if (_virtualIndex != -1)
                {
                    _ = SDL.JoystickDetachVirtual(_virtualIndex);
                    _ = VirtualJoystickDescriptorCache.Descriptors.Remove(_virtualIndex, out _);
                }
                ref var ptr = ref Unsafe.AsRef(in _joystick);
                ptr = 0;
            }
        }
    }

    private static Joystick FromDeviceIndex(int deviceIndex, bool isVirtual)
    {
        var joystick = SDL.JoystickOpen(deviceIndex);
        if (joystick is 0)
            SdlException.ThrowLastError();
        return new Joystick(joystick, isVirtual ? deviceIndex : -1);
    }

    public static Joystick FromDeviceIndex(int deviceIndex) => FromDeviceIndex(deviceIndex, isVirtual: false);

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

    public static Joystick CreateVirtual(JoystickType type, int axes, int buttons, int hats)
    {
        var deviceId = SDL.JoystickAttachVirtual((SDL_JoystickType)type, axes, buttons, hats);
        if (deviceId == -1)
            SdlException.ThrowLastError();
        return FromDeviceIndex(deviceId, isVirtual: true);
    }

    public static Joystick CreateVirtual(VirtualJoystickDescriptor descriptor)
    {
        unsafe
        {
            fixed (byte* name = descriptor.Name is null ? null : Encoding.UTF8.GetBytes(descriptor.Name))
            {
                var d = new SDL_VirtualJoystickDesc
                {
                    version = VirtualJoystickDescriptor.Version,
                    name = name,
                    type = (ushort)descriptor.Type,
                    naxes = descriptor.Axes,
                    nbuttons = descriptor.Buttons,
                    nhats = descriptor.Hats,
                    vendor_id = descriptor.VendorId,
                    product_id = descriptor.ProductId,
                    button_mask = (uint)descriptor.ButtonMask,
                    axis_mask = (uint)descriptor.AxisMask,
                };

                if (descriptor.Update is not null)
                    d.Update = (delegate* unmanaged[Cdecl]<void*, void>)GetPtr(
                        new JoystickUpdateNative(_ => descriptor.Update(descriptor.UserData)));

                if (descriptor.SetPlayerIndex is not null)
                    d.SetPlayerIndex = (delegate* unmanaged[Cdecl]<void*, int, void>)GetPtr(
                        new JoystickSetPlayerIndexNative((_, index) => descriptor.SetPlayerIndex(descriptor.UserData, index)));

                if (descriptor.Rumble is not null)
                    d.Rumble = (delegate* unmanaged[Cdecl]<void*, ushort, ushort, int>)GetPtr(
                        new JoystickRumbleNative((_, low, high, ms) => descriptor.Rumble(descriptor.UserData, low, high, TimeSpan.FromMicroseconds(ms))));

                if (descriptor.RumbleTriggers is not null)
                    d.RumbleTriggers = (delegate* unmanaged[Cdecl]<void*, ushort, ushort, int>)GetPtr(
                        new JoystickRumbleTriggersNative((_, left, right) => descriptor.RumbleTriggers(descriptor.UserData, left, right)));

                if (descriptor.SetLed is not null)
                    d.SetLED = (delegate* unmanaged[Cdecl]<void*, byte, byte, byte, int>)GetPtr(
                        new JoystickSetLedNative((_, r, g, b) => descriptor.SetLed(descriptor.UserData, new ColorRgb(r, g, b))));

                if (descriptor.SendEffect is not null)
                    d.SendEffect = (delegate* unmanaged[Cdecl]<void*, void*, int, int>)GetPtr(
                        new JoystickSendEffectNative((_, data, size) => descriptor.SendEffect(descriptor.UserData, new ReadOnlySpan<byte>(data, size))));

                var deviceId = SDL.JoystickAttachVirtualEx(&d);
                if (deviceId == -1)
                    SdlException.ThrowLastError();

                if (!VirtualJoystickDescriptorCache.Descriptors.TryAdd(deviceId, descriptor))
                    throw new SdlException($"Joystick with device id '{deviceId}' already added");

                return FromDeviceIndex(deviceId, isVirtual: true);
            }

            static void* GetPtr<T>(T @delegate) where T : notnull => Marshal.GetFunctionPointerForDelegate(@delegate).ToPointer();
        }
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

    public static void GetGuidInfo(Guid guid, out ushort vendorId, out ushort productId, out ushort deviceVersion, out ushort crc16)
    {
        ushort vid, pid, dvs, crc;
        unsafe
        {
            SDL.GetJoystickGUIDInfo(Unsafe.BitCast<Guid, SDL_GUID>(guid), &vid, &pid, &dvs, &crc);
        }
        vendorId = vid;
        productId = pid;
        deviceVersion = dvs;
        crc16 = crc;
    }
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

internal static class VirtualJoystickDescriptorCache
{
    public static readonly ConcurrentDictionary<int, VirtualJoystickDescriptor> Descriptors = [];
}

public delegate void JoystickUpdate(object? userData);
public delegate void JoystickSetPlayerIndex(object? userData, int playerIndex);
public delegate bool JoystickRumble(object? userData, ushort lowFrequency, ushort highFrequency, TimeSpan duration);
public delegate bool JoystickRumbleTriggers(object? userData, ushort leftRumble, ushort rightRumble);
public delegate bool JoystickSetLed(object? userData, ColorRgb color);
public delegate bool JoystickSendEffect(object? userData, ReadOnlySpan<byte> data);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
internal unsafe delegate void JoystickUpdateNative(void* userData);
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
internal unsafe delegate void JoystickSetPlayerIndexNative(void* userData, int playerIndex);
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
internal unsafe delegate bool JoystickRumbleNative(void* userData, ushort lowFrequency, ushort highFrequency, uint durationMs);
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
internal unsafe delegate bool JoystickRumbleTriggersNative(void* userData, ushort leftRumble, ushort rightRumble);
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
internal unsafe delegate bool JoystickSetLedNative(void* userData, byte r, byte g, byte b);
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
internal unsafe delegate bool JoystickSendEffectNative(void* userData, void* data, int size);

public sealed class VirtualJoystickDescriptor
{
    public const ushort Version = SDL.SDL_VIRTUAL_JOYSTICK_DESC_VERSION;

    public string? Name { get; init; }
    public JoystickType Type { get; init; }
    public ushort Axes { get; init; }
    public ushort Buttons { get; init; }
    public ushort Hats { get; init; }
    public ushort VendorId { get; init; }
    public ushort ProductId { get; init; }
    public ButtonMask ButtonMask { get; init; }
    public AxisMask AxisMask { get; init; }
    public object? UserData { get; init; }
    public JoystickUpdate? Update { get; init; }
    public JoystickSetPlayerIndex? SetPlayerIndex { get; init; }
    public JoystickRumble? Rumble { get; init; }
    public JoystickRumbleTriggers? RumbleTriggers { get; init; }
    public JoystickSetLed? SetLed { get; init; }
    public JoystickSendEffect? SendEffect { get; init; }
}