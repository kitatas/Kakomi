using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Kakomi.InGame.Application;
using Kakomi.InGame.Data.DataStore;
using Kakomi.InGame.Data.Entity.Interface;
using Kakomi.InGame.Domain.UseCase.Interface;
using Kakomi.InGame.Factory;
using Kakomi.InGame.Presentation.View;
using Kakomi.InGame.Presentation.View.Interface;
using UnityEngine;

namespace Kakomi.InGame.Domain.UseCase
{
    public sealed class EnclosureObjectUseCase : IEnclosureObjectUseCase
    {
        private readonly IEnclosureObjectDataEntity _enclosureObjectDataEntity;
        private readonly StockFactory _stockFactory;
        private readonly AttackEffectFactory _attackEffectFactory;
        private readonly EnclosureSpriteTable _enclosureSpriteTable;
        private readonly StockPositionCommander _stockPositionCommander;

        public EnclosureObjectUseCase(IEnclosureObjectDataEntity enclosureObjectDataEntity, StockFactory stockFactory,
            AttackEffectFactory attackEffectFactory, EnclosureSpriteTable enclosureSpriteTable,
            StockPositionCommander stockPositionCommander)
        {
            _enclosureObjectDataEntity = enclosureObjectDataEntity;
            _stockFactory = stockFactory;
            _attackEffectFactory = attackEffectFactory;
            _enclosureSpriteTable = enclosureSpriteTable;
            _stockPositionCommander = stockPositionCommander;

            _stockPositionCommander.ResetStockPosition();
        }

        public async UniTaskVoid StockEnclosureObjectDataAsync(IEnclosureObject enclosureObject, Vector2 localPosition)
        {
            var stockObject = _stockFactory.Stock();

            await stockObject.SetSprite(GetStockSprite(enclosureObject.EnclosureObjectType), localPosition);

            var enclosureObjectData = new EnclosureObjectData(
                stockObject,
                enclosureObject.EffectValue,
                enclosureObject.EnclosureObjectType);
            _enclosureObjectDataEntity.AddEnclosureObjectList(enclosureObjectData);

            await stockObject.TweenStockPosition(_stockPositionCommander.GetStockPosition());
        }

        private Sprite GetStockSprite(EnclosureObjectType enclosureObjectType)
        {
            switch (enclosureObjectType)
            {
                case EnclosureObjectType.Bullet:
                    return _enclosureSpriteTable.GetBulletSprite;
                case EnclosureObjectType.Bomb:
                    return _enclosureSpriteTable.GetBombSprite;
                case EnclosureObjectType.Heart:
                    return _enclosureSpriteTable.GetHeartSprite;
                case EnclosureObjectType.None:
                default:
                    throw new ArgumentOutOfRangeException(nameof(enclosureObjectType), enclosureObjectType, null);
            }
        }

        public async UniTask AttackAsync(CancellationToken token, Action<EnclosureObjectData> action)
        {
            foreach (var enclosureObjectData in _enclosureObjectDataEntity.GetEnclosureObjectStockList)
            {
                var position = _stockPositionCommander.GetAttackPosition(enclosureObjectData.enclosureObjectType);
                enclosureObjectData.stockObject.TweenAttackPosition(position, stockObject =>
                {
                    _attackEffectFactory.Activate(position, Color.red);
                    _stockFactory.Return(stockObject);
                });

                action?.Invoke(enclosureObjectData);
                await UniTask.Delay(TimeSpan.FromSeconds(0.1f), cancellationToken: token);
            }

            _enclosureObjectDataEntity.ClearEnclosureObjectList();
            _stockPositionCommander.ResetStockPosition();
        }
    }
}