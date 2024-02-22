using System.Runtime.InteropServices;

namespace SharpSDL.Interop;

public static unsafe partial class SDL
{
    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_OpenURL", ExactSpelling = true)]
    public static extern int OpenURL([NativeTypeName("const char *")] byte* url);
}
