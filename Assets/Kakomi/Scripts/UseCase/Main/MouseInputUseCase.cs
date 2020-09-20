using Kakomi.Scripts.UseCase.Main.Interface;
using UnityEngine;

namespace Kakomi.Scripts.UseCase.Main
{
    public sealed class MouseInputUseCase : IInputUseCase
    {
        private readonly Camera _camera;

        public MouseInputUseCase(Camera camera)
        {
            _camera = camera;
        }

        public bool InputMouseButton() => Input.GetMouseButton(0);

        public Vector3 GetMousePosition()
        {
            var mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            return mousePosition;
        }
    }
}