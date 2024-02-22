using System.Runtime.InteropServices;

namespace SharpSDL.Interop;

internal enum SDL_errorcode
{
    SDL_ENOMEM,
    SDL_EFREAD,
    SDL_EFWRITE,
    SDL_EFSEEK,
    SDL_UNSUPPORTED,
    SDL_LASTERROR,
}

internal static unsafe partial class SDL
{
    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetError", ExactSpelling = true)]
    public static extern int SetError([NativeTypeName("const char *")] byte* fmt, __arglist);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetError")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("const char *")]
    public static partial byte* GetError();

    [LibraryImport("SDL2", EntryPoint = "SDL_GetErrorMsg")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("char *")]
    public static partial byte* GetErrorMsg([NativeTypeName("char *")] byte* errstr, int maxlen);

    [LibraryImport("SDL2", EntryPoint = "SDL_ClearError")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void ClearError();

    [LibraryImport("SDL2", EntryPoint = "SDL_Error")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int Error(SDL_errorcode code);
}
