using System.Runtime.InteropServices;

namespace SharpSDL.Interop
{
    public partial struct _SDL_Sensor
    {
    }

    public enum SensorType
    {
        INVALID = -1,
        UNKNOWN,
        ACCEL,
        GYRO,
        ACCEL_L,
        GYRO_L,
        ACCEL_R,
        GYRO_R,
    }

    public static unsafe partial class SDL
    {
        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LockSensors", ExactSpelling = true)]
        public static extern void LockSensors();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UnlockSensors", ExactSpelling = true)]
        public static extern void UnlockSensors();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_NumSensors", ExactSpelling = true)]
        public static extern int NumSensors();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SensorGetDeviceName", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern byte* SensorGetDeviceName(int device_index);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SensorGetDeviceType", ExactSpelling = true)]
        public static extern SensorType SensorGetDeviceType(int device_index);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SensorGetDeviceNonPortableType", ExactSpelling = true)]
        public static extern int SensorGetDeviceNonPortableType(int device_index);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SensorGetDeviceInstanceID", ExactSpelling = true)]
        [return: NativeTypeName("SDL_SensorID")]
        public static extern int SensorGetDeviceInstanceID(int device_index);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SensorOpen", ExactSpelling = true)]
        [return: NativeTypeName("SDL_Sensor *")]
        public static extern _SDL_Sensor* SensorOpen(int device_index);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SensorFromInstanceID", ExactSpelling = true)]
        [return: NativeTypeName("SDL_Sensor *")]
        public static extern _SDL_Sensor* SensorFromInstanceID([NativeTypeName("SDL_SensorID")] int instance_id);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SensorGetName", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern byte* SensorGetName([NativeTypeName("SDL_Sensor *")] _SDL_Sensor* sensor);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SensorGetType", ExactSpelling = true)]
        public static extern SensorType SensorGetType([NativeTypeName("SDL_Sensor *")] _SDL_Sensor* sensor);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SensorGetNonPortableType", ExactSpelling = true)]
        public static extern int SensorGetNonPortableType([NativeTypeName("SDL_Sensor *")] _SDL_Sensor* sensor);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SensorGetInstanceID", ExactSpelling = true)]
        [return: NativeTypeName("SDL_SensorID")]
        public static extern int SensorGetInstanceID([NativeTypeName("SDL_Sensor *")] _SDL_Sensor* sensor);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SensorGetData", ExactSpelling = true)]
        public static extern int SensorGetData([NativeTypeName("SDL_Sensor *")] _SDL_Sensor* sensor, float* data, int num_values);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SensorGetDataWithTimestamp", ExactSpelling = true)]
        public static extern int SensorGetDataWithTimestamp([NativeTypeName("SDL_Sensor *")] _SDL_Sensor* sensor, [NativeTypeName(" *")] ulong* timestamp, float* data, int num_values);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SensorClose", ExactSpelling = true)]
        public static extern void SensorClose([NativeTypeName("SDL_Sensor *")] _SDL_Sensor* sensor);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SensorUpdate", ExactSpelling = true)]
        public static extern void SensorUpdate();

        [NativeTypeName("#define SDL_STANDARD_GRAVITY 9.80665f")]
        public const float SDL_STANDARD_GRAVITY = 9.80665f;
    }
}
