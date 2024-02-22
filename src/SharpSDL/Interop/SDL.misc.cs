using System.Runtime.InteropServices;

namespace SharpSDL.Interop;

internal static unsafe partial class SDL
{
    [LibraryImport("SDL2", EntryPoint = "SDL_OpenURL")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int OpenURL([NativeTypeName("const char *")] byte* url);
}
