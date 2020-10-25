using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Kakomi.InGame.Application;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Kakomi.InGame.Presentation.View
{
    public sealed class FinishView : MonoBehaviour
    {
        [SerializeField] private Image backMenu = default;
        [SerializeField] private TextMeshProUGUI backText = default;
        [SerializeField] private TextMeshProUGUI finishText = default;

        private CancellationToken _token;

        public void Initialize()
        {
            backMenu.enabled = false;
            backText.enabled = false;
            finishText.text = "";

            _token = this.GetCancellationTokenOnDestroy();
        }

        public void SetFinish(GameState gameState)
        {
            SetFinishAsync(gameState).Forget();
        }

        private async UniTaskVoid SetFinishAsync(GameState gameState)
        {
            try
            {
                finishText.text = $"{GetFinishType(gameState).ToString()}";

                await UniTask.Delay(TimeSpan.FromSeconds(1f), cancellationToken: _token);

                backMenu.enabled = true;
                backText.enabled = true;
            }
            catch (Exception)
            {
                UnityEngine.Debug.LogError("finish type error.");
                throw;
            }
        }

        private static FinishType GetFinishType(GameState gameState)
        {
            switch (gameState)
            {
                case GameState.Clear:
                    return FinishType.Clear;
                case GameState.Failed:
                    return FinishType.Failed;
                default:
                    throw new ArgumentOutOfRangeException(nameof(gameState), gameState, null);
            }
        }
    }
}