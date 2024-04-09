namespace SharpSDL;

internal static class SdlPointer
{
    public static unsafe SdlPointer<T> Defer<T>(T* pointer) where T : unmanaged => new(pointer);
}

internal readonly unsafe ref struct SdlPointer<T>(T* pointer) where T : unmanaged
{
    public readonly T* Pointer = pointer;

    public readonly bool IsNull => Pointer is null;

    public void Dispose()
    {
        if (Pointer is not null)
        {
            SDL2.free(Pointer);
            fixed (T** ptr = &Pointer)
                *ptr = null;
        }
    }

    public static unsafe implicit operator T*(SdlPointer<T> value) => value.Pointer;
    public static unsafe implicit operator SdlPointer<T>(T* value) => new(value);
}
