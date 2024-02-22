using System.Runtime.InteropServices;

namespace SharpSDL.Interop;

public partial struct VkInstance_T
{
}

public partial struct VkSurfaceKHR_T
{
}

public static unsafe partial class SDL
{
    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_Vulkan_LoadLibrary", ExactSpelling = true)]
    public static extern int Vulkan_LoadLibrary([NativeTypeName("const char *")] byte* path);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_Vulkan_GetVkGetInstanceProcAddr", ExactSpelling = true)]
    public static extern void* Vulkan_GetVkGetInstanceProcAddr();

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_Vulkan_UnloadLibrary", ExactSpelling = true)]
    public static extern void Vulkan_UnloadLibrary();

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_Vulkan_GetInstanceExtensions", ExactSpelling = true)]
    public static extern CBool Vulkan_GetInstanceExtensions(Window* window, [NativeTypeName("unsigned int *")] uint* pCount, [NativeTypeName("const char **")] byte** pNames);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_Vulkan_CreateSurface", ExactSpelling = true)]
    public static extern CBool Vulkan_CreateSurface(Window* window, [NativeTypeName("VkInstance")] VkInstance_T* instance, [NativeTypeName("VkSurfaceKHR *")] VkSurfaceKHR_T** surface);

    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_Vulkan_GetDrawableSize", ExactSpelling = true)]
    public static extern void Vulkan_GetDrawableSize(Window* window, int* w, int* h);
}
