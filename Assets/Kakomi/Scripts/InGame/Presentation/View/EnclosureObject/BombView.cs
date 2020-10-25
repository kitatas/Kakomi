using Kakomi.InGame.Application;
using UnityEngine;
using Zenject;

namespace Kakomi.InGame.Presentation.View
{
    public sealed class BombView : BaseEnclosureObject
    {
        [SerializeField] private int damageValue = 0;
        public override int EffectValue => damageValue;
        public override EnclosureObjectType EnclosureObjectType => EnclosureObjectType.Bomb;

        public class Factory : PlaceholderFactory<BombView>
        {
        }
    }
}