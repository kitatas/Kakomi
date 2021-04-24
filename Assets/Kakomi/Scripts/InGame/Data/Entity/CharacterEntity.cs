using Kakomi.InGame.Data.Entity.Interface;
using UnityEngine;

namespace Kakomi.InGame.Data.Entity
{
    public sealed class CharacterEntity : ICharacterEntity
    {
        private int _hp;
        private int _maxHp;
        private int _attack;

        public CharacterEntity(int hp, int attack)
        {
            _hp = hp;
            _maxHp = hp;
            _attack = attack;
        }

        public int GetHp() => _hp;

        public int GetAttack() => _attack;

        private void SetHp(int value) => _hp = value;

        public void AddHp(int addValue)
        {
            var nextHp = GetHp() + addValue;
            var clampHp = Mathf.Clamp(nextHp, 0, _maxHp);
            SetHp(clampHp);
        }
    }
}