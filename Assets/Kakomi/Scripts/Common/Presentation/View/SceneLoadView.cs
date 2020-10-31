using Kakomi.Common.Application;
using Kakomi.Common.Presentation.Controller;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Kakomi.Common.Presentation.View
{
    [RequireComponent(typeof(Button))]
    public sealed class SceneLoadView : MonoBehaviour
    {
        [SerializeField] private SceneName sceneName = default;

        private SceneLoader _sceneLoader;

        [Inject]
        private void Construct(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        private void Start()
        {
            GetComponent<Button>()
                .OnClickAsObservable()
                .Subscribe(_ => _sceneLoader.LoadScene(sceneName))
                .AddTo(this);
        }
    }
}