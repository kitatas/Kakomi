using Kakomi.InGame.Presentation.View;
using UnityEngine;

namespace Kakomi.InGame.Data.DataStore
{
    [CreateAssetMenu(fileName = "LineTable", menuName = "DataTable/LineTable", order = 0)]
    public sealed class LineTable : ScriptableObject
    {
        [SerializeField] private EnclosureCollider enclosureCollider = default;
        [SerializeField] private LineView lineView = default;

        public EnclosureCollider EnclosureCollider => enclosureCollider;
        public LineView LineView => lineView;
    }
}