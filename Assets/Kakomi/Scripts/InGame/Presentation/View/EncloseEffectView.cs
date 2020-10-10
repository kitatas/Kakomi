using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace Kakomi.InGame.Presentation.View
{
    public sealed class EncloseEffectView : MonoBehaviour
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
                .ForEachAsync(_ => encloseEffect.Stop());
        }

        public class Factory : PlaceholderFactory<EncloseEffectView>
        {
        }
    }
}