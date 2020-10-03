using Kakomi.InGame.Data.Entity;
using Kakomi.InGame.Data.Entity.Interface;
using Kakomi.InGame.Domain.Model;
using Kakomi.InGame.Domain.Model.Interface;
using Kakomi.InGame.Domain.UseCase.Interface;
using UniRx;
using UnityEngine;

namespace Kakomi.InGame.Domain.UseCase
{
    public sealed class EnemyHpUseCase : IEnemyHpUseCase
    {
        private int _maxHpValue;
        private IHpEntity _hpEntity;
        private IHpModel _hpModel;

        public void Initialize(int maxHpValue)
        {
            _maxHpValue = maxHpValue;
            _hpEntity = new HpEntity(_maxHpValue);
            _hpModel = new HpModel(_maxHpValue);
        }

        public IReadOnlyReactiveProperty<int> HpModel() => _hpModel.HpValue;

        public void Damage(int damageValue)
        {
            _hpModel.SetPlayerHp(ClampHpValue(-damageValue));
        }

        private int ClampHpValue(int addHpValue)
        {
            var hpValue = Mathf.Clamp(_hpEntity.GetCalculateHpValue(addHpValue), 0, _maxHpValue);
            _hpEntity.SetHpValue(hpValue);
            return _hpEntity.GetHpValue();
        }
    }
}