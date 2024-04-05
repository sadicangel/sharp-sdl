using System.Text;

namespace SharpSDL.Devices;
public sealed class Touchpad
{
    private readonly long _touchpadId;
    private readonly int _touchpadIndex;

    internal Touchpad(long id, int index)
    {
        _touchpadId = id;
        _touchpadIndex = index;
    }

    public ReadOnlySpan<byte> Name
    {
        get
        {
            unsafe
            {
                return MemoryMarshal.CreateReadOnlySpanFromNullTerminated(SDL.GetTouchName(_touchpadIndex));
            }
        }
    }

    public string NameUtf16 { get => Encoding.UTF8.GetString(Name); }

    public TouchpadType Type { get => (TouchpadType)SDL.GetTouchDeviceType(_touchpadId); }

    public int FingerCount
    {
        get
        {
            var result = SDL.GetNumTouchFingers(_touchpadId);
            if (result == 0)
                SdlException.ThrowLastError();
            return result;
        }
    }

    public ref readonly TouchpadFinger GetTouchpadFinger(int fingerIndex)
    {
        unsafe
        {
            return ref Unsafe.AsRef<TouchpadFinger>(SDL.GetTouchFinger(_touchpadId, fingerIndex));
        }
    }

    public bool RecordGesture() => SDL.RecordGesture(_touchpadId) == 1;

    public static void RecordGestureOnAllDevices() => _ = SDL.RecordGesture(-1);

    public static int GetTouchpadCount() => SDL.GetNumTouchDevices();

    public static Touchpad ForDeviceIndex(int deviceIndex)
    {
        var id = SDL.GetTouchDevice(deviceIndex);
        if (id == 0)
            SdlException.ThrowLastError();
        return new Touchpad(id, deviceIndex);
    }

    public static IReadOnlyList<Touchpad> GetTouchDevices()
    {
        var devices = new Touchpad[GetTouchpadCount()];
        for (int i = 0; i < devices.Length; ++i)
            devices[i] = ForDeviceIndex(i);
        return devices;
    }
}

public enum TouchpadType
{
    Invalid = SDL_TouchDeviceType.SDL_TOUCH_DEVICE_INVALID,
    Direct = SDL_TouchDeviceType.SDL_TOUCH_DEVICE_DIRECT,
    IndirectAbsolute = SDL_TouchDeviceType.SDL_TOUCH_DEVICE_INDIRECT_ABSOLUTE,
    IndirectRelative = SDL_TouchDeviceType.SDL_TOUCH_DEVICE_INDIRECT_RELATIVE,
}

[StructLayout(LayoutKind.Explicit)]
public readonly struct TouchpadFinger
{
    [FieldOffset(0)]
    public readonly long FingerId;
    [FieldOffset(8)]
    public readonly TouchpadFingerValues Values;
    [FieldOffset(8)]
    public readonly float X;
    [FieldOffset(12)]
    public readonly float Y;
    [FieldOffset(16)]
    public readonly float Pressure;
}

public readonly struct TouchpadFingerValues
{
    public readonly float X;
    public readonly float Y;
    public readonly float Pressure;
}
