using System.Collections.Generic;
using Kakomi.InGame.Application;
using Kakomi.InGame.Data.Entity.Interface;

namespace Kakomi.InGame.Data.Entity
{
    public sealed class EnclosureObjectDataEntity : IEnclosureObjectDataEntity
    {
        private readonly List<EnclosureObjectData> _enclosureObjectStockList;

        public EnclosureObjectDataEntity()
        {
            _enclosureObjectStockList = new List<EnclosureObjectData>();
        }

        public List<EnclosureObjectData> GetEnclosureObjectStockList => _enclosureObjectStockList;

        public void AddEnclosureObjectList(EnclosureObjectData enclosureObjectType)
        {
            _enclosureObjectStockList.Add(enclosureObjectType);
        }

        public void ClearEnclosureObjectList()
        {
            _enclosureObjectStockList.Clear();
        }
    }
}