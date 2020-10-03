using Kakomi.InGame.Factory.Interface;
using Kakomi.InGame.Presentation.View;
using UniRx.Toolkit;
using UnityEngine;

namespace Kakomi.InGame.Factory
{
    public sealed class BombFactory : ObjectPool<BombView>, IEnclosureObjectFactory
    {
        private readonly BombView.Factory _bombViewFactory;

        public BombFactory(BombView.Factory bombViewFactory)
        {
            _bombViewFactory = bombViewFactory;
        }

        protected override BombView CreateInstance()
        {
            return _bombViewFactory.Create();
        }

        public void Activate(Vector2 generatePosition, int direction)
        {
            var bombView = Rent();
            bombView.Init(generatePosition, direction, () =>
            {
                Return(bombView);
            });
        }
    }
}