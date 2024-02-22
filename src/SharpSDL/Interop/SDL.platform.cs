using System.Runtime.InteropServices;

namespace SharpSDL.Interop;

internal static unsafe partial class SDL
{
    [LibraryImport("SDL2", EntryPoint = "SDL_GetPlatform")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("const char *")]
    public static partial byte* GetPlatform();
}
