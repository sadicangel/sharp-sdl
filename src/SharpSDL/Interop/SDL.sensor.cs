namespace SharpSDL.Interop;

internal enum SDL_SensorType
{
    SDL_SENSOR_INVALID = -1,
    SDL_SENSOR_UNKNOWN,
    SDL_SENSOR_ACCEL,
    SDL_SENSOR_GYRO,
    SDL_SENSOR_ACCEL_L,
    SDL_SENSOR_GYRO_L,
    SDL_SENSOR_ACCEL_R,
    SDL_SENSOR_GYRO_R,
}

internal static unsafe partial class SDL
{
    [LibraryImport("SDL2", EntryPoint = "SDL_LockSensors")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void LockSensors();

    [LibraryImport("SDL2", EntryPoint = "SDL_UnlockSensors")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void UnlockSensors();

    [LibraryImport("SDL2", EntryPoint = "SDL_NumSensors")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int NumSensors();

    [LibraryImport("SDL2", EntryPoint = "SDL_SensorGetDeviceName")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("const char *")]
    public static partial byte* SensorGetDeviceName(int device_index);

    [LibraryImport("SDL2", EntryPoint = "SDL_SensorGetDeviceType")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SDL_SensorType SensorGetDeviceType(int device_index);

    [LibraryImport("SDL2", EntryPoint = "SDL_SensorGetDeviceNonPortableType")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SensorGetDeviceNonPortableType(int device_index);

    [LibraryImport("SDL2", EntryPoint = "SDL_SensorGetDeviceInstanceID")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_SensorID")]
    public static partial int SensorGetDeviceInstanceID(int device_index);

    [LibraryImport("SDL2", EntryPoint = "SDL_SensorOpen")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_Sensor *")]
    public static partial nint SensorOpen(int device_index);

    [LibraryImport("SDL2", EntryPoint = "SDL_SensorFromInstanceID")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_Sensor *")]
    public static partial nint SensorFromInstanceID([NativeTypeName("SDL_SensorID")] int instance_id);

    [LibraryImport("SDL2", EntryPoint = "SDL_SensorGetName")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("const char *")]
    public static partial byte* SensorGetName([NativeTypeName("SDL_Sensor *")] nint sensor);

    [LibraryImport("SDL2", EntryPoint = "SDL_SensorGetType")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SDL_SensorType SensorGetType([NativeTypeName("SDL_Sensor *")] nint sensor);

    [LibraryImport("SDL2", EntryPoint = "SDL_SensorGetNonPortableType")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SensorGetNonPortableType([NativeTypeName("SDL_Sensor *")] nint sensor);

    [LibraryImport("SDL2", EntryPoint = "SDL_SensorGetInstanceID")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_SensorID")]
    public static partial int SensorGetInstanceID([NativeTypeName("SDL_Sensor *")] nint sensor);

    [LibraryImport("SDL2", EntryPoint = "SDL_SensorGetData")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SensorGetData([NativeTypeName("SDL_Sensor *")] nint sensor, float* data, int num_values);

    [LibraryImport("SDL2", EntryPoint = "SDL_SensorGetDataWithTimestamp")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SensorGetDataWithTimestamp([NativeTypeName("SDL_Sensor *")] nint sensor, [NativeTypeName(" *")] ulong* timestamp, float* data, int num_values);

    [LibraryImport("SDL2", EntryPoint = "SDL_SensorClose")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SensorClose([NativeTypeName("SDL_Sensor *")] nint sensor);

    [LibraryImport("SDL2", EntryPoint = "SDL_SensorUpdate")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SensorUpdate();

    [NativeTypeName("#define SDL_STANDARD_GRAVITY 9.80665f")]
    public const float SDL_STANDARD_GRAVITY = 9.80665f;
}
