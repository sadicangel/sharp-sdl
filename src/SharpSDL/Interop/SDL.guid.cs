using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpSDL.Interop
{
    public partial struct GUID
    {
        [NativeTypeName("[16]")]
        public _data_e__FixedBuffer data;

        [InlineArray(16)]
        public partial struct _data_e__FixedBuffer
        {
            public byte e0;
        }
    }

    public static unsafe partial class SDL
    {
        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GUIDToString", ExactSpelling = true)]
        public static extern void GUIDToString(GUID guid, [NativeTypeName("char *")] byte* pszGUID, int cbGUID);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GUIDFromString", ExactSpelling = true)]
        public static extern GUID GUIDFromString([NativeTypeName("const char *")] byte* pchGUID);
    }
}
