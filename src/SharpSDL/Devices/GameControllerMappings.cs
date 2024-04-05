using SharpSDL.IO;
using System.Text;

namespace SharpSDL.Devices;

public static class GameControllerMappings
{
    public static int LoadMappings(RwStream stream)
    {
        unsafe
        {
            var mappings = SDL.GameControllerAddMappingsFromRW(stream._stream, freerw: 0);
            return mappings >= 0 ? mappings : SdlException.ThrowLastError<int>();
        }
    }

    public static int LoadMappings(ReadOnlySpan<byte> fileName)
    {
        using var stream = new RwStream(fileName, "rb"u8);
        return LoadMappings(stream);
    }

    public static int LoadMappings(string fileName)
    {
        using var stream = new RwStream(fileName, "rb");
        return LoadMappings(stream);
    }

    public static int LoadMapping(ReadOnlySpan<byte> mapping)
    {
        unsafe
        {
            fixed (byte* ptr = mapping)
            {
                var result = SDL.GameControllerAddMapping(ptr);
                if (result < 0)
                    SdlException.ThrowLastError();
                return result;
            }
        }
    }

    public static int LoadMapping(string mapping)
    {
        unsafe
        {
            return mapping.AsUtf8((ptr, len) => LoadMapping(new ReadOnlySpan<byte>(ptr, len)));
        }
    }

    public static string GetMapping(Guid guid)
    {
        unsafe
        {
            using var mapping = SdlFree.Defer(SDL.GameControllerMappingForGUID(Unsafe.BitCast<Guid, SDL_GUID>(guid)));
            if (mapping.IsNull)
                SdlException.ThrowLastError();
            return Encoding.UTF8.GetString(MemoryMarshal.CreateReadOnlySpanFromNullTerminated(mapping));
        }
    }

    public static string GetMapping(GameController controller)
    {
        unsafe
        {
            using var mapping = SdlFree.Defer(SDL.GameControllerMapping(controller._controller));
            if (mapping.IsNull)
                SdlException.ThrowLastError();
            return Encoding.UTF8.GetString(MemoryMarshal.CreateReadOnlySpanFromNullTerminated(mapping));
        }
    }

    public static string GetMapping(int mappingIndex)
    {
        unsafe
        {
            using var mapping = SdlFree.Defer(SDL.GameControllerMappingForIndex(mappingIndex));
            if (mapping.IsNull)
                SdlException.ThrowLastError();
            return Encoding.UTF8.GetString(MemoryMarshal.CreateReadOnlySpanFromNullTerminated(mapping));
        }
    }

    public static int GetMappingCount() => SDL.GameControllerNumMappings();
}
