using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Kakomi.InGame.Application;
using Kakomi.InGame.Domain.UseCase.Interface;
using Kakomi.InGame.Presentation.View.Interface;
using UnityEngine;
using Zenject;

namespace Kakomi.InGame.Presentation.View
{
    public abstract class BaseEnclosureObject : MonoBehaviour, IEnclosureObject
    {
        private bool _isEnclose;

        private CancellationToken _token;
        protected IPlayerHpUseCase _playerHpUseCase;
        protected IEnemyHpUseCase _enemyHpUseCase;

        [Inject]
        private void Construct(IPlayerHpUseCase playerHpUseCase, IEnemyHpUseCase enemyHpUseCase)
        {
            _token = this.GetCancellationTokenOnDestroy();
            _playerHpUseCase = playerHpUseCase;
            _enemyHpUseCase = enemyHpUseCase;
        }

        public void Init(Vector2 initializePosition, int direction, Action action)
        {
            _isEnclose = false;
            transform.position = initializePosition;

            UniTask.Void(async _ =>
            {
                await UniTask.WhenAny(
                    UniTask.WaitUntil(() => _isEnclose, cancellationToken: _token),
                    Move(direction));

                // poolに返却
                action?.Invoke();
            }, this);
        }

        private UniTask Move(int direction)
        {
            return UniTask.WaitWhile(() =>
            {
                transform.position += new Vector3(0, direction) * Time.deltaTime * 0.5f;

                return
                    transform.position.y > FieldParameter.yPoints[0] - 0.6f &&
                    transform.position.y < FieldParameter.yPoints[FieldParameter.yPoints.Length - 1] + 0.6f;
            }, cancellationToken: _token);
        }

        public virtual void Enclose()
        {
            _isEnclose = true;
        }
    }
}