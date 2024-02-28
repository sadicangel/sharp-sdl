using Timer = SharpSDL.Timer;

namespace Breakout;

public sealed class Game
{
    private readonly GameSettings _settings;

    private Bar _bar;
    private Projectile _prj;
    private readonly Target[] _targets;

    private int _barDx = 0;
    private int _prjDx = 1;
    private int _prjDy = 1;

    private bool _quit = false;
    private bool _pause = false;
    private bool _started = false;

    public Game(GameSettings settings)
    {
        _settings = settings;

        _bar = new Bar(new Rect(
            X: (int)(settings.WindowSize.Width / 2f - settings.ObjectSize.Width / 2f),
            Y: (int)((settings.WindowSize.Height - settings.ObjectSize.Width - 50) - settings.ObjectSize.Height / 2f),
            Width: settings.ObjectSize.Width,
            Height: settings.ObjectSize.Height));

        _prj = new Projectile(new Rect(
            X: (int)(settings.WindowSize.Width / 2f - settings.ObjectSize.Width / 2f),
            Y: (int)(_bar.Rect.Y - settings.ObjectSize.Height / 2f - settings.ObjectSize.Width),
            Width: 20,
            Height: settings.ObjectSize.Height));

        var mat = (Rows: 4, Cols: 5);
        var pad = new Point(20, 50);
        var grd = new PointF(settings.WindowSize.Width / 2 - (float)(mat.Cols * settings.ObjectSize.Width + (mat.Cols - 1) * pad.X) / 2, 50);
        _targets = new Target[mat.Rows * mat.Cols];
        for (int row = 0; row < mat.Rows; ++row)
        {
            for (int col = 0; col < mat.Cols; ++col)
            {
                _targets[row * mat.Cols + col] = new Target(
                    Rect: new Rect(
                        X: (int)(grd.X + (settings.ObjectSize.Width + pad.X) * col),
                        Y: (int)(grd.Y + pad.Y * (float)row),
                        Width: settings.ObjectSize.Width,
                        Height: settings.ObjectSize.Height));
            }
        }
    }

    public void Run()
    {
        using var system = SubSystem.Init(SubSystemName.Video);
        using var window = new Window("Breakout", new Point(100, 100), _settings.WindowSize, 0);
        using var renderer = new Renderer(window, -1, RendererFlags.Accelerated);

        var keyboard = new Keyboard();

        while (!_quit)
        {
            // Events
            while (Events.PollEvent(out var @event))
            {
                switch (@event.Type)
                {
                    case EventType.Quit:
                        _quit = true;
                        break;

                    case EventType.KeyDown:
                        switch (@event.Key.KeySym.KeyCode)
                        {
                            case KeyCode.Space:
                                _pause = !_pause;
                                break;
                        }
                        break;
                }
            }

            // Input
            _barDx = 0;
            if (keyboard.IsKeyPressed(ScanCode.A))
            {
                _barDx += -1;
                if (!_started)
                {
                    _started = true;
                    _prjDx = -1;
                }
            }
            if (keyboard.IsKeyPressed(ScanCode.D))
            {
                _barDx += 1;
                if (!_started)
                {
                    _started = true;
                    _prjDx = 1;
                }
            }

            // Update
            Update(_settings.DeltaTimeSecs);

            // Render
            renderer.Color = _settings.BackgroundColor;
            renderer.Clear();

            renderer.Color = _prj.Color;
            renderer.FillRect(_prj.Rect);

            renderer.Color = _bar.Color;
            renderer.FillRect(_bar.Rect);

            foreach (var target in _targets)
            {
                if (!target.Dead)
                {
                    renderer.Color = target.Color;
                    renderer.FillRect(target.Rect);
                }
            }

            renderer.Present();

            Timer.Delay((uint)(1000 / _settings.Fps));
        }
    }

    private void Update(float dt)
    {
        if (!_pause && _started)
        {
            if (_prj.Rect.OverlapsWith(_bar.Rect))
            {
                _prj.Rect.Y = (int)(_bar.Rect.Y - _settings.ObjectSize.Height / 2 - _settings.ObjectSize.Width - 1.0f);
                return;
            }

            // Bar Collision
            var barN = _bar.Rect with { X = (int)Math.Clamp(_bar.Rect.X + _barDx * _bar.Speed * dt, 0, _settings.WindowSize.Width - _settings.ObjectSize.Width) };
            if (!_prj.Rect.OverlapsWith(barN))
            {
                _bar.Rect = barN;
            }

            // Horizontal Collision
            var prjN = _prj.Rect with { X = (int)(_prj.Rect.X + _prjDx * _prj.Speed * dt) };
            if (prjN.X < 0 || prjN.X + _prj.Rect.Width > _settings.WindowSize.Width || prjN.OverlapsWith(_bar.Rect))
            {
                _prjDx *= -1;
                return;
            }
            for (int i = 0; i < _targets.Length; ++i)
            {
                if (!_targets[i].Dead && prjN.OverlapsWith(_targets[i].Rect))
                {
                    _targets[i].Dead = true;
                    _prjDx *= -1;
                    return;
                }
            }
            _prj.Rect = prjN;

            // Vertical Collision
            prjN = _prj.Rect with { Y = (int)(_prj.Rect.Y + _prjDy * _prj.Speed * dt) };
            if (prjN.Y < 0 || prjN.Y + _prj.Rect.Height > _settings.WindowSize.Height)
            {
                _prjDy *= -1;
                return;
            }
            if (prjN.OverlapsWith(_bar.Rect))
            {
                if (_barDx != 0) _prjDx = _barDx;
                _prjDy *= -1;
                return;
            }
            for (int i = 0; i < _targets.Length; ++i)
            {
                if (!_targets[i].Dead && prjN.OverlapsWith(_targets[i].Rect))
                {
                    _targets[i].Dead = true;
                    _prjDy *= -1;
                    return;
                }
            }
            _prj.Rect = prjN;
        }
    }
}