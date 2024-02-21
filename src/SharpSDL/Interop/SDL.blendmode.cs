using System.Runtime.InteropServices;

namespace SharpSDL.Interop
{
    [Flags]
    public enum BlendMode
    {
        NONE = 0x00000000,
        BLEND = 0x00000001,
        ADD = 0x00000002,
        MOD = 0x00000004,
        MUL = 0x00000008,
        INVALID = 0x7FFFFFFF,
    }

    public enum BlendOperation
    {
        ADD = 0x1,
        SUBTRACT = 0x2,
        REV_SUBTRACT = 0x3,
        MINIMUM = 0x4,
        MAXIMUM = 0x5,
    }

    public enum BlendFactor
    {
        ZERO = 0x1,
        ONE = 0x2,
        SRC_COLOR = 0x3,
        ONE_MINUS_SRC_COLOR = 0x4,
        SRC_ALPHA = 0x5,
        ONE_MINUS_SRC_ALPHA = 0x6,
        DST_COLOR = 0x7,
        ONE_MINUS_DST_COLOR = 0x8,
        DST_ALPHA = 0x9,
        ONE_MINUS_DST_ALPHA = 0xA,
    }

    public static partial class SDL
    {
        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ComposeCustomBlendMode", ExactSpelling = true)]
        public static extern BlendMode ComposeCustomBlendMode(BlendFactor srcColorFactor, BlendFactor dstColorFactor, BlendOperation colorOperation, BlendFactor srcAlphaFactor, BlendFactor dstAlphaFactor, BlendOperation alphaOperation);
    }
}
