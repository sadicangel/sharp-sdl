using System.Buffers;
using System.Text;

namespace SharpSDL.IO;
public static class Clipboard
{
    public static bool HasText { get => SDL2.HasClipboardText(); }

    public static string Text
    {
        get
        {
            unsafe
            {
                using var pointer = SdlPointer.Defer(SDL2.GetClipboardText());
                var span = MemoryMarshal.CreateReadOnlySpanFromNullTerminated(pointer);
                if (span.Length == 0)
                    SdlException.ThrowLastError();
                return Encoding.UTF8.GetString(span);
            }
        }
        set
        {
            unsafe
            {
                var utf8 = ArrayPool<byte>.Shared.Rent(Encoding.UTF8.GetMaxByteCount(value.Length));
                try
                {
                    var bytesWritten = Encoding.UTF8.GetBytes(value, utf8);
                    fixed (byte* p = utf8.AsSpan(..bytesWritten))
                        if (SDL2.SetClipboardText(p) is not 0)
                            SdlException.ThrowLastError();
                }
                finally
                {
                    ArrayPool<byte>.Shared.Return(utf8, clearArray: true);
                }
            }
        }
    }

    public static bool HasPrimarySelectionText { get => SDL2.HasPrimarySelectionText(); }

    public static string PrimarySelectionText
    {
        get
        {
            unsafe
            {
                using var pointer = SdlPointer.Defer(SDL2.GetPrimarySelectionText());
                var span = MemoryMarshal.CreateReadOnlySpanFromNullTerminated(pointer);
                if (span.Length == 0)
                    SdlException.ThrowLastError();
                return Encoding.UTF8.GetString(span);
            }
        }
        set
        {
            unsafe
            {
                var utf8 = ArrayPool<byte>.Shared.Rent(Encoding.UTF8.GetMaxByteCount(value.Length));
                try
                {
                    var bytesWritten = Encoding.UTF8.GetBytes(value, utf8);
                    fixed (byte* p = utf8.AsSpan(..bytesWritten))
                        if (SDL2.SetPrimarySelectionText(p) is not 0)
                            SdlException.ThrowLastError();
                }
                finally
                {
                    ArrayPool<byte>.Shared.Return(utf8, clearArray: true);
                }
            }
        }
    }
}
