using Kakomi.Scripts.UseCase.Main.Interface;
using Kakomi.Scripts.View.Main.EnclosureObject.Interface;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace Kakomi.Scripts.View.Main
{
    [RequireComponent(typeof(PolygonCollider2D))]
    public sealed class EnclosureCollider : MonoBehaviour
    {
        [Inject]
        private void Construct(IEnclosurePointsUseCase enclosurePointsUseCase)
        {
            enclosurePointsUseCase.CreateEnclosureArea();

            Destroy(gameObject, 0.1f);
        }

        private void Start()
        {
            this.OnTriggerEnter2DAsObservable()
                .Subscribe(other =>
                {
                    // TODO : 囲まれたオブジェクトをどうにかする
                    if (other.TryGetComponent(out IEnclosureObject enclosureObject))
                    {
                        enclosureObject.Enclose();
                    }
                })
                .AddTo(this);
        }
    }
}