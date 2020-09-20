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

        public List<Vector3> EnclosurePoints => _enclosurePoints;

        public void AddEnclosurePoint(Vector3 point) => _enclosurePoints.Add(point);

        public void ClearEnclosurePoints() => _enclosurePoints.Clear();
    }
}