using System.Collections.Generic;
using Kakomi.InGame.Data.DataStore;
using Kakomi.InGame.Presentation.View;
using UniRx.Toolkit;
using UnityEngine;

namespace Kakomi.InGame.Factory
{
    public sealed class LineFactory : ObjectPool<LineView>
    {
        private readonly List<LineView> _lineViews;
        private readonly LineView _lineView;

        public LineFactory(EnclosureTable enclosureTable)
        {
            _lineViews = new List<LineView>();
            _lineView = enclosureTable.LineView;
        }

        protected override LineView CreateInstance()
        {
            return Object.Instantiate(_lineView);
        }

        public void GenerateLineView()
        {
            var lineView = Rent();
            lineView.DrawLine(() =>
            {
                Return(lineView);
            });
            _lineViews.Add(lineView);
        }

        public void ClearLineViews()
        {
            foreach (var lineView in _lineViews)
            {
                if (lineView == null || lineView.IsEnclose)
                {
                    continue;
                }

                lineView.SetEnclose();
            }

            _lineViews.Clear();
        }
    }
}