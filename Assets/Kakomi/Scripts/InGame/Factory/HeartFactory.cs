using Kakomi.InGame.Factory.Interface;
using Kakomi.InGame.Presentation.View;
using UniRx.Toolkit;
using UnityEngine;

namespace Kakomi.InGame.Factory
{
    public sealed class HeartFactory : ObjectPool<HeartView>, IEnclosureObjectFactory
    {
        private readonly HeartView.Factory _heartViewFactory;

        public HeartFactory(HeartView.Factory heartViewFactory)
        {
            _heartViewFactory = heartViewFactory;
        }

        protected override HeartView CreateInstance()
        {
            return _heartViewFactory.Create();
        }

        public void Activate(Vector2 generatePosition, int direction)
        {
            var heartView = Rent();
            heartView.Init(generatePosition, direction, () =>
            {
                Return(heartView);
            });
        }
    }
}