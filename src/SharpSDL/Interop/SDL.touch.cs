using System.Runtime.InteropServices;

namespace SharpSDL.Interop
{
    public enum TouchDeviceType
    {
        INVALID = -1,
        DIRECT,
        INDIRECT_ABSOLUTE,
        INDIRECT_RELATIVE,
    }

    public partial struct Finger
    {
        [NativeTypeName("FingerID")]
        public long id;

        public float x;

        public float y;

        public float pressure;
    }

    public static unsafe partial class SDL
    {
        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetNumTouchDevices", ExactSpelling = true)]
        public static extern int GetNumTouchDevices();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetTouchDevice", ExactSpelling = true)]
        [return: NativeTypeName("SDL_TouchID")]
        public static extern long GetTouchDevice(int index);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetTouchName", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern byte* GetTouchName(int index);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetTouchDeviceType", ExactSpelling = true)]
        public static extern TouchDeviceType GetTouchDeviceType([NativeTypeName("SDL_TouchID")] long touchID);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetNumTouchFingers", ExactSpelling = true)]
        public static extern int GetNumTouchFingers([NativeTypeName("SDL_TouchID")] long touchID);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetTouchFinger", ExactSpelling = true)]
        public static extern Finger* GetTouchFinger([NativeTypeName("SDL_TouchID")] long touchID, int index);

        [NativeTypeName("#define SDL_TOUCH_MOUSEID (()-1)")]
        public const uint SDL_TOUCH_MOUSEID = unchecked((uint)(-1));

        [NativeTypeName("#define SDL_MOUSE_TOUCHID (()-1)")]
        public const long SDL_MOUSE_TOUCHID = ((long)(-1));
    }
}
