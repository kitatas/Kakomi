using UnityEngine;

namespace Kakomi.Scripts.View.Main
{
    public sealed class CursorView : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 25f;

        public void Move(Vector3 mousePosition)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                mousePosition,
                moveSpeed * Time.deltaTime);
        }

        public Vector3 GetPosition() => transform.position;
    }
}