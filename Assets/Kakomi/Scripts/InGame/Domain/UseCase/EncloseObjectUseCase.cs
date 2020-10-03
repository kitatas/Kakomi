using System.Collections.Generic;
using Kakomi.InGame.Application;
using Kakomi.InGame.Domain.UseCase.Interface;
using Kakomi.InGame.Factory;
using Kakomi.InGame.Factory.Interface;
using UnityEngine;

namespace Kakomi.InGame.Domain.UseCase
{
    public sealed class EncloseObjectUseCase : IEncloseObjectUseCase
    {
        private readonly List<IEnclosureObjectFactory> _factories;

        public EncloseObjectUseCase(BombFactory bombFactory, HeartFactory heartFactory, BulletFactory bulletFactory)
        {
            _factories = new List<IEnclosureObjectFactory>
            {
                bombFactory,
                heartFactory,
                bulletFactory,
            };

            Initialize();
        }

        private void Initialize()
        {
            for (int i = 0; i < FieldParameter.xPoints.Length; i++)
            {
                for (int j = 0; j < FieldParameter.yPoints.Length; j++)
                {
                    var position = new Vector2(FieldParameter.xPoints[i], FieldParameter.yPoints[j]);
                    var direction = GetDirection(i);
                    ActivateEnclosureObject(position, direction);
                }
            }
        }

        public void Activate()
        {
            for (int i = 0; i < FieldParameter.xPoints.Length; i++)
            {
                var y = i % 2 == 0
                    ? FieldParameter.yPoints[0] - 0.5f
                    : FieldParameter.yPoints[FieldParameter.yPoints.Length - 1] + 0.5f;

                var position = new Vector2(FieldParameter.xPoints[i], y);
                var direction = GetDirection(i);
                ActivateEnclosureObject(position, direction);
            }
        }

        private int GetDirection(int index) => index % 2 == 0 ? 1 : -1;

        private void ActivateEnclosureObject(Vector2 position, int direction)
        {
            int index = Random.Range(0, _factories.Count);
            _factories[index]?.Activate(position, direction);
        }
    }
}