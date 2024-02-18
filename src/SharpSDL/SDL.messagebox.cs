using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpSDL;
internal static partial class SDL
{
    [Flags]
    public enum SDL_MessageBoxFlags : uint
    {
        SDL_MESSAGEBOX_ERROR = 0x00000010,
        SDL_MESSAGEBOX_WARNING = 0x00000020,
        SDL_MESSAGEBOX_INFORMATION = 0x00000040
    }

    [Flags]
    public enum SDL_MessageBoxButtonFlags : uint
    {
        SDL_MESSAGEBOX_BUTTON_RETURNKEY_DEFAULT = 0x00000001,
        SDL_MESSAGEBOX_BUTTON_ESCAPEKEY_DEFAULT = 0x00000002
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct SDL_MessageBoxButtonData
    {
        public SDL_MessageBoxButtonFlags flags;
        public int buttonid;
        public byte* text;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_MessageBoxColor
    {
        public byte r, g, b;
    }

    public enum SDL_MessageBoxColorType
    {
        SDL_MESSAGEBOX_COLOR_BACKGROUND,
        SDL_MESSAGEBOX_COLOR_TEXT,
        SDL_MESSAGEBOX_COLOR_BUTTON_BORDER,
        SDL_MESSAGEBOX_COLOR_BUTTON_BACKGROUND,
        SDL_MESSAGEBOX_COLOR_BUTTON_SELECTED,
        SDL_MESSAGEBOX_COLOR_MAX
    }

    [InlineArray((int)SDL_MessageBoxColorType.SDL_MESSAGEBOX_COLOR_MAX)]
    public struct SDL_MessageBoxColorScheme
    {
        internal SDL_MessageBoxColor _element0;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct SDL_MessageBoxData
    {
        public SDL_MessageBoxFlags flags;
        // Parent window, can be NULL.
        public nint window;
        public byte* title;
        public byte* message;
        public int numbuttons;
        public SDL_MessageBoxButtonData* buttons;
        // Can be NULL to use system settings.
        public SDL_MessageBoxColorScheme* colorScheme;
    }

    // All data in SDL_MessageBoxData is owned by the caller.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    public static partial int SDL_ShowMessageBox(in SDL_MessageBoxData messageboxdata, out int buttonid);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial int SDL_ShowSimpleMessageBox(SDL_MessageBoxFlags flags, byte* title, byte* message, nint window);
}
