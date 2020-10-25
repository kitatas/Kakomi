using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Kakomi.InGame.Application;
using Kakomi.Utility;
using UnityEngine;

namespace Kakomi.InGame.Presentation.View
{
    public sealed class EnclosureObjectView : MonoBehaviour
    {
        [SerializeField] private Collider2D collider2d = default;
        [SerializeField] private SpriteRenderer coreSprite = default;
        [SerializeField] private SpriteRenderer shadowSprite = default;

        public void Initialize(Color color)
        {
            shadowSprite.color = color.SetAlpha(0.5f);
        }

        public async UniTaskVoid SpawnAsync(CancellationToken token)
        {
            collider2d.enabled = false;
            coreSprite.color = coreSprite.color.SetAlpha(0f);
            transform.localScale = Vector2.one;

            await UniTask.Delay(TimeSpan.FromSeconds(FieldParameter.SPAWN_TIME), cancellationToken: token);

            await (
                coreSprite
                    .DOColor(coreSprite.color.SetAlpha(1f), FieldParameter.SPAWN_TIME)
                    .WithCancellation(token),
                transform
                    .DOScale(Vector2.one * 2f, FieldParameter.SPAWN_TIME)
                    .SetEase(Ease.OutExpo)
                    .WithCancellation(token));

            collider2d.enabled = true;
        }
    }
}