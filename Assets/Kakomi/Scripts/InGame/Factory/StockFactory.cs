using Kakomi.InGame.Presentation.View;
using UniRx.Toolkit;
using UnityEngine;

namespace Kakomi.InGame.Factory
{
    public sealed class StockFactory : ObjectPool<StockObject>
    {
        private readonly Camera _uiCamera;
        private readonly Canvas _uiCanvas;
        private readonly RectTransform _uiTransform;
        private readonly StockObject.Factory _stockObjectFactory;

        public StockFactory(Camera uiCamera, Canvas uiCanvas, RectTransform uiTransform,
            StockObject.Factory stockObjectFactory)
        {
            _uiCamera = uiCamera;
            _uiCanvas = uiCanvas;
            _uiTransform = uiTransform;
            _stockObjectFactory = stockObjectFactory;
        }

        protected override StockObject CreateInstance()
        {
            var stockObject = _stockObjectFactory.Create();
            stockObject.Initialize(_uiCamera, _uiCanvas, _uiTransform);
            return stockObject;
        }

        public StockObject Stock()
        {
            return Rent();
        }
    }
}