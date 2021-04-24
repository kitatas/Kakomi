using System.Threading;
using Cysharp.Threading.Tasks;
using Kakomi.InGame.Application;
using UnityEngine;

namespace Kakomi.InGame.Presentation.View.State
{
    public abstract class BaseState : MonoBehaviour
    {
        public abstract GameState GetState();

        public virtual async UniTask InitAsync(CancellationToken token)
        {
            
        }

        public virtual async UniTask ResetAsync(GameState state, CancellationToken token)
        {

        }

        public virtual async UniTask<GameState> TickAsync(CancellationToken token)
        {
            return GameState.None;
        }

        public virtual async UniTask DisposeAsync(CancellationToken token)
        {

        }
    }
}