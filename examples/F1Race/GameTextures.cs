using SharpSDL;
using SharpSDL.Graphics;
using SharpSDL.Objects;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace F1Race;
public sealed class GameTextures : IDisposable, IReadOnlyDictionary<TextureId, Texture>
{
    private readonly Dictionary<TextureId, Texture> _textures;

    public GameTextures(Renderer renderer)
    {
        var values = Enum.GetValues<TextureId>();
        _textures = values.Where(v => v is not TextureId.SCREEN).ToDictionary(
            textureId => textureId,
            textureId =>
            {
                using var surface = Surface.LoadBmp($"assets/GAME_F1RACE_{textureId}.bmp");
                return renderer.CreateTexture(surface);
            });
        _textures[TextureId.SCREEN] = renderer.CreateTexture(PixelFormatEnum.Rgba8888, TextureAccess.Target, new Size(128, 128));
    }

    public IEnumerable<TextureId> Keys { get => _textures.Keys; }
    public IEnumerable<Texture> Values { get => _textures.Values; }
    public int Count { get => _textures.Count; }

    public Texture this[TextureId key] { get => _textures[key]; }

    public void Dispose()
    {
        foreach (var (_, texture) in _textures)
            texture.Dispose();
        _textures.Clear();
    }

    public bool ContainsKey(TextureId key) => _textures.ContainsKey(key);
    public bool TryGetValue(TextureId key, [MaybeNullWhen(false)] out Texture value) => _textures.TryGetValue(key, out value);
    public IEnumerator<KeyValuePair<TextureId, Texture>> GetEnumerator() => _textures.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public enum TextureId
{
    NUMBER_0,
    NUMBER_1,
    NUMBER_2,
    NUMBER_3,
    NUMBER_4,
    NUMBER_5,
    NUMBER_6,
    NUMBER_7,
    NUMBER_8,
    NUMBER_9,
    SCREEN,
    PLAYER_CAR,
    PLAYER_CAR_FLY,
    PLAYER_CAR_FLY_UP,
    PLAYER_CAR_FLY_DOWN,
    PLAYER_CAR_HEAD_LIGHT,
    PLAYER_CAR_CRASH,
    LOGO,
    STATUS_SCORE,
    STATUS_BOX,
    STATUS_LEVEL,
    STATUS_FLY,
    OPPOSITE_CAR_0,
    OPPOSITE_CAR_1,
    OPPOSITE_CAR_2,
    OPPOSITE_CAR_3,
    OPPOSITE_CAR_4,
    OPPOSITE_CAR_5,
    OPPOSITE_CAR_6,
    GAMEOVER,
    GAMEOVER_FIELD,
    GAMEOVER_CRASH,
}
