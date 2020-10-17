using Kakomi.Common.Application;
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

        public void LoadScene(SceneName sceneName)
        {
            _zenjectSceneLoader.LoadScene(sceneName.ToString());
        }
    }
}
