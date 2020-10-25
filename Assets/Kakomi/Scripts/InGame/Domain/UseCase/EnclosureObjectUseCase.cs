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
        private readonly IEnclosureObjectValueEntity _enclosureObjectValueEntity;
        private readonly IEnclosureObjectDataEntity _enclosureObjectDataEntity;
        private readonly StockFactory _stockFactory;

        public EnclosureObjectUseCase(IEnclosureObjectValueEntity enclosureObjectValueEntity,
            IEnclosureObjectDataEntity enclosureObjectDataEntity, StockFactory stockFactory)
        {
            _enclosureObjectValueEntity = enclosureObjectValueEntity;
            _enclosureObjectDataEntity = enclosureObjectDataEntity;
            _stockFactory = stockFactory;
        }

        public int BulletTotalValue => _enclosureObjectValueEntity.BulletTotalValue;
        public int BombTotalValue => _enclosureObjectValueEntity.BombTotalValue;
        public int HeartTotalValue => _enclosureObjectValueEntity.HeartTotalValue;

        public void StockEnclosureObjectData(IEnclosureObject enclosureObject, Vector2 localPosition)
        {
            switch (enclosureObject.EnclosureObjectData.enclosureObjectType)
            {
                case EnclosureObjectType.None:
                    break;
                case EnclosureObjectType.Bullet:
                    _enclosureObjectValueEntity.AddAttackValue(enclosureObject.EnclosureObjectData.effectValue);
                    break;
                case EnclosureObjectType.Bomb:
                    _enclosureObjectValueEntity.AddDamageValue(enclosureObject.EnclosureObjectData.effectValue);
                    break;
                case EnclosureObjectType.Heart:
                    _enclosureObjectValueEntity.AddRecoverValue(enclosureObject.EnclosureObjectData.effectValue);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(enclosureObject.EnclosureObjectData.enclosureObjectType),
                        enclosureObject.EnclosureObjectData.enclosureObjectType, null);
            }

            _enclosureObjectDataEntity.AddEnclosureObjectList(enclosureObject.EnclosureObjectData);
            _stockFactory.Stock(enclosureObject.EnclosureObjectData.enclosureObjectType, localPosition).Forget();
        }

        public async UniTask Test(CancellationToken token, Action<EnclosureObjectData> action)
        {
            foreach (var enclosureObjectData in _enclosureObjectDataEntity.GetEnclosureObjectStockList)
            {
                action?.Invoke(enclosureObjectData);
                await UniTask.Delay(TimeSpan.FromSeconds(0.1f), cancellationToken: token);
            }
        }

        public int GetRecoverValue() => HeartTotalValue - BombTotalValue;

        public int GetDamageValue() => BombTotalValue - HeartTotalValue;

        public void ResetTotalValue()
        {
            _enclosureObjectValueEntity.ResetAllValue();
            _enclosureObjectDataEntity.ClearEnclosureObjectList();
        }
    }
}