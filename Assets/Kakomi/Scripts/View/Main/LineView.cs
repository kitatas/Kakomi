using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Kakomi.Scripts.View.Main
{
    public sealed class LineView : MonoBehaviour
    {
        [SerializeField] private LineRendererView lineRendererView = default;

        private List<LineRendererView> _lineViews;

        private void Awake()
        {
            _lineViews = new List<LineRendererView>();
        }

        public void DrawLine()
        {
            var line = Instantiate(lineRendererView, transform);
            line.DrawLine();
            _lineViews.Add(line);
        }

        public void DeleteLine()
        {
            foreach (var line in _lineViews.Where(line => line != null))
            {
                Destroy(line.gameObject);
            }

            _lineViews.Clear();
        }
    }
}