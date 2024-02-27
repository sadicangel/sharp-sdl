namespace SharpSDL.Interop;

internal static unsafe partial class SDL
{
    [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void __builtin_prefetch([NativeTypeName("const void *")] void* param0, __arglist);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetCPUCount")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetCPUCount();

    [LibraryImport("SDL2", EntryPoint = "SDL_GetCPUCacheLineSize")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetCPUCacheLineSize();

    [LibraryImport("SDL2", EntryPoint = "SDL_HasRDTSC")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool HasRDTSC();

    [LibraryImport("SDL2", EntryPoint = "SDL_HasAltiVec")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool HasAltiVec();

    [LibraryImport("SDL2", EntryPoint = "SDL_HasMMX")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool HasMMX();

    [LibraryImport("SDL2", EntryPoint = "SDL_Has3DNow")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool Has3DNow();

    [LibraryImport("SDL2", EntryPoint = "SDL_HasSSE")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool HasSSE();

    [LibraryImport("SDL2", EntryPoint = "SDL_HasSSE2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool HasSSE2();

    [LibraryImport("SDL2", EntryPoint = "SDL_HasSSE3")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool HasSSE3();

    [LibraryImport("SDL2", EntryPoint = "SDL_HasSSE41")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool HasSSE41();

    [LibraryImport("SDL2", EntryPoint = "SDL_HasSSE42")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool HasSSE42();

    [LibraryImport("SDL2", EntryPoint = "SDL_HasAVX")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool HasAVX();

    [LibraryImport("SDL2", EntryPoint = "SDL_HasAVX2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool HasAVX2();

    [LibraryImport("SDL2", EntryPoint = "SDL_HasAVX512F")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool HasAVX512F();

    [LibraryImport("SDL2", EntryPoint = "SDL_HasARMSIMD")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool HasARMSIMD();

    [LibraryImport("SDL2", EntryPoint = "SDL_HasNEON")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool HasNEON();

    [LibraryImport("SDL2", EntryPoint = "SDL_HasLSX")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool HasLSX();

    [LibraryImport("SDL2", EntryPoint = "SDL_HasLASX")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool HasLASX();

    [LibraryImport("SDL2", EntryPoint = "SDL_GetSystemRAM")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetSystemRAM();

    [LibraryImport("SDL2", EntryPoint = "SDL_SIMDGetAlignment")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("size_t")]
    public static partial nuint SIMDGetAlignment();

    [LibraryImport("SDL2", EntryPoint = "SDL_SIMDAlloc")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void* SIMDAlloc([NativeTypeName("const size_t")] nuint len);

    [LibraryImport("SDL2", EntryPoint = "SDL_SIMDRealloc")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void* SIMDRealloc(void* mem, [NativeTypeName("const size_t")] nuint len);

    [LibraryImport("SDL2", EntryPoint = "SDL_SIMDFree")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SIMDFree(void* ptr);

    [NativeTypeName("#define SDL_CACHELINE_SIZE 128")]
    public const int SDL_CACHELINE_SIZE = 128;
}
