using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Kakomi.InGame.Application;
using Kakomi.InGame.Domain.UseCase.Interface;
using Kakomi.InGame.Factory;
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
        private IEnclosurePointsUseCase _enclosurePointsUseCase;
        private IEnclosureObjectUseCase _enclosureObjectUseCase;
        private EffectFactory _effectFactory;

        [Inject]
        private void Construct(IEnclosurePointsUseCase enclosurePointsUseCase,
            IEnclosureObjectUseCase enclosureObjectUseCase, EffectFactory effectFactory)
        {
            _token = this.GetCancellationTokenOnDestroy();
            _enclosurePointsUseCase = enclosurePointsUseCase;
            _enclosureObjectUseCase = enclosureObjectUseCase;
            _effectFactory = effectFactory;
        }

        public void EncloseLine(Action action)
        {
            polygonCollider.points = _enclosurePointsUseCase.GetEnclosurePoints();

            UniTask.Void(async _ =>
            {
                await UniTask.Delay(TimeSpan.FromSeconds(DrawParameter.ENCLOSURE_TIME), cancellationToken: _token);

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
                        var position = other.transform.position;
                        _effectFactory.Activate(position, enclosureObject.CoreColor);
                        enclosureObject.Enclose(x =>
                        {
                            _enclosureObjectUseCase.ActivateEnclosureObject(position, x);
                        });
                    }
                })
                .AddTo(this);
        }

        public class Factory : PlaceholderFactory<EnclosureCollider>
        {
        }
    }
}