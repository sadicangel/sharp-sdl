using SharpSDL.Interop;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpSDL;
internal class Breakout
{
    private const int FPS = 60;
    private const float DELTA_TIME_SEC = 1.0f / FPS;
    private const int WINDOW_WIDTH = 800;
    private const int WINDOW_HEIGHT = 600;
    private const uint BACKGROUND_COLOR = 0xFF181818;

    private const float PROJ_SIZE = 25 * 0.80f;
    private const float PROJ_SPEED = 350;
    private const uint PROJ_COLOR = 0xFFFFFFFF;

    private const float BAR_LEN = 100;
    private const float BAR_THICCNESS = PROJ_SIZE;
    private const float BAR_Y = WINDOW_HEIGHT - PROJ_SIZE - 50;
    private const float BAR_SPEED = PROJ_SPEED * 1.5f;
    private const uint BAR_COLOR = 0xFF3030FF;

    private const float TARGET_WIDTH = BAR_LEN;
    private const float TARGET_HEIGHT = PROJ_SIZE;
    private const int TARGET_PADDING_X = 20;
    private const int TARGET_PADDING_Y = 50;
    private const int TARGET_ROWS = 4;
    private const int TARGET_COLS = 5;
    private const float TARGET_GRID_WIDTH = (TARGET_COLS * TARGET_WIDTH + (TARGET_COLS - 1) * TARGET_PADDING_X);
    private const float TARGET_GRID_X = WINDOW_WIDTH / 2 - TARGET_GRID_WIDTH / 2;
    private const float TARGET_GRID_Y = 50;
    private const uint TARGET_COLOR = 0xFF30FF30;

    private record struct Target(float x, float y, bool dead = false);

    private static Target[] init_targets()
    {
        var targets = new Target[TARGET_ROWS * TARGET_COLS];
        for (int row = 0; row < TARGET_ROWS; ++row)
        {
            for (int col = 0; col < TARGET_COLS; ++col)
            {
                targets[row * TARGET_COLS + col] = new Target(
                    x: TARGET_GRID_X + (TARGET_WIDTH + TARGET_PADDING_X) * (float)col,
                    y: TARGET_GRID_Y + TARGET_PADDING_Y * (float)row);
            }
        }
        return targets;
    }


    private static Rect make_rect(float x, float y, float w, float h) =>
        new Rect { x = (int)x, y = (int)y, w = (int)w, h = (int)h };

    private static unsafe void set_color(Renderer* renderer, uint color)
    {
        var r = (byte)((color >> (0 * 8)) & 0xFF);
        var g = (byte)((color >> (1 * 8)) & 0xFF);
        var b = (byte)((color >> (2 * 8)) & 0xFF);
        var a = (byte)((color >> (3 * 8)) & 0xFF);
        _ = SDL.SetRenderDrawColor(renderer, r, g, b, a);
    }

    private static Rect target_rect(Target target) =>
        make_rect(target.x, target.y, TARGET_WIDTH, TARGET_HEIGHT);

    private static Rect proj_rect(float x, float y) =>
        make_rect(x, y, PROJ_SIZE, PROJ_SIZE);

    private static Rect bar_rect(float x) =>
        make_rect(x, BAR_Y - BAR_THICCNESS / 2, BAR_LEN, BAR_THICCNESS);
    static unsafe int Throw()
    {
        var error = SDL.GetError();
        var utf8 = MemoryMarshal.CreateReadOnlySpanFromNullTerminated(error);
        var str = Encoding.UTF8.GetString(utf8);
        throw new InvalidOperationException(str);
    }

    public static unsafe int Run()
    {
        var targets_pool = init_targets();
        var bar_x = WINDOW_WIDTH / 2 - BAR_LEN / 2;
        var bar_dx = 0;
        var proj_x = WINDOW_WIDTH / 2 - PROJ_SIZE / 2;
        var proj_y = BAR_Y - BAR_THICCNESS / 2 - PROJ_SIZE;
        var proj_dx = 1;
        var proj_dy = 1;
        var quit = false;
        var pause = false;
        var started = false;
        // TODO: death
        // TODO: score
        // TODO: victory

        unsafe void horz_collision(float dt)
        {
            var proj_nx = proj_x + proj_dx * PROJ_SPEED * dt;
            var r1 = proj_rect(proj_nx, proj_y);
            var r2 = bar_rect(bar_x);
            if (proj_nx < 0 || proj_nx + PROJ_SIZE > WINDOW_WIDTH || SDL.HasIntersection(&r1, &r2))
            {
                proj_dx *= -1;
                return;
            }
            for (int i = 0; i < targets_pool.Length; ++i)
            {
                r1 = proj_rect(proj_nx, proj_y);
                r2 = target_rect(targets_pool[i]);
                if (!targets_pool[i].dead && SDL.HasIntersection(&r1, &r2))
                {
                    targets_pool[i].dead = true;
                    proj_dx *= -1;
                    return;
                }
            }
            proj_x = proj_nx;
        }

        unsafe void vert_collision(float dt)
        {
            var proj_ny = proj_y + proj_dy * PROJ_SPEED * dt;
            if (proj_ny < 0 || proj_ny + PROJ_SIZE > WINDOW_HEIGHT)
            {
                proj_dy *= -1;
                return;
            }
            var r1 = proj_rect(proj_x, proj_ny);
            var r2 = bar_rect(bar_x);
            if (SDL.HasIntersection(&r1, &r2))
            {
                if (bar_dx != 0) proj_dx = bar_dx;
                proj_dy *= -1;
                return;
            }
            for (int i = 0; i < targets_pool.Length; ++i)
            {
                r1 = proj_rect(proj_x, proj_ny);
                r2 = target_rect(targets_pool[i]);
                if (!targets_pool[i].dead && SDL.HasIntersection(&r1, &r2))
                {
                    targets_pool[i].dead = true;
                    proj_dy *= -1;
                    return;
                }
            }
            proj_y = proj_ny;
        }

        unsafe void bar_collision(float dt)
        {
            var bar_nx = Math.Clamp(bar_x + bar_dx * BAR_SPEED * dt, 0, WINDOW_WIDTH - BAR_LEN);

            var r1 = proj_rect(proj_x, proj_y);
            var r2 = bar_rect(bar_nx);
            if (SDL.HasIntersection(&r1, &r2)) return;
            bar_x = bar_nx;
        }

        unsafe void update(float dt)
        {
            if (!pause && started)
            {
                var r1 = proj_rect(proj_x, proj_y);
                var r2 = bar_rect(bar_x);
                if (SDL.HasIntersection(&r1, &r2))
                {
                    proj_y = BAR_Y - BAR_THICCNESS / 2 - PROJ_SIZE - 1.0f;
                    return;
                }
                bar_collision(dt);
                horz_collision(dt);
                vert_collision(dt);
            }
        }

        unsafe void render(Renderer* renderer)
        {
            set_color(renderer, PROJ_COLOR);
            var pr = proj_rect(proj_x, proj_y);
            _ = SDL.RenderFillRect(renderer, &pr);

            set_color(renderer, BAR_COLOR);
            var br = bar_rect(bar_x);
            _ = SDL.RenderFillRect(renderer, &br);

            set_color(renderer, TARGET_COLOR);
            foreach (var target in targets_pool)
            {
                if (!target.dead)
                {
                    var tr = target_rect(target);
                    _ = SDL.RenderFillRect(renderer, &tr);

                }
            }
        }

        if (SDL.Init(InitFlags.VIDEO) < 0)
        {
            //SDL.Log("Unable to initialize SDL: %s", SDL.GetError());
            return Throw();
        }

        var title = stackalloc byte[9];
        "Breakout\0"u8.CopyTo(new Span<byte>(title, 9));
        var window = SDL.CreateWindow(title, 100, 100, WINDOW_WIDTH, WINDOW_HEIGHT, 0);
        if (window is null)
        {
            //SDL.Log("Unable to initialize SDL: %s", SDL.GetError());
            return Throw();
        };

        var renderer = SDL.CreateRenderer(window, -1, RendererFlags.ACCELERATED);
        if (renderer is null)
        {
            //SDL.Log("Unable to initialize SDL: %s", SDL.GetError());
            return Throw();
        };

        var keyboard = SDL.GetKeyboardState(null);

        while (!quit)
        {
            var @event = default(Event);
            while (SDL.PollEvent(&@event) != 0)
            {
                switch (@event.type)
                {
                    case EventType.QUIT:
                        quit = true;
                        break;

                    case EventType.KEYDOWN:
                        switch (@event.key.keysym.sym)
                        {
                            case ' ':
                                pause = !pause;
                                break;
                        }
                        break;
                }
            }

            bar_dx = 0;
            if (keyboard[(int)Scancode.A] != 0)
            {
                bar_dx += -1;
                if (!started)
                {
                    started = true;
                    proj_dx = -1;
                }
            }
            if (keyboard[(int)Scancode.D] != 0)
            {
                bar_dx += 1;
                if (!started)
                {
                    started = true;
                    proj_dx = 1;
                }
            }

            update(DELTA_TIME_SEC);

            set_color(renderer, BACKGROUND_COLOR);
            _ = SDL.RenderClear(renderer);

            render(renderer);

            SDL.RenderPresent(renderer);

            SDL.Delay(1000 / FPS);
        }

        SDL.DestroyRenderer(renderer);
        SDL.DestroyWindow(window);
        SDL.Quit();

        return 0;
    }
}
