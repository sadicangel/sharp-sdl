using SharpSDL.Devices;

namespace SharpSDL.IO;

public sealed class WavFile : IDisposable
{
    private readonly unsafe byte* _data;
    private readonly uint _size;
    private readonly AudioSpec _spec;

    public WavFile(RwStream stream, AudioSpec spec)
    {
        unsafe
        {
            fixed (byte** data = &_data)
            fixed (uint* size = &_size)
            {
                var desired = spec.ToNative();
                _spec = AudioSpec.FromNative(SDL2.LoadWAV_RW(stream._stream, freesrc: 0, &desired, data, size));
            }
        }
    }

    public WavFile(ReadOnlySpan<byte> fileName, AudioSpec spec)
    {
        using var stream = new RwStream(fileName, "rb"u8);
        unsafe
        {
            fixed (byte** data = &_data)
            fixed (uint* size = &_size)
            {
                var desired = spec.ToNative();
                _spec = AudioSpec.FromNative(SDL2.LoadWAV_RW(stream._stream, freesrc: 0, &desired, data, size));
            }
        }
    }

    public WavFile(string fileName, AudioSpec spec)
    {
        using var stream = new RwStream(fileName, "rb");
        unsafe
        {
            fixed (byte** data = &_data)
            fixed (uint* size = &_size)
            {
                var desired = spec.ToNative();
                _spec = AudioSpec.FromNative(SDL2.LoadWAV_RW(stream._stream, freesrc: 0, &desired, data, size));
            }
        }
    }

    public ReadOnlySpan<byte> Data { get { unsafe { return new(_data, (int)_size); } } }

    public void Dispose()
    {
        unsafe
        {
            if (_data is not null)
            {
                SDL2.FreeWAV(_data);
                fixed (byte** ptr1 = &_data)
                    *ptr1 = null;
                fixed (uint* ptr2 = &_size)
                    *ptr2 = 0;
            }
        }
    }
}