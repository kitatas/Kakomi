using UnityEngine;
using Zenject;

namespace Kakomi.InGame.Presentation.View
{
    public sealed class BombView : BaseEnclosureObject
    {
        [SerializeField] private int damageValue = 0;
        public int DamageValue => damageValue;

        public class Factory : PlaceholderFactory<BombView>
        {
        }
    }
}