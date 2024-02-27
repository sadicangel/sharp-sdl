namespace SharpSDL.Interop;

internal enum SDL_TouchDeviceType
{
    SDL_TOUCH_DEVICE_INVALID = -1,
    SDL_TOUCH_DEVICE_DIRECT,
    SDL_TOUCH_DEVICE_INDIRECT_ABSOLUTE,
    SDL_TOUCH_DEVICE_INDIRECT_RELATIVE,
}

internal partial struct SDL_Finger
{
    [NativeTypeName("SDL_FingerID")]
    public long id;

    public float x;

    public float y;

    public float pressure;
}

internal static unsafe partial class SDL
{
    [LibraryImport("SDL2", EntryPoint = "SDL_GetNumTouchDevices")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetNumTouchDevices();

    [LibraryImport("SDL2", EntryPoint = "SDL_GetTouchDevice")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_TouchID")]
    public static partial long GetTouchDevice(int index);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetTouchName")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("const char *")]
    public static partial byte* GetTouchName(int index);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetTouchDeviceType")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SDL_TouchDeviceType GetTouchDeviceType([NativeTypeName("SDL_TouchID")] long touchID);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetNumTouchFingers")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetNumTouchFingers([NativeTypeName("SDL_TouchID")] long touchID);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetTouchFinger")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SDL_Finger* GetTouchFinger([NativeTypeName("SDL_TouchID")] long touchID, int index);

    [NativeTypeName("#define SDL_TOUCH_MOUSEID (()-1)")]
    public const uint SDL_TOUCH_MOUSEID = unchecked((uint)(-1));

    [NativeTypeName("#define SDL_MOUSE_TOUCHID (()-1)")]
    public const long SDL_MOUSE_TOUCHID = ((long)(-1));
}
