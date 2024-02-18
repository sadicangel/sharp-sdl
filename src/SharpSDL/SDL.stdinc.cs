using System.Runtime.InteropServices;

namespace SharpSDL;
internal static partial class SDL
{
    public enum SDL_bool
    {
        SDL_FALSE = 0,
        SDL_TRUE = 1
    }

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    internal static partial nint SDL_malloc(nuint size);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    internal static partial void SDL_free(nint ptr);
}
