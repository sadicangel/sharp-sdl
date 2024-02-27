namespace SharpSDL.Interop;

internal static unsafe partial class SDL
{
    [LibraryImport("SDL2", EntryPoint = "SDL_SetClipboardText")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int SetClipboardText([NativeTypeName("const char *")] byte* text);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetClipboardText")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("char *")]
    public static partial byte* GetClipboardText();

    [LibraryImport("SDL2", EntryPoint = "SDL_HasClipboardText")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool HasClipboardText();

    [LibraryImport("SDL2", EntryPoint = "SDL_SetPrimarySelectionText")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int SetPrimarySelectionText([NativeTypeName("const char *")] byte* text);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetPrimarySelectionText")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("char *")]
    public static partial byte* GetPrimarySelectionText();

    [LibraryImport("SDL2", EntryPoint = "SDL_HasPrimarySelectionText")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool HasPrimarySelectionText();
}
