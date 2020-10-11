using UnityEngine;
using Zenject;

namespace Kakomi.InGame.Presentation.View
{
    public sealed class BulletView : BaseEnclosureObject
    {
        [SerializeField] private int attackValue = 0;
        public int AttackValue => attackValue;

        public class Factory : PlaceholderFactory<BulletView>
        {
        }
    }
}