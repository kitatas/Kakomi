using Kakomi.Scripts.View.Main.EnclosureObject.Interface;
using UnityEngine;

namespace Kakomi.Scripts.View.Main.EnclosureObject
{
    public sealed class NormalEnclosureObject : MonoBehaviour, IEnclosureObject
    {
        [SerializeField] private int endurancePoint = 0;

        public void Enclose()
        {
            if (--endurancePoint <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}