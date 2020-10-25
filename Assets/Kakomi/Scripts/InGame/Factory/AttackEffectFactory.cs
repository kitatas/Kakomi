using Kakomi.InGame.Presentation.View;
using UniRx;
using UniRx.Toolkit;
using UnityEngine;

namespace Kakomi.InGame.Factory
{
    public sealed class AttackEffectFactory : ObjectPool<AttackEffectView>
    {
        private readonly AttackEffectView.Factory _attackEffectFactory;

        public AttackEffectFactory(AttackEffectView.Factory attackEffectFactory)
        {
            _attackEffectFactory = attackEffectFactory;
        }
        
        protected override AttackEffectView CreateInstance()
        {
            return _attackEffectFactory.Create();
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