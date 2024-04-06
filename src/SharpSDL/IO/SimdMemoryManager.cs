using System.Buffers;

namespace SharpSDL.IO;

public sealed class SimdMemoryManager(nuint length) : SimdMemoryManager<byte>(length)
{
    public static nuint Alignment { get => SDL.SIMDGetAlignment(); }
}

public class SimdMemoryManager<T> : MemoryManager<T> where T : unmanaged
{
    private readonly unsafe T* _pointer;
    private readonly nuint _length;

    public SimdMemoryManager(nuint length)
    {
        unsafe
        {
            _pointer = (T*)SDL.SIMDAlloc(length * (nuint)sizeof(T));
            if (_pointer is null)
                throw new SdlException("Out of memory");
            _length = length;
        }
    }

    public void Realloc(nuint length)
    {
        unsafe
        {
            var realloc = (T*)SDL.SIMDRealloc(_pointer, length * (nuint)sizeof(T));
            if (realloc is null)
                throw new SdlException("Out of memory");

            fixed (T** p = &_pointer)
                *p = realloc;
            fixed (nuint* l = &_length)
                *l = length;
        }
    }

    public sealed override Span<T> GetSpan()
    {
        unsafe { return new Span<T>(_pointer, (int)_length); }
    }

    public sealed override MemoryHandle Pin(int elementIndex = 0)
    {
        if (elementIndex < 0 || (nuint)elementIndex >= _length)
            throw new ArgumentOutOfRangeException(nameof(elementIndex));
        unsafe { return new MemoryHandle(_pointer + elementIndex); }
    }

    public sealed override void Unpin()
    {
        // This performs no operation since the underlying memory is unmanaged.
    }

    protected sealed override unsafe void Dispose(bool disposing)
    {
        if (_pointer is not null)
        {
            SDL.SIMDFree(_pointer);
            fixed (T** ptr = &_pointer)
                *ptr = null;
        }
    }
}
