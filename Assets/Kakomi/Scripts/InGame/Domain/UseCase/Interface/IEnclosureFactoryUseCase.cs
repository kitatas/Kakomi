using UnityEngine;

namespace Kakomi.InGame.Domain.UseCase.Interface
{
    public interface IEnclosureFactoryUseCase
    {
        void Activate();
        void ActivateEnclosureObject(Vector2 position, int direction);
    }
}