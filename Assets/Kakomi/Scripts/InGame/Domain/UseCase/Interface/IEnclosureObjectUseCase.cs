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
        int BulletTotalValue { get; }
        int BombTotalValue { get; }
        int HeartTotalValue { get; }
        void StockEnclosureObjectData(IEnclosureObject enclosureObject, Vector2 localPosition);
        UniTask Test(CancellationToken token, Action<EnclosureObjectData> action);
        int GetRecoverValue();
        int GetDamageValue();
        void ResetTotalValue();
    }
}