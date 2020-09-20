using UnityEngine;

namespace Kakomi.Scripts.View.Main
{
    public sealed class EnclosureRepository : MonoBehaviour
    {
        [SerializeField] private EnclosureCollider enclosureCollider = default;

        public void GenerateEnclosureCollider()
        {
            Instantiate(enclosureCollider, transform);
        }
    }
}