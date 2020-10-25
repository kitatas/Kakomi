using Kakomi.InGame.Application;
using UnityEngine;
using Zenject;

namespace Kakomi.InGame.Presentation.View
{
    public sealed class BulletView : BaseEnclosureObject
    {
        [SerializeField] private int attackValue = 0;
        public override int EffectValue => attackValue;
        public override EnclosureObjectType EnclosureObjectType => EnclosureObjectType.Bullet;

        public class Factory : PlaceholderFactory<BulletView>
        {
        }
    }
}