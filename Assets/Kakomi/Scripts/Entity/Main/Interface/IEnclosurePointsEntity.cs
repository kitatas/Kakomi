using UnityEngine;

namespace Kakomi.Scripts.Entity.Main.Interface
{
    public interface IEnclosurePointsEntity
    {
        Vector3[] GetEnclosurePoints();
        void AddEnclosurePoint(Vector3 point);
        void ClearEnclosurePoints();
    }
}