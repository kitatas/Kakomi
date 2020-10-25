using System;
using System.Collections.Generic;
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
        private readonly List<StockObject> _stockObjects;
        private readonly float _x = -367.5f;
        private readonly float _y = -600f;
        private float _currentX;
        private float _currentY;

        private readonly Camera _uiCamera;
        private readonly Canvas _uiCanvas;
        private readonly RectTransform _uiTransform;
        private readonly EnclosureSpriteTable _enclosureSpriteTable;
        private readonly StockObject.Factory _stockObjectFactory;

        public StockFactory(Camera uiCamera, Canvas uiCanvas, RectTransform uiTransform,
            EnclosureSpriteTable enclosureSpriteTable, StockObject.Factory stockObjectFactory)
        {
            _stockObjects = new List<StockObject>();
            _currentX = _x;
            _currentY = _y;

            _uiCamera = uiCamera;
            _uiCanvas = uiCanvas;
            _uiTransform = uiTransform;
            _enclosureSpriteTable = enclosureSpriteTable;
            _stockObjectFactory = stockObjectFactory;
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
            _stockObjects.Add(stockObject);

            await stockObject.SetSprite(GetStockSprite(enclosureObjectType), localPosition);

            await stockObject.TweenStockPosition(CalculateStockPosition());
        }

        private Vector2 CalculateStockPosition()
        {
            _currentX += 15f;
            if (_currentX >= -_x)
            {
                _currentX = _x + 15f;
                _currentY -= 20f;
            }

            return new Vector2(_currentX, _currentY);
        }

        public void Burst()
        {
            if (_stockObjects.Count <= 0)
            {
                return;
            }

            var stockObject = _stockObjects[0];
            Return(stockObject);
            _stockObjects.Remove(stockObject);
        }

        public void ClearStock()
        {
            _stockObjects.Clear();

            _currentX = _x;
            _currentY = _y;
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