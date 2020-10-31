namespace Kakomi.InGame.Application
{
    public sealed class DrawParameter
    {
        public const float DRAW_TIME = 10f;

        public const float DIFFERENCE_DISTANCE = 0.01f;

        public const float LINE_WIDTH = 0.1f;
        public const float DELETE_TIME = 2.0f;

        public const float CURSOR_SPEED = 30f;

        public const float ENCLOSURE_TIME = 0.05f;
    }

    public sealed class PlayerStatus
    {
        public const int MAX_HP = 100;
    }

    public sealed class EnemyStatus
    {
        public const int MAX_HP = 100;
        public const int ATTACK = 10;
    }

    public sealed class FieldParameter
    {
        public static readonly float[] xPoints =
        {
            -1.75f, -1.05f, -0.35f, 0.35f, 1.05f, 1.75f,
        };

        public static readonly float[] yPoints =
        {
            -3.9f, -3.2f, -2.5f, -1.8f, -1.1f, -0.4f, 0.3f, 1.0f, 1.7f, 2.4f,
        };

        public const float INTERVAL = 0.7f;
        public const float SPAWN_TIME = 0.5f;

        public const float MAX_X = 2.3f;
        public const float MIN_X = -2.3f;
        public const float MAX_Y = 2.2f;
        public const float MIN_Y = -3.7f;

        public const float HP_ANIMATION_TIME = 0.25f;
    }
}