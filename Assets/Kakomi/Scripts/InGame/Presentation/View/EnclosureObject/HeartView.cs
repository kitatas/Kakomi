using Kakomi.InGame.Domain.UseCase.Interface;
using Kakomi.InGame.Presentation.View.Interface;
using UnityEngine;
using Zenject;

namespace Kakomi.InGame.Presentation.View
{
    public sealed class HeartView : MonoBehaviour, IEnclosureObject
    {        
        [SerializeField] private int recoverValue = 0;

        private IPlayerHpUseCase _playerHpUseCase;

        [Inject]
        private void Construct(IPlayerHpUseCase playerHpUseCase)
        {
            _playerHpUseCase = playerHpUseCase;
        }

        public void Enclose()
        {
            _playerHpUseCase.Recover(recoverValue);
        }
    }
}