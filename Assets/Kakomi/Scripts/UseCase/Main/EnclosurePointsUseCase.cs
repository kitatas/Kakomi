using Kakomi.Scripts.Entity.Main.Interface;
using Kakomi.Scripts.UseCase.Main.Interface;
using Kakomi.Scripts.Utility;
using UnityEngine;

namespace Kakomi.Scripts.UseCase.Main
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
            var pointsArray = _enclosurePointsEntity.EnclosurePoints.ToArray();
            _polygonCollider.points = pointsArray.ConvertVector2();
        }
    }
}