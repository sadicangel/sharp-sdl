namespace SharpSDL;
public sealed class Timer
{
    public static void Delay(uint milliseconds) => SDL.Delay(milliseconds);
}
