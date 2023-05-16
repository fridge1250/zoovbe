namespace ZombieTestProject.Core.Enemies
{
    using System;
    using UnityEngine;
    using Zenject;
    using ZombieTestProject.Interfaces;
    using ZombieTestProject.SO;

    public class Zombie : Enemy, IEnemy
    {
        private int _health;

        public int Health => _health;

        public event Action OnHit;

        [SerializeField] private ZombieData _data;

        [Inject]
        private void Init (Player player) => SetPlayer(player);

        private void Awake() 
        {
            if (!_data) 
            {
                throw new NullReferenceException("zombie data not seted");
            }

            _health = _data.Health;
        }

        public void Attack()
        {
            throw new System.NotImplementedException();
        }

        public void Hit(int value)
        {
            _health = Mathf.Clamp(_health - value, 0, int.MaxValue);

            OnHit?.Invoke();
        }

        public void Move()
        {
            throw new System.NotImplementedException();
        }
    }
}