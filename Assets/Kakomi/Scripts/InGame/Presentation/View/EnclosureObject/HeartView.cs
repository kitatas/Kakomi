using UnityEngine;
using Zenject;

namespace Kakomi.InGame.Presentation.View
{
    public sealed class HeartView : BaseEnclosureObject
    {
        [SerializeField] private int recoverValue = 0;
        public int RecoverValue => recoverValue;

        public class Factory : PlaceholderFactory<HeartView>
        {
        }
    }
}