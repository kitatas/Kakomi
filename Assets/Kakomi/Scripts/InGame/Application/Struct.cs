namespace Kakomi.InGame.Application
{
    public struct EnclosureObjectData
    {
        public readonly EnclosureObjectType enclosureObjectType;
        public readonly int effectValue;

        public EnclosureObjectData(EnclosureObjectType enclosureObjectType, int effectValue)
        {
            this.enclosureObjectType = enclosureObjectType;
            this.effectValue = effectValue;
        }
    }
}