using System.Runtime.InteropServices;

namespace SharpSDL.Interop;

internal unsafe partial struct SDL_RWops
{
    [NativeTypeName(" (*)(struct SDL_RWops *) __attribute__((cdecl))")]
    public delegate* unmanaged[Cdecl]<SDL_RWops*, long> size;

    [NativeTypeName(" (*)(struct SDL_RWops *, , int) __attribute__((cdecl))")]
    public delegate* unmanaged[Cdecl]<SDL_RWops*, long, int, long> seek;

    [NativeTypeName("size_t (*)(struct SDL_RWops *, void *, size_t, size_t) __attribute__((cdecl))")]
    public delegate* unmanaged[Cdecl]<SDL_RWops*, void*, nuint, nuint, nuint> read;

    [NativeTypeName("size_t (*)(struct SDL_RWops *, const void *, size_t, size_t) __attribute__((cdecl))")]
    public delegate* unmanaged[Cdecl]<SDL_RWops*, void*, nuint, nuint, nuint> write;

    [NativeTypeName("int (*)(struct SDL_RWops *) __attribute__((cdecl))")]
    public delegate* unmanaged[Cdecl]<SDL_RWops*, int> close;

    public uint type;

    [NativeTypeName("__AnonymousRecord_SDL_rwops_L94_C5")]
    public _hidden_e__Union hidden;

    [StructLayout(LayoutKind.Explicit)]
    internal partial struct _hidden_e__Union
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

        internal unsafe partial struct _windowsio_e__Struct
        {
            [NativeTypeName("SDL_bool")]
            public CBool append;

            public void* h;

            [NativeTypeName("__AnonymousRecord_SDL_rwops_L106_C13")]
            public _buffer_e__Struct buffer;

            internal unsafe partial struct _buffer_e__Struct
            {
                public void* data;

                [NativeTypeName("size_t")]
                public nuint size;

                [NativeTypeName("size_t")]
                public nuint left;
            }
        }

        internal unsafe partial struct _mem_e__Struct
        {
            [NativeTypeName(" *")]
            public byte* @base;

            [NativeTypeName(" *")]
            public byte* here;

            [NativeTypeName(" *")]
            public byte* stop;
        }

        internal unsafe partial struct _unknown_e__Struct
        {
            public void* data1;

            public void* data2;
        }
    }
}

internal static unsafe partial class SDL
{
    [LibraryImport("SDL2", EntryPoint = "SDL_RWFromFile")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial SDL_RWops* RWFromFile([NativeTypeName("const char *")] byte* file, [NativeTypeName("const char *")] byte* mode);

    [LibraryImport("SDL2", EntryPoint = "SDL_RWFromFP")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial SDL_RWops* RWFromFP(void* fp, [NativeTypeName("SDL_bool")] CBool autoclose);

    [LibraryImport("SDL2", EntryPoint = "SDL_RWFromMem")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial SDL_RWops* RWFromMem(void* mem, int size);

    [LibraryImport("SDL2", EntryPoint = "SDL_RWFromConstMem")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial SDL_RWops* RWFromConstMem([NativeTypeName("const void *")] void* mem, int size);

    [LibraryImport("SDL2", EntryPoint = "SDL_AllocRW")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial SDL_RWops* AllocRW();

    [LibraryImport("SDL2", EntryPoint = "SDL_FreeRW")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void FreeRW(SDL_RWops* area);

    [LibraryImport("SDL2", EntryPoint = "SDL_RWsize")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial long RWsize(SDL_RWops* context);

    [LibraryImport("SDL2", EntryPoint = "SDL_RWseek")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial long RWseek(SDL_RWops* context, long offset, int whence);

    [LibraryImport("SDL2", EntryPoint = "SDL_RWtell")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial long RWtell(SDL_RWops* context);

    [LibraryImport("SDL2", EntryPoint = "SDL_RWread")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("size_t")]
    public static partial nuint RWread(SDL_RWops* context, void* ptr, [NativeTypeName("size_t")] nuint size, [NativeTypeName("size_t")] nuint maxnum);

    [LibraryImport("SDL2", EntryPoint = "SDL_RWwrite")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("size_t")]
    public static partial nuint RWwrite(SDL_RWops* context, [NativeTypeName("const void *")] void* ptr, [NativeTypeName("size_t")] nuint size, [NativeTypeName("size_t")] nuint num);

    [LibraryImport("SDL2", EntryPoint = "SDL_RWclose")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial int RWclose(SDL_RWops* context);

    [LibraryImport("SDL2", EntryPoint = "SDL_LoadFile_RW")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void* LoadFile_RW(SDL_RWops* src, [NativeTypeName("size_t *")] nuint* datasize, int freesrc);

    [LibraryImport("SDL2", EntryPoint = "SDL_LoadFile")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial void* LoadFile([NativeTypeName("const char *")] byte* file, [NativeTypeName("size_t *")] nuint* datasize);

    [LibraryImport("SDL2", EntryPoint = "SDL_ReadU8")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial byte ReadU8(SDL_RWops* src);

    [LibraryImport("SDL2", EntryPoint = "SDL_ReadLE16")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial ushort ReadLE16(SDL_RWops* src);

    [LibraryImport("SDL2", EntryPoint = "SDL_ReadBE16")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial ushort ReadBE16(SDL_RWops* src);

    [LibraryImport("SDL2", EntryPoint = "SDL_ReadLE32")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial uint ReadLE32(SDL_RWops* src);

    [LibraryImport("SDL2", EntryPoint = "SDL_ReadBE32")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial uint ReadBE32(SDL_RWops* src);

    [LibraryImport("SDL2", EntryPoint = "SDL_ReadLE64")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial ulong ReadLE64(SDL_RWops* src);

    [LibraryImport("SDL2", EntryPoint = "SDL_ReadBE64")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    public static partial ulong ReadBE64(SDL_RWops* src);

    [LibraryImport("SDL2", EntryPoint = "SDL_WriteU8")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("size_t")]
    public static partial nuint WriteU8(SDL_RWops* dst, byte value);

    [LibraryImport("SDL2", EntryPoint = "SDL_WriteLE16")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("size_t")]
    public static partial nuint WriteLE16(SDL_RWops* dst, ushort value);

    [LibraryImport("SDL2", EntryPoint = "SDL_WriteBE16")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("size_t")]
    public static partial nuint WriteBE16(SDL_RWops* dst, ushort value);

    [LibraryImport("SDL2", EntryPoint = "SDL_WriteLE32")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("size_t")]
    public static partial nuint WriteLE32(SDL_RWops* dst, uint value);

    [LibraryImport("SDL2", EntryPoint = "SDL_WriteBE32")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("size_t")]
    public static partial nuint WriteBE32(SDL_RWops* dst, uint value);

    [LibraryImport("SDL2", EntryPoint = "SDL_WriteLE64")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("size_t")]
    public static partial nuint WriteLE64(SDL_RWops* dst, ulong value);

    [LibraryImport("SDL2", EntryPoint = "SDL_WriteBE64")]
    [UnmanagedCallConv(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    [return: NativeTypeName("size_t")]
    public static partial nuint WriteBE64(SDL_RWops* dst, ulong value);

    [NativeTypeName("#define SDL_RWOPS_UNKNOWN 0U")]
    public const uint SDL_RWOPS_UNKNOWN = 0U;

    [NativeTypeName("#define SDL_RWOPS_WINFILE 1U")]
    public const uint SDL_RWOPS_WINFILE = 1U;

    [NativeTypeName("#define SDL_RWOPS_STDFILE 2U")]
    public const uint SDL_RWOPS_STDFILE = 2U;

    [NativeTypeName("#define SDL_RWOPS_JNIFILE 3U")]
    public const uint SDL_RWOPS_JNIFILE = 3U;

    [NativeTypeName("#define SDL_RWOPS_MEMORY 4U")]
    public const uint SDL_RWOPS_MEMORY = 4U;

    [NativeTypeName("#define SDL_RWOPS_MEMORY_RO 5U")]
    public const uint SDL_RWOPS_MEMORY_RO = 5U;

    [NativeTypeName("#define RW_SEEK_SET 0")]
    public const int RW_SEEK_SET = 0;

    [NativeTypeName("#define RW_SEEK_CUR 1")]
    public const int RW_SEEK_CUR = 1;

    [NativeTypeName("#define RW_SEEK_END 2")]
    public const int RW_SEEK_END = 2;
}
