using UnityEngine;

namespace Kakomi.InGame.Data.Entity.Interface
{
    public interface IEnclosurePointsEntity
    {
        Vector2[] GetEnclosurePoints();
        void AddEnclosurePoint(Vector2 point);
        void ClearEnclosurePoints();
    }
}