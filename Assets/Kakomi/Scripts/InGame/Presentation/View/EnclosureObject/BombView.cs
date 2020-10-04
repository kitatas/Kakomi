using System;
using UnityEngine;
using Zenject;

namespace Kakomi.InGame.Presentation.View
{
    public sealed class BombView : BaseEnclosureObject
    {
        [SerializeField] private int damageValue = 0;

        public override void Enclose(Action<int> action)
        {
            base.Enclose(action);
            _playerHpUseCase.Damage(damageValue);
        }

        public class Factory : PlaceholderFactory<BombView>
        {
        }
    }
}