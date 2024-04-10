
using SharpSDL;
using SharpSDL.Devices;
using SharpSDL.IO;
using SharpSDL.Objects;

namespace F1Race;

public sealed record class PlayerCar
{
    public Point Point;
    public Point Delta;
    public TextureId Image;
    public TextureId Flying;
    public TextureId HeadLight;
}
public sealed record class OppositeCar
{
    public Point Point;
    public Point Delta;
    public int Speed;
    public int RoadId;
    public int DxFromRoad;
    public bool IsAddScore;
    public TextureId Image;
}
public sealed record class OppositeCarType
{
    public Point Delta;
    public TextureId Image;
    public int Speed;
    public int DxFromRoad;
}


public sealed class Game(Renderer renderer, GameTextures textures, Mixer mixer, GameSounds sounds)
{
    const int F1RACE_PLAYER_CAR_IMAGE_SIZE_X = 15;
    const int F1RACE_PLAYER_CAR_IMAGE_SIZE_Y = 20;
    const int F1RACE_PLAYER_CAR_CARSH_IMAGE_SIZE_X = 15;
    const int F1RACE_PLAYER_CAR_CARSH_IMAGE_SIZE_Y = 25;
    const int F1RACE_PLAYER_CAR_FLY_IMAGE_SIZE_X = 23;
    const int F1RACE_PLAYER_CAR_FLY_IMAGE_SIZE_Y = 27;
    const int F1RACE_PLAYER_CAR_HEAD_LIGHT_IMAGE_SIZE_X = 7;
    const int F1RACE_PLAYER_CAR_HEAD_LIGHT_IMAGE_SIZE_Y = 15;
    const int F1RACE_PLAYER_CAR_HEAD_LIGHT_0_SHIFT = 1;
    const int F1RACE_PLAYER_CAR_HEAD_LIGHT_1_SHIFT = 7;
    const int F1RACE_OPPOSITE_CAR_TYPE_COUNT = 7;
    const int F1RACE_PLAYER_CAR_FLY_FRAME_COUNT = 10;
    const int F1RACE_OPPOSITE_CAR_0_IMAGE_SIZE_X = 17;
    const int F1RACE_OPPOSITE_CAR_0_IMAGE_SIZE_Y = 35;
    const int F1RACE_OPPOSITE_CAR_1_IMAGE_SIZE_X = 12;
    const int F1RACE_OPPOSITE_CAR_1_IMAGE_SIZE_Y = 18;
    const int F1RACE_OPPOSITE_CAR_2_IMAGE_SIZE_X = 15;
    const int F1RACE_OPPOSITE_CAR_2_IMAGE_SIZE_Y = 20;
    const int F1RACE_OPPOSITE_CAR_3_IMAGE_SIZE_X = 12;
    const int F1RACE_OPPOSITE_CAR_3_IMAGE_SIZE_Y = 18;
    const int F1RACE_OPPOSITE_CAR_4_IMAGE_SIZE_X = 17;
    const int F1RACE_OPPOSITE_CAR_4_IMAGE_SIZE_Y = 27;
    const int F1RACE_OPPOSITE_CAR_5_IMAGE_SIZE_X = 13;
    const int F1RACE_OPPOSITE_CAR_5_IMAGE_SIZE_Y = 21;
    const int F1RACE_OPPOSITE_CAR_6_IMAGE_SIZE_X = 13;
    const int F1RACE_OPPOSITE_CAR_6_IMAGE_SIZE_Y = 22;
    const int F1RACE_OPPOSITE_CAR_COUNT = 8;
    const int F1RACE_OPPOSITE_CAR_DEFAULT_APPEAR_RATE = 2;
    const int F1RACE_MAX_FLY_COUNT = 9;
    const int F1RACE_TIMER_ELAPSE = 100;
    const int F1RACE_PLAYER_CAR_SHIFT = 5;
    const int F1RACE_PLAYER_CAR_FLY_SHIFT = 2;
    const int F1RACE_DISPLAY_START_X = 3;
    const int F1RACE_DISPLAY_START_Y = 3;
    const int F1RACE_DISPLAY_END_X = 124;
    const int F1RACE_DISPLAY_END_Y = 124;
    const int F1RACE_ROAD_WIDTH = 23;
    const int F1RACE_SEPARATOR_WIDTH = 3;
    const int F1RACE_GRASS_WIDTH = 7;
    const int F1RACE_STATUS_WIDTH = 32;
    const int F1RACE_SEPARATOR_HEIGHT_SPACE = 3;
    const int F1RACE_SEPARATOR_RATIO = 6;
    const int F1RACE_SEPARATOR_HEIGHT = F1RACE_SEPARATOR_HEIGHT_SPACE * F1RACE_SEPARATOR_RATIO;
    const int F1RACE_STATUS_NUMBER_WIDTH = 4;
    const int F1RACE_STATUS_NUBBER_HEIGHT = 7;
    const int F1RACE_GRASS_0_START_X = F1RACE_DISPLAY_START_X;
    const int F1RACE_GRASS_0_END_X = F1RACE_GRASS_0_START_X + F1RACE_GRASS_WIDTH - 1;
    const int F1RACE_ROAD_0_START_X = F1RACE_GRASS_0_START_X + F1RACE_GRASS_WIDTH;
    const int F1RACE_ROAD_0_END_X = F1RACE_ROAD_0_START_X + F1RACE_ROAD_WIDTH - 1;
    const int F1RACE_SEPARATOR_0_START_X = F1RACE_ROAD_0_START_X + F1RACE_ROAD_WIDTH;
    const int F1RACE_SEPARATOR_0_END_X = F1RACE_SEPARATOR_0_START_X + F1RACE_SEPARATOR_WIDTH - 1;
    const int F1RACE_ROAD_1_START_X = F1RACE_SEPARATOR_0_START_X + F1RACE_SEPARATOR_WIDTH;
    const int F1RACE_ROAD_1_END_X = F1RACE_ROAD_1_START_X + F1RACE_ROAD_WIDTH - 1;
    const int F1RACE_SEPARATOR_1_START_X = F1RACE_ROAD_1_START_X + F1RACE_ROAD_WIDTH;
    const int F1RACE_SEPARATOR_1_END_X = F1RACE_SEPARATOR_1_START_X + F1RACE_SEPARATOR_WIDTH - 1;
    const int F1RACE_ROAD_2_START_X = F1RACE_SEPARATOR_1_START_X + F1RACE_SEPARATOR_WIDTH;
    const int F1RACE_ROAD_2_END_X = F1RACE_ROAD_2_START_X + F1RACE_ROAD_WIDTH - 1;
    const int F1RACE_GRASS_1_START_X = F1RACE_ROAD_2_START_X + F1RACE_ROAD_WIDTH;
    const int F1RACE_GRASS_1_END_X = F1RACE_GRASS_1_START_X + F1RACE_GRASS_WIDTH - 1;
    const int F1RACE_STATUS_START_X = F1RACE_GRASS_1_START_X + F1RACE_GRASS_WIDTH;
    const int F1RACE_STATUS_END_X = F1RACE_STATUS_START_X + F1RACE_STATUS_WIDTH;

    private bool exit_main_loop = false;
    private bool using_new_background_ogg = false;
    private bool f1race_is_new_game = true;
    private bool f1race_is_crashing = false;
    private int f1race_crashing_count_down;
    private int f1race_separator_0_block_start_y;
    private int f1race_separator_1_block_start_y;
    private int f1race_last_car_road;
    private bool f1race_player_is_car_fly;
    private int f1race_player_car_fly_duration;
    private int f1race_score;
    private int f1race_level;
    private int f1race_pass;
    private int f1race_fly_count;
    private int f1race_fly_charger_count;
    private bool f1race_key_up_pressed = false;
    private bool f1race_key_down_pressed = false;
    private bool f1race_key_right_pressed = false;
    private bool f1race_key_left_pressed = false;

    private PlayerCar f1race_player_car;
    private OppositeCar?[] f1race_opposite_car = new OppositeCar[F1RACE_OPPOSITE_CAR_COUNT];
    private OppositeCarType[] f1race_opposite_car_type = new OppositeCarType[F1RACE_OPPOSITE_CAR_TYPE_COUNT];

    private int volume_old;

    private void Texture_Draw(int x, int y, TextureId textureId)
    {
        var texture = textures[textureId];
        renderer.Copy(texture, Rect.Empty, new Rect(new Point(x, y), texture.Size));
    }

    private void PlayMusic(MusicId id, bool loop) => mixer.PlayMusic(sounds[id], loop ? -1 : 0);

    public void F1Race_Show_Game_Over_Screen()
    {
        renderer.DrawColor = new ColorRgba(234, 243, 255, 0); // Light Blue.
        renderer.Clear();

        Texture_Draw(18, 10, TextureId.GAMEOVER);
        Texture_Draw(30, 40, TextureId.GAMEOVER_FIELD);

        renderer.DrawColor = new ColorRgba(0, 0, 0, 0);
        renderer.FillRect(new Rect(33, 43, 64, 20));

        Texture_Draw(36, 50, TextureId.STATUS_SCORE);
        Texture_Draw(65, 48, TextureId.STATUS_BOX);

        F1Race_Render_Score(64, -2);

        Texture_Draw(47, 80, TextureId.GAMEOVER_CRASH);
    }

    private void F1Race_Render_Separator()
    {
        int start_y, end_y;

        var rectangle = new Rect();

        renderer.DrawColor = new ColorRgba(250, 250, 250, 0);
        rectangle.X = F1RACE_SEPARATOR_0_START_X;
        rectangle.Y = F1RACE_DISPLAY_START_Y;
        rectangle.Width = F1RACE_SEPARATOR_0_END_X + 1 - rectangle.X;
        rectangle.Height = F1RACE_DISPLAY_END_Y - rectangle.Y;
        renderer.FillRect(rectangle);

        renderer.DrawColor = new ColorRgba(250, 250, 250, 0);
        rectangle.X = F1RACE_SEPARATOR_1_START_X;
        rectangle.Y = F1RACE_DISPLAY_START_Y;
        rectangle.Width = F1RACE_SEPARATOR_1_END_X + 1 - rectangle.X;
        rectangle.Height = F1RACE_DISPLAY_END_Y - rectangle.Y;
        renderer.FillRect(rectangle);

        start_y = f1race_separator_0_block_start_y;
        end_y = start_y + F1RACE_SEPARATOR_HEIGHT_SPACE;
        while (true)
        {
            renderer.DrawColor = new ColorRgba(150, 150, 150, 0);
            rectangle.X = F1RACE_SEPARATOR_0_START_X;
            rectangle.Y = start_y;
            rectangle.Width = F1RACE_SEPARATOR_0_END_X + 1 - rectangle.X;
            rectangle.Height = end_y - rectangle.Y;
            renderer.FillRect(rectangle);

            start_y += F1RACE_SEPARATOR_HEIGHT;
            end_y = start_y + F1RACE_SEPARATOR_HEIGHT_SPACE;
            if (start_y > F1RACE_DISPLAY_END_Y)
                break;
            if (end_y > F1RACE_DISPLAY_END_Y)
                end_y = F1RACE_DISPLAY_END_Y;
        }
        f1race_separator_0_block_start_y += F1RACE_SEPARATOR_HEIGHT_SPACE;
        if (f1race_separator_0_block_start_y >=
            (F1RACE_DISPLAY_START_Y + F1RACE_SEPARATOR_HEIGHT_SPACE * F1RACE_SEPARATOR_RATIO))
            f1race_separator_0_block_start_y = F1RACE_DISPLAY_START_Y;

        start_y = f1race_separator_1_block_start_y;
        end_y = start_y + F1RACE_SEPARATOR_HEIGHT_SPACE;
        while (true)
        {
            renderer.DrawColor = new ColorRgba(150, 150, 150, 0);
            rectangle.X = F1RACE_SEPARATOR_1_START_X;
            rectangle.Y = start_y;
            rectangle.Width = F1RACE_SEPARATOR_1_END_X + 1 - rectangle.X;
            rectangle.Height = end_y - rectangle.Y;
            renderer.FillRect(rectangle);

            start_y += F1RACE_SEPARATOR_HEIGHT;
            end_y = start_y + F1RACE_SEPARATOR_HEIGHT_SPACE;
            if (start_y > F1RACE_DISPLAY_END_Y)
                break;
            if (end_y > F1RACE_DISPLAY_END_Y)
                end_y = F1RACE_DISPLAY_END_Y;
        }
        f1race_separator_1_block_start_y += F1RACE_SEPARATOR_HEIGHT_SPACE;
        if (f1race_separator_1_block_start_y >=
            (F1RACE_DISPLAY_START_Y + F1RACE_SEPARATOR_HEIGHT_SPACE * F1RACE_SEPARATOR_RATIO))
            f1race_separator_1_block_start_y = F1RACE_DISPLAY_START_Y;
    }

    private void F1Race_Render_Road()
    {
        var rectangle = new Rect();
        renderer.DrawColor = new ColorRgba(150, 150, 150, 0);
        rectangle.X = F1RACE_ROAD_0_START_X;
        rectangle.Y = F1RACE_DISPLAY_START_Y;
        rectangle.Width = F1RACE_ROAD_2_END_X + 1 - rectangle.X;
        rectangle.Height = F1RACE_DISPLAY_END_Y - rectangle.Y;
        renderer.FillRect(rectangle);
    }

    private void F1Race_Render_Score(int x_pos, int y_pos)
    {
        int value;
        int remain;

        var rectangle = new Rect();
        renderer.DrawColor = new ColorRgba(0, 0, 0, 0);
        rectangle.X = x_pos + 4;
        rectangle.Y = y_pos + 52;
        rectangle.Width = x_pos + 29 + 1 - rectangle.X;
        rectangle.Height = y_pos + 58 - rectangle.Y;
        renderer.FillRect(rectangle);

        value = f1race_score % 10;
        remain = f1race_score / 10;

        while (true)
        {
            Texture_Draw(x_pos + 25, y_pos + 52, (TextureId)value);

            x_pos -= 5;
            if (remain > 0)
            {
                value = remain % 10;
                remain = remain / 10;
            }
            else
                break;
        }
    }

    private void F1Race_Render_Status()
    {
        int x_pos;
        int y_pos;
        int index;

        F1Race_Render_Score(F1RACE_STATUS_START_X, F1RACE_DISPLAY_START_Y);

        var rectangle = new Rect();
        renderer.DrawColor = new ColorRgba(0, 0, 0, 0);
        rectangle.X = F1RACE_STATUS_START_X + 4;
        rectangle.Y = F1RACE_DISPLAY_START_Y + 74;
        rectangle.Width = F1RACE_STATUS_START_X + 29 + 1 - rectangle.X;
        rectangle.Height = F1RACE_DISPLAY_START_Y + 80 - rectangle.Y;
        renderer.FillRect(rectangle);

        x_pos = F1RACE_STATUS_START_X + 16;
        y_pos = F1RACE_DISPLAY_START_Y + 74;

        Texture_Draw(x_pos, y_pos, (TextureId)f1race_level);

        x_pos = F1RACE_STATUS_START_X + 4;
        y_pos = F1RACE_DISPLAY_START_Y + 102;
        for (index = 0; index < 5; index++)
        {
            if (index < f1race_fly_charger_count)
                renderer.DrawColor = new ColorRgba(255, 0, 0, 0);
            else
                renderer.DrawColor = new ColorRgba(100, 100, 100, 0);
            rectangle.X = x_pos + index * 4;
            rectangle.Y = y_pos - 2 - index;
            rectangle.Width = x_pos + 2 + index * 4 + 1 - rectangle.X;
            rectangle.Height = y_pos - rectangle.Y;
            renderer.FillRect(rectangle);
        }

        x_pos = F1RACE_STATUS_START_X + 25;
        y_pos = F1RACE_DISPLAY_START_Y + 96;
        Texture_Draw(x_pos, y_pos, (TextureId)f1race_fly_count);
    }

    private void F1Race_Render_Player_Car()
    {
        int dx;
        int dy;

        TextureId image;

        if (f1race_player_is_car_fly == false)
        {
            Texture_Draw(f1race_player_car.Point.X, f1race_player_car.Point.Y, TextureId.PLAYER_CAR);
        }
        else
        {
            dx = (F1RACE_PLAYER_CAR_FLY_IMAGE_SIZE_X - F1RACE_PLAYER_CAR_IMAGE_SIZE_X) / 2;
            dy = (F1RACE_PLAYER_CAR_FLY_IMAGE_SIZE_Y - F1RACE_PLAYER_CAR_IMAGE_SIZE_Y) / 2;
            dx = f1race_player_car.Point.X - dx;
            dy = f1race_player_car.Point.Y - dy;
            image = f1race_player_car_fly_duration switch
            {
                0 or 1 => TextureId.PLAYER_CAR_FLY_UP,
                (F1RACE_PLAYER_CAR_FLY_FRAME_COUNT - 1) or (F1RACE_PLAYER_CAR_FLY_FRAME_COUNT - 2) => TextureId.PLAYER_CAR_FLY_DOWN,
                _ => TextureId.PLAYER_CAR_FLY,
            };
            Texture_Draw(dx, dy, image);
        }
    }

    private void F1Race_Render_Opposite_Car()
    {
        int index;
        for (index = 0; index < F1RACE_OPPOSITE_CAR_COUNT; index++)
        {
            if (f1race_opposite_car[index] is OppositeCar car)
                Texture_Draw(car.Point.X, car.Point.Y, car.Image);
        }
    }

    private void F1Race_Render_Player_Car_Crash()
    {
        Texture_Draw(f1race_player_car.Point.X, f1race_player_car.Point.Y - 5, TextureId.PLAYER_CAR_CRASH);
    }

    private void F1Race_Render()
    {
        var rectangle = new Rect();
        rectangle.X = F1RACE_STATUS_START_X;
        rectangle.Y = F1RACE_DISPLAY_START_Y;
        rectangle.Width = F1RACE_STATUS_END_X + 1 - rectangle.X;
        rectangle.Height = F1RACE_DISPLAY_END_Y - rectangle.Y;
        renderer.ClipRect = rectangle;

        F1Race_Render_Status();

        rectangle.X = F1RACE_ROAD_0_START_X;
        rectangle.Y = F1RACE_DISPLAY_START_Y;
        rectangle.Width = F1RACE_ROAD_2_END_X + 1 - rectangle.X;
        rectangle.Height = F1RACE_DISPLAY_END_Y - rectangle.Y;
        renderer.ClipRect = rectangle;

        F1Race_Render_Road();
        F1Race_Render_Separator();
        F1Race_Render_Opposite_Car();
        F1Race_Render_Player_Car();
    }

    private void F1Race_Render_Background()
    {
        var rectangle = new Rect();

        renderer.DrawColor = new ColorRgba(255, 255, 255, 0);
        renderer.Clear();

        renderer.DrawColor = new ColorRgba(0, 0, 0, 0);
        rectangle.X = F1RACE_DISPLAY_START_X - 1;
        rectangle.Y = F1RACE_DISPLAY_START_Y - 1;
        rectangle.Width = F1RACE_DISPLAY_END_X + 2 - rectangle.X;
        rectangle.Height = F1RACE_DISPLAY_END_Y + 1 - rectangle.Y;
        renderer.DrawRect(rectangle);

        renderer.DrawColor = new ColorRgba(130, 230, 100, 0);
        rectangle.X = F1RACE_GRASS_0_START_X;
        rectangle.Y = F1RACE_DISPLAY_START_Y;
        rectangle.Width = F1RACE_GRASS_0_END_X + 1 - rectangle.X;
        rectangle.Height = F1RACE_DISPLAY_END_Y - rectangle.Y;
        renderer.FillRect(rectangle);

        renderer.DrawColor = new ColorRgba(100, 180, 100, 0);
        renderer.DrawLine(new Line(F1RACE_GRASS_0_END_X - 1,
                           F1RACE_DISPLAY_START_Y, F1RACE_GRASS_0_END_X - 1, F1RACE_DISPLAY_END_Y - 1));

        renderer.DrawColor = new ColorRgba(0, 0, 0, 0);
        renderer.DrawLine(new Line(F1RACE_GRASS_0_END_X,
                           F1RACE_DISPLAY_START_Y, F1RACE_GRASS_0_END_X, F1RACE_DISPLAY_END_Y));

        renderer.DrawColor = new ColorRgba(130, 230, 100, 0);
        rectangle.X = F1RACE_GRASS_1_START_X;
        rectangle.Y = F1RACE_DISPLAY_START_Y;
        rectangle.Width = F1RACE_GRASS_1_END_X + 1 - rectangle.X;
        rectangle.Height = F1RACE_DISPLAY_END_Y - rectangle.Y;
        renderer.FillRect(rectangle);

        renderer.DrawColor = new ColorRgba(100, 180, 100, 0);
        renderer.DrawLine(new Line(F1RACE_GRASS_1_START_X + 1,
                           F1RACE_DISPLAY_START_Y, F1RACE_GRASS_1_START_X + 1, F1RACE_DISPLAY_END_Y - 1));

        renderer.DrawColor = new ColorRgba(0, 0, 0, 0);
        renderer.DrawLine(new Line(F1RACE_GRASS_1_START_X,
                           F1RACE_DISPLAY_START_Y, F1RACE_GRASS_1_START_X, F1RACE_DISPLAY_END_Y));

        renderer.DrawColor = new ColorRgba(0, 0, 0, 0);
        rectangle.X = F1RACE_STATUS_START_X;
        rectangle.Y = F1RACE_DISPLAY_START_Y;
        rectangle.Width = F1RACE_STATUS_END_X + 1 - rectangle.X;
        rectangle.Height = F1RACE_DISPLAY_END_Y - rectangle.Y;
        renderer.FillRect(rectangle);

        Texture_Draw(F1RACE_STATUS_START_X + 0, F1RACE_DISPLAY_START_Y + 0, TextureId.LOGO);
        Texture_Draw(F1RACE_STATUS_START_X + 5, F1RACE_DISPLAY_START_Y + 42, TextureId.STATUS_SCORE);
        Texture_Draw(F1RACE_STATUS_START_X + 2, F1RACE_DISPLAY_START_Y + 50, TextureId.STATUS_BOX);
        Texture_Draw(F1RACE_STATUS_START_X + 6, F1RACE_DISPLAY_START_Y + 64, TextureId.STATUS_LEVEL);
        Texture_Draw(F1RACE_STATUS_START_X + 2, F1RACE_DISPLAY_START_Y + 72, TextureId.STATUS_BOX);
        Texture_Draw(F1RACE_STATUS_START_X + 2, F1RACE_DISPLAY_START_Y + 89, TextureId.STATUS_FLY);
    }

    public void F1Race_Init()
    {
        int index;
        f1race_key_up_pressed = false;
        f1race_key_down_pressed = false;
        f1race_key_right_pressed = false;
        f1race_key_left_pressed = false;

        f1race_separator_0_block_start_y = F1RACE_DISPLAY_START_Y;
        f1race_separator_1_block_start_y = F1RACE_DISPLAY_START_Y + F1RACE_SEPARATOR_HEIGHT_SPACE * 3;

        f1race_player_car = new PlayerCar
        {
            Point = new Point((F1RACE_ROAD_1_START_X + F1RACE_ROAD_1_END_X - F1RACE_PLAYER_CAR_IMAGE_SIZE_X) / 2, F1RACE_DISPLAY_END_Y - F1RACE_PLAYER_CAR_IMAGE_SIZE_Y - 1),
            Delta = new Point(F1RACE_PLAYER_CAR_IMAGE_SIZE_X, F1RACE_PLAYER_CAR_IMAGE_SIZE_Y),
            Image = TextureId.PLAYER_CAR,
            Flying = TextureId.PLAYER_CAR_FLY,
            HeadLight = TextureId.PLAYER_CAR_HEAD_LIGHT
        };

        f1race_opposite_car_type[0] = new OppositeCarType
        {
            Delta = new Point(F1RACE_OPPOSITE_CAR_0_IMAGE_SIZE_X, F1RACE_OPPOSITE_CAR_0_IMAGE_SIZE_Y),
            Image = TextureId.OPPOSITE_CAR_0,
            Speed = 3,
            DxFromRoad = (F1RACE_ROAD_WIDTH - F1RACE_OPPOSITE_CAR_0_IMAGE_SIZE_X) / 2
        };

        f1race_opposite_car_type[1] = new OppositeCarType
        {
            Delta = new Point(F1RACE_OPPOSITE_CAR_1_IMAGE_SIZE_X, F1RACE_OPPOSITE_CAR_1_IMAGE_SIZE_Y),
            Image = TextureId.OPPOSITE_CAR_1,
            Speed = 4,
            DxFromRoad = (F1RACE_ROAD_WIDTH - F1RACE_OPPOSITE_CAR_1_IMAGE_SIZE_X) / 2
        };

        f1race_opposite_car_type[2] = new OppositeCarType
        {
            Delta = new Point(F1RACE_OPPOSITE_CAR_2_IMAGE_SIZE_X, F1RACE_OPPOSITE_CAR_2_IMAGE_SIZE_Y),
            Image = TextureId.OPPOSITE_CAR_2,
            Speed = 6,
            DxFromRoad = (F1RACE_ROAD_WIDTH - F1RACE_OPPOSITE_CAR_2_IMAGE_SIZE_X) / 2
        };

        f1race_opposite_car_type[3] = new OppositeCarType
        {
            Delta = new Point(F1RACE_OPPOSITE_CAR_3_IMAGE_SIZE_X, F1RACE_OPPOSITE_CAR_3_IMAGE_SIZE_Y),
            Image = TextureId.OPPOSITE_CAR_3,
            Speed = 3,
            DxFromRoad = (F1RACE_ROAD_WIDTH - F1RACE_OPPOSITE_CAR_3_IMAGE_SIZE_X) / 2
        };

        f1race_opposite_car_type[4] = new OppositeCarType
        {
            Delta = new Point(F1RACE_OPPOSITE_CAR_4_IMAGE_SIZE_X, F1RACE_OPPOSITE_CAR_4_IMAGE_SIZE_Y),
            Image = TextureId.OPPOSITE_CAR_4,
            Speed = 3,
            DxFromRoad = (F1RACE_ROAD_WIDTH - F1RACE_OPPOSITE_CAR_4_IMAGE_SIZE_X) / 2
        };

        f1race_opposite_car_type[5] = new OppositeCarType
        {
            Delta = new Point(F1RACE_OPPOSITE_CAR_5_IMAGE_SIZE_X, F1RACE_OPPOSITE_CAR_5_IMAGE_SIZE_Y),
            Image = TextureId.OPPOSITE_CAR_5,
            Speed = 5,
            DxFromRoad = (F1RACE_ROAD_WIDTH - F1RACE_OPPOSITE_CAR_5_IMAGE_SIZE_X) / 2
        };

        f1race_opposite_car_type[6] = new OppositeCarType
        {
            Delta = new Point(F1RACE_OPPOSITE_CAR_6_IMAGE_SIZE_X, F1RACE_OPPOSITE_CAR_6_IMAGE_SIZE_Y),
            Image = TextureId.OPPOSITE_CAR_6,
            Speed = 3,
            DxFromRoad = (F1RACE_ROAD_WIDTH - F1RACE_OPPOSITE_CAR_6_IMAGE_SIZE_X) / 2
        };

        for (index = 0; index < F1RACE_OPPOSITE_CAR_COUNT; index++)
        {
            f1race_opposite_car[index] = null;
        }

        f1race_is_crashing = false;
        f1race_last_car_road = 0;
        f1race_player_is_car_fly = false;
        f1race_score = 0;
        f1race_level = 1;
        f1race_pass = 0;
        f1race_fly_count = 1;
        f1race_fly_charger_count = 0;
    }

    public void F1Race_Main()
    {
        if (f1race_is_new_game != false)
        {
            F1Race_Init();
            f1race_is_new_game = false;
        }

        F1Race_Render_Background();
        F1Race_Render();

        if (using_new_background_ogg)
            PlayMusic(MusicId.BGM, loop: true);
        else
            PlayMusic(MusicId.BGM_LOWCOST, loop: true);
    }

    private bool F1RACE_RELEASE_ALL_KEY()
    {
        f1race_key_up_pressed = false;
        f1race_key_down_pressed = false;
        f1race_key_left_pressed = false;
        f1race_key_right_pressed = false;
        return f1race_is_crashing == true;
    }

    private void F1Race_Key_Left_Pressed()
    {
        if (F1RACE_RELEASE_ALL_KEY()) return;
        f1race_key_left_pressed = true;
    }

    private void F1Race_Key_Left_Released()
    {
        f1race_key_left_pressed = false;
    }

    private void F1Race_Key_Right_Pressed()
    {
        if (F1RACE_RELEASE_ALL_KEY()) return;
        f1race_key_right_pressed = true;
    }

    private void F1Race_Key_Right_Released()
    {
        f1race_key_right_pressed = false;
    }

    private void F1Race_Key_Up_Pressed()
    {
        if (F1RACE_RELEASE_ALL_KEY()) return;
        f1race_key_up_pressed = true;
    }

    private void F1Race_Key_Up_Released()
    {
        f1race_key_up_pressed = false;
    }

    private void F1Race_Key_Down_Pressed()
    {
        if (F1RACE_RELEASE_ALL_KEY()) return;
        f1race_key_down_pressed = true;
    }

    private void F1Race_Key_Down_Released()
    {
        f1race_key_down_pressed = false;
    }

    private void F1Race_Key_Fly_Pressed()
    {
        if (f1race_player_is_car_fly != false)
            return;

        if (f1race_fly_count > 0)
        {
            f1race_player_is_car_fly = true;
            f1race_player_car_fly_duration = 0;
            f1race_fly_count--;
        }
    }

    public void F1Race_Keyboard_Key_Handler(KeyCode code, ButtonState state)
    {
        switch (code)
        {
            case KeyCode.Left:
            case KeyCode.Kp4:
                if (state is ButtonState.Pressed) F1Race_Key_Left_Pressed(); else F1Race_Key_Left_Released();
                break;
            case KeyCode.Right:
            case KeyCode.Kp6:
                if (state is ButtonState.Pressed) F1Race_Key_Right_Pressed(); else F1Race_Key_Right_Released();
                break;
            case KeyCode.Up:
            case KeyCode.N2:
            case KeyCode.Kp8:
                if (state is ButtonState.Pressed) F1Race_Key_Up_Pressed(); else F1Race_Key_Up_Released();
                break;
            case KeyCode.Down:
            case KeyCode.N8:
            case KeyCode.Kp2:
                if (state is ButtonState.Pressed) F1Race_Key_Down_Pressed(); else F1Race_Key_Down_Released();
                break;
            case KeyCode.Space:
            case KeyCode.Return:
            case KeyCode.KpEnter:
            case KeyCode.N5:
            case KeyCode.Kp5:
                if (state is ButtonState.Pressed)
                    F1Race_Key_Fly_Pressed();
                break;
            case KeyCode.N:
            case KeyCode.Tab:
            case KeyCode.N0:
            case KeyCode.Kp0:
                if (state is ButtonState.Pressed)
                {
                    if (!using_new_background_ogg)
                        PlayMusic(MusicId.BGM, loop: true);
                    else
                        PlayMusic(MusicId.BGM_LOWCOST, loop: true);
                    using_new_background_ogg = !using_new_background_ogg;
                }
                break;
            case KeyCode.M:
            case KeyCode.N7:
            case KeyCode.Kp7:
                if (state is ButtonState.Pressed)
                {
                    if (volume_old == -1)
                    {
                        mixer.SetMusicVolume(0);
                        volume_old = 0;
                    }
                    else
                    {
                        mixer.SetMusicVolume(volume_old);
                        volume_old = -1;
                    }
                }
                break;
            case KeyCode.Escape:
                if (state is ButtonState.Pressed)
                    exit_main_loop = true;
                break;
        }
    }

    private void F1Race_Crashing()
    {
        PlayMusic(MusicId.CRASH, loop: false);

        f1race_is_crashing = true;
        f1race_crashing_count_down = 50;
    }

    private void F1Race_New_Opposite_Car()
    {
        int index;
        int validIndex = 0;
        bool no_slot;
        int car_type = 0;
        int road;
        int car_pos_x = 0;
        int car_shift;
        bool enough_space;
        int rand_num;
        int speed_add;

        no_slot = true;
        if ((Random.Shared.Next() % F1RACE_OPPOSITE_CAR_DEFAULT_APPEAR_RATE) == 0)
        {
            for (index = 0; index < F1RACE_OPPOSITE_CAR_COUNT; index++)
            {
                if (f1race_opposite_car[index] is null)
                {
                    validIndex = index;
                    no_slot = false;
                    break;
                }
            }
        }

        if (no_slot != false)
            return;

        road = Random.Shared.Next() % 3;

        if (road == f1race_last_car_road)
        {
            road++;
            road %= 3;
        }

        if (f1race_level < 3)
        {
            rand_num = Random.Shared.Next() % 11;
            switch (rand_num)
            {
                case 0:
                case 1:
                    car_type = 0;
                    break;
                case 2:
                case 3:
                case 4:
                    car_type = 1;
                    break;
                case 5:
                    car_type = 2;
                    break;
                case 6:
                case 7:
                    car_type = 3;
                    break;
                case 8:
                    car_type = 4;
                    break;
                case 9:
                    car_type = 5;
                    break;
                case 10:
                    car_type = 6;
                    break;
            }
        }

        if (f1race_level >= 3)
        {
            rand_num = Random.Shared.Next() % 11;
            switch (rand_num)
            {
                case 0:
                    car_type = 0;
                    break;
                case 1:
                case 2:
                    car_type = 1;
                    break;
                case 3:
                case 4:
                    car_type = 2;
                    break;
                case 5:
                case 6:
                    car_type = 3;
                    break;
                case 7:
                    car_type = 4;
                    break;
                case 8:
                case 9:
                    car_type = 5;
                    break;
                case 10:
                    car_type = 6;
                    break;
            }
        }
        enough_space = true;
        for (index = 0; index < F1RACE_OPPOSITE_CAR_COUNT; index++)
        {
            if (f1race_opposite_car[index] is OppositeCar car && car.Point.Y < (F1RACE_PLAYER_CAR_IMAGE_SIZE_Y * 1.5))
                enough_space = false;
        }

        if (enough_space == false)
            return;

        speed_add = f1race_level - 1;


        car_shift = f1race_opposite_car_type[car_type].DxFromRoad;

        switch (road)
        {
            case 0:
                car_pos_x = F1RACE_ROAD_0_START_X + car_shift;
                break;
            case 1:
                car_pos_x = F1RACE_ROAD_1_START_X + car_shift;
                break;
            case 2:
                car_pos_x = F1RACE_ROAD_2_START_X + car_shift;
                break;
        }


        f1race_opposite_car[validIndex] = new OppositeCar
        {
            Point = new Point(car_pos_x, F1RACE_DISPLAY_START_Y - f1race_opposite_car_type[car_type].Delta.Y),
            Delta = new Point(f1race_opposite_car_type[car_type].Delta.X, f1race_opposite_car_type[car_type].Delta.Y),
            Speed = f1race_opposite_car_type[car_type].Speed + speed_add,
            RoadId = road,
            DxFromRoad = f1race_opposite_car_type[car_type].DxFromRoad,
            IsAddScore = false,
            Image = f1race_opposite_car_type[car_type].Image
        };

        f1race_last_car_road = road;
    }

    private void F1Race_CollisionCheck()
    {
        int index;
        int minA_x, minA_y, maxA_x, maxA_y;
        int minB_x, minB_y, maxB_x, maxB_y;

        minA_x = f1race_player_car.Point.X - 1;
        maxA_x = minA_x + f1race_player_car.Delta.X - 1;
        minA_y = f1race_player_car.Point.Y - 1;
        maxA_y = minA_y + f1race_player_car.Delta.Y - 1;

        for (index = 0; index < F1RACE_OPPOSITE_CAR_COUNT; index++)
        {
            if (f1race_opposite_car[index] is OppositeCar car)
            {
                minB_x = car.Point.X - 1;
                maxB_x = minB_x + car.Delta.X - 1;
                minB_y = car.Point.Y - 1;
                maxB_y = minB_y + car.Delta.Y - 1;
                if (((minA_x <= minB_x) && (minB_x <= maxA_x)) || ((minA_x <= maxB_x) && (maxB_x <= maxA_x)))
                {
                    if (((minA_y <= minB_y) && (minB_y <= maxA_y)) || ((minA_y <= maxB_y) && (maxB_y <= maxA_y)))
                    {
                        F1Race_Crashing();
                        return;
                    }
                }

                if ((minA_x >= minB_x) && (minA_x <= maxB_x) && (minA_y >= minB_y) && (minA_y <= maxB_y))
                {
                    F1Race_Crashing();
                    return;
                }

                if ((minA_x >= minB_x) && (minA_x <= maxB_x) && (maxA_y >= minB_y) && (maxA_y <= maxB_y))
                {
                    F1Race_Crashing();
                    return;
                }

                if ((maxA_x >= minB_x) && (maxA_x <= maxB_x) && (minA_y >= minB_y) && (minA_y <= maxB_y))
                {
                    F1Race_Crashing();
                    return;
                }

                if ((maxA_x >= minB_x) && (maxA_x <= maxB_x) && (maxA_y >= minB_y) && (maxA_y <= maxB_y))
                {
                    F1Race_Crashing();
                    return;
                }

                if ((maxA_y < minB_y) && (car.IsAddScore == false))
                {
                    f1race_score++;
                    f1race_pass++;
                    car.IsAddScore = true;

                    if (f1race_pass == 10)
                        f1race_level++; /* level 2 */
                    else if (f1race_pass == 20)
                        f1race_level++; /* level 3 */
                    else if (f1race_pass == 30)
                        f1race_level++; /* level 4 */
                    else if (f1race_pass == 40)
                        f1race_level++; /* level 5 */
                    else if (f1race_pass == 50)
                        f1race_level++; /* level 6 */
                    else if (f1race_pass == 60)
                        f1race_level++; /* level 7 */
                    else if (f1race_pass == 70)
                        f1race_level++; /* level 8 */
                    else if (f1race_pass == 100)
                        f1race_level++; /* level 9 */

                    f1race_fly_charger_count++;
                    if (f1race_fly_charger_count >= 6)
                    {
                        if (f1race_fly_count < F1RACE_MAX_FLY_COUNT)
                        {
                            f1race_fly_charger_count = 0;
                            f1race_fly_count++;
                        }
                        else
                            f1race_fly_charger_count--;
                    }
                }
            }
        }
    }

    private void F1Race_Framemove()
    {
        int shift;
        int max;
        int index;

        f1race_player_car_fly_duration++;
        if (f1race_player_car_fly_duration == F1RACE_PLAYER_CAR_FLY_FRAME_COUNT)
            f1race_player_is_car_fly = false;

        shift = F1RACE_PLAYER_CAR_SHIFT;
        if (f1race_key_up_pressed)
        {
            if (f1race_player_car.Point.Y - shift < F1RACE_DISPLAY_START_Y)
                shift = f1race_player_car.Point.Y - F1RACE_DISPLAY_START_Y - 1;
            if (f1race_player_is_car_fly == false)
                f1race_player_car.Point.Y -= shift;
        }

        if (f1race_key_down_pressed)
        {
            max = f1race_player_car.Point.Y + f1race_player_car.Delta.Y;
            if (max + shift > F1RACE_DISPLAY_END_Y)
                shift = F1RACE_DISPLAY_END_Y - max;
            if (f1race_player_is_car_fly == false)
                f1race_player_car.Point.Y += shift;
        }

        if (f1race_key_right_pressed)
        {
            max = f1race_player_car.Point.X + f1race_player_car.Delta.X;
            if (max + shift > F1RACE_ROAD_2_END_X)
                shift = F1RACE_ROAD_2_END_X - max;
            f1race_player_car.Point.X += shift;
        }

        if (f1race_key_left_pressed)
        {
            if (f1race_player_car.Point.X - shift < F1RACE_ROAD_0_START_X)
                shift = f1race_player_car.Point.X - F1RACE_ROAD_0_START_X - 1;
            f1race_player_car.Point.X -= shift;
        }

        for (index = 0; index < F1RACE_OPPOSITE_CAR_COUNT; index++)
        {
            if (f1race_opposite_car[index] is OppositeCar car)
            {
                car.Point.Y += car.Speed;
                if (car.Point.Y > (F1RACE_DISPLAY_END_Y + car.Delta.Y))
                    f1race_opposite_car[index] = null;
            }
        }

        if (f1race_player_is_car_fly != false)
        {
            shift = F1RACE_PLAYER_CAR_FLY_SHIFT;
            if (f1race_player_car.Point.Y - shift < F1RACE_DISPLAY_START_Y)
                shift = f1race_player_car.Point.Y - F1RACE_DISPLAY_START_Y - 1;
            f1race_player_car.Point.Y -= shift;
        }
        else
            F1Race_CollisionCheck();

        F1Race_New_Opposite_Car();
    }

    /* === END LOGIC CODE === */

    public void F1Race_Cyclic_Timer()
    {
        if (f1race_is_crashing == false)
        {
            F1Race_Framemove();
            F1Race_Render();
        }
        else
        {
            f1race_crashing_count_down--;
            if (f1race_crashing_count_down >= 40)
                F1Race_Render_Player_Car_Crash();
            else
            {
                if (f1race_crashing_count_down == 39)
                    PlayMusic(MusicId.GAMEOVER, loop: false);
                F1Race_Show_Game_Over_Screen();
            }
            if (f1race_crashing_count_down <= 0)
            {
                f1race_is_crashing = false;
                f1race_is_new_game = true;
                F1Race_Main();
            }
        }
    }
}