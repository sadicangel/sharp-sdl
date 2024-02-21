using System.Runtime.InteropServices;

namespace SharpSDL.Interop
{
    public static unsafe partial class SDL
    {
        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetBasePath", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern byte* GetBasePath();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetPrefPath", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern byte* GetPrefPath([NativeTypeName("const char *")] byte* org, [NativeTypeName("const char *")] byte* app);
    }
}
