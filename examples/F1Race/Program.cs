using F1Race;
using SharpSDL;
using SharpSDL.Devices;
using SharpSDL.Graphics;
using SharpSDL.Objects;

using var context = new SdlContext(SubSystem.Video | SubSystem.Audio);
Hint.Set(Hints.RENDER_DRIVER, "software"u8);
Hint.Set(Hints.RENDER_SCALE_QUALITY, "nearest"u8);

using var window = new Window("F1 Race", Point.Empty, new Size(256, 256), WindowFlags.Shown | WindowFlags.Resizable);

using (var icon = Surface.LoadBmp("assets/GAME_F1RACE_ICON.bmp"))
{
    icon.ColorKey = icon.Format.RgbToPixel(new ColorRgb(R: 36, G: 227, B: 113));
    window.SetIcon(icon);
}

using var renderer = new Renderer(window, index: -1, RendererFlags.Accelerated | RendererFlags.TargetTexture);

using var textures = new GameTextures(renderer);

//int result = Mix_Init(MIX_INIT_OGG);
//if (result != MIX_INIT_OGG)
//{
//    fprintf(stderr, "Mix_Init Error: %s.\n", Mix_GetError());
//    return EXIT_FAILURE;
//}
//if (Mix_OpenAudio(44100, AUDIO_S16SYS, 1, 4096) == -1)
//{
//    fprintf(stderr, "Mix_OpenAudio Error: %s.\n", Mix_GetError());
//    return EXIT_FAILURE;
//}

//Music_Load();


var f1Race = new Game(renderer, textures);

renderer.RenderTarget = textures[TextureId.SCREEN];
renderer.Clear();
f1Race.F1Race_Main();
renderer.RenderTarget = null;

var exitMainLoop = false;

while (!exitMainLoop)
{
    while (EventQueue.PollEvent(out var @event))
    {
        switch (@event.Type)
        {

            case EventType.Quit:
                exitMainLoop = true;
                break;
            case EventType.KeyDown:
                f1Race.F1Race_Keyboard_Key_Handler(@event.As.KeyEvent.KeySym.KeyCode, ButtonState.Pressed);
                break;
            case EventType.KeyUp:
                f1Race.F1Race_Keyboard_Key_Handler(@event.As.KeyEvent.KeySym.KeyCode, ButtonState.Released);
                break;
        }
    }
    renderer.RenderTarget = textures[TextureId.SCREEN];
    f1Race.F1Race_Cyclic_Timer();
    renderer.RenderTarget = null;
    renderer.Copy(textures[TextureId.SCREEN], new Rect(0, 0, window.Size.Width, window.Size.Height), Rect.Empty);
    renderer.Present();
    SdlTimer.Delay(TimeSpan.FromMilliseconds(100)); // 10 FPS.
}

//Mix_CloseAudio();
//Music_Unload();
