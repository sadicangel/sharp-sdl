using System.Runtime.InteropServices;

namespace SharpSDL.Interop;

internal partial struct SDL_Keysym
{
    public SDL_Scancode scancode;

    [NativeTypeName("SDL_Keycode")]
    public int sym;

    public ushort mod;

    public uint unused;
}

internal static unsafe partial class SDL
{
    [LibraryImport("SDL2", EntryPoint = "SDL_GetKeyboardFocus")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("SDL_Window*")]
    public static partial nint GetKeyboardFocus();

    [LibraryImport("SDL2", EntryPoint = "SDL_GetKeyboardState")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName(" *")]
    public static partial byte* GetKeyboardState(int* numkeys);

    [LibraryImport("SDL2", EntryPoint = "SDL_ResetKeyboard")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void ResetKeyboard();

    [LibraryImport("SDL2", EntryPoint = "SDL_GetModState")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial SDL_Keymod GetModState();

    [LibraryImport("SDL2", EntryPoint = "SDL_SetModState")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void SetModState(SDL_Keymod modstate);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetKeyFromScancode")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("SDL_Keycode")]
    public static partial int GetKeyFromScancode(SDL_Scancode scancode);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetScancodeFromKey")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial SDL_Scancode GetScancodeFromKey([NativeTypeName("SDL_Keycode")] int key);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetScancodeName")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("const char *")]
    public static partial byte* GetScancodeName(SDL_Scancode scancode);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetScancodeFromName")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial SDL_Scancode GetScancodeFromName([NativeTypeName("const char *")] byte* name);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetKeyName")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("const char *")]
    public static partial byte* GetKeyName([NativeTypeName("SDL_Keycode")] int key);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetKeyFromName")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("SDL_Keycode")]
    public static partial int GetKeyFromName([NativeTypeName("const char *")] byte* name);

    [LibraryImport("SDL2", EntryPoint = "SDL_StartTextInput")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void StartTextInput();

    [LibraryImport("SDL2", EntryPoint = "SDL_IsTextInputActive")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool IsTextInputActive();

    [LibraryImport("SDL2", EntryPoint = "SDL_StopTextInput")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void StopTextInput();

    [LibraryImport("SDL2", EntryPoint = "SDL_ClearComposition")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void ClearComposition();

    [LibraryImport("SDL2", EntryPoint = "SDL_IsTextInputShown")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool IsTextInputShown();

    [LibraryImport("SDL2", EntryPoint = "SDL_SetTextInputRect")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void SetTextInputRect([NativeTypeName("const SDL_Rect *")] SDL_Rect* rect);

    [LibraryImport("SDL2", EntryPoint = "SDL_HasScreenKeyboardSupport")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool HasScreenKeyboardSupport();

    [LibraryImport("SDL2", EntryPoint = "SDL_IsScreenKeyboardShown")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool IsScreenKeyboardShown([NativeTypeName("SDL_Window*")] nint window);
}
