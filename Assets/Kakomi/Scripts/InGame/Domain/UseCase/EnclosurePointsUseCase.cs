using Kakomi.InGame.Data.Entity.Interface;
using Kakomi.InGame.Domain.UseCase.Interface;
using UnityEngine;

namespace Kakomi.InGame.Domain.UseCase
{
    public sealed class EnclosurePointsUseCase : IEnclosurePointsUseCase
    {
        private readonly IEnclosurePointsEntity _enclosurePointsEntity;

        public EnclosurePointsUseCase(IEnclosurePointsEntity enclosurePointsEntity)
        {
            _enclosurePointsEntity = enclosurePointsEntity;
        }

        public Vector2[] GetEnclosurePoints()
        {
            return _enclosurePointsEntity.GetEnclosurePoints();
        }
    }
}