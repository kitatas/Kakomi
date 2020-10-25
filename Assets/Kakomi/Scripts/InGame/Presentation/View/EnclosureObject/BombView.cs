using Kakomi.InGame.Application;
using UnityEngine;
using Zenject;

namespace Kakomi.InGame.Presentation.View
{
    public sealed class BombView : BaseEnclosureObject
    {
        [SerializeField] private int damageValue = 0;

        public override EnclosureObjectData EnclosureObjectData =>
            new EnclosureObjectData(EnclosureObjectType.Bomb, damageValue);

        public class Factory : PlaceholderFactory<BombView>
        {
        }
    }
}