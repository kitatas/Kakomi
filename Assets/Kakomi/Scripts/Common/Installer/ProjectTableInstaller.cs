using Kakomi.Common.Data.DataStore;
using UnityEngine;
using Zenject;

namespace Kakomi.Common.Installer
{
    [CreateAssetMenu(fileName = "ProjectTableInstaller", menuName = "Installers/ProjectTableInstaller")]
    public sealed class ProjectTableInstaller : ScriptableObjectInstaller<ProjectTableInstaller>
    {
        [SerializeField] private BgmTable bgmTable = default;
        [SerializeField] private SeTable seTable = default;

        public override void InstallBindings()
        {
            Container
                .BindInstance(bgmTable)
                .AsCached();

            Container
                .BindInstance(seTable)
                .AsCached();
        }
    }
}