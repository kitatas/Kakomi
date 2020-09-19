using UnityEngine;

namespace Kakomi.Scripts.View.Main
{
    public sealed class EnclosureView : MonoBehaviour
    {
        [SerializeField] private EnclosureColliderView enclosureColliderView = default;

        public void GenerateEnclosureCollider()
        {
            Instantiate(enclosureColliderView, transform);
        }
    }
}