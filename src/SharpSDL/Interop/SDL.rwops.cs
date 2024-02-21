using System.Runtime.InteropServices;

namespace SharpSDL.Interop
{
    public enum RWopsType : uint
    {
        [NativeTypeName("#define SDL_RWOPS_UNKNOWN 0U")]
        UNKNOWN = 0U,
        [NativeTypeName("#define SDL_RWOPS_WINFILE 1U")]
        WINFILE = 1U,
        [NativeTypeName("#define SDL_RWOPS_STDFILE 2U")]
        STDFILE = 2U,
        [NativeTypeName("#define SDL_RWOPS_JNIFILE 3U")]
        JNIFILE = 3U,
        [NativeTypeName("#define SDL_RWOPS_MEMORY 4U")]
        MEMORY = 4U,
        [NativeTypeName("#define SDL_RWOPS_MEMORY_RO 5U")]
        MEMORY_RO = 5U,
    }

    public enum SeekMode
    {
        [NativeTypeName("#define RW_SEEK_SET 0")]
        SET = 0,
        [NativeTypeName("#define RW_SEEK_CUR 1")]
        CUR = 1,
        [NativeTypeName("#define RW_SEEK_END 2")]
        END = 2,
    }

    public unsafe partial struct RWops
    {
        [NativeTypeName(" (*)(struct RWops *) __attribute__((cdecl))")]
        public delegate* unmanaged[Cdecl]<RWops*, long> size;

        [NativeTypeName(" (*)(struct RWops *, , int) __attribute__((cdecl))")]
        public delegate* unmanaged[Cdecl]<RWops*, long, int, long> seek;

        [NativeTypeName("size_t (*)(struct RWops *, void *, size_t, size_t) __attribute__((cdecl))")]
        public delegate* unmanaged[Cdecl]<RWops*, void*, nuint, nuint, nuint> read;

        [NativeTypeName("size_t (*)(struct RWops *, const void *, size_t, size_t) __attribute__((cdecl))")]
        public delegate* unmanaged[Cdecl]<RWops*, void*, nuint, nuint, nuint> write;

        [NativeTypeName("int (*)(struct RWops *) __attribute__((cdecl))")]
        public delegate* unmanaged[Cdecl]<RWops*, int> close;

        public RWopsType type;

        [NativeTypeName("__AnonymousRecord_SDL_rwops_L94_C5")]
        public _hidden_e__Union hidden;

        [StructLayout(LayoutKind.Explicit)]
        public partial struct _hidden_e__Union
        {
            [FieldOffset(0)]
            [NativeTypeName("__AnonymousRecord_SDL_rwops_L102_C9")]
            public _windowsio_e__Struct windowsio;

            [FieldOffset(0)]
            [NativeTypeName("__AnonymousRecord_SDL_rwops_L122_C9")]
            public _mem_e__Struct mem;

            [FieldOffset(0)]
            [NativeTypeName("__AnonymousRecord_SDL_rwops_L128_C9")]
            public _unknown_e__Struct unknown;

            public unsafe partial struct _windowsio_e__Struct
            {
                public CBool append;

                public void* h;

                [NativeTypeName("__AnonymousRecord_SDL_rwops_L106_C13")]
                public _buffer_e__Struct buffer;

                public unsafe partial struct _buffer_e__Struct
                {
                    public void* data;

                    [NativeTypeName("size_t")]
                    public nuint size;

                    [NativeTypeName("size_t")]
                    public nuint left;
                }
            }

            public unsafe partial struct _mem_e__Struct
            {
                [NativeTypeName(" *")]
                public byte* @base;

                [NativeTypeName(" *")]
                public byte* here;

                [NativeTypeName(" *")]
                public byte* stop;
            }

            public unsafe partial struct _unknown_e__Struct
            {
                public void* data1;

                public void* data2;
            }
        }
    }

    public static unsafe partial class SDL
    {
        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWFromFile", ExactSpelling = true)]
        public static extern RWops* RWFromFile([NativeTypeName("const char *")] byte* file, [NativeTypeName("const char *")] byte* mode);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWFromFP", ExactSpelling = true)]
        public static extern RWops* RWFromFP(void* fp, CBool autoclose);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWFromMem", ExactSpelling = true)]
        public static extern RWops* RWFromMem(void* mem, int size);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWFromConstMem", ExactSpelling = true)]
        public static extern RWops* RWFromConstMem([NativeTypeName("const void *")] void* mem, int size);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_AllocRW", ExactSpelling = true)]
        public static extern RWops* AllocRW();

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FreeRW", ExactSpelling = true)]
        public static extern void FreeRW(RWops* area);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWsize", ExactSpelling = true)]
        public static extern long RWsize(RWops* context);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWseek", ExactSpelling = true)]
        public static extern long RWseek(RWops* context, long offset, SeekMode whence);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWtell", ExactSpelling = true)]
        public static extern long RWtell(RWops* context);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWread", ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint RWread(RWops* context, void* ptr, [NativeTypeName("size_t")] nuint size, [NativeTypeName("size_t")] nuint maxnum);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWwrite", ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint RWwrite(RWops* context, [NativeTypeName("const void *")] void* ptr, [NativeTypeName("size_t")] nuint size, [NativeTypeName("size_t")] nuint num);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWclose", ExactSpelling = true)]
        public static extern int RWclose(RWops* context);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LoadFile_RW", ExactSpelling = true)]
        public static extern void* LoadFile_RW(RWops* src, [NativeTypeName("size_t *")] nuint* datasize, int freesrc);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LoadFile", ExactSpelling = true)]
        public static extern void* LoadFile([NativeTypeName("const char *")] byte* file, [NativeTypeName("size_t *")] nuint* datasize);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ReadU8", ExactSpelling = true)]
        public static extern byte ReadU8(RWops* src);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ReadLE16", ExactSpelling = true)]
        public static extern ushort ReadLE16(RWops* src);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ReadBE16", ExactSpelling = true)]
        public static extern ushort ReadBE16(RWops* src);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ReadLE32", ExactSpelling = true)]
        public static extern uint ReadLE32(RWops* src);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ReadBE32", ExactSpelling = true)]
        public static extern uint ReadBE32(RWops* src);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ReadLE64", ExactSpelling = true)]
        public static extern ulong ReadLE64(RWops* src);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ReadBE64", ExactSpelling = true)]
        public static extern ulong ReadBE64(RWops* src);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WriteU8", ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint WriteU8(RWops* dst, byte value);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WriteLE16", ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint WriteLE16(RWops* dst, ushort value);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WriteBE16", ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint WriteBE16(RWops* dst, ushort value);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WriteLE32", ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint WriteLE32(RWops* dst, uint value);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WriteBE32", ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint WriteBE32(RWops* dst, uint value);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WriteLE64", ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint WriteLE64(RWops* dst, ulong value);

        [DllImport("SDL2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WriteBE64", ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint WriteBE64(RWops* dst, ulong value);
    }
}
