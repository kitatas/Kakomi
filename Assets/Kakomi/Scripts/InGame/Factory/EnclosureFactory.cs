using Kakomi.InGame.Presentation.View;
using UniRx.Toolkit;

namespace Kakomi.InGame.Factory
{
    public sealed class EnclosureFactory : ObjectPool<EnclosureCollider>
    {
        private readonly EnclosureCollider.Factory _enclosureColliderFactory;

        public EnclosureFactory(EnclosureCollider.Factory enclosureColliderFactory)
        {
            _enclosureColliderFactory = enclosureColliderFactory;
        }

        protected override EnclosureCollider CreateInstance()
        {
            return _enclosureColliderFactory.Create();
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