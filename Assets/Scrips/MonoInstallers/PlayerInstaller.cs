namespace ZombieTestProject.MonoInstallers
{
using UnityEngine;
using Zenject;
using ZombieTestProject.Core;
    
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private Player _playerPrefab;
        [SerializeField] private Transform _startPoint;
        public override void InstallBindings()
        {
            var player = Container.InstantiatePrefabForComponent<Player>(_playerPrefab, _startPoint);

            Container.Bind<Player>().FromComponentOn(player.gameObject).AsSingle();
        }
    }
}