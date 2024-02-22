using System.Runtime.InteropServices;

namespace SharpSDL.Interop;

public static unsafe partial class SDL
{
    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_Metal_CreateView", ExactSpelling = true)]
    [return: NativeTypeName("SDL_MetalView")]
    public static extern void* Metal_CreateView(Window* window);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_Metal_DestroyView", ExactSpelling = true)]
    public static extern void Metal_DestroyView([NativeTypeName("SDL_MetalView")] void* view);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_Metal_GetLayer", ExactSpelling = true)]
    public static extern void* Metal_GetLayer([NativeTypeName("SDL_MetalView")] void* view);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_Metal_GetDrawableSize", ExactSpelling = true)]
    public static extern void Metal_GetDrawableSize(Window* window, int* w, int* h);
}
