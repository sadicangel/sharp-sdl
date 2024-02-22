using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpSDL.Interop;

internal partial struct SDL_GUID
{
    [NativeTypeName("[16]")]
    public _data_e__FixedBuffer data;

    [InlineArray(16)]
    internal partial struct _data_e__FixedBuffer
    {
        public byte e0;
    }
}

internal static unsafe partial class SDL
{
    [LibraryImport("SDL2", EntryPoint = "SDL_GUIDToString")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void GUIDToString(SDL_GUID guid, [NativeTypeName("char *")] byte* pszGUID, int cbGUID);

    [LibraryImport("SDL2", EntryPoint = "SDL_GUIDFromString")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SDL_GUID GUIDFromString([NativeTypeName("const char *")] byte* pchGUID);
}
