using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Kakomi.InGame.Application;
using Kakomi.InGame.Presentation.View.Interface;
using UnityEngine;

namespace Kakomi.InGame.Domain.UseCase.Interface
{
    public interface IEnclosureObjectUseCase
    {
        UniTaskVoid StockEnclosureObjectDataAsync(IEnclosureObject enclosureObject, Vector2 localPosition);
        UniTask AttackAsync(CancellationToken token, Action<EnclosureObjectData> action);
    }
}