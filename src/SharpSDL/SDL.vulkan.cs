using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpSDL;
internal static partial class SDL
{
    // 2.0.6 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial int SDL_Vulkan_LoadLibrary(byte* path);

    // 2.0.6 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial nint SDL_Vulkan_GetVkGetInstanceProcAddr();

    // 2.0.6 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_Vulkan_UnloadLibrary();

    // 2.0.6 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial SDL_bool SDL_Vulkan_GetInstanceExtensions(/*SDL_Window*/ nint window, out uint pCount, byte** pNames);

    // 2.0.6 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SDL_bool SDL_Vulkan_CreateSurface(/*SDL_Window*/ nint window, /*VkInstance*/ nint instance, out ulong surface);

    // 2.0.6 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_Vulkan_GetDrawableSize(/*SDL_Window*/ nint window, out int w, out int h);
}
