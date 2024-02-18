using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using unsafe MainCallback = delegate*<int, byte**, int>;

namespace SharpSDL;
internal static partial class SDL
{
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_SetMainReady();

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial int SDL_WinRTRunApp(MainCallback main, nint reserved);

    // 2.24.0 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial int SDL_GDKRunApp(MainCallback main, nint reserved);

    // 2.0.10 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial int SDL_UIKitRunApp(int argc, nint argv, MainCallback main);
}
