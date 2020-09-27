using Kakomi.InGame.Application;
using UnityEngine;

namespace Kakomi.InGame.Presentation.View
{
    public sealed class CursorView : MonoBehaviour
    {
        public Vector2 Move(Vector2 mousePosition)
        {
            mousePosition.x = Mathf.Clamp(mousePosition.x, -2.4f, 2.4f);
            mousePosition.y = Mathf.Clamp(mousePosition.y, -4.2f, 4.2f);

            return transform.position = Vector2.MoveTowards(
                transform.position,
                mousePosition,
                DrawParameter.CURSOR_SPEED * Time.deltaTime);
        }
    }
}