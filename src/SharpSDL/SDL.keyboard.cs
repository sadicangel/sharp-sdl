using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpSDL;
internal static partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_Keysym
    {
        public SDL_Scancode scancode;
        public SDL_Keycode sym;
        public SDL_Keymod mod;
        [Obsolete] public uint unicode;
    }

    /// <summary>
    /// Gets the window which has keyboard focus.
    /// </summary>
    /// <returns>An SDL_Window pointer.</returns>
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial nint SDL_GetKeyboardFocus();

    /// <summary>
    /// Gets a snapshot of the keyboard state.
    /// Numkeys returns the size of the array if non-null
    /// </summary>
    /// <param name="numkeys"></param>
    /// <returns>A <see cref="byte"/>* pointer.</returns>
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial nint SDL_GetKeyboardState(out int numkeys);

    /// <summary>
    /// Gets the current key modifier state for the keyboard.
    /// </summary>
    /// <returns></returns>
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SDL_Keymod SDL_GetModState();

    /// <summary>
    /// Sets the current key modifier state for the keyboard.
    /// </summary>
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_SetModState(SDL_Keymod modstate);

    /// <summary>
    /// Gets the key code corresponding to the given scancode with the current keyboard layout.
    /// </summary>
    /// <param name="scancode"></param>
    /// <returns></returns>
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SDL_Keycode SDL_GetKeyFromScancode(SDL_Scancode scancode);

    /// <summary>
    /// Gets the scancode for the given keycode
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SDL_Scancode SDL_GetScancodeFromKey(SDL_Keycode key);

    /// <summary>
    /// Gets a human-readable name from a scan code.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial byte* SDL_GetScancodeName(SDL_Scancode scancode);

    /// <summary>
    /// Gets a scan code from a human-readable name.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    [LibraryImport(DllName, EntryPoint = "SDL_GetScancodeFromName")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial SDL_Scancode SDL_GetScancodeFromName(byte* name);

    /// <summary>
    /// Gets a human-readable name from a key code.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial byte* SDL_GetKeyName(SDL_Keycode key);

    /// <summary>
    /// Gets a key code from a human-readable name.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial SDL_Keycode SDL_GetKeyFromName(byte* name);

    /// <summary>
    /// Starts accepting Unicode text input events, shows onscreen keyboard.
    /// </summary>
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_StartTextInput();

    /// <summary>
    /// Checks if unicode input events are enabled.
    /// </summary>
    /// <returns></returns>
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SDL_bool SDL_IsTextInputActive();

    /// <summary>
    /// Stops receiving any text input events, hides onscreen keyboard.
    /// </summary>
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_StopTextInput();

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_ClearComposition();

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SDL_bool SDL_IsTextInputShown();

    /// <summary>
    /// Sets the rectangle used for text input, hint for IME.
    /// </summary>
    /// <param name="rect"></param>
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_SetTextInputRect(ref SDL_Rect rect);

    /// <summary>
    /// Gets whether the current platform supports on-screen keyboard.
    /// </summary>
    /// <returns></returns>
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SDL_bool SDL_HasScreenKeyboardSupport();

    /// <summary>
    /// Gets whether the on-screen keyboard shown for a given window.
    /// </summary>
    /// <param name="window"></param>
    /// <returns></returns>
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SDL_bool SDL_IsScreenKeyboardShown(/*SDL_Window*/ nint window);
}
