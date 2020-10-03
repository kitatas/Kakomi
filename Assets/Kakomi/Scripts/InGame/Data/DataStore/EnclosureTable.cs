using Kakomi.InGame.Presentation.View;
using UnityEngine;

namespace Kakomi.InGame.Data.DataStore
{
    [CreateAssetMenu(fileName = "EnclosureTable", menuName = "DataTable/EnclosureTable", order = 0)]
    public sealed class EnclosureTable : ScriptableObject
    {
        [SerializeField] private BombView bombView = default;
        [SerializeField] private HeartView heartView = default;
        [SerializeField] private BulletView bulletView = default;

        public BombView BombView => bombView;
        public HeartView HeartView => heartView;
        public BulletView BulletView => bulletView;
    }
}