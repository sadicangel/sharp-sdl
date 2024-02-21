using System.Runtime.InteropServices;

namespace SharpSDL.Interop
{
    public enum WindowShapeMode
    {
        Default,
        BinarizeAlpha,
        ReverseBinarizeAlpha,
        ColorKey,
    }

    public enum ShapeOperationResult
    {
        Success = 0,
        [NativeTypeName("#define SDL_NONSHAPEABLE_WINDOW -1")]
        NONSHAPEABLE_WINDOW = -1,
        [NativeTypeName("#define SDL_INVALID_SHAPE_ARGUMENT -2")]
        INVALID_SHAPE_ARGUMENT = -2,
        [NativeTypeName("#define SDL_WINDOW_LACKS_SHAPE -3")]
        WINDOW_LACKS_SHAPE = -3,
    }

    [StructLayout(LayoutKind.Explicit)]
    public partial struct WindowShapeParams
    {
        [FieldOffset(0)]
        public byte binarizationCutoff;

        [FieldOffset(0)]
        public Color colorKey;
    }

    public partial struct WindowShape
    {
        public WindowShapeMode mode;

        public WindowShapeParams parameters;
    }

    public static unsafe partial class SDL
    {
        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateShapedWindow", ExactSpelling = true)]
        public static extern Window* CreateShapedWindow([NativeTypeName("const char *")] byte* title, [NativeTypeName("unsigned int")] uint x, [NativeTypeName("unsigned int")] uint y, [NativeTypeName("unsigned int")] uint w, [NativeTypeName("unsigned int")] uint h, WindowFlags flags);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_IsShapedWindow", ExactSpelling = true)]
        public static extern CBool IsShapedWindow([NativeTypeName("const Window *")] Window* window);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowShape", ExactSpelling = true)]
        public static extern ShapeOperationResult SetWindowShape(Window* window, Surface* shape, WindowShape* shape_mode);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetShapedWindowMode", ExactSpelling = true)]
        public static extern ShapeOperationResult GetShapedWindowMode(Window* window, WindowShape* shape_mode);
    }
}
