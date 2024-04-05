namespace SharpSDL;

internal static class SdlFree
{
    public static unsafe SdlFree<T> Defer<T>(T* pointer) where T : unmanaged => new(pointer);
}

internal readonly unsafe ref struct SdlFree<T>(T* pointer) where T : unmanaged
{
    public readonly T* Pointer = pointer;

    public readonly bool IsNull => Pointer is null;

    public void Dispose()
    {
        if (Pointer is not null)
        {
            SDL.free(Pointer);
            fixed (T** ptr = &Pointer)
                *ptr = null;

        }
    }

    public static unsafe implicit operator T*(SdlFree<T> value) => value.Pointer;
    public static unsafe implicit operator SdlFree<T>(T* value) => new(value);
}
