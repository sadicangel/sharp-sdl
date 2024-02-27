namespace SharpSDL.Interop;

internal static unsafe partial class SDL
{
    [LibraryImport("SDL2", EntryPoint = "SDL_SetWindowsMessageHook")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void SetWindowsMessageHook([NativeTypeName("SDL_WindowsMessageHook")] delegate* unmanaged[Cdecl]<void*, void*, uint, ulong, long, void> callback, void* userdata);

    [LibraryImport("SDL2", EntryPoint = "SDL_Direct3D9GetAdapterIndex")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int Direct3D9GetAdapterIndex(int displayIndex);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderGetD3D9Device")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("IDirect3DDevice9*")]
    public static partial nint RenderGetD3D9Device([NativeTypeName("SDL_Renderer*")] nint renderer);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderGetD3D11Device")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("ID3D11Device*")]
    public static partial nint RenderGetD3D11Device([NativeTypeName("SDL_Renderer*")] nint renderer);

    [LibraryImport("SDL2", EntryPoint = "SDL_RenderGetD3D12Device")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("ID3D12Device*")]
    public static partial nint RenderGetD3D12Device([NativeTypeName("SDL_Renderer*")] nint renderer);

    [LibraryImport("SDL2", EntryPoint = "SDL_DXGIGetOutputInfo")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool DXGIGetOutputInfo(int displayIndex, int* adapterIndex, int* outputIndex);

    [LibraryImport("SDL2", EntryPoint = "SDL_IsTablet")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool IsTablet();

    [LibraryImport("SDL2", EntryPoint = "SDL_OnApplicationWillTerminate")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void OnApplicationWillTerminate();

    [LibraryImport("SDL2", EntryPoint = "SDL_OnApplicationDidReceiveMemoryWarning")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void OnApplicationDidReceiveMemoryWarning();

    [LibraryImport("SDL2", EntryPoint = "SDL_OnApplicationWillResignActive")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void OnApplicationWillResignActive();

    [LibraryImport("SDL2", EntryPoint = "SDL_OnApplicationDidEnterBackground")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void OnApplicationDidEnterBackground();

    [LibraryImport("SDL2", EntryPoint = "SDL_OnApplicationWillEnterForeground")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void OnApplicationWillEnterForeground();

    [LibraryImport("SDL2", EntryPoint = "SDL_OnApplicationDidBecomeActive")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void OnApplicationDidBecomeActive();
}
