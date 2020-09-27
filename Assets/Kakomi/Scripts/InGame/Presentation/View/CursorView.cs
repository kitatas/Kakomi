using Kakomi.InGame.Application;
using Kakomi.InGame.Domain.UseCase.Interface;
using UnityEngine;
using Zenject;

namespace Kakomi.InGame.Presentation.View
{
    public sealed class CursorView : MonoBehaviour
    {
        private ICursorPointsUseCase _cursorPointsUseCase;

        [Inject]
        private void Construct(ICursorPointsUseCase cursorPointsUseCase)
        {
            _cursorPointsUseCase = cursorPointsUseCase;
        }

        public void Move(Vector2 mousePosition)
        {
            mousePosition.x = Mathf.Clamp(mousePosition.x, -2.4f, 2.4f);
            mousePosition.y = Mathf.Clamp(mousePosition.y, -4.2f, 4.2f);

            transform.position = Vector2.MoveTowards(
                transform.position,
                mousePosition,
                DrawParameter.CURSOR_SPEED * Time.deltaTime);

            _cursorPointsUseCase.AddCursorPoint(transform.position);
        }
    }
}