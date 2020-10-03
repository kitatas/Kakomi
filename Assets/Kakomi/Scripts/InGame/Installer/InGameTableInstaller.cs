using UnityEngine;
using Zenject;

namespace Kakomi.InGame.Installer
{
    [CreateAssetMenu(fileName = "InGameTableInstaller", menuName = "Installers/InGameTableInstaller")]
    public sealed class InGameTableInstaller : ScriptableObjectInstaller<InGameTableInstaller>
    {
        public override void InstallBindings()
        {
        }
    }
}