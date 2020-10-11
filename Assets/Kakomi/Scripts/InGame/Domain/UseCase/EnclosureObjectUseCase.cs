using Kakomi.InGame.Data.Entity.Interface;
using Kakomi.InGame.Domain.UseCase.Interface;
using Kakomi.InGame.Presentation.View;
using Kakomi.InGame.Presentation.View.Interface;

namespace Kakomi.InGame.Domain.UseCase
{
    public sealed class EnclosureObjectUseCase : IEnclosureObjectUseCase
    {
        private readonly IEnclosureObjectValueEntity _enclosureObjectValueEntity;

        public EnclosureObjectUseCase(IEnclosureObjectValueEntity enclosureObjectValueEntity)
        {
            _enclosureObjectValueEntity = enclosureObjectValueEntity;
        }

        public int BulletTotalValue => _enclosureObjectValueEntity.BulletTotalValue;
        public int BombTotalValue => _enclosureObjectValueEntity.BombTotalValue;
        public int HeartTotalValue => _enclosureObjectValueEntity.HeartTotalValue;

        public void CalculateTotalValue(IEnclosureObject enclosureObject)
        {
            switch (enclosureObject)
            {
                case BulletView bullet:
                    _enclosureObjectValueEntity.AddAttackValue(bullet.AttackValue);
                    break;
                case BombView bomb:
                    _enclosureObjectValueEntity.AddDamageValue(bomb.DamageValue);
                    break;
                case HeartView heart:
                    _enclosureObjectValueEntity.AddRecoverValue(heart.RecoverValue);
                    break;
                default:
                    UnityEngine.Debug.LogWarning("not set enclosureObject.");
                    break;
            }
        }

        public int GetRecoverValue() => HeartTotalValue - BombTotalValue;

        public int GetDamageValue() => BombTotalValue - HeartTotalValue;

        public void ResetTotalValue()
        {
            _enclosureObjectValueEntity.ResetAllValue();
        }
    }
}