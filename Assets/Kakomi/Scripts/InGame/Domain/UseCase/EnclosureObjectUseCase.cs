using Kakomi.InGame.Domain.UseCase.Interface;
using Kakomi.InGame.Presentation.View;
using Kakomi.InGame.Presentation.View.Interface;

namespace Kakomi.InGame.Domain.UseCase
{
    public sealed class EnclosureObjectUseCase : IEnclosureObjectUseCase
    {
        public int BulletTotalValue { get; private set; }
        public int BombTotalValue { get; private set; }
        public int HeartTotalValue { get; private set; }

        public EnclosureObjectUseCase()
        {
            ResetTotalValue();
        }

        public void CalculateTotalValue(IEnclosureObject enclosureObject)
        {
            switch (enclosureObject)
            {
                case BulletView bullet:
                    BulletTotalValue += bullet.AttackValue;
                    break;
                case BombView bomb:
                    BombTotalValue += bomb.DamageValue;
                    break;
                case HeartView heart:
                    HeartTotalValue += heart.RecoverValue;
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
            BulletTotalValue = 0;
            BombTotalValue = 0;
            HeartTotalValue = 0;
        }
    }
}