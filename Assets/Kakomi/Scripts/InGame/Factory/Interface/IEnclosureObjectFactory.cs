using UnityEngine;

namespace Kakomi.InGame.Factory.Interface
{
    public interface IEnclosureObjectFactory
    {
        void Activate(Vector2 generatePosition, int direction);
    }
}