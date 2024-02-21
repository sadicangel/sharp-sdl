using System.Runtime.InteropServices;

namespace SharpSDL.Interop
{
    public partial struct IDirect3DDevice9
    {
    }

    public partial struct ID3D11Device
    {
    }

    public partial struct ID3D12Device
    {
    }

    public static unsafe partial class SDL
    {
        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowsMessageHook", ExactSpelling = true)]
        public static extern void SetWindowsMessageHook([NativeTypeName("WindowsMessageHook")] delegate* unmanaged[Cdecl]<void*, void*, uint, ulong, long, void> callback, void* userdata);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_Direct3D9GetAdapterIndex", ExactSpelling = true)]
        public static extern int Direct3D9GetAdapterIndex(int displayIndex);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderGetD3D9Device", ExactSpelling = true)]
        public static extern IDirect3DDevice9* RenderGetD3D9Device(Renderer* renderer);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderGetD3D11Device", ExactSpelling = true)]
        public static extern ID3D11Device* RenderGetD3D11Device(Renderer* renderer);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderGetD3D12Device", ExactSpelling = true)]
        public static extern ID3D12Device* RenderGetD3D12Device(Renderer* renderer);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_DXGIGetOutputInfo", ExactSpelling = true)]
        public static extern CBool DXGIGetOutputInfo(int displayIndex, int* adapterIndex, int* outputIndex);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_IsTablet", ExactSpelling = true)]
        public static extern CBool IsTablet();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_OnApplicationWillTerminate", ExactSpelling = true)]
        public static extern void OnApplicationWillTerminate();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_OnApplicationDidReceiveMemoryWarning", ExactSpelling = true)]
        public static extern void OnApplicationDidReceiveMemoryWarning();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_OnApplicationWillResignActive", ExactSpelling = true)]
        public static extern void OnApplicationWillResignActive();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_OnApplicationDidEnterBackground", ExactSpelling = true)]
        public static extern void OnApplicationDidEnterBackground();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_OnApplicationWillEnterForeground", ExactSpelling = true)]
        public static extern void OnApplicationWillEnterForeground();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_OnApplicationDidBecomeActive", ExactSpelling = true)]
        public static extern void OnApplicationDidBecomeActive();
    }
}
