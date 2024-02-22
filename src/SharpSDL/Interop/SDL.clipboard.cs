using System.Runtime.InteropServices;

namespace SharpSDL.Interop;

public static unsafe partial class SDL
{
    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetClipboardText", ExactSpelling = true)]
    public static extern int SetClipboardText([NativeTypeName("const char *")] byte* text);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetClipboardText", ExactSpelling = true)]
    [return: NativeTypeName("char *")]
    public static extern byte* GetClipboardText();

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasClipboardText", ExactSpelling = true)]
    public static extern CBool HasClipboardText();

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetPrimarySelectionText", ExactSpelling = true)]
    public static extern int SetPrimarySelectionText([NativeTypeName("const char *")] byte* text);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetPrimarySelectionText", ExactSpelling = true)]
    [return: NativeTypeName("char *")]
    public static extern byte* GetPrimarySelectionText();

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasPrimarySelectionText", ExactSpelling = true)]
    public static extern CBool HasPrimarySelectionText();
}
