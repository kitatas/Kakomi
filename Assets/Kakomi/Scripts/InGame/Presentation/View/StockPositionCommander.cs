using System;
using Kakomi.InGame.Application;
using UnityEngine;

namespace Kakomi.InGame.Presentation.View
{
    public sealed class StockPositionCommander : MonoBehaviour
    {
        [SerializeField] private RectTransform player = default;
        [SerializeField] private RectTransform enemy = default;

        private readonly float _x = -367.5f;
        private readonly float _y = -600f;
        private float _currentX;
        private float _currentY;

        public void ResetStockPosition()
        {
            _currentX = _x;
            _currentY = _y;
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

        public Vector2 GetAttackPosition(EnclosureObjectType enclosureObjectType)
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
    }
}