using System.Collections.Generic;
using System.Linq;
using Kakomi.InGame.Presentation.View;
using UniRx.Toolkit;

namespace Kakomi.InGame.Factory
{
    public sealed class LineFactory : ObjectPool<LineView>
    {
        private readonly List<LineView> _lineViews;
        private readonly LineView.Factory _lineViewFactory;

        public LineFactory(LineView.Factory lineViewFactory)
        {
            _lineViews = new List<LineView>();
            _lineViewFactory = lineViewFactory;
        }

        protected override LineView CreateInstance()
        {
            return _lineViewFactory.Create();
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
            foreach (var lineView in _lineViews.Where(lineView => lineView != null))
            {
                lineView.SetEnclose();
            }

            _lineViews.Clear();
        }
    }
}