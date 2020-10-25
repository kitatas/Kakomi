using Kakomi.InGame.Presentation.View;

namespace Kakomi.InGame.Application
{
    public struct EnclosureObjectData
    {
        public readonly StockObject stockObject;
        public readonly int effectValue;
        public readonly EnclosureObjectType enclosureObjectType;

        public EnclosureObjectData(StockObject stockObject, int effectValue, EnclosureObjectType enclosureObjectType)
        {
            this.stockObject = stockObject;
            this.effectValue = effectValue;
            this.enclosureObjectType = enclosureObjectType;
        }
    }
}