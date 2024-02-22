using System.Runtime.InteropServices;

namespace SharpSDL.Interop;

public partial struct Cursor
{
}

public enum SystemCursor
{
    ARROW,
    IBEAM,
    WAIT,
    CROSSHAIR,
    WAITARROW,
    SIZENWSE,
    SIZENESW,
    SIZEWE,
    SIZENS,
    SIZEALL,
    NO,
    HAND,
    CUSTOM,
}

public enum MouseWheelDirection
{
    NORMAL,
    FLIPPED,
}

[Flags]
public enum MouseButtonState : uint
{
    [NativeTypeName("#define SDL_BUTTON_LMASK SDL_BUTTON(SDL_BUTTON_LEFT)")]
    LEFT = 1 << ((1) - 1),
    [NativeTypeName("#define SDL_BUTTON_MMASK SDL_BUTTON(SDL_BUTTON_MIDDLE)")]
    MIDDLE = 1 << ((2) - 1),
    [NativeTypeName("#define SDL_BUTTON_RMASK SDL_BUTTON(SDL_BUTTON_RIGHT)")]
    RIGHT = 1 << ((3) - 1),
    [NativeTypeName("#define SDL_BUTTON_X1MASK SDL_BUTTON(SDL_BUTTON_X1)")]
    X1 = 1 << ((4) - 1),
    [NativeTypeName("#define SDL_BUTTON_X2MASK SDL_BUTTON(SDL_BUTTON_X2)")]
    X2 = 1 << ((5) - 1),
}

public static unsafe partial class SDL
{
    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetMouseFocus", ExactSpelling = true)]
    public static extern Window* GetMouseFocus();

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetMouseState", ExactSpelling = true)]
    public static extern MouseButtonState GetMouseState(int* x, int* y);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetGlobalMouseState", ExactSpelling = true)]
    public static extern MouseButtonState GetGlobalMouseState(int* x, int* y);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRelativeMouseState", ExactSpelling = true)]
    public static extern MouseButtonState GetRelativeMouseState(int* x, int* y);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WarpMouseInWindow", ExactSpelling = true)]
    public static extern void WarpMouseInWindow(Window* window, int x, int y);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WarpMouseGlobal", ExactSpelling = true)]
    public static extern int WarpMouseGlobal(int x, int y);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetRelativeMouseMode", ExactSpelling = true)]
    public static extern int SetRelativeMouseMode(CBool enabled);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CaptureMouse", ExactSpelling = true)]
    public static extern int CaptureMouse(CBool enabled);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRelativeMouseMode", ExactSpelling = true)]
    public static extern CBool GetRelativeMouseMode();

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateCursor", ExactSpelling = true)]
    public static extern Cursor* CreateCursor([NativeTypeName("const  *")] byte* data, [NativeTypeName("const  *")] byte* mask, int w, int h, int hot_x, int hot_y);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateColorCursor", ExactSpelling = true)]
    public static extern Cursor* CreateColorCursor(Surface* surface, int hot_x, int hot_y);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateSystemCursor", ExactSpelling = true)]
    public static extern Cursor* CreateSystemCursor(SystemCursor id);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetCursor", ExactSpelling = true)]
    public static extern void SetCursor(Cursor* cursor);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetCursor", ExactSpelling = true)]
    public static extern Cursor* GetCursor();

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetDefaultCursor", ExactSpelling = true)]
    public static extern Cursor* GetDefaultCursor();

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FreeCursor", ExactSpelling = true)]
    public static extern void FreeCursor(Cursor* cursor);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ShowCursor", ExactSpelling = true)]
    public static extern int ShowCursor(int toggle);
}
