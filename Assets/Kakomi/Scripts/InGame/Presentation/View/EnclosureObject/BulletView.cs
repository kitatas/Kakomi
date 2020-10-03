using UnityEngine;
using Zenject;

namespace Kakomi.InGame.Presentation.View
{
    public sealed class BulletView : BaseEnclosureObject
    {
        [SerializeField] private int attackValue = 0;

        public override void Enclose()
        {
            base.Enclose();
            _enemyHpUseCase.Damage(attackValue);
        }

        public class Factory : PlaceholderFactory<BulletView>
        {
        }
    }
}