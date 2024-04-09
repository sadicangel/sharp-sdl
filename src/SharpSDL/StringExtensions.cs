using System.Text;

namespace SharpSDL;

public static class StringExtensions
{
    public static string ToStringUtf16(this ReadOnlySpan<byte> str) => Encoding.UTF8.GetString(str);
}
