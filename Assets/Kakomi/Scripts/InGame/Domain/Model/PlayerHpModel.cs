using Kakomi.InGame.Application;
using Kakomi.InGame.Domain.Model.Interface;
using UniRx;
using UnityEngine;

namespace Kakomi.InGame.Domain.Model
{
    public sealed class PlayerHpModel : IPlayerHpModel
    {
        private ReactiveProperty<int> _hpModel;

        public IPlayerHpModel Initialize(int maxHpValue)
        {
            _hpModel = new ReactiveProperty<int>(maxHpValue);
            return this;
        }

        public IReadOnlyReactiveProperty<int> HpModel => _hpModel;

        public void UpdatePlayerHp(int addValue)
        {
            var hpValue = _hpModel.Value + addValue;
            _hpModel.Value = Mathf.Clamp(hpValue, 0, PlayerStatus.MAX_HP);
        }
    }
}