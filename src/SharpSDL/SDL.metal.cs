using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpSDL;
internal static partial class SDL
{
    // 2.0.11 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial nint SDL_Metal_CreateView(/*SDL_Window*/ nint window);

    // 2.0.11 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_Metal_DestroyView(/*SDL_MetalView*/ nint view);

    // 2.0.11 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial nint SDL_Metal_GetLayer(/*SDL_MetalView*/ nint view);

    // 2.0.14 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_Metal_GetDrawableSize(/*SDL_Window*/
    nint window, out int w, out int h);
}
