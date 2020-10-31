using Kakomi.InGame.Data.Entity.Interface;
using Kakomi.InGame.Domain.Model.Interface;
using Kakomi.InGame.Domain.UseCase.Interface;
using UniRx;
using UnityEngine;

namespace Kakomi.InGame.Domain.UseCase
{
    public sealed class HpUseCase : IHpUseCase
    {
        private readonly int _maxHpValue;

        private readonly IHpEntity _hpEntity;
        private readonly IHpModel _hpModel;

        public HpUseCase(IHpEntity hpEntity, IHpModel hpModel)
        {
            _hpEntity = hpEntity;
            _hpModel = hpModel;

            _maxHpValue = _hpEntity.GetHpValue();
        }

        public IReadOnlyReactiveProperty<int> HpModel() => _hpModel.HpValue;

        public void Recover(int recoverValue)
        {
            _hpModel.SetHpValue(ClampHpValue(recoverValue));
        }

        public void Damage(int damageValue)
        {
            _hpModel.SetHpValue(ClampHpValue(-damageValue));
        }

        private int ClampHpValue(int addHpValue)
        {
            var hpValue = Mathf.Clamp(_hpEntity.GetCalculateHpValue(addHpValue), 0, _maxHpValue);
            _hpEntity.SetHpValue(hpValue);
            return _hpEntity.GetHpValue();
        }

        public bool IsAlive() => _hpEntity.GetHpValue() > 0;
    }
}