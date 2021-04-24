namespace Kakomi.InGame.Application
{
    public enum GameState
    {
        None,
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

    public enum EnclosureObjectType
    {
        None,
        Bullet,
        Bomb,
        Heart,
    }
}