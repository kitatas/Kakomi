using System.Collections.Generic;
using UnityEngine;

namespace Kakomi.Scripts.Entity.Main.Interface
{
    public interface IEnclosurePointsEntity
    {
        List<Vector3> EnclosurePoints { get; }
        Vector3 GetEnclosurePoint(int index);
        int EnclosurePointsCount();
        void AddEnclosurePoint(Vector3 point);
        void ClearEnclosurePoints();
    }
}