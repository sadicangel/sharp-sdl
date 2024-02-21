using System;
using System.Runtime.InteropServices;

namespace SharpSDL.Interop
{
    public partial struct Version
    {
        public byte major;

        public byte minor;

        public byte patch;
    }

    public static unsafe partial class SDL
    {
        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetVersion", ExactSpelling = true)]
        public static extern void GetVersion(Version* ver);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRevision", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern byte* GetRevision();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRevisionNumber", ExactSpelling = true)]
        [Obsolete]
        public static extern int GetRevisionNumber();

        [NativeTypeName("#define SDL_MAJOR_VERSION 2")]
        public const int SDL_MAJOR_VERSION = 2;

        [NativeTypeName("#define SDL_MINOR_VERSION 30")]
        public const int SDL_MINOR_VERSION = 30;

        [NativeTypeName("#define SDL_PATCHLEVEL 0")]
        public const int SDL_PATCHLEVEL = 0;

        [NativeTypeName("#define SDL_COMPILEDVERSION SDL_VERSIONNUM(SDL_MAJOR_VERSION, SDL_MINOR_VERSION, SDL_PATCHLEVEL)")]
        public const int SDL_COMPILEDVERSION = ((2) * 1000 + (30) * 100 + (0));
    }
}
