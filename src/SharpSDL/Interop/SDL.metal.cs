using System.Runtime.InteropServices;

namespace SharpSDL.Interop;

internal static unsafe partial class SDL
{
    [LibraryImport("SDL2", EntryPoint = "SDL_Metal_CreateView")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("SDL_MetalView")]
    public static partial void* Metal_CreateView([NativeTypeName("SDL_Window*")] nint window);

    [LibraryImport("SDL2", EntryPoint = "SDL_Metal_DestroyView")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void Metal_DestroyView([NativeTypeName("SDL_MetalView")] void* view);

    [LibraryImport("SDL2", EntryPoint = "SDL_Metal_GetLayer")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void* Metal_GetLayer([NativeTypeName("SDL_MetalView")] void* view);

    [LibraryImport("SDL2", EntryPoint = "SDL_Metal_GetDrawableSize")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void Metal_GetDrawableSize([NativeTypeName("SDL_Window*")] nint window, int* w, int* h);
}