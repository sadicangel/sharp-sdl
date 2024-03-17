using System.Text;

namespace SharpSDL.Devices;
public sealed class TouchDevice
{
    private readonly long _touchId;
    private readonly int _index;

    internal TouchDevice(long id, int index)
    {
        _touchId = id;
        _index = index;
    }

    public ReadOnlySpan<byte> Name
    {
        get
        {
            unsafe
            {
                return MemoryMarshal.CreateReadOnlySpanFromNullTerminated(SDL.GetTouchName(_index));
            }
        }
    }

    public string NameUtf16 { get => Encoding.UTF8.GetString(Name); }

    public TouchDeviceType Type { get => (TouchDeviceType)SDL.GetTouchDeviceType(_touchId); }

    public int FingerCount
    {
        get
        {
            var result = SDL.GetNumTouchFingers(_touchId);
            if (result == 0)
                SdlException.ThrowLastError();
            return result;
        }
    }

    public ref readonly TouchFinger GetTouchFinger(int fingerIndex)
    {
        unsafe
        {
            return ref Unsafe.AsRef<TouchFinger>(SDL.GetTouchFinger(_touchId, fingerIndex));
        }
    }

    public static int GetTouchDeviceCount() => SDL.GetNumTouchDevices();

    public static TouchDevice GetTouchDevice(int deviceIndex)
    {
        var id = SDL.GetTouchDevice(deviceIndex);
        if (id == 0)
            SdlException.ThrowLastError();
        return new TouchDevice(id, deviceIndex);
    }

    public static IReadOnlyList<TouchDevice> GetTouchDevices()
    {
        var devices = new TouchDevice[GetTouchDeviceCount()];
        for (int i = 0; i < devices.Length; ++i)
            devices[i] = GetTouchDevice(i);
        return devices;
    }
}

public enum TouchDeviceType
{
    Invalid = -1,
    Direct,
    IndirectAbsolute,
    IndirectRelative,
}

public readonly struct TouchFinger
{
    public readonly long FingerId;
    public readonly float X;
    public readonly float Y;
    public readonly float Pressure;
}
