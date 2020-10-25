using System;
using System.Collections.Generic;
using Kakomi.InGame.Application;
using Kakomi.InGame.Factory;
using UnityEngine;
using Zenject;

namespace Kakomi.InGame.Presentation.View
{
    public sealed class StockObjectContainer : MonoBehaviour
    {
        [SerializeField] private RectTransform player = default;
        [SerializeField] private RectTransform enemy = default;

        private readonly List<StockObject> _stockObjects = new List<StockObject>();

        private readonly float _x = -367.5f;
        private readonly float _y = -600f;
        private float _currentX;
        private float _currentY;

        private AttackEffectFactory _attackEffectFactory;
        
        [Inject]
        private void Construct(AttackEffectFactory attackEffectFactory)
        {
            _attackEffectFactory = attackEffectFactory;
            
            ClearStock();
        }

        public void ClearStock()
        {
            _stockObjects.Clear();

            _currentX = _x;
            _currentY = _y;
        }

        public void Add(StockObject stockObject)
        {
            _stockObjects.Add(stockObject);
        }

        public void Remove(EnclosureObjectType enclosureObjectType, Action<StockObject> action)
        {
            var stockObject = _stockObjects[0];
            _stockObjects.Remove(stockObject);
            var position = GetAttackPosition(enclosureObjectType);
            stockObject.TweenAttackPosition(position, stock =>
            {
                _attackEffectFactory.Activate(position, Color.red);
                action(stock);
            });
        }

        private Vector2 GetAttackPosition(EnclosureObjectType enclosureObjectType)
        {
            switch (enclosureObjectType)
            {
                case EnclosureObjectType.None:
                    break;
                case EnclosureObjectType.Bullet:
                    return enemy.position;
                case EnclosureObjectType.Bomb:
                case EnclosureObjectType.Heart:
                    return player.position;
                default:
                    throw new ArgumentOutOfRangeException(nameof(enclosureObjectType), enclosureObjectType, null);
            }

            return Vector2.zero;
        }

        public bool IsStock()
        {
            return _stockObjects.Count > 0;
        }

        public Vector2 GetStockPosition()
        {
            _currentX += 15f;
            if (_currentX >= -_x)
            {
                _currentX = _x + 15f;
                _currentY -= 20f;
            }

            return new Vector2(_currentX, _currentY);
        }
    }
}