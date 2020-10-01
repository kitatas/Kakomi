using Kakomi.InGame.Domain.UseCase;
using Kakomi.InGame.Presentation.View.Interface;
using UnityEngine;
using Zenject;

namespace Kakomi.InGame.Presentation.View
{
    public sealed class BulletView : MonoBehaviour, IEnclosureObject
    {
        [SerializeField] private int attackValue = 0;

        private IEnemyHpUseCase _enemyHpUseCase;

        [Inject]
        private void Construct(IEnemyHpUseCase enemyHpUseCase)
        {
            _enemyHpUseCase = enemyHpUseCase;
        }

        public void Enclose()
        {
            _enemyHpUseCase.Damage(attackValue);
        }
    }
}