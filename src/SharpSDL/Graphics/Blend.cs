namespace SharpSDL.Graphics;
public static class Blend
{
    public static BlendMode Compose(
        BlendFactor srcColorFactor,
        BlendFactor dstColorFactor,
        BlendOperation colorOperation,
        BlendFactor srcAlphaFactor,
        BlendFactor dstAlphaFactor,
        BlendOperation alphaOperation) =>
        (BlendMode)SDL2.ComposeCustomBlendMode(
            (SDL_BlendFactor)srcColorFactor,
            (SDL_BlendFactor)dstColorFactor,
            (SDL_BlendOperation)colorOperation,
            (SDL_BlendFactor)srcAlphaFactor,
            (SDL_BlendFactor)dstAlphaFactor,
            (SDL_BlendOperation)alphaOperation);
}

public enum BlendMode
{
    None = SDL_BlendMode.SDL_BLENDMODE_NONE,
    Blend = SDL_BlendMode.SDL_BLENDMODE_BLEND,
    Add = SDL_BlendMode.SDL_BLENDMODE_ADD,
    Mod = SDL_BlendMode.SDL_BLENDMODE_MOD,
    Mul = SDL_BlendMode.SDL_BLENDMODE_MUL,
    Invalid = SDL_BlendMode.SDL_BLENDMODE_INVALID,
}


public enum BlendOperation
{
    Add = SDL_BlendOperation.SDL_BLENDOPERATION_ADD,
    Subtract = SDL_BlendOperation.SDL_BLENDOPERATION_SUBTRACT,
    RevSubtract = SDL_BlendOperation.SDL_BLENDOPERATION_REV_SUBTRACT,
    Minimum = SDL_BlendOperation.SDL_BLENDOPERATION_MINIMUM,
    Maximum = SDL_BlendOperation.SDL_BLENDOPERATION_MAXIMUM,
}

public enum BlendFactor
{
    Zero = SDL_BlendFactor.SDL_BLENDFACTOR_ZERO,
    One = SDL_BlendFactor.SDL_BLENDFACTOR_ONE,
    SrcColor = SDL_BlendFactor.SDL_BLENDFACTOR_SRC_COLOR,
    OneMinusSrcColor = SDL_BlendFactor.SDL_BLENDFACTOR_ONE_MINUS_SRC_COLOR,
    SrcAlpha = SDL_BlendFactor.SDL_BLENDFACTOR_SRC_ALPHA,
    OneMinusSrcAlpha = SDL_BlendFactor.SDL_BLENDFACTOR_ONE_MINUS_SRC_ALPHA,
    DstColor = SDL_BlendFactor.SDL_BLENDFACTOR_DST_COLOR,
    OneMinusDstColor = SDL_BlendFactor.SDL_BLENDFACTOR_ONE_MINUS_DST_COLOR,
    DstAlpha = SDL_BlendFactor.SDL_BLENDFACTOR_DST_ALPHA,
    OneMinusDstAlpha = SDL_BlendFactor.SDL_BLENDFACTOR_ONE_MINUS_DST_ALPHA,
}