using System.Runtime.InteropServices;

namespace SharpSDL.Interop
{
    public enum ErrorCode
    {
        ENOMEM,
        EFREAD,
        EFWRITE,
        EFSEEK,
        UNSUPPORTED,
        LASTERROR,
    }

    public static unsafe partial class SDL
    {
        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetError", ExactSpelling = true)]
        public static extern int SetError([NativeTypeName("const char *")] byte* fmt, __arglist);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetError", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern byte* GetError();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetErrorMsg", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern byte* GetErrorMsg([NativeTypeName("char *")] byte* errstr, int maxlen);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ClearError", ExactSpelling = true)]
        public static extern void ClearError();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_Error", ExactSpelling = true)]
        public static extern int Error(ErrorCode code);
    }
}
