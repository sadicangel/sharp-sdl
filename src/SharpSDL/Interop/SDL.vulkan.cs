namespace SharpSDL.Interop;

internal static unsafe partial class SDL
{
    [LibraryImport("SDL2", EntryPoint = "SDL_Vulkan_LoadLibrary")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int Vulkan_LoadLibrary([NativeTypeName("const char *")] byte* path);

    [LibraryImport("SDL2", EntryPoint = "SDL_Vulkan_GetVkGetInstanceProcAddr")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void* Vulkan_GetVkGetInstanceProcAddr();

    [LibraryImport("SDL2", EntryPoint = "SDL_Vulkan_UnloadLibrary")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void Vulkan_UnloadLibrary();

    [LibraryImport("SDL2", EntryPoint = "SDL_Vulkan_GetInstanceExtensions")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool Vulkan_GetInstanceExtensions([NativeTypeName("SDL_Window*")] nint window, [NativeTypeName("unsigned int *")] uint* pCount, [NativeTypeName("const char **")] byte** pNames);

    [LibraryImport("SDL2", EntryPoint = "SDL_Vulkan_CreateSurface")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool Vulkan_CreateSurface([NativeTypeName("SDL_Window*")] nint window, [NativeTypeName("VkInstance")] nint instance, [NativeTypeName("VkSurfaceKHR *")] nint* surface);

    [LibraryImport("SDL2", EntryPoint = "SDL_Vulkan_GetDrawableSize")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void Vulkan_GetDrawableSize([NativeTypeName("SDL_Window*")] nint window, int* w, int* h);
}
