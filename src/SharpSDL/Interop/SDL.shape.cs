namespace SharpSDL.Interop;

internal enum WindowShapeMode
{
    ShapeModeDefault,
    ShapeModeBinarizeAlpha,
    ShapeModeReverseBinarizeAlpha,
    ShapeModeColorKey,
}

[StructLayout(LayoutKind.Explicit)]
internal partial struct SDL_WindowShapeParams
{
    [FieldOffset(0)]
    public byte binarizationCutoff;

    [FieldOffset(0)]
    public SDL_Color colorKey;
}

internal partial struct SDL_WindowShapeMode
{
    public WindowShapeMode mode;

    public SDL_WindowShapeParams parameters;
}

internal static unsafe partial class SDL
{
    [LibraryImport("SDL2", EntryPoint = "SDL_CreateShapedWindow")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("SDL_Window*")]
    public static partial nint CreateShapedWindow([NativeTypeName("const char *")] byte* title, [NativeTypeName("unsigned int")] uint x, [NativeTypeName("unsigned int")] uint y, [NativeTypeName("unsigned int")] uint w, [NativeTypeName("unsigned int")] uint h, uint flags);

    [LibraryImport("SDL2", EntryPoint = "SDL_IsShapedWindow")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool IsShapedWindow([NativeTypeName("const SDL_Window *")] nint window);

    [LibraryImport("SDL2", EntryPoint = "SDL_SetWindowShape")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int SetWindowShape([NativeTypeName("SDL_Window*")] nint window, SDL_Surface* shape, SDL_WindowShapeMode* shape_mode);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetShapedWindowMode")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int GetShapedWindowMode([NativeTypeName("SDL_Window*")] nint window, SDL_WindowShapeMode* shape_mode);

    [NativeTypeName("#define SDL_NONSHAPEABLE_WINDOW -1")]
    public const int SDL_NONSHAPEABLE_WINDOW = -1;

    [NativeTypeName("#define SDL_INVALID_SHAPE_ARGUMENT -2")]
    public const int SDL_INVALID_SHAPE_ARGUMENT = -2;

    [NativeTypeName("#define SDL_WINDOW_LACKS_SHAPE -3")]
    public const int SDL_WINDOW_LACKS_SHAPE = -3;
}
