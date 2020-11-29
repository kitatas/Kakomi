using Kakomi.Common.Application;
using UnityEngine.SceneManagement;
using Zenject;

namespace Kakomi.Common.Presentation.Controller
{
    public sealed class SceneLoader
    {
        private ZenjectSceneLoader _zenjectSceneLoader;

        [Inject]
        private void Construct(ZenjectSceneLoader zenjectSceneLoader)
        {
            _zenjectSceneLoader = zenjectSceneLoader;
        }

        public void LoadScene(SceneName sceneName, int level = 0)
        {
            _zenjectSceneLoader.LoadScene(sceneName.ToString(), LoadSceneMode.Single, container =>
            {
                container.BindInstance(level);
            });
        }
    }
}