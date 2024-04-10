using SharpSDL.IO;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace F1Race;
public sealed class GameSounds : IDisposable, IReadOnlyDictionary<MusicId, Music>
{
    private readonly Dictionary<MusicId, Music> _sounds;

    public GameSounds()
    {
        _sounds = Enum.GetValues<MusicId>().ToDictionary(
            musicId => musicId,
            musicId => new Music($"assets/GAME_F1RACE_{musicId}.ogg"));
    }

    public Music this[MusicId key] { get => _sounds[key]; }

    public IEnumerable<MusicId> Keys { get => _sounds.Keys; }
    public IEnumerable<Music> Values { get => _sounds.Values; }
    public int Count { get => _sounds.Count; }

    public bool ContainsKey(MusicId key) => _sounds.ContainsKey(key);
    public IEnumerator<KeyValuePair<MusicId, Music>> GetEnumerator() => _sounds.GetEnumerator();
    public bool TryGetValue(MusicId key, [MaybeNullWhen(false)] out Music value) => _sounds.TryGetValue(key, out value);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public void Dispose()
    {
        foreach (var (_, sound) in _sounds)
            sound.Dispose();
        _sounds.Clear();
    }
}

public enum MusicId
{
    BGM,
    BGM_LOWCOST,
    CRASH,
    GAMEOVER,
}