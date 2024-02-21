using System.Runtime.InteropServices;

namespace SharpSDL.Interop
{
    public partial struct Keysym
    {
        public Scancode scancode;

        [NativeTypeName("SDL_Keycode")]
        public int sym;

        public ushort mod;

        public uint unused;
    }

    public static unsafe partial class SDL
    {
        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetKeyboardFocus", ExactSpelling = true)]
        public static extern Window* GetKeyboardFocus();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetKeyboardState", ExactSpelling = true)]
        [return: NativeTypeName("const  *")]
        public static extern byte* GetKeyboardState(int* numkeys);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ResetKeyboard", ExactSpelling = true)]
        public static extern void ResetKeyboard();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetModState", ExactSpelling = true)]
        public static extern Keymod GetModState();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetModState", ExactSpelling = true)]
        public static extern void SetModState(Keymod modstate);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetKeyFromScancode", ExactSpelling = true)]
        [return: NativeTypeName("SDL_Keycode")]
        public static extern int GetKeyFromScancode(Scancode scancode);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetScancodeFromKey", ExactSpelling = true)]
        public static extern Scancode GetScancodeFromKey([NativeTypeName("SDL_Keycode")] int key);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetScancodeName", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern byte* GetScancodeName(Scancode scancode);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetScancodeFromName", ExactSpelling = true)]
        public static extern Scancode GetScancodeFromName([NativeTypeName("const char *")] byte* name);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetKeyName", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern byte* GetKeyName([NativeTypeName("SDL_Keycode")] int key);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetKeyFromName", ExactSpelling = true)]
        [return: NativeTypeName("SDL_Keycode")]
        public static extern int GetKeyFromName([NativeTypeName("const char *")] byte* name);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_StartTextInput", ExactSpelling = true)]
        public static extern void StartTextInput();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_IsTextInputActive", ExactSpelling = true)]
        public static extern CBool IsTextInputActive();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_StopTextInput", ExactSpelling = true)]
        public static extern void StopTextInput();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ClearComposition", ExactSpelling = true)]
        public static extern void ClearComposition();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_IsTextInputShown", ExactSpelling = true)]
        public static extern CBool IsTextInputShown();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetTextInputRect", ExactSpelling = true)]
        public static extern void SetTextInputRect([NativeTypeName("const Rect *")] Rect* rect);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasScreenKeyboardSupport", ExactSpelling = true)]
        public static extern CBool HasScreenKeyboardSupport();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_IsScreenKeyboardShown", ExactSpelling = true)]
        public static extern CBool IsScreenKeyboardShown(Window* window);
    }
}
