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
            mousePosition.x = Mathf.Clamp(mousePosition.x, FieldParameter.MIN_X, FieldParameter.MAX_X);
            mousePosition.y = Mathf.Clamp(mousePosition.y, FieldParameter.MIN_Y, FieldParameter.MAX_Y);

            transform.position = Vector2.MoveTowards(
                transform.position,
                mousePosition,
                DrawParameter.CURSOR_SPEED * Time.deltaTime);

            _cursorPointsUseCase.AddCursorPoint(transform.position);
        }
    }
}