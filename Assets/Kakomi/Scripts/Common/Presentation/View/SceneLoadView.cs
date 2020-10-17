using Kakomi.Common.Application;
using Kakomi.Common.Presentation.Controller;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Kakomi.Common.Presentation.View
{
    public sealed class SceneLoadView : UIBehaviour
    {
        [SerializeField] private SceneName sceneName = default;

        private SceneLoader _sceneLoader;

        [Inject]
        private void Construct(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        protected override void Start()
        {
            this.OnPointerDownAsObservable()
                .Subscribe(_ => _sceneLoader.LoadScene(sceneName))
                .AddTo(this);
        }
    }
}
