using UnityEngine;

namespace Kakomi.InGame.Presentation.View
{
    public sealed class CursorView : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 25f;

        public void Move(Vector2 mousePosition)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                mousePosition,
                moveSpeed * Time.deltaTime);
        }

        public Vector3 GetPosition() => transform.position;
    }
}