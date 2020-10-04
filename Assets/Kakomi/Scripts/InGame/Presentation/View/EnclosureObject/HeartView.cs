using System;
using UnityEngine;
using Zenject;

namespace Kakomi.InGame.Presentation.View
{
    public sealed class HeartView : BaseEnclosureObject
    {
        [SerializeField] private int recoverValue = 0;

        public override void Enclose(Action<int> action)
        {
            base.Enclose(action);
            _playerHpUseCase.Recover(recoverValue);
        }

        public class Factory : PlaceholderFactory<HeartView>
        {
        }
    }
}