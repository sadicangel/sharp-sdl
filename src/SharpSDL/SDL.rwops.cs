using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpSDL;
internal static partial class SDL
{
    public const int RW_SEEK_SET = 0;
    public const int RW_SEEK_CUR = 1;
    public const int RW_SEEK_END = 2;

    // Unknown stream type.
    public const uint SDL_RWOPS_UNKNOWN = 0;
    // Win32 file.
    public const uint SDL_RWOPS_WINFILE = 1;
    // Stdio file.
    public const uint SDL_RWOPS_STDFILE = 2;
    // Android asset.
    public const uint SDL_RWOPS_JNIFILE = 3;
    // Memory stream.
    public const uint SDL_RWOPS_MEMORY = 4;
    // Read-Only memory stream.
    public const uint SDL_RWOPS_MEMORY_RO = 5;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate long SDLRWopsSizeCallback(nint context);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate long SDLRWopsSeekCallback(nint context, long offset, int whence);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate nint SDLRWopsReadCallback(nint context, nint ptr, nint size, nint maxnum);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate nint SDLRWopsWriteCallback(nint context, nint ptr, nint size, nint num);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int SDLRWopsCloseCallback(nint context);

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct SDL_RWops
    {
        /// <summary>
        /// Returns the total size of the <see cref="SDL_RWops"/>, or -1 on error.
        /// </summary>
        public delegate*<SDL_RWops*, long> size;

        /// <summary>
        /// Seeks to offset relative to whence, using one of the whence values
        /// <see cref="RW_SEEK_SET"/>, <see cref="RW_SEEK_CUR"/> or <see cref="RW_SEEK_END"/>
        /// and returns the final offset in the data stream, or -1 on error. 
        /// </summary>
        public delegate*<SDL_RWops*, long, int, long> seek;

        /// <summary>
        /// Reads up to size bytes from the data stream to the area pointed at by ptr
        /// and returns the number of bytes read.
        /// </summary>
        public delegate*<SDL_RWops*, nint, nuint, nuint> read;

        /// <summary>
        /// Writes exactly size bytes from the area pointed at by ptr to the data stream
        /// and returns the number of bytes written.
        /// </summary>
        public delegate*<SDL_RWops*, nint, nuint, nuint> write;

        /// <summary>
        ///  Closes and frees an allocated <see cref="SDL_RWops"/> structure.
        /// </summary>
        public delegate*<SDL_RWops*, int> close;

        public uint type;
        public uint status;
        public uint props;

        // platform dependent hidden union
    }

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial /*SDL_RWops*/ nint SDL_RWFromFile(byte* file, byte* mode);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial /*SDL_RWops*/ nint SDL_AllocRW();

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_FreeRW(/*SDL_RWops*/ nint area);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial /*SDL_RWops*/ nint SDL_RWFromFP(nint fp, SDL_bool autoClose);

    /* mem refers to a nint, IntPtr to an SDL_RWops* */
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial /*SDL_RWops*/ nint SDL_RWFromMem(nint mem, int size);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial /*SDL_RWops*/ nint SDL_RWFromConstMem(nint mem, int size);

    // 2.0.10 and above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial long SDL_RWsize(/*SDL_RWops*/ nint context);

    // 2.0.10 an above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial long SDL_RWseek(/*SDL_RWops*/ nint context, long offset, int whence);

    // 2.0.10 an above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial long SDL_RWtell(/*SDL_RWops*/ nint context);

    // 2.0.10 an above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial long SDL_RWread(/*SDL_RWops*/ nint context, nint ptr, nint size, nint maxnum);

    // 2.0.10 an above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial long SDL_RWwrite(/*SDL_RWops*/ nint context, nint ptr, nint size, nint maxnum);

    /* Read endian functions */
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial byte SDL_ReadU8(nint src);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ushort SDL_ReadLE16(nint src);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ushort SDL_ReadBE16(nint src);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint SDL_ReadLE32(nint src);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint SDL_ReadBE32(nint src);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ulong SDL_ReadLE64(nint src);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ulong SDL_ReadBE64(nint src);

    /* Write endian functions */
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint SDL_WriteU8(nint dst, byte value);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint SDL_WriteLE16(nint dst, ushort value);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint SDL_WriteBE16(nint dst, ushort value);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint SDL_WriteLE32(nint dst, uint value);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint SDL_WriteBE32(nint dst, uint value);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint SDL_WriteLE64(nint dst, ulong value);

    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial uint SDL_WriteBE64(nint dst, ulong value);

    // 2.0.10 an above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial long SDL_RWclose(nint context);

    // 2.0.10 an above.
    [LibraryImport(DllName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial nint SDL_LoadFile(byte* file, out nuint dataSize);
}
