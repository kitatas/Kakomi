using System.Collections.Generic;
using System.Linq;
using Kakomi.InGame.Data.Entity.Interface;
using Kakomi.InGame.Presentation.View;
using UnityEngine;

namespace Kakomi.InGame.Data.Entity
{
    public sealed class LineViewsEntity : ILineViewsEntity
    {
        private readonly List<LineView> _lineViews;

        public LineViewsEntity()
        {
            _lineViews = new List<LineView>();
        }

        public void AddLineView(LineView lineView) => _lineViews.Add(lineView);

        public void ClearLineViews()
        {
            foreach (var line in _lineViews.Where(line => line != null))
            {
                Object.Destroy(line.gameObject);
            }

            _lineViews.Clear();
        }
    }
}