using Kakomi.InGame.Domain.UseCase.Interface;
using UnityEngine;

namespace Kakomi.InGame.Domain.UseCase
{
    public sealed class MouseInputUseCase : IInputUseCase
    {
        private readonly Camera _camera;

        public MouseInputUseCase(Camera camera)
        {
            _camera = camera;
        }

        public bool IsInputScreen() => Input.GetMouseButton(0);

        public Vector2 GetInputPosition()
        {
            return _camera.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}