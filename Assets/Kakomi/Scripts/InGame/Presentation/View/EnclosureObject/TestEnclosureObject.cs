using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Kakomi.InGame.Presentation.View.Interface;
using TMPro;
using UniRx;
using UnityEngine;

namespace Kakomi.InGame.Presentation.View
{
    public sealed class TestEnclosureObject : MonoBehaviour, IEnclosureObject
    {
        [SerializeField] private TextMeshProUGUI endurancePointText = default;
        [SerializeField] private int endurancePoint = 0;
        private ReactiveProperty<int> _endurancePoint;

        private void Start()
        {
            _endurancePoint = new ReactiveProperty<int>(endurancePoint);

            _endurancePoint
                .Where(x => x >= 0)
                .Subscribe(x => endurancePointText.text = $"{x}")
                .AddTo(this);

            _endurancePoint
                .Where(x => x == 0)
                .Subscribe(_ =>
                {
                    endurancePointText.text = "Complete!!!";
                    var token = this.GetCancellationTokenOnDestroy();
                    DestroyAsync(token).Forget();
                })
                .AddTo(this);
        }

        private async UniTaskVoid DestroyAsync(CancellationToken token)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(0.5f), cancellationToken: token);

            Destroy(gameObject);
        }

        public Color CoreColor { get; }

        public void Enclose(Action<int> action)
        {
            _endurancePoint.Value--;
        }
    }
}