using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpSDL.Interop
{
    public enum SYSWM_TYPE
    {
        UNKNOWN,
        WINDOWS,
        X11,
        DIRECTFB,
        COCOA,
        UIKIT,
        WAYLAND,
        MIR,
        WINRT,
        ANDROID,
        VIVANTE,
        OS2,
        HAIKU,
        KMSDRM,
        RISCOS,
    }

    public partial struct SysWMmsg
    {
        public Version version;

        public SYSWM_TYPE subsystem;

        [NativeTypeName("__AnonymousRecord_SDL_syswm_L161_C5")]
        public _msg_e__Union msg;

        [StructLayout(LayoutKind.Explicit)]
        public partial struct _msg_e__Union
        {
            [FieldOffset(0)]
            [NativeTypeName("__AnonymousRecord_SDL_syswm_L164_C9")]
            public _win_e__Struct win;

            [FieldOffset(0)]
            public int dummy;

            public unsafe partial struct _win_e__Struct
            {
                [NativeTypeName("HWND")]
                public nint hwnd;

                public uint msg;

                [NativeTypeName("WPARAM")]
                public ulong wParam;

                [NativeTypeName("LPARAM")]
                public long lParam;
            }
        }
    }

    public partial struct SysWMinfo
    {
        public Version version;

        public SYSWM_TYPE subsystem;

        [NativeTypeName("__AnonymousRecord_SDL_syswm_L230_C5")]
        public _info_e__Union info;

        [StructLayout(LayoutKind.Explicit)]
        public partial struct _info_e__Union
        {
            [FieldOffset(0)]
            [NativeTypeName("__AnonymousRecord_SDL_syswm_L233_C9")]
            public _win_e__Struct win;

            [FieldOffset(0)]
            [NativeTypeName("[64]")]
            public _dummy_e__FixedBuffer dummy;

            public unsafe partial struct _win_e__Struct
            {
                [NativeTypeName("HWND")]
                public nint window;

                [NativeTypeName("HDC")]
                public nint hdc;

                [NativeTypeName("HINSTANCE")]
                public nint hinstance;
            }

            [InlineArray(64)]
            public partial struct _dummy_e__FixedBuffer
            {
                public byte e0;
            }
        }
    }

    public static unsafe partial class SDL
    {
        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowWMInfo", ExactSpelling = true)]
        public static extern CBool GetWindowWMInfo(Window* window, SysWMinfo* info);

        [NativeTypeName("#define SDL_METALVIEW_TAG 255")]
        public const int SDL_METALVIEW_TAG = 255;
    }
}
