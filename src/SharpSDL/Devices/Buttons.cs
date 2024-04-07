namespace SharpSDL.Devices;

public enum ButtonState : byte { Released, Pressed }

[Flags]
public enum ButtonMask : uint
{
    A = 1 << SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_A,
    B = 1 << SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_B,
    X = 1 << SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_X,
    Y = 1 << SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_Y,
    Back = 1 << SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_BACK,
    Guide = 1 << SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_GUIDE,
    Start = 1 << SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_START,
    LeftStick = 1 << SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_LEFTSTICK,
    RightStick = 1 << SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_RIGHTSTICK,
    LeftShoulder = 1 << SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_LEFTSHOULDER,
    RightShoulder = 1 << SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_RIGHTSHOULDER,
    DPadUp = 1 << SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_DPAD_UP,
    DPadDown = 1 << SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_DPAD_DOWN,
    DPadLeft = 1 << SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_DPAD_LEFT,
    DPadRight = 1 << SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_DPAD_RIGHT,
    Misc1 = 1 << SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_MISC1,
    Paddle1 = 1 << SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_PADDLE1,
    Paddle2 = 1 << SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_PADDLE2,
    Paddle3 = 1 << SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_PADDLE3,
    Paddle4 = 1 << SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_PADDLE4,
    Touchpad = 1 << SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_TOUCHPAD,
}

[Flags]
public enum AxisMask : uint
{
    LeftX = 1 << SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_LEFTX,
    LeftY = 1 << SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_LEFTY,
    RightX = 1 << SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_RIGHTX,
    RightY = 1 << SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_RIGHTY,
    TriggerLeft = 1 << SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_TRIGGERLEFT,
    TriggerRight = 1 << SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_TRIGGERRIGHT,
}