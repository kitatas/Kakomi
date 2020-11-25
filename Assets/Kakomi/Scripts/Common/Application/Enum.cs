namespace Kakomi.Common.Application
{
    public enum SceneName
    {
        Title,
        Menu,
        Main,
    }

    public enum SeType
    {
        Decision = 0,
        Cancel   = 1,
        Enclose  = 2,
        Attack   = 3,
        Damage   = 4,
        Recover  = 5,
        Clear    = 6,
        Failed   = 7,
    }

    public enum BgmType
    {
        Title  = 0,
        Menu   = 1,
        Game   = 2,
    }
}