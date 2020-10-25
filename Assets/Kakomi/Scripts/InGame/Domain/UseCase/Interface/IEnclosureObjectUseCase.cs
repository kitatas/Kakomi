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
        void StockEnclosureObjectData(IEnclosureObject enclosureObject, Vector2 localPosition);
        UniTask Attack(CancellationToken token, Action<EnclosureObjectData> action);
        void ResetStockData();
    }
}