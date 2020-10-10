using Kakomi.InGame.Presentation.View;
using UniRx;
using UniRx.Toolkit;
using UnityEngine;

namespace Kakomi.InGame.Factory
{
    public sealed class EffectFactory : ObjectPool<EncloseEffectView>
    {
        private readonly EncloseEffectView.Factory _encloseEffectFactory;

        public EffectFactory(EncloseEffectView.Factory encloseEffectFactory)
        {
            _encloseEffectFactory = encloseEffectFactory;
        }

        protected override EncloseEffectView CreateInstance()
        {
            return _encloseEffectFactory.Create();
        }

        public void Activate(Vector2 generatePosition, Color coreColor)
        {
            var effect = Rent();
            effect
                .Activate(generatePosition, coreColor)
                .Subscribe(_ => Return(effect));
        }
    }
}