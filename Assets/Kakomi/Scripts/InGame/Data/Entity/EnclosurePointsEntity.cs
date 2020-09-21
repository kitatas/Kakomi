using System.Collections.Generic;
using Kakomi.InGame.Data.Entity.Interface;
using UnityEngine;

namespace Kakomi.InGame.Data.Entity
{
    public sealed class EnclosurePointsEntity : IEnclosurePointsEntity
    {
        private readonly List<Vector2> _enclosurePoints;

        public EnclosurePointsEntity()
        {
            _enclosurePoints = new List<Vector2>();
        }

        public Vector2[] GetEnclosurePoints() => _enclosurePoints.ToArray();

        public void AddEnclosurePoint(Vector2 point) => _enclosurePoints.Add(point);

        public void ClearEnclosurePoints() => _enclosurePoints.Clear();
    }
}