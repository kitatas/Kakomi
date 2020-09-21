using Kakomi.InGame.Presentation.View;
using UnityEngine;

namespace Kakomi.InGame.Data.DataStore
{
    [CreateAssetMenu(fileName = "EnclosureTable", menuName = "DataTable/EnclosureTable", order = 0)]
    public sealed class EnclosureTable : ScriptableObject
    {
        [SerializeField] private EnclosureCollider enclosureCollider = default;
        [SerializeField] private LineView lineView = default;

        public EnclosureCollider EnclosureCollider => enclosureCollider;
        public LineView LineView => lineView;
    }
}