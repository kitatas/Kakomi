using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Kakomi.InGame.Application;
using UnityEngine;

namespace Kakomi.InGame.Presentation.View
{
    public sealed class GameStateView : MonoBehaviour
    {
        [SerializeField] private TurnCountView turnCountView = default;
        [SerializeField] private DrawCountView drawCountView = default;
        [SerializeField] private FinishView finishView = default;
        [SerializeField] private EnemyView enemyView = default;

        public void Initialize()
        {
            finishView.Initialize();
        }

        public void SetFinish(GameState gameState)
        {
            finishView.SetFinish(gameState);
        }

        public async UniTask TweenTurnTextAsync(CancellationToken token)
        {
            drawCountView.ResetCountDrawTime();
            await turnCountView.TweenTurnTextAsync(token);
        }

        public async UniTask AttackPlayerAsync(CancellationToken token, Action action)
        {
            await enemyView.AttackPlayerAsync(token, () => action?.Invoke());
        }

        public async UniTask CountAsync(CancellationToken token)
        {
            await drawCountView.CountDrawTimeAsync(token);
        }
    }
}