using SharpSDL.Objects;
using System.Buffers;
using System.Text;

namespace SharpSDL;
public static class MessageBox
{
    public static void Show(string title, string message, MessageBoxFlags flags, Window? parent = null)
    {
        byte[]? titleArray = null;
        byte[]? messageArray = null;
        try
        {
            var titleLength = Encoding.UTF8.GetMaxByteCount(title.Length);
            var titleSpan = titleLength <= 256
                ? stackalloc byte[titleLength]
                : (titleArray = ArrayPool<byte>.Shared.Rent(titleLength)).AsSpan(..titleLength);
            Encoding.UTF8.GetBytes(title, titleSpan);

            var messageLength = Encoding.UTF8.GetMaxByteCount(message.Length);
            var messageSpan = messageLength <= 256
                ? stackalloc byte[messageLength]
                : (messageArray = ArrayPool<byte>.Shared.Rent(messageLength)).AsSpan(..messageLength);
            Encoding.UTF8.GetBytes(message, messageSpan);

            unsafe
            {
                fixed (byte* titlePtr = titleSpan, messagePtr = messageSpan)
                {
                    if (SDL.ShowSimpleMessageBox((uint)flags, titlePtr, messagePtr, parent?._window ?? 0) != 0)
                        SdlException.ThrowLastError();
                }
            }
        }
        finally
        {
            if (titleArray is not null)
                ArrayPool<byte>.Shared.Return(titleArray);
            if (messageArray is not null)
                ArrayPool<byte>.Shared.Return(messageArray);
        }
    }

    public static int Show(MessageBoxData data)
    {
        unsafe
        {
            fixed (byte* title = Encoding.UTF8.GetBytes(data.Title))
            fixed (byte* message = Encoding.UTF8.GetBytes(data.Message))
            fixed (SDL_MessageBoxButtonData* buttons = GetNativeButtons(data.Buttons))
            fixed (SDL_MessageBoxColorScheme* colorScheme = GetNativeColorScheme(data.ColorScheme))
            {
                var config = new SDL_MessageBoxData
                {
                    title = title,
                    message = message,
                    flags = (uint)data.Flags,
                    window = data.Parent?._window ?? 0,
                    numbuttons = data.Buttons.Length,
                    buttons = buttons,
                    colorScheme = colorScheme,
                };
                var button = 0;

                var result = SDL.ShowMessageBox(&config, &button);
                for (int i = 0; i < config.numbuttons; ++i)
                    Marshal.ZeroFreeCoTaskMemUTF8((nint)config.buttons[i].text);
                if (result != 0)
                    SdlException.ThrowLastError();
                return button;
            }
        }


        static SDL_MessageBoxColorScheme[]? GetNativeColorScheme(MessageBoxColorScheme? src)
        {
            if (src is null)
                return null;

            var dst = new SDL_MessageBoxColorScheme();
            dst.colors[0] = Unsafe.BitCast<ColorRgb, SDL_MessageBoxColor>(src.Background);
            dst.colors[1] = Unsafe.BitCast<ColorRgb, SDL_MessageBoxColor>(src.Text);
            dst.colors[2] = Unsafe.BitCast<ColorRgb, SDL_MessageBoxColor>(src.ButtonBorder);
            dst.colors[3] = Unsafe.BitCast<ColorRgb, SDL_MessageBoxColor>(src.ButtonBackground);
            dst.colors[4] = Unsafe.BitCast<ColorRgb, SDL_MessageBoxColor>(src.ButtonSelected);
            return [dst];
        }

        static unsafe SDL_MessageBoxButtonData[] GetNativeButtons(MessageBoxButton[] src)
        {
            var dst = new SDL_MessageBoxButtonData[src.Length];
            for (var i = 0; i < dst.Length; ++i)
            {
                dst[i] = new SDL_MessageBoxButtonData
                {
                    buttonid = src[i].ButtonId,
                    flags = (uint)src[i].Flags,
                    text = (byte*)Marshal.StringToCoTaskMemUTF8(src[i].Text),
                };
            }
            return dst;
        }
    }
}

[Flags]
public enum MessageBoxFlags
{
    Error = SDL_MessageBoxFlags.SDL_MESSAGEBOX_ERROR,
    Warning = SDL_MessageBoxFlags.SDL_MESSAGEBOX_WARNING,
    Information = SDL_MessageBoxFlags.SDL_MESSAGEBOX_INFORMATION,
    ButtonsLeftToRight = SDL_MessageBoxFlags.SDL_MESSAGEBOX_BUTTONS_LEFT_TO_RIGHT,
    ButtonsRightToLeft = SDL_MessageBoxFlags.SDL_MESSAGEBOX_BUTTONS_RIGHT_TO_LEFT,
}

[Flags]
public enum MessageBoxButtonFlags
{
    ReturnKeyDefault = SDL_MessageBoxButtonFlags.SDL_MESSAGEBOX_BUTTON_RETURNKEY_DEFAULT,
    EscapeKeyDefault = SDL_MessageBoxButtonFlags.SDL_MESSAGEBOX_BUTTON_ESCAPEKEY_DEFAULT,
}

public readonly record struct MessageBoxButton(int ButtonId, MessageBoxButtonFlags Flags, string Text);

public sealed record class MessageBoxColorScheme(
    ColorRgb Background,
    ColorRgb Text,
    ColorRgb ButtonBorder,
    ColorRgb ButtonBackground,
    ColorRgb ButtonSelected);

public sealed class MessageBoxData
{
    public Window? Parent { get; init; }
    public string Title { get; init; } = string.Empty;
    public string Message { get; init; } = string.Empty;
    public MessageBoxFlags Flags { get; init; }
    public MessageBoxButton[] Buttons { get; init; } = [];
    public MessageBoxColorScheme? ColorScheme { get; init; }
}