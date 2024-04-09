// <auto-generated />
using System.Runtime.InteropServices;

namespace SharpSDL.Interop
{
    internal unsafe partial struct SDL_Locale
    {
        [NativeTypeName("const char *")]
        public byte* language;

        [NativeTypeName("const char *")]
        public byte* country;
    }

    internal static unsafe partial class SDL2
    {
        [LibraryImport("SDL2", EntryPoint = "SDL_GetPreferredLocales")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial SDL_Locale* GetPreferredLocales();
    }
}
