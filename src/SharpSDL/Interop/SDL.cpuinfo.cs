using System.Runtime.InteropServices;

namespace SharpSDL.Interop
{
    public static unsafe partial class SDL
    {
        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void __builtin_prefetch([NativeTypeName("const void *")] void* param0, __arglist);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetCPUCount", ExactSpelling = true)]
        public static extern int GetCPUCount();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetCPUCacheLineSize", ExactSpelling = true)]
        public static extern int GetCPUCacheLineSize();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasRDTSC", ExactSpelling = true)]
        public static extern CBool HasRDTSC();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasAltiVec", ExactSpelling = true)]
        public static extern CBool HasAltiVec();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasMMX", ExactSpelling = true)]
        public static extern CBool HasMMX();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_Has3DNow", ExactSpelling = true)]
        public static extern CBool Has3DNow();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasSSE", ExactSpelling = true)]
        public static extern CBool HasSSE();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasSSE2", ExactSpelling = true)]
        public static extern CBool HasSSE2();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasSSE3", ExactSpelling = true)]
        public static extern CBool HasSSE3();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasSSE41", ExactSpelling = true)]
        public static extern CBool HasSSE41();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasSSE42", ExactSpelling = true)]
        public static extern CBool HasSSE42();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasAVX", ExactSpelling = true)]
        public static extern CBool HasAVX();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasAVX2", ExactSpelling = true)]
        public static extern CBool HasAVX2();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasAVX512F", ExactSpelling = true)]
        public static extern CBool HasAVX512F();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasARMSIMD", ExactSpelling = true)]
        public static extern CBool HasARMSIMD();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasNEON", ExactSpelling = true)]
        public static extern CBool HasNEON();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasLSX", ExactSpelling = true)]
        public static extern CBool HasLSX();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasLASX", ExactSpelling = true)]
        public static extern CBool HasLASX();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetSystemRAM", ExactSpelling = true)]
        public static extern int GetSystemRAM();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SIMDGetAlignment", ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint SIMDGetAlignment();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SIMDAlloc", ExactSpelling = true)]
        public static extern void* SIMDAlloc([NativeTypeName("const size_t")] nuint len);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SIMDRealloc", ExactSpelling = true)]
        public static extern void* SIMDRealloc(void* mem, [NativeTypeName("const size_t")] nuint len);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SIMDFree", ExactSpelling = true)]
        public static extern void SIMDFree(void* ptr);

        [NativeTypeName("#define SDL_CACHELINE_SIZE 128")]
        public const int SDL_CACHELINE_SIZE = 128;
    }
}
