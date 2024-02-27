namespace SharpSDL.Interop;

internal static unsafe partial class SDL
{
    [LibraryImport("SDL2", EntryPoint = "SDL_main")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int main(int argc, [NativeTypeName("char *[]")] byte** argv);

    [LibraryImport("SDL2", EntryPoint = "SDL_SetMainReady")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void SetMainReady();

    [LibraryImport("SDL2", EntryPoint = "SDL_RegisterApp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int RegisterApp([NativeTypeName("const char *")] byte* name, uint style, void* hInst);

    [LibraryImport("SDL2", EntryPoint = "SDL_UnregisterApp")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void UnregisterApp();
}
