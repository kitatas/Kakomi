using Kakomi.InGame.Factory.Interface;
using Kakomi.InGame.Presentation.View;
using UniRx.Toolkit;
using UnityEngine;

namespace Kakomi.InGame.Factory
{
    public sealed class BulletFactory : ObjectPool<BulletView>, IEnclosureObjectFactory
    {
        private readonly BulletView.Factory _bulletViewFactory;

        public BulletFactory(BulletView.Factory bulletViewFactory)
        {
            _bulletViewFactory = bulletViewFactory;
        }

        protected override BulletView CreateInstance()
        {
            return _bulletViewFactory.Create();
        }

        public void Activate(Vector2 generatePosition, int direction)
        {
            var bulletView = Rent();
            bulletView.Init(generatePosition, direction, () =>
            {
                Return(bulletView);
            });
        }
    }
}