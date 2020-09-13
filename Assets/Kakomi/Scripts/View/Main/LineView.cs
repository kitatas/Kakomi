using Kakomi.Scripts.Utility;
using UnityEngine;

namespace Kakomi.Scripts.View.Main
{
    [RequireComponent(typeof(LineRenderer))]
    public sealed class LineView : MonoBehaviour
    {
        private LineRenderer _lineRenderer;

        private void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();
            _lineRenderer.SetWidth(0.1f);
        }

        public void DrawLine(Vector3 cursorPosition)
        {
            _lineRenderer.positionCount++;
            _lineRenderer.SetPosition(
                _lineRenderer.positionCount - 1,
                cursorPosition);
        }

        public void ResetLine()
        {
            // TODO : 最後の位置だけ消さないようにする
            _lineRenderer.positionCount = 0;
        }
    }
}