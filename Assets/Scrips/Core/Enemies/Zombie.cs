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

        public bool IsDead => _isDead;

        public event Action OnHit;
        public event Action OnDead;

        [SerializeField] private ZombieData _data;
        private bool _isDead;

        [Inject]
        private void Init (Player player) => SetPlayer(player);

        private void Awake() 
        {
            if (!_data) 
            {
                throw new NullReferenceException("zombie data not seted");
            }

            _health = _data.Health;

            Speed = _data.Speed;
        }


        public override void Hit(int value)
        {
            _health = Mathf.Clamp(_health - value, 0, _data.Health);

            OnHit?.Invoke();
            
            if (_health == 0) 
            {
                OnDead?.Invoke();
                
                gameObject.SetActive(false);
            }
        }
    }
}