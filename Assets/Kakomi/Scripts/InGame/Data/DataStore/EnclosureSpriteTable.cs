using UnityEngine;

namespace Kakomi.InGame.Data.DataStore
{
    [CreateAssetMenu(fileName = "SpriteTable", menuName = "DataTable/SpriteTable", order = 0)]
    public sealed class EnclosureSpriteTable : ScriptableObject
    {
        [SerializeField] private Sprite bomb = default;
        [SerializeField] private Sprite bullet = default;
        [SerializeField] private Sprite heart = default;

        public Sprite GetBombSprite => bomb;
        public Sprite GetBulletSprite => bullet;
        public Sprite GetHeartSprite => heart;
    }
}