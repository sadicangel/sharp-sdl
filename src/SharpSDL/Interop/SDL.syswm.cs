using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpSDL.Interop;

internal enum SDL_SYSWM_TYPE
{
    SDL_SYSWM_UNKNOWN,
    SDL_SYSWM_WINDOWS,
    SDL_SYSWM_X11,
    SDL_SYSWM_DIRECTFB,
    SDL_SYSWM_COCOA,
    SDL_SYSWM_UIKIT,
    SDL_SYSWM_WAYLAND,
    SDL_SYSWM_MIR,
    SDL_SYSWM_WINRT,
    SDL_SYSWM_ANDROID,
    SDL_SYSWM_VIVANTE,
    SDL_SYSWM_OS2,
    SDL_SYSWM_HAIKU,
    SDL_SYSWM_KMSDRM,
    SDL_SYSWM_RISCOS,
}

internal partial struct SDL_SysWMmsg
{
    public SDL_version version;

    public SDL_SYSWM_TYPE subsystem;

    [NativeTypeName("__AnonymousRecord_SDL_syswm_L161_C5")]
    public _msg_e__Union msg;

    [StructLayout(LayoutKind.Explicit)]
    internal partial struct _msg_e__Union
    {
        [FieldOffset(0)]
        [NativeTypeName("__AnonymousRecord_SDL_syswm_L164_C9")]
        public _win_e__Struct win;

        [FieldOffset(0)]
        public int dummy;

        internal partial struct _win_e__Struct
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

internal partial struct SDL_SysWMinfo
{
    public SDL_version version;

    public SDL_SYSWM_TYPE subsystem;

    [NativeTypeName("__AnonymousRecord_SDL_syswm_L230_C5")]
    public _info_e__Union info;

    [StructLayout(LayoutKind.Explicit)]
    internal partial struct _info_e__Union
    {
        [FieldOffset(0)]
        [NativeTypeName("__AnonymousRecord_SDL_syswm_L233_C9")]
        public _win_e__Struct win;

        [FieldOffset(0)]
        [NativeTypeName("[64]")]
        public _dummy_e__FixedBuffer dummy;

        internal partial struct _win_e__Struct
        {
            [NativeTypeName("HWND")]
            public nint window;

            [NativeTypeName("HDC")]
            public nint hdc;

            [NativeTypeName("HINSTANCE")]
            public nint hinstance;
        }

        [InlineArray(64)]
        internal partial struct _dummy_e__FixedBuffer
        {
            public byte e0;
        }
    }
}

internal static unsafe partial class SDL
{
    [LibraryImport("SDL2", EntryPoint = "SDL_GetWindowWMInfo")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: NativeTypeName("SDL_bool")]
    public static partial CBool GetWindowWMInfo([NativeTypeName("SDL_Window*")] nint window, SDL_SysWMinfo* info);

    [NativeTypeName("#define SDL_METALVIEW_TAG 255")]
    public const int SDL_METALVIEW_TAG = 255;
}
