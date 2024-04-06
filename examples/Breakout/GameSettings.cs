using SharpSDL.Objects;

namespace Breakout;
public readonly record struct GameSettings(
    int Fps,
    Size WindowSize,
    ColorRgba BackgroundColor,
    Size ObjectSize
)
{
    public float DeltaTimeSecs { get => 1.0f / Fps; }
}