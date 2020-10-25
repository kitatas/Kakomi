using Kakomi.InGame.Application;
using UnityEngine;
using Zenject;

namespace Kakomi.InGame.Presentation.View
{
    public sealed class HeartView : BaseEnclosureObject
    {
        [SerializeField] private int recoverValue = 0;

        public override EnclosureObjectData EnclosureObjectData =>
            new EnclosureObjectData(EnclosureObjectType.Heart, recoverValue);

        public class Factory : PlaceholderFactory<HeartView>
        {
        }
    }
}