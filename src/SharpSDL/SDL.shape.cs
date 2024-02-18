using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpSDL;

internal static partial class SDL
{
    public const int SDL_NONSHAPEABLE_WINDOW = -1;
    public const int SDL_INVALID_SHAPE_ARGUMENT = -2;
    public const int SDL_WINDOW_LACKS_SHAPE = -3;

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial /*SDL_Window*/ nint SDL_CreateShapedWindow(byte* title, uint x, uint y, uint w, uint h, SDL_WindowFlags flags);

    [LibraryImport(DllName, EntryPoint = "SDL_IsShapedWindow")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SDL_bool SDL_IsShapedWindow(/*SDL_Window*/ nint window);

    public enum WindowShapeMode
    {
        ShapeModeDefault,
        ShapeModeBinarizeAlpha,
        ShapeModeReverseBinarizeAlpha,
        ShapeModeColorKey
    }

    public static bool SDL_SHAPEMODEALPHA(WindowShapeMode mode)
    {
        switch (mode)
        {
            case WindowShapeMode.ShapeModeDefault:
            case WindowShapeMode.ShapeModeBinarizeAlpha:
            case WindowShapeMode.ShapeModeReverseBinarizeAlpha:
                return true;
            default:
                return false;
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct SDL_WindowShapeParams
    {
        [FieldOffset(0)]
        public byte binarizationCutoff;
        [FieldOffset(0)]
        public SDL_Color colorKey;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_WindowShapeMode
    {
        public WindowShapeMode mode;
        public SDL_WindowShapeParams parameters;
    }

    [LibraryImport(DllName, EntryPoint = "SDL_SetWindowShape")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_SetWindowShape(/*SDL_Window*/ nint window, nint shape, ref SDL_WindowShapeMode shape_mode);

    [LibraryImport(DllName, EntryPoint = "SDL_GetShapedWindowMode")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_GetShapedWindowMode(/*SDL_Window*/ nint window, out SDL_WindowShapeMode shape_mode);

    [LibraryImport(DllName, EntryPoint = "SDL_GetShapedWindowMode")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SDL_GetShapedWindowMode(/*SDL_Window*/ nint window, nint shape_mode);
}
