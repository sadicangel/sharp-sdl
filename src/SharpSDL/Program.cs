// See https://aka.ms/new-console-template for more information
using SharpSDL;
using SharpSDL.Interop;
using System.Runtime.InteropServices;
using System.Text;
using Version = SharpSDL.Interop.Version;

unsafe
{
    Breakout.Run();

    return;

    if (SDL.Init(InitFlags.VIDEO) < 0)
        Throw();

    var version = stackalloc Version[1]; ;
    SDL.GetVersion(version);

    Console.WriteLine($"Using SDL {version->major}.{version->minor}.{version->patch}");

    var title = stackalloc byte[9];
    "SDL Demo\0"u8.CopyTo(new Span<byte>(title, 9));
    var window = SDL.CreateWindow(title, 50, 50, 800, 600, WindowFlags.OPENGL | WindowFlags.RESIZABLE);
    if (window is null)
        Throw();

    var renderer = SDL.CreateRenderer(window, -1, RendererFlags.ACCELERATED);

    var quit = false;

    while (!quit)
    {
        Event @event;
        while (SDL.PollEvent(&@event) != 0)
        {
            switch (@event.type)
            {
                case EventType.QUIT:
                    quit = true;
                    break;
            }
        }
        _ = SDL.SetRenderDrawColor(renderer, 0x18, 0x18, 0x18, 0xFF);
        _ = SDL.RenderClear(renderer);
        SDL.RenderPresent(renderer);

        SDL.Delay(17);
    }

    SDL.DestroyRenderer(renderer);
    SDL.DestroyWindow(window);
    SDL.Quit();
}

static unsafe void Throw()
{
    var error = SDL.GetError();
    var utf8 = MemoryMarshal.CreateReadOnlySpanFromNullTerminated(error);
    var str = Encoding.UTF8.GetString(utf8);
    throw new InvalidOperationException(str);
}
