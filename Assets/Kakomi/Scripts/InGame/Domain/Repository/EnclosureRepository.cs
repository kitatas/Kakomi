using Kakomi.InGame.Data.DataStore;
using Kakomi.InGame.Presentation.View;
using UnityEngine;

namespace Kakomi.InGame.Domain.Repository
{
    public sealed class EnclosureRepository
    {
        private readonly EnclosureCollider _enclosureCollider;

        public EnclosureRepository(EnclosureTable enclosureTable)
        {
            _enclosureCollider = enclosureTable.EnclosureCollider;
        }

        public void GenerateEnclosureCollider()
        {
            Object.Instantiate(_enclosureCollider);
        }
    }
}