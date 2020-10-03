namespace Kakomi.InGame.Application
{
    public sealed class DrawParameter
    {
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
    }

    public sealed class FieldParameter
    {
        public static readonly float[] xPoints =
        {
            -2.0f, -1.5f, -1.0f, -0.5f, 0.0f, 0.5f, 1.0f, 1.5f, 2.0f,
        };

        public static readonly float[] yPoints =
        {
            -3.5f, -3.0f, -2.5f, -2.0f, -1.5f, -1.0f, -0.5f, 0.0f, 0.5f, 1.0f, 1.5f, 2.0f,
        };
    }
}