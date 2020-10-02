using Kakomi.InGame.Data.DataStore;
using Kakomi.InGame.Presentation.View;
using UniRx.Toolkit;
using UnityEngine;

namespace Kakomi.InGame.Factory
{
    public sealed class EnclosureFactory : ObjectPool<EnclosureCollider>
    {
        private readonly EnclosureCollider _enclosureCollider;

        public EnclosureFactory(LineTable lineTable)
        {
            _enclosureCollider = lineTable.EnclosureCollider;
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