using Kakomi.InGame.Data.DataStore;
using UnityEngine;
using Zenject;

namespace Kakomi.InGame.Installer
{
    [CreateAssetMenu(fileName = "InGameTableInstaller", menuName = "Installers/InGameTableInstaller")]
    public sealed class InGameTableInstaller : ScriptableObjectInstaller<InGameTableInstaller>
    {
        [SerializeField] private EnclosureTable enclosureTable = default;

        public override void InstallBindings()
        {
            Container
                .BindInstance(enclosureTable)
                .AsCached();
        }
    }
}