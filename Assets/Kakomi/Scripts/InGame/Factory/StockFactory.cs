using System;
using Cysharp.Threading.Tasks;
using Kakomi.InGame.Application;
using Kakomi.InGame.Data.DataStore;
using Kakomi.InGame.Presentation.View;
using UniRx.Toolkit;
using UnityEngine;

namespace Kakomi.InGame.Factory
{
    public sealed class StockFactory : ObjectPool<StockObject>
    {
        private readonly Camera _uiCamera;
        private readonly Canvas _uiCanvas;
        private readonly RectTransform _uiTransform;
        private readonly EnclosureSpriteTable _enclosureSpriteTable;
        private readonly StockObject.Factory _stockObjectFactory;
        private readonly StockObjectContainer _stockObjectContainer;

        public StockFactory(Camera uiCamera, Canvas uiCanvas, RectTransform uiTransform,
            EnclosureSpriteTable enclosureSpriteTable, StockObject.Factory stockObjectFactory,
            StockObjectContainer stockObjectContainer)
        {
            _uiCamera = uiCamera;
            _uiCanvas = uiCanvas;
            _uiTransform = uiTransform;
            _enclosureSpriteTable = enclosureSpriteTable;
            _stockObjectFactory = stockObjectFactory;
            _stockObjectContainer = stockObjectContainer;
        }

        protected override StockObject CreateInstance()
        {
            var stockObject = _stockObjectFactory.Create();
            stockObject.Initialize(_uiCamera, _uiCanvas, _uiTransform);
            return stockObject;
        }

        public async UniTaskVoid Stock(EnclosureObjectType enclosureObjectType, Vector2 localPosition)
        {
            var stockObject = Rent();
            _stockObjectContainer.Add(stockObject);

            await stockObject.SetSprite(GetStockSprite(enclosureObjectType), localPosition);

            await stockObject.TweenStockPosition(_stockObjectContainer.GetStockPosition());
        }

        public void Burst(EnclosureObjectType enclosureObjectType)
        {
            if (_stockObjectContainer.IsStock() == false)
            {
                return;
            }

            _stockObjectContainer.Remove(enclosureObjectType, Return);
        }

        public void ClearStockData()
        {
            _stockObjectContainer.ClearStock();
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
    }
}