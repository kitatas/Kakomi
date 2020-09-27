using Kakomi.InGame.Data.DataStore;
using Kakomi.InGame.Presentation.View;
using UniRx.Toolkit;
using UnityEngine;

namespace Kakomi.InGame.Domain.Repository
{
    public sealed class EnclosureRepository : ObjectPool<EnclosureCollider>
    {
        private readonly EnclosureCollider _enclosureCollider;

        public EnclosureRepository(EnclosureTable enclosureTable)
        {
            _enclosureCollider = enclosureTable.EnclosureCollider;
        }

        protected override EnclosureCollider CreateInstance()
        {
            return Object.Instantiate(_enclosureCollider);
        }

        public void GenerateEnclosureCollider()
        {
            var enclosureCollider = Rent();
            enclosureCollider.EncloseLine(() =>
            {
                Return(enclosureCollider);
            });
        }
    }
}