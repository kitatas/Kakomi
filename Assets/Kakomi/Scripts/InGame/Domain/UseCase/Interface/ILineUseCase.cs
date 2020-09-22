using System;
using UnityEngine;

namespace Kakomi.InGame.Domain.UseCase.Interface
{
    public interface ILineUseCase
    {
        void DrawLine(Action<(Vector2, Vector2)> viewAction);
        void DeleteLinePoint(Vector2 point);
    }
}