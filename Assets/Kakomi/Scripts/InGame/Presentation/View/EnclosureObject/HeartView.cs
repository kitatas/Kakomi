using Kakomi.InGame.Application;
using UnityEngine;
using Zenject;

namespace Kakomi.InGame.Presentation.View
{
    public sealed class HeartView : BaseEnclosureObject
    {
        [SerializeField] private int recoverValue = 0;
        public override int EffectValue => recoverValue;
        public override EnclosureObjectType EnclosureObjectType => EnclosureObjectType.Heart;

        public class Factory : PlaceholderFactory<HeartView>
        {
        }
    }
}