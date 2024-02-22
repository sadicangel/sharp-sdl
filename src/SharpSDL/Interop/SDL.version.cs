using System;
using System.Runtime.InteropServices;

namespace SharpSDL.Interop;

internal partial struct SDL_version
{
    public byte major;

    public byte minor;

    public byte patch;
}

internal static unsafe partial class SDL
{
    [LibraryImport("SDL2", EntryPoint = "SDL_GetVersion")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void GetVersion(SDL_version* ver);

    [LibraryImport("SDL2", EntryPoint = "SDL_GetRevision")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("const char *")]
    public static partial byte* GetRevision();

    [LibraryImport("SDL2", EntryPoint = "SDL_GetRevisionNumber")]
    [Obsolete]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int GetRevisionNumber();

    [NativeTypeName("#define SDL_MAJOR_VERSION 2")]
    public const int SDL_MAJOR_VERSION = 2;

    [NativeTypeName("#define SDL_MINOR_VERSION 30")]
    public const int SDL_MINOR_VERSION = 30;

    [NativeTypeName("#define SDL_PATCHLEVEL 0")]
    public const int SDL_PATCHLEVEL = 0;

    [NativeTypeName("#define SDL_COMPILEDVERSION SDL_VERSIONNUM(SDL_MAJOR_VERSION, SDL_MINOR_VERSION, SDL_PATCHLEVEL)")]
    public const int SDL_COMPILEDVERSION = ((2) * 1000 + (30) * 100 + (0));
}
