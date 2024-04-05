namespace SharpSDL.IO;

public sealed class RwFile : IDisposable
{
    private readonly unsafe void* _data;
    private readonly nuint _size;

    internal unsafe RwFile(void* data, nuint size)
    {
        _data = data;
        _size = size;
    }
    public RwFile(ReadOnlySpan<byte> fileName)
    {
        unsafe
        {
            fixed (byte* f = fileName)
            fixed (nuint* s = &_size)
                _data = SDL.LoadFile(f, s);
            if (_data is null)
                SdlException.ThrowLastError();
        }
    }

    public RwFile(string fileName)
    {
        unsafe
        {
            void* data = null;
            fileName.AsUtf8((p, l) =>
            {
                nuint size = 0;
                data = SDL.LoadFile(p, &size);
            });
            _data = data;
            if (_data is null)
                SdlException.ThrowLastError();
        }
    }

    public ReadOnlySpan<byte> Data { get { unsafe { return new(_data, (int)_size); } } }

    public void Dispose()
    {
        unsafe
        {
            if (_data is not null)
            {
                SDL.free(_data);
                fixed (void** ptr1 = &_data)
                    *ptr1 = null;
                fixed (nuint* ptr2 = &_size)
                    *ptr2 = 0;
            }
        }
    }
}