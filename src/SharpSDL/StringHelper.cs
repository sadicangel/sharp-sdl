using System.Text;
using System.Text.Unicode;

namespace SharpSDL;

internal static class StringHelper
{
    public unsafe delegate T Utf8Func<T>(byte* str, int len);
    public unsafe delegate void Utf8Action(byte* str, int len);
    public unsafe delegate T Utf16Func<T>(char* str, int len);
    public unsafe delegate void Utf16Action(char* str, int len);

    public static T AsUtf16<T>(this ReadOnlySpan<byte> bytes, Utf16Func<T> func)
    {
        Span<char> chars = stackalloc char[bytes.Length];
        var result = Utf8.ToUtf16(bytes, chars, out _, out _);
        if (result != System.Buffers.OperationStatus.Done)
            throw new InvalidOperationException("Failed to convert UTF8 string to UTF16 string");
        unsafe
        {
            fixed (char* ptr = chars)
                return func(ptr, bytes.Length);
        }
    }
    public static void AsUtf16(this ReadOnlySpan<byte> bytes, Utf16Action action)
    {
        Span<char> chars = stackalloc char[bytes.Length];
        var result = Utf8.ToUtf16(bytes, chars, out _, out _);
        if (result != System.Buffers.OperationStatus.Done)
            throw new InvalidOperationException("Failed to convert UTF8 string to UTF16 string");
        unsafe
        {
            fixed (char* ptr = chars)
                action(ptr, bytes.Length);
        }
    }

    public static T AsUtf8<T>(this ReadOnlySpan<char> chars, Utf8Func<T> func)
    {
        Span<byte> bytes = stackalloc byte[chars.Length];
        var result = Utf8.FromUtf16(chars, bytes, out _, out _);
        if (result != System.Buffers.OperationStatus.Done)
            throw new InvalidOperationException("Failed to convert UTF16 string to UTF8 string");
        unsafe
        {
            fixed (byte* ptr = bytes)
                return func(ptr, chars.Length);
        }
    }

    public static void AsUtf8(this ReadOnlySpan<char> chars, Utf8Action action)
    {
        Span<byte> bytes = stackalloc byte[chars.Length];
        var result = Utf8.FromUtf16(chars, bytes, out _, out _);
        if (result != System.Buffers.OperationStatus.Done)
            throw new InvalidOperationException("Failed to convert UTF16 string to UTF8 string");
        unsafe
        {
            fixed (byte* ptr = bytes)
                action(ptr, chars.Length);
        }
    }

    public static T AsUtf8<T>(this string chars, Utf8Func<T> func) => AsUtf8(chars.AsSpan(), func);
    public static void AsUtf8(this string chars, Utf8Action action) => AsUtf8(chars.AsSpan(), action);

    public static string ToUtf16(ReadOnlySpan<byte> span) => Encoding.UTF8.GetString(span);
    public static unsafe string ToUtf16(byte* ptr) => Encoding.UTF8.GetString(MemoryMarshal.CreateReadOnlySpanFromNullTerminated(ptr));
}
