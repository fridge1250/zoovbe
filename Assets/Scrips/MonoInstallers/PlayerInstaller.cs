namespace ZombieTestProject.MonoInstallers
{
using UnityEngine;
using Zenject;
using ZombieTestProject.Core;
    
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private Player _player;
        public override void InstallBindings()
        {        
            Container.Bind<Player>().FromComponentOn(_player.gameObject).AsSingle();

            Debug.Log(3232);
        }
    }
}