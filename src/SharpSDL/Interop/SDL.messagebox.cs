using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpSDL.Interop
{
    [Flags]
    public enum MessageBoxFlags : uint
    {
        ERROR = 0x00000010,
        WARNING = 0x00000020,
        INFORMATION = 0x00000040,
        BUTTONS_LEFT_TO_RIGHT = 0x00000080,
        BUTTONS_RIGHT_TO_LEFT = 0x00000100,
    }

    [Flags]
    public enum MessageBoxButtonFlags : uint
    {
        RETURNKEY_DEFAULT = 0x00000001,
        ESCAPEKEY_DEFAULT = 0x00000002,
    }

    public unsafe partial struct MessageBoxButtonData
    {
        public MessageBoxButtonFlags flags;

        public int buttonid;

        [NativeTypeName("const char *")]
        public byte* text;
    }

    public partial struct MessageBoxColor
    {
        public byte r;

        public byte g;

        public byte b;
    }

    public enum MessageBoxColorType
    {
        BACKGROUND,
        TEXT,
        BUTTON_BORDER,
        BUTTON_BACKGROUND,
        BUTTON_SELECTED,
        MAX,
    }

    public partial struct MessageBoxColorScheme
    {
        [NativeTypeName("MessageBoxColor[5]")]
        public _colors_e__FixedBuffer colors;

        [InlineArray(5)]
        public partial struct _colors_e__FixedBuffer
        {
            public MessageBoxColor e0;
        }
    }

    public unsafe partial struct MessageBoxData
    {
        public MessageBoxFlags flags;

        public Window* window;

        [NativeTypeName("const char *")]
        public byte* title;

        [NativeTypeName("const char *")]
        public byte* message;

        public int numbuttons;

        [NativeTypeName("const MessageBoxButtonData *")]
        public MessageBoxButtonData* buttons;

        [NativeTypeName("const MessageBoxColorScheme *")]
        public MessageBoxColorScheme* colorScheme;
    }

    public static unsafe partial class SDL
    {
        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ShowMessageBox", ExactSpelling = true)]
        public static extern int ShowMessageBox([NativeTypeName("const MessageBoxData *")] MessageBoxData* messageboxdata, int* buttonid);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ShowSimpleMessageBox", ExactSpelling = true)]
        public static extern int ShowSimpleMessageBox(MessageBoxFlags flags, [NativeTypeName("const char *")] byte* title, [NativeTypeName("const char *")] byte* message, Window* window);
    }
}
