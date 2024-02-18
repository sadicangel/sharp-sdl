using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpSDL;
internal static partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_version
    {
        public byte major;
        public byte minor;
        public byte patch;
    }

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_GetVersion(out SDL_version ver);
}
