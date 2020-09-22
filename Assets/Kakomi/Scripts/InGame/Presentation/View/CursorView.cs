using Kakomi.InGame.Application;
using UnityEngine;

namespace Kakomi.InGame.Presentation.View
{
    public sealed class CursorView : MonoBehaviour
    {
        public void Move(Vector2 mousePosition)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                mousePosition,
                DrawParameter.CURSOR_SPEED * Time.deltaTime);
        }

        public Vector3 GetPosition() => transform.position;
    }
}