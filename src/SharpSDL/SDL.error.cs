using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpSDL;
internal static partial class SDL
{
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_ClearError();

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial byte* SDL_GetError();

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial void SDL_SetError(byte* error);

    // 2.0.14 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial nint SDL_GetErrorMsg(byte* error, int maxLength);
}
