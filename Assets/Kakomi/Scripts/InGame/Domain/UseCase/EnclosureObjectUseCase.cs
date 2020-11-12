using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Kakomi.InGame.Application;
using Kakomi.InGame.Data.DataStore;
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
        private readonly AttackEffectFactory _attackEffectFactory;
        private readonly EnclosureSpriteTable _enclosureSpriteTable;

        public EnclosureObjectUseCase(IEnclosureObjectDataEntity enclosureObjectDataEntity, StockFactory stockFactory,
            AttackEffectFactory attackEffectFactory, EnclosureSpriteTable enclosureSpriteTable)
        {
            _enclosureObjectDataEntity = enclosureObjectDataEntity;
            _stockFactory = stockFactory;
            _attackEffectFactory = attackEffectFactory;
            _enclosureSpriteTable = enclosureSpriteTable;
        }

        public async UniTaskVoid StockEnclosureObjectDataAsync(IEnclosureObject enclosureObject, Vector2 localPosition)
        {
            var stockObject = _stockFactory.Stock();

            await stockObject.SetSpriteAsync(GetStockSprite(enclosureObject.EnclosureObjectType), localPosition);

            var enclosureObjectData = new EnclosureObjectData(
                stockObject,
                enclosureObject.EffectValue,
                enclosureObject.EnclosureObjectType);
            _enclosureObjectDataEntity.AddEnclosureObjectList(enclosureObjectData);

            await stockObject.TweenStockPositionAsync();
        }

        private Sprite GetStockSprite(EnclosureObjectType enclosureObjectType)
        {
            switch (enclosureObjectType)
            {
                case EnclosureObjectType.Bullet:
                    return _enclosureSpriteTable.BulletSprite;
                case EnclosureObjectType.Bomb:
                    return _enclosureSpriteTable.BombSprite;
                case EnclosureObjectType.Heart:
                    return _enclosureSpriteTable.HeartSprite;
                case EnclosureObjectType.None:
                default:
                    throw new ArgumentOutOfRangeException(nameof(enclosureObjectType), enclosureObjectType, null);
            }
        }

        public async UniTask AttackAsync(CancellationToken token, Action<EnclosureObjectData> action)
        {
            foreach (var enclosureObjectData in _enclosureObjectDataEntity.GetEnclosureObjectStockList)
            {
                enclosureObjectData.stockObject.TweenAttackPosition(enclosureObjectData.enclosureObjectType,
                    (stockObject, position) =>
                    {
                        _attackEffectFactory.Activate(position, Color.red);
                        _stockFactory.Return(stockObject);
                    });

                action?.Invoke(enclosureObjectData);
                await UniTask.Delay(TimeSpan.FromSeconds(0.1f), cancellationToken: token);
            }

            _enclosureObjectDataEntity.ClearEnclosureObjectList();
        }
    }
}