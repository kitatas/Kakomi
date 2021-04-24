using Kakomi.InGame.Application;
using Kakomi.InGame.Domain.UseCase.Interface;
using UnityEngine;
using Zenject;

namespace Kakomi.InGame.Presentation.Controller
{
    public sealed class EnclosureObjectGenerator : ITickable
    {
        private float _interval;

        private IGameStateUseCase _gameStateUseCase;
        private IEnclosureFactoryUseCase _enclosureFactoryUseCase;

        [Inject]
        private void Construct(IGameStateUseCase gameStateUseCase, IEnclosureFactoryUseCase enclosureFactoryUseCase)
        {
            _interval = FieldParameter.INTERVAL * 4.0f;

            _gameStateUseCase = gameStateUseCase;
            _enclosureFactoryUseCase = enclosureFactoryUseCase;
        }

        public void Tick()
        {
            if (_gameStateUseCase.IsEqual(GameState.Draw) == false)
            {
                return;
            }

            _interval += Time.deltaTime;
            if (_interval > FieldParameter.INTERVAL * 4.0f)
            {
                _interval = 0.0f;
                _enclosureFactoryUseCase.Activate();
            }
        }
    }
}