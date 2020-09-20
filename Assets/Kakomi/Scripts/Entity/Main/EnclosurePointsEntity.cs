using System.Collections.Generic;
using Kakomi.Scripts.Entity.Main.Interface;
using UnityEngine;

namespace Kakomi.Scripts.Entity.Main
{
    public sealed class EnclosurePointsEntity : IEnclosurePointsEntity
    {
        private readonly List<Vector3> _enclosurePoints;

        public EnclosurePointsEntity()
        {
            _enclosurePoints = new List<Vector3>();
        }

        public Vector3[] GetEnclosurePoints() => _enclosurePoints.ToArray();

        public void AddEnclosurePoint(Vector3 point) => _enclosurePoints.Add(point);

        public void ClearEnclosurePoints() => _enclosurePoints.Clear();
    }
}