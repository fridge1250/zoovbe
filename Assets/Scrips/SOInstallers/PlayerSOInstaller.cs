namespace ZombieTestProject.SOInstallers
{
using UnityEngine;
using Zenject;
    using ZombieTestProject.SO;

    public class PlayerSOInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerData>().FromScriptableObjectResource("PlayerData").AsSingle().NonLazy();
        }
    }
}