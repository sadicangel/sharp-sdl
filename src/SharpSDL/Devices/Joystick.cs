using SharpSDL.Objects;
using System.Collections.Concurrent;
using System.Text;

namespace SharpSDL.Devices;

public sealed class Joystick : IDisposable
{
    internal readonly nint _joystick;
    internal readonly int _deviceIndex;
    private readonly bool _owned;

    internal Joystick(nint joystick, int deviceIndex, bool owned, bool isVirtual)
    {
        _joystick = joystick;
        _deviceIndex = deviceIndex;
        _owned = owned;
        IsVirtual = isVirtual;
    }

    public bool IsVirtual { get; }

    public int InstanceId { get => SDL2.JoystickInstanceID(_joystick); }

    public ReadOnlySpan<byte> Name
    {
        get
        {
            unsafe
            {
                var name = SDL2.JoystickName(_joystick);
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
                var path = SDL2.JoystickPath(_joystick);
                if (path is null)
                    SdlException.ThrowLastError();
                return MemoryMarshal.CreateReadOnlySpanFromNullTerminated(path);
            }
        }
    }

    public string PathUtf16 { get => Encoding.UTF8.GetString(Path); }

    public int PlayerIndex { get => SDL2.JoystickGetPlayerIndex(_joystick); set => SDL2.JoystickSetPlayerIndex(_joystick, value); }

    public Guid Guid
    {
        get
        {
            var guid = Unsafe.BitCast<SDL_GUID, Guid>(SDL2.JoystickGetGUID(_joystick));
            if (guid == default)
                SdlException.ThrowLastError();
            return guid;
        }
    }

    public ushort Vendor { get => SDL2.JoystickGetVendor(_joystick); }

    public ushort Product { get => SDL2.JoystickGetProduct(_joystick); }

    public ushort ProductVersion { get => SDL2.JoystickGetProductVersion(_joystick); }

    public ushort FirmwareVersion { get => SDL2.JoystickGetFirmwareVersion(_joystick); }

    public ReadOnlySpan<byte> SerialNumber
    {
        get
        {
            unsafe
            {
                return MemoryMarshal.CreateReadOnlySpanFromNullTerminated(SDL2.JoystickGetSerial(_joystick));
            }
        }
    }

    public string SerialNumberUtf16 { get => Encoding.UTF8.GetString(SerialNumber); }

    public JoystickType Type { get => (JoystickType)SDL2.JoystickGetType(_joystick); }

    public bool IsAttached { get => SDL2.JoystickGetAttached(_joystick); }

    public int AxisCount { get => SDL2.JoystickNumAxes(_joystick); }

    public int TrackBallCount { get => SDL2.JoystickNumBalls(_joystick); }

    public int HatCount { get => SDL2.JoystickNumHats(_joystick); }

    public int ButtonCount { get => SDL2.JoystickNumButtons(_joystick); }

    public bool HasRumble { get => SDL2.JoystickHasRumble(_joystick); }

    public bool HasRumbleTriggers { get => SDL2.JoystickHasRumbleTriggers(_joystick); }

    public bool HasLed { get => SDL2.JoystickHasLED(_joystick); }

    public bool IsHaptic { get => SDL2.JoystickIsHaptic(_joystick) == 1; }

    public bool IsGameController { get => SDL2.IsGameController(_deviceIndex); }

    public JoystickPowerLevel PowerLevel { get => (JoystickPowerLevel)SDL2.JoystickCurrentPowerLevel(_joystick); }

    public short GetAxisValue(int axis) => SDL2.JoystickGetAxis(_joystick, axis);

    public bool TryGetAxisValue(int axis, out short value)
    {
        value = 0;

        short state = 0;
        unsafe
        {
            if (!SDL2.JoystickGetAxisInitialState(_joystick, axis, &state))
                return false;
        }
        value = state;
        return true;
    }

    public JoystickHatPosition GetHatPosition(int hat) =>
        (JoystickHatPosition)SDL2.JoystickGetHat(_joystick, hat);

    public Point GetTrackballPosition(int trackball)
    {
        var point = new Point();
        unsafe
        {
            if (SDL2.JoystickGetBall(_joystick, trackball, &point.X, &point.Y) != 0)
                SdlException.ThrowLastError();
        }
        return point;
    }

    public ButtonState GetButtonState(int button) =>
        (ButtonState)SDL2.JoystickGetButton(_joystick, button);

    public bool SetVirtualAxisValue(int axis, short value) =>
        IsVirtual && SDL2.JoystickSetVirtualAxis(_joystick, axis, value) == 0;

    public bool SetVirtualButtonState(int button, ButtonState state) =>
        IsVirtual && SDL2.JoystickSetVirtualButton(_joystick, button, (byte)state) == 0;

    public bool SetVirtualHatPosition(int hat, JoystickHatPosition position) =>
        IsVirtual && SDL2.JoystickSetVirtualHat(_joystick, hat, (byte)position) == 0;

    public bool Rumble(ushort lowFrequency, ushort highFrequency, TimeSpan duration) =>
        SDL2.JoystickRumble(_joystick, lowFrequency, highFrequency, (uint)duration.TotalMilliseconds) == 0;

    public bool RumbleTriggers(ushort leftRumble, ushort rightRumble, TimeSpan duration) =>
        SDL2.JoystickRumbleTriggers(_joystick, leftRumble, rightRumble, (uint)duration.TotalMilliseconds) == 0;

    public bool SetLed(ColorRgb color) => SDL2.JoystickSetLED(_joystick, color.R, color.G, color.B) == 0;

    public bool SendEffect(ReadOnlySpan<byte> data)
    {
        unsafe
        {
            fixed (byte* ptr = data)
            {
                return SDL2.JoystickSendEffect(_joystick, ptr, data.Length) == 0;
            }
        }
    }

    public void Dispose()
    {
        if (_owned)
        {
            if (_joystick is not 0)
            {
                unsafe
                {
                    SDL2.JoystickClose(_joystick);
                    if (IsVirtual)
                    {
                        _ = SDL2.JoystickDetachVirtual(_deviceIndex);
                        _ = VirtualJoystickDescriptorCache.Descriptors.Remove(_deviceIndex, out _);
                    }
                    ref var ptr = ref Unsafe.AsRef(in _joystick);
                    ptr = 0;
                }
            }
        }
    }

    private static Joystick FromDeviceIndex(int deviceIndex, bool isVirtual)
    {
        var joystick = SDL2.JoystickOpen(deviceIndex);
        if (joystick is 0)
            SdlException.ThrowLastError();
        return new Joystick(joystick, deviceIndex, owned: true, isVirtual);
    }

    static int FindDeviceIndex<T>(T needle, Func<int, T> getComparand) where T : IEquatable<T>
    {
        using var @lock = Lock.Joysticks();
        var count = GetJoystickCount();
        for (int i = 0; i < count; ++i)
            if (needle.Equals(getComparand(i)))
                return i;
        return -1;
    }

    public static Joystick FromDeviceIndex(int deviceIndex) => FromDeviceIndex(deviceIndex, isVirtual: false);

    public static Joystick FromInstanceId(int instanceId)
    {
        var joystick = SDL2.JoystickFromInstanceID(instanceId);
        if (joystick is 0)
            SdlException.ThrowLastError();
        var deviceIndex = FindDeviceIndex(instanceId, SDL2.JoystickGetDeviceInstanceID);
        if (deviceIndex < 0)
            throw new SdlException($"Invalid joystick instance id '{instanceId}'");
        return new Joystick(joystick, deviceIndex, owned: true, isVirtual: false);
    }

    public static Joystick FromPlayerIndex(int playerIndex)
    {
        var joystick = SDL2.JoystickFromPlayerIndex(playerIndex);
        if (joystick is 0)
            SdlException.ThrowLastError();
        var deviceIndex = FindDeviceIndex(playerIndex, SDL2.JoystickGetDevicePlayerIndex);
        if (deviceIndex < 0)
            throw new SdlException($"Invalid joystick player index'{playerIndex}'");
        return new Joystick(joystick, deviceIndex, owned: true, isVirtual: false);
    }

    public static Joystick FromGameController(GameController gameController)
    {
        var joystick = SDL2.GameControllerGetJoystick(gameController._controller);
        if (joystick is 0)
            SdlException.ThrowLastError();
        var deviceIndex = FindDeviceIndex(SDL2.JoystickInstanceID(joystick), SDL2.JoystickGetDeviceInstanceID);
        if (deviceIndex < 0)
            throw new SdlException($"Invalid joystick for '{gameController.NameUtf16}'");
        return new Joystick(joystick, deviceIndex, owned: false, isVirtual: false);
    }

    public static Joystick CreateVirtual(JoystickType type, int axes, int buttons, int hats)
    {
        var deviceId = SDL2.JoystickAttachVirtual((SDL_JoystickType)type, axes, buttons, hats);
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

                var deviceId = SDL2.JoystickAttachVirtualEx(&d);
                if (deviceId == -1)
                    SdlException.ThrowLastError();

                if (!VirtualJoystickDescriptorCache.Descriptors.TryAdd(deviceId, descriptor))
                    throw new SdlException($"Joystick with device id '{deviceId}' already added");

                return FromDeviceIndex(deviceId, isVirtual: true);
            }

            static void* GetPtr<T>(T @delegate) where T : notnull => Marshal.GetFunctionPointerForDelegate(@delegate).ToPointer();
        }
    }

    public static int GetJoystickCount() => SDL2.NumJoysticks();

    public static IReadOnlyList<Joystick> GetJoysticks()
    {
        var devices = new Joystick[GetJoystickCount()];
        for (int i = 0; i < devices.Length; ++i)
            devices[i] = FromDeviceIndex(i);
        return devices;
    }

    public static void UpdateJoysticks() => SDL2.JoystickUpdate();

    public static void GetGuidInfo(Guid guid, out ushort vendorId, out ushort productId, out ushort deviceVersion, out ushort crc16)
    {
        ushort vid, pid, dvs, crc;
        unsafe
        {
            SDL2.GetJoystickGUIDInfo(Unsafe.BitCast<Guid, SDL_GUID>(guid), &vid, &pid, &dvs, &crc);
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
    Centered = SDL2.SDL_HAT_CENTERED,
    Up = SDL2.SDL_HAT_UP,
    Right = SDL2.SDL_HAT_RIGHT,
    Down = SDL2.SDL_HAT_DOWN,
    Left = SDL2.SDL_HAT_LEFT,
    RightUp = SDL2.SDL_HAT_RIGHTUP,
    RightDown = SDL2.SDL_HAT_RIGHTDOWN,
    LeftUp = SDL2.SDL_HAT_LEFTUP,
    LeftDown = SDL2.SDL_HAT_LEFTDOWN,
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
    public const ushort Version = SDL2.SDL_VIRTUAL_JOYSTICK_DESC_VERSION;

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