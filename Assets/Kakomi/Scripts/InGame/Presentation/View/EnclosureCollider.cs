using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Kakomi.InGame.Application;
using Kakomi.InGame.Domain.UseCase.Interface;
using Kakomi.InGame.Presentation.View.Interface;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace Kakomi.InGame.Presentation.View
{
    [RequireComponent(typeof(PolygonCollider2D))]
    public sealed class EnclosureCollider : MonoBehaviour
    {
        [SerializeField] private PolygonCollider2D polygonCollider = default;

        private CancellationToken _token;
        private IPlayerHpUseCase _playerHpUseCase;
        private IEnemyHpUseCase _enemyHpUseCase;
        private IEnclosurePointsUseCase _enclosurePointsUseCase;
        private IEnclosureObjectUseCase _enclosureObjectUseCase;
        private IEnclosureFactoryUseCase _enclosureFactoryUseCase;

        [Inject]
        private void Construct(IPlayerHpUseCase playerHpUseCase, IEnemyHpUseCase enemyHpUseCase,
            IEnclosurePointsUseCase enclosurePointsUseCase, IEnclosureObjectUseCase enclosureObjectUseCase,
            IEnclosureFactoryUseCase enclosureFactoryUseCase)
        {
            _token = this.GetCancellationTokenOnDestroy();
            _playerHpUseCase = playerHpUseCase;
            _enemyHpUseCase = enemyHpUseCase;
            _enclosurePointsUseCase = enclosurePointsUseCase;
            _enclosureObjectUseCase = enclosureObjectUseCase;
            _enclosureFactoryUseCase = enclosureFactoryUseCase;
        }

        public void EncloseLine(Action action)
        {
            polygonCollider.points = _enclosurePointsUseCase.GetEnclosurePoints();

            UniTask.Void(async _ =>
            {
                await UniTask.Delay(TimeSpan.FromSeconds(DrawParameter.ENCLOSURE_TIME), cancellationToken: _token);

                ExecuteEncloseAction();

                // poolに返却
                action?.Invoke();
            }, this);
        }

        private void Start()
        {
            this.OnTriggerEnter2DAsObservable()
                .Subscribe(other =>
                {
                    if (other.TryGetComponent(out IEnclosureObject enclosureObject))
                    {
                        _enclosureObjectUseCase.CalculateTotalValue(enclosureObject);
                        var position = other.transform.position;
                        enclosureObject.Enclose(x =>
                        {
                            _enclosureFactoryUseCase.ActivateEnclosureObject(position, x);
                        });
                    }
                })
                .AddTo(this);
        }

        private void ExecuteEncloseAction()
        {
            _enemyHpUseCase.Damage(_enclosureObjectUseCase.BulletTotalValue);

            if (_enclosureObjectUseCase.GetRecoverValue() > 0)
            {
                _playerHpUseCase.Recover(_enclosureObjectUseCase.GetRecoverValue());
            }
            else if (_enclosureObjectUseCase.GetDamageValue() > 0)
            {
                _playerHpUseCase.Damage(_enclosureObjectUseCase.GetDamageValue());
            }

            _enclosureObjectUseCase.ResetTotalValue();
        }

        public class Factory : PlaceholderFactory<EnclosureCollider>
        {
        }
    }
}