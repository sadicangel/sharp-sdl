namespace SharpSDL.Devices;
public sealed class Sensor : IDisposable
{
    private readonly nint _sensor;

    internal Sensor(nint sensor) => _sensor = sensor;

    public int Id { get => SDL2.SensorGetInstanceID(_sensor); }

    public ReadOnlySpan<byte> Name
    {
        get
        {
            unsafe
            {
                return MemoryMarshal.CreateReadOnlySpanFromNullTerminated(SDL2.SensorGetName(_sensor));
            }
        }
    }

    public SensorType Type { get => (SensorType)SDL2.SensorGetType(_sensor); }

    public int TypeNonPortable { get => SDL2.SensorGetNonPortableType(_sensor); }

    public void GetData(Span<float> data)
    {
        unsafe
        {
            fixed (float* ptr = data)
            {
                if (SDL2.SensorGetData(_sensor, ptr, data.Length) != 0)
                    throw new SdlException($"Error retrieving data for sensor '{Name.ToStringUtf16()}'");
            }
        }
    }

    public void GetData(Span<float> data, out ulong timestamp)
    {
        unsafe
        {
            fixed (float* ptr = data)
            fixed (ulong* tmp = &timestamp)
            {
                if (SDL2.SensorGetDataWithTimestamp(_sensor, tmp, ptr, data.Length) != 0)
                    throw new SdlException($"Error retrieving data for sensor '{Name.ToStringUtf16()}'");
            }
        }
    }

    public void Dispose()
    {
        if (_sensor is not 0)
        {
            unsafe
            {
                SDL2.SensorClose(_sensor);
                ref var ptr = ref Unsafe.AsRef(in _sensor);
                ptr = 0;
            }
        }
    }

    public static Sensor FromDeviceIndex(int sensorIndex)
    {
        var sensor = SDL2.SensorOpen(sensorIndex);
        if (sensor is 0)
            throw new SdlException("Invalid sensor index");
        return new Sensor(sensor);
    }

    public static Sensor FromInstanceId(int instanceId)
    {
        var sensor = SDL2.SensorFromInstanceID(instanceId);
        if (sensor is 0)
            throw new SdlException("Invalid sensor instance ID");
        return new Sensor(sensor);
    }

    public static int GetSensorDeviceCount() => SDL2.NumSensors();

    public static void UpdateSensors() => SDL2.SensorUpdate();
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
