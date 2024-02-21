using System.Runtime.InteropServices;

namespace SharpSDL.Interop
{
    public static unsafe partial class SDL
    {
        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetPlatform", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern byte* GetPlatform();
    }
}
