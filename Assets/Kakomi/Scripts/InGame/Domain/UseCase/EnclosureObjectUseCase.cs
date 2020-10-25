using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Kakomi.InGame.Application;
using Kakomi.InGame.Data.Entity.Interface;
using Kakomi.InGame.Domain.UseCase.Interface;
using Kakomi.InGame.Factory;
using Kakomi.InGame.Presentation.View.Interface;
using UnityEngine;

namespace Kakomi.InGame.Domain.UseCase
{
    public sealed class EnclosureObjectUseCase : IEnclosureObjectUseCase
    {
        private readonly IEnclosureObjectDataEntity _enclosureObjectDataEntity;
        private readonly StockFactory _stockFactory;

        public EnclosureObjectUseCase(IEnclosureObjectDataEntity enclosureObjectDataEntity, StockFactory stockFactory)
        {
            _enclosureObjectDataEntity = enclosureObjectDataEntity;
            _stockFactory = stockFactory;
        }

        public void StockEnclosureObjectData(IEnclosureObject enclosureObject, Vector2 localPosition)
        {
            _enclosureObjectDataEntity.AddEnclosureObjectList(enclosureObject.EnclosureObjectData);
            _stockFactory.Stock(enclosureObject.EnclosureObjectData.enclosureObjectType, localPosition).Forget();
        }

        public async UniTask Attack(CancellationToken token, Action<EnclosureObjectData> action)
        {
            foreach (var enclosureObjectData in _enclosureObjectDataEntity.GetEnclosureObjectStockList)
            {
                action?.Invoke(enclosureObjectData);
                await UniTask.Delay(TimeSpan.FromSeconds(0.1f), cancellationToken: token);
            }
        }

        public void ResetStockData()
        {
            _enclosureObjectDataEntity.ClearEnclosureObjectList();
        }
    }
}