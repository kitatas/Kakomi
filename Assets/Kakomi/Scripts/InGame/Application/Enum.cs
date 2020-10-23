namespace Kakomi.InGame.Application
{
    public enum GameState
    {
        Ready,
        Draw,
        Attack,
        Damage,
        Clear,
        Failed,
    }

    public enum FinishType
    {
        Clear,
        Failed,
    }

    public enum IdType
    {
        Player,
        Enemy,
    }
}