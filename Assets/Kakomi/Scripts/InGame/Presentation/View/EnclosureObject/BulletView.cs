using Kakomi.InGame.Application;
using UnityEngine;
using Zenject;

namespace Kakomi.InGame.Presentation.View
{
    public sealed class BulletView : BaseEnclosureObject
    {
        [SerializeField] private int attackValue = 0;

        public override EnclosureObjectData EnclosureObjectData =>
            new EnclosureObjectData(EnclosureObjectType.Bullet, attackValue);

        public class Factory : PlaceholderFactory<BulletView>
        {
        }
    }
}