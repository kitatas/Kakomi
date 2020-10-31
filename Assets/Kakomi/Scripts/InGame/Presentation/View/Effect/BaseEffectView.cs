using System;
using UniRx;
using UnityEngine;

namespace Kakomi.InGame.Presentation.View
{
    public abstract class BaseEffectView : MonoBehaviour
    {
        [SerializeField] private ParticleSystem encloseEffect = default;

        public IObservable<Unit> Activate(Vector2 initializePosition, Color coreColor)
        {
            transform.position = initializePosition;

            var effect = encloseEffect.main;
            effect.startColor = coreColor;
            encloseEffect.Play();

            return Observable
                .Timer(TimeSpan.FromSeconds(5.0f))
                .ForEachAsync(_ => encloseEffect.Stop())
                .TakeUntilDestroy(this);
        }
    }
}