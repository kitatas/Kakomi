using Kakomi.InGame.Data.DataStore;
using UnityEngine;
using Zenject;

namespace Kakomi.InGame.Installer
{
    [CreateAssetMenu(fileName = "InGameTableInstaller", menuName = "Installers/InGameTableInstaller")]
    public sealed class InGameTableInstaller : ScriptableObjectInstaller<InGameTableInstaller>
    {
        [SerializeField] private EnclosureSpriteTable enclosureSpriteTable = default;
        [SerializeField] private StageDataTable stageDataTable = default;

        public override void InstallBindings()
        {
            Container
                .Bind<EnclosureSpriteTable>()
                .FromInstance(enclosureSpriteTable)
                .AsCached();

            Container
                .Bind<StageDataTable>()
                .FromInstance(stageDataTable)
                .AsCached();
        }
    }
}