// <auto-generated />
using System.Runtime.InteropServices;

namespace SharpSDL.Interop
{
    internal static unsafe partial class SDL2
    {
        [LibraryImport("SDL2", EntryPoint = "SDL_GetPlatform")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: NativeTypeName("const char *")]
        public static partial byte* GetPlatform();
    }
}
