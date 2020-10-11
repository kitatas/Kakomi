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

        private int _bulletTotalValue = 0;
        private int _bombTotalValue = 0;
        private int _heartTotalValue = 0;

        private CancellationToken _token;
        private IPlayerHpUseCase _playerHpUseCase;
        private IEnemyHpUseCase _enemyHpUseCase;
        private IEnclosurePointsUseCase _enclosurePointsUseCase;
        private IEnclosureObjectUseCase _enclosureObjectUseCase;

        [Inject]
        private void Construct(IPlayerHpUseCase playerHpUseCase, IEnemyHpUseCase enemyHpUseCase,
            IEnclosurePointsUseCase enclosurePointsUseCase, IEnclosureObjectUseCase enclosureObjectUseCase)
        {
            _token = this.GetCancellationTokenOnDestroy();
            _playerHpUseCase = playerHpUseCase;
            _enemyHpUseCase = enemyHpUseCase;
            _enclosurePointsUseCase = enclosurePointsUseCase;
            _enclosureObjectUseCase = enclosureObjectUseCase;
        }

        public void EncloseLine(Action action)
        {
            polygonCollider.points = _enclosurePointsUseCase.GetEnclosurePoints();

            UniTask.Void(async _ =>
            {
                await UniTask.Delay(TimeSpan.FromSeconds(DrawParameter.ENCLOSURE_TIME), cancellationToken: _token);

                ExecuteEncloseAction();
                ResetTotalValue();

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
                        CalculateTotalValue(enclosureObject);
                        var position = other.transform.position;
                        enclosureObject.Enclose(x =>
                        {
                            _enclosureObjectUseCase.ActivateEnclosureObject(position, x);
                        });
                    }
                })
                .AddTo(this);
        }

        private void CalculateTotalValue(IEnclosureObject enclosureObject)
        {
            switch (enclosureObject)
            {
                case BulletView bullet:
                    _bulletTotalValue += bullet.AttackValue;
                    break;
                case BombView bomb:
                    _bombTotalValue += bomb.DamageValue;
                    break;
                case HeartView heart:
                    _heartTotalValue += heart.RecoverValue;
                    break;
                default:
                    UnityEngine.Debug.LogWarning("not set enclosureObject.");
                    break;
            }
        }

        private void ExecuteEncloseAction()
        {
            _enemyHpUseCase.Damage(_bulletTotalValue);

            if (_heartTotalValue > _bombTotalValue)
            {
                var updateValue = _heartTotalValue - _bombTotalValue;
                _playerHpUseCase.Recover(updateValue);
            }
            else if (_heartTotalValue < _bombTotalValue)
            {
                var updateValue = _bombTotalValue - _heartTotalValue;
                _playerHpUseCase.Damage(updateValue);
            }
        }

        private void ResetTotalValue()
        {
            _bulletTotalValue = 0;
            _bombTotalValue = 0;
            _heartTotalValue = 0;
        }

        public class Factory : PlaceholderFactory<EnclosureCollider>
        {
        }
    }
}