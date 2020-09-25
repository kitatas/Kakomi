using System.Collections.Generic;
using System.Linq;
using Kakomi.InGame.Data.DataStore;
using Kakomi.InGame.Presentation.View;
using UnityEngine;

namespace Kakomi.InGame.Domain.Repository
{
    public sealed class LineRepository
    {
        private readonly List<LineView> _lineViews;
        private readonly LineView _lineView;

        public LineRepository(EnclosureTable enclosureTable)
        {
            _lineViews = new List<LineView>();
            _lineView = enclosureTable.LineView;
        }

        public void GenerateLineView()
        {
            var lineView = Object.Instantiate(_lineView);
            _lineViews.Add(lineView);
        }

        public void ClearLineViews()
        {
            foreach (var lineView in _lineViews.Where(lineView => lineView != null))
            {
                Object.Destroy(lineView.gameObject);
            }

            _lineViews.Clear();
        }
    }
}