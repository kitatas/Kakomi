using Kakomi.Scripts.UseCase.Main.Interface;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace Kakomi.Scripts.View.Main
{
    [RequireComponent(typeof(PolygonCollider2D))]
    public sealed class EnclosureColliderView : MonoBehaviour
    {
        [Inject]
        private void Construct(IEnclosurePointsUseCase enclosurePointsUseCase)
        {
            enclosurePointsUseCase.CreateEnclosureArea();
        }

        private void Start()
        {
            this.OnTriggerEnter2DAsObservable()
                .Subscribe(_ =>
                {
                    // TODO : 囲まれたオブジェクトをどうにかする
                })
                .AddTo(this);
        }
    }
}