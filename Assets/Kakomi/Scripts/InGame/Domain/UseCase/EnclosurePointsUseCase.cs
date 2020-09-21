using Kakomi.InGame.Data.Entity.Interface;
using Kakomi.InGame.Domain.UseCase.Interface;
using Kakomi.Utility;
using UnityEngine;

namespace Kakomi.InGame.Domain.UseCase
{
    public sealed class EnclosurePointsUseCase : IEnclosurePointsUseCase
    {
        private readonly PolygonCollider2D _polygonCollider;
        private readonly IEnclosurePointsEntity _enclosurePointsEntity;

        public EnclosurePointsUseCase(PolygonCollider2D polygonCollider, IEnclosurePointsEntity enclosurePointsEntity)
        {
            _polygonCollider = polygonCollider;
            _enclosurePointsEntity = enclosurePointsEntity;
        }

        public void CreateEnclosureArea()
        {
            _polygonCollider.points = _enclosurePointsEntity.GetEnclosurePoints();
        }
    }
}