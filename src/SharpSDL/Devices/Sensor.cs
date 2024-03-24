using System.Text;

namespace SharpSDL.Devices;
public sealed class Sensor : IDisposable
{
    private readonly nint _sensor;

    internal Sensor(nint sensor) => _sensor = sensor;

    public Sensor(int sensorIndex)
    {
        _sensor = SDL.SensorOpen(sensorIndex);
        if (_sensor is 0)
            throw new SdlException("Invalid sensor index");
    }

    public int Id { get => SDL.SensorGetInstanceID(_sensor); }

    public ReadOnlySpan<byte> Name
    {
        get
        {
            unsafe
            {
                return MemoryMarshal.CreateReadOnlySpanFromNullTerminated(SDL.SensorGetName(_sensor));
            }
        }
    }

    public string NameUtf16 { get => Encoding.UTF8.GetString(Name); }

    public SensorType Type { get => (SensorType)SDL.SensorGetType(_sensor); }

    public int TypeNonPortable { get => SDL.SensorGetNonPortableType(_sensor); }

    public void GetData(Span<float> data)
    {
        unsafe
        {
            fixed (float* ptr = data)
            {
                if (SDL.SensorGetData(_sensor, ptr, data.Length) != 0)
                    throw new SdlException($"Error retrieving data for sensor '{NameUtf16}'");
            }
        }
    }

    public void GetData(Span<float> data, out ulong timestamp)
    {
        unsafe
        {
            fixed (float* ptr = data)
            {
                ulong ts = 0;
                if (SDL.SensorGetDataWithTimestamp(_sensor, &ts, ptr, data.Length) != 0)
                    throw new SdlException($"Error retrieving data for sensor '{NameUtf16}'");
                timestamp = ts;
            }
        }
    }

    public void Dispose()
    {
        if (_sensor is not 0)
        {
            unsafe
            {
                SDL.SensorClose(_sensor);
                ref var ptr = ref Unsafe.AsRef(in _sensor);
                ptr = 0;
            }
        }
    }

    public static Sensor CreateFromInstanceId(int instanceId)
    {
        var sensor = SDL.SensorFromInstanceID(instanceId);
        if (sensor is 0)
            throw new SdlException("Invalid sensor instance ID");
        return new Sensor(sensor);
    }

    public static int GetSensorDeviceCount() => SDL.NumSensors();

    public static void UpdateSensors() => SDL.SensorUpdate();

    public static IDisposable LockSensors() => new SensorsLock();

}

file sealed class SensorsLock : IDisposable
{
    private bool _disposed;

    public SensorsLock()
    {
        SDL.LockSensors();
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            _disposed = true;
            SDL.UnlockSensors();
        }
    }
}

public enum SensorType
{
    Invalid = SDL_SensorType.SDL_SENSOR_INVALID,
    Unknown = SDL_SensorType.SDL_SENSOR_UNKNOWN,
    Accelerometer = SDL_SensorType.SDL_SENSOR_ACCEL,
    Gyroscope = SDL_SensorType.SDL_SENSOR_GYRO,
    AccelerometerLeft = SDL_SensorType.SDL_SENSOR_ACCEL_L,
    GyroscopeLeft = SDL_SensorType.SDL_SENSOR_GYRO_L,
    AccelerometerRight = SDL_SensorType.SDL_SENSOR_ACCEL_R,
    GyroscopeRight = SDL_SensorType.SDL_SENSOR_GYRO_R,
}
