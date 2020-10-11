using Kakomi.InGame.Presentation.View.Interface;

namespace Kakomi.InGame.Domain.UseCase.Interface
{
    public interface IEnclosureObjectUseCase
    {
        int BulletTotalValue { get; }
        int BombTotalValue { get; }
        int HeartTotalValue { get; }
        void CalculateTotalValue(IEnclosureObject enclosureObject);
        int GetRecoverValue();
        int GetDamageValue();
        void ResetTotalValue();
    }
}