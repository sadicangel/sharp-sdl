namespace SharpSDL;

public enum JoystickType
{
    Unknown = SDL_JoystickType.SDL_JOYSTICK_TYPE_UNKNOWN,
    GameController = SDL_JoystickType.SDL_JOYSTICK_TYPE_GAMECONTROLLER,
    Wheel = SDL_JoystickType.SDL_JOYSTICK_TYPE_WHEEL,
    ArcadeStick = SDL_JoystickType.SDL_JOYSTICK_TYPE_ARCADE_STICK,
    FlightStick = SDL_JoystickType.SDL_JOYSTICK_TYPE_FLIGHT_STICK,
    DancePad = SDL_JoystickType.SDL_JOYSTICK_TYPE_DANCE_PAD,
    Guitar = SDL_JoystickType.SDL_JOYSTICK_TYPE_GUITAR,
    DrumKit = SDL_JoystickType.SDL_JOYSTICK_TYPE_DRUM_KIT,
    ArcadePad = SDL_JoystickType.SDL_JOYSTICK_TYPE_ARCADE_PAD,
    Throttle = SDL_JoystickType.SDL_JOYSTICK_TYPE_THROTTLE,
}

public enum JoystickPowerLevel
{
    Unknown = SDL_JoystickPowerLevel.SDL_JOYSTICK_POWER_UNKNOWN,
    Empty = SDL_JoystickPowerLevel.SDL_JOYSTICK_POWER_EMPTY,
    Low = SDL_JoystickPowerLevel.SDL_JOYSTICK_POWER_LOW,
    Medium = SDL_JoystickPowerLevel.SDL_JOYSTICK_POWER_MEDIUM,
    Full = SDL_JoystickPowerLevel.SDL_JOYSTICK_POWER_FULL,
    Wired = SDL_JoystickPowerLevel.SDL_JOYSTICK_POWER_WIRED,
    Max = SDL_JoystickPowerLevel.SDL_JOYSTICK_POWER_MAX,
}
