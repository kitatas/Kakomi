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
        [Inject]
        private void Construct(IEnclosurePointsUseCase enclosurePointsUseCase)
        {
            enclosurePointsUseCase.CreateEnclosureArea();

            Destroy(gameObject, DrawParameter.ENCLOSURE_TIME);
        }

        private void Start()
        {
            this.OnTriggerEnter2DAsObservable()
                .Subscribe(other =>
                {
                    if (other.TryGetComponent(out IEnclosureObject enclosureObject))
                    {
                        enclosureObject.Enclose();
                    }
                })
                .AddTo(this);
        }
    }
}