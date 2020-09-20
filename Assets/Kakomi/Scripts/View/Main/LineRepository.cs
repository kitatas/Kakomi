using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Kakomi.Scripts.View.Main
{
    public sealed class LineRepository : MonoBehaviour
    {
        [SerializeField] private LineView lineView = default;

        private List<LineView> _lineViews;

        private void Awake()
        {
            _lineViews = new List<LineView>();
        }

        public void CreateLine()
        {
            var line = Instantiate(lineView, transform);
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