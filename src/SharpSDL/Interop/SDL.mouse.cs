using System.Runtime.InteropServices;

namespace SharpSDL.Interop;

internal enum SDL_SystemCursor
{
    SDL_SYSTEM_CURSOR_ARROW,
    SDL_SYSTEM_CURSOR_IBEAM,
    SDL_SYSTEM_CURSOR_WAIT,
    SDL_SYSTEM_CURSOR_CROSSHAIR,
    SDL_SYSTEM_CURSOR_WAITARROW,
    SDL_SYSTEM_CURSOR_SIZENWSE,
    SDL_SYSTEM_CURSOR_SIZENESW,
    SDL_SYSTEM_CURSOR_SIZEWE,
    SDL_SYSTEM_CURSOR_SIZENS,
    SDL_SYSTEM_CURSOR_SIZEALL,
    SDL_SYSTEM_CURSOR_NO,
    SDL_SYSTEM_CURSOR_HAND,
    SDL_NUM_SYSTEM_CURSORS,
}

internal enum SDL_MouseWheelDirection
{
    SDL_MOUSEWHEEL_NORMAL,
    SDL_MOUSEWHEEL_FLIPPED,
}

internal static unsafe partial class SDL
{
    [LibraryImport("SDL2", EntryPoint = "SDL_GetMouseFocus")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("SDL_Window*")]
    public static partial nint GetMouseFocus();

    [LibraryImport("SDL2", EntryPoint = "SDL_GetMouseState")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial uint GetMouseState(int* x, int* y);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetGlobalMouseState")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial uint GetGlobalMouseState(int* x, int* y);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetRelativeMouseState")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial uint GetRelativeMouseState(int* x, int* y);

    [LibraryImport("SDL2", EntryPoint = "SDL_WarpMouseInWindow")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void WarpMouseInWindow([NativeTypeName("SDL_Window*")] nint window, int x, int y);

    [LibraryImport("SDL2", EntryPoint = "SDL_WarpMouseGlobal")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int WarpMouseGlobal(int x, int y);

    [LibraryImport("SDL2", EntryPoint = "SDL_SetRelativeMouseMode")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int SetRelativeMouseMode([NativeTypeName("SDL_bool")] CBool enabled);

    [LibraryImport("SDL2", EntryPoint = "SDL_CaptureMouse")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int CaptureMouse([NativeTypeName("SDL_bool")] CBool enabled);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetRelativeMouseMode")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool GetRelativeMouseMode();

    [LibraryImport("SDL2", EntryPoint = "SDL_CreateCursor")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("SDL_Cursor*")]
    public static partial nint CreateCursor([NativeTypeName(" *")] byte* data, [NativeTypeName(" *")] byte* mask, int w, int h, int hot_x, int hot_y);

    [LibraryImport("SDL2", EntryPoint = "SDL_CreateColorCursor")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("SDL_Cursor*")]
    public static partial nint CreateColorCursor(SDL_Surface* surface, int hot_x, int hot_y);

    [LibraryImport("SDL2", EntryPoint = "SDL_CreateSystemCursor")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("SDL_Cursor*")]
    public static partial nint CreateSystemCursor(SDL_SystemCursor id);

    [LibraryImport("SDL2", EntryPoint = "SDL_SetCursor")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void SetCursor([NativeTypeName("SDL_Cursor*")] nint cursor);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetCursor")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("SDL_Cursor*")]
    public static partial nint GetCursor();

    [LibraryImport("SDL2", EntryPoint = "SDL_GetDefaultCursor")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("SDL_Cursor*")]
    public static partial nint GetDefaultCursor();

    [LibraryImport("SDL2", EntryPoint = "SDL_FreeCursor")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void FreeCursor([NativeTypeName("SDL_Cursor*")] nint cursor);

    [LibraryImport("SDL2", EntryPoint = "SDL_ShowCursor")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int ShowCursor(int toggle);

    [NativeTypeName("#define SDL_BUTTON_LEFT 1")]
    public const int SDL_BUTTON_LEFT = 1;

    [NativeTypeName("#define SDL_BUTTON_MIDDLE 2")]
    public const int SDL_BUTTON_MIDDLE = 2;

    [NativeTypeName("#define SDL_BUTTON_RIGHT 3")]
    public const int SDL_BUTTON_RIGHT = 3;

    [NativeTypeName("#define SDL_BUTTON_X1 4")]
    public const int SDL_BUTTON_X1 = 4;

    [NativeTypeName("#define SDL_BUTTON_X2 5")]
    public const int SDL_BUTTON_X2 = 5;

    [NativeTypeName("#define SDL_BUTTON_LMASK SDL_BUTTON(SDL_BUTTON_LEFT)")]
    public const int SDL_BUTTON_LMASK = (1 << ((1) - 1));

    [NativeTypeName("#define SDL_BUTTON_MMASK SDL_BUTTON(SDL_BUTTON_MIDDLE)")]
    public const int SDL_BUTTON_MMASK = (1 << ((2) - 1));

    [NativeTypeName("#define SDL_BUTTON_RMASK SDL_BUTTON(SDL_BUTTON_RIGHT)")]
    public const int SDL_BUTTON_RMASK = (1 << ((3) - 1));

    [NativeTypeName("#define SDL_BUTTON_X1MASK SDL_BUTTON(SDL_BUTTON_X1)")]
    public const int SDL_BUTTON_X1MASK = (1 << ((4) - 1));

    [NativeTypeName("#define SDL_BUTTON_X2MASK SDL_BUTTON(SDL_BUTTON_X2)")]
    public const int SDL_BUTTON_X2MASK = (1 << ((5) - 1));
}
