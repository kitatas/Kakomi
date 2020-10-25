using Kakomi.InGame.Presentation.View;
using UnityEngine;

namespace Kakomi.InGame.Data.DataStore
{
    [CreateAssetMenu(fileName = "EnclosureTable", menuName = "DataTable/EnclosureTable", order = 0)]
    public sealed class EnclosureObjectTable : ScriptableObject
    {
        [SerializeField] private BombView bombView = default;
        [SerializeField] private HeartView heartView = default;
        [SerializeField] private BulletView bulletView = default;
        [SerializeField] private EncloseEffectView encloseEffectView = default;
        [SerializeField] private StockObject stockObject = default;

        public BombView BombView => bombView;
        public HeartView HeartView => heartView;
        public BulletView BulletView => bulletView;
        public EncloseEffectView EncloseEffectView => encloseEffectView;
        public StockObject StockObject => stockObject;
    }
}