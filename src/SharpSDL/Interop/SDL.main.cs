using System.Runtime.InteropServices;

namespace SharpSDL.Interop;

public static unsafe partial class SDL
{
    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_main", ExactSpelling = true)]
    public static extern int main(int argc, [NativeTypeName("char *[]")] byte** argv);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetMainReady", ExactSpelling = true)]
    public static extern void SetMainReady();

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RegisterApp", ExactSpelling = true)]
    public static extern int RegisterApp([NativeTypeName("const char *")] byte* name, uint style, void* hInst);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UnregisterApp", ExactSpelling = true)]
    public static extern void UnregisterApp();
}
