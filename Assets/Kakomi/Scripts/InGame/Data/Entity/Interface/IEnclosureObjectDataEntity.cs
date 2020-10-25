using System.Collections.Generic;
using Kakomi.InGame.Application;

namespace Kakomi.InGame.Data.Entity.Interface
{
    public interface IEnclosureObjectDataEntity
    {
        List<EnclosureObjectData> GetEnclosureObjectStockList { get; }
        void AddEnclosureObjectList(EnclosureObjectData enclosureObjectType);
        void ClearEnclosureObjectList();
    }
}