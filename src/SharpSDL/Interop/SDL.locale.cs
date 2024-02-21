using System.Runtime.InteropServices;

namespace SharpSDL.Interop
{
    public unsafe partial struct Locale
    {
        [NativeTypeName("const char *")]
        public byte* language;

        [NativeTypeName("const char *")]
        public byte* country;
    }

    public static unsafe partial class SDL
    {
        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetPreferredLocales", ExactSpelling = true)]
        public static extern Locale* GetPreferredLocales();
    }
}
