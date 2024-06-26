// <auto-generated />
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpSDL.Interop
{
    internal enum SDL_MessageBoxFlags
    {
        SDL_MESSAGEBOX_ERROR = 0x00000010,
        SDL_MESSAGEBOX_WARNING = 0x00000020,
        SDL_MESSAGEBOX_INFORMATION = 0x00000040,
        SDL_MESSAGEBOX_BUTTONS_LEFT_TO_RIGHT = 0x00000080,
        SDL_MESSAGEBOX_BUTTONS_RIGHT_TO_LEFT = 0x00000100,
    }

    internal enum SDL_MessageBoxButtonFlags
    {
        SDL_MESSAGEBOX_BUTTON_RETURNKEY_DEFAULT = 0x00000001,
        SDL_MESSAGEBOX_BUTTON_ESCAPEKEY_DEFAULT = 0x00000002,
    }

    internal unsafe partial struct SDL_MessageBoxButtonData
    {
        public uint flags;

        public int buttonid;

        [NativeTypeName("const char *")]
        public byte* text;
    }

    internal partial struct SDL_MessageBoxColor
    {
        public byte r;

        public byte g;

        public byte b;
    }

    internal enum SDL_MessageBoxColorType
    {
        SDL_MESSAGEBOX_COLOR_BACKGROUND,
        SDL_MESSAGEBOX_COLOR_TEXT,
        SDL_MESSAGEBOX_COLOR_BUTTON_BORDER,
        SDL_MESSAGEBOX_COLOR_BUTTON_BACKGROUND,
        SDL_MESSAGEBOX_COLOR_BUTTON_SELECTED,
        SDL_MESSAGEBOX_COLOR_MAX,
    }

    internal partial struct SDL_MessageBoxColorScheme
    {
        [NativeTypeName("SDL_MessageBoxColor[5]")]
        public _colors_e__FixedBuffer colors;

        [InlineArray(5)]
        internal partial struct _colors_e__FixedBuffer
        {
            public SDL_MessageBoxColor e0;
        }
    }

    internal unsafe partial struct SDL_MessageBoxData
    {
        public uint flags;

        [NativeTypeName("SDL_Window*")]
        public nint window;

        [NativeTypeName("const char *")]
        public byte* title;

        [NativeTypeName("const char *")]
        public byte* message;

        public int numbuttons;

        [NativeTypeName("const SDL_MessageBoxButtonData *")]
        public SDL_MessageBoxButtonData* buttons;

        [NativeTypeName("const SDL_MessageBoxColorScheme *")]
        public SDL_MessageBoxColorScheme* colorScheme;
    }

    internal static unsafe partial class SDL2
    {
        [LibraryImport("SDL2", EntryPoint = "SDL_ShowMessageBox")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial int ShowMessageBox([NativeTypeName("const SDL_MessageBoxData *")] SDL_MessageBoxData* messageboxdata, int* buttonid);

        [LibraryImport("SDL2", EntryPoint = "SDL_ShowSimpleMessageBox")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        public static partial int ShowSimpleMessageBox(uint flags, [NativeTypeName("const char *")] byte* title, [NativeTypeName("const char *")] byte* message, [NativeTypeName("SDL_Window*")] nint window);
    }
}
