namespace ZombieTestProject.Core.Enemies
{
    using System;
    using UnityEngine;
    using Zenject;
    using ZombieTestProject.Interfaces;
    using ZombieTestProject.SO;

    public class Zombie : Enemy, IEnemy
    {

        [SerializeField] private ZombieData _data;

        [Inject]
        private void Init (Player player) => SetPlayer(player);

        private void Awake() 
        {
            if (!_data) 
            {
                throw new NullReferenceException("zombie data not seted");
            }

            SetData(_data);
        }
    }
}