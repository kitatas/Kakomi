using Kakomi.InGame.Application;
using Kakomi.InGame.Data.Entity.Interface;
using Kakomi.InGame.Domain.UseCase.Interface;
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
            switch (enclosureObject.EnclosureObjectType)
            {
                case EnclosureObjectType.None:
                    break;
                case EnclosureObjectType.Bullet:
                    _enclosureObjectValueEntity.AddAttackValue(enclosureObject.EffectValue);
                    break;
                case EnclosureObjectType.Bomb:
                    _enclosureObjectValueEntity.AddDamageValue(enclosureObject.EffectValue);
                    break;
                case EnclosureObjectType.Heart:
                    _enclosureObjectValueEntity.AddRecoverValue(enclosureObject.EffectValue);
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