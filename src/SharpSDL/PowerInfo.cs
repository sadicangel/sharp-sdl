namespace SharpSDL;
public readonly struct PowerInfo(PowerState PowerState, int BatterySecondsLeft, int BatteryPercentLeft)
{
    public readonly PowerState PowerState = PowerState;
    public readonly int BatterySecondsLeft = BatterySecondsLeft;
    public readonly int BatteryPercentLeft = BatteryPercentLeft;

    public static PowerInfo GetPowerInfo()
    {
        unsafe
        {
            int s = 0; int p = 0;
            var e = SDL2.GetPowerInfo(&s, &p);
            return new PowerInfo((PowerState)e, s, p);
        }
    }
}

public enum PowerState
{
    Unknown = SDL_PowerState.SDL_POWERSTATE_UNKNOWN,
    OnBattery = SDL_PowerState.SDL_POWERSTATE_ON_BATTERY,
    NoBattery = SDL_PowerState.SDL_POWERSTATE_NO_BATTERY,
    Charging = SDL_PowerState.SDL_POWERSTATE_CHARGING,
    Charged = SDL_PowerState.SDL_POWERSTATE_CHARGED,
}
