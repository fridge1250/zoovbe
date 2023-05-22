namespace ZombieTestProject.Core
{
using System;
using UnityEngine;
using ZombieTestProject.Interfaces;
using ZombieTestProject.SO;

    public class Player : MonoBehaviour, IPlayer
    {
        [SerializeField] private PlayerData _startStats;
        [SerializeField, Min(0)] private int _currentHealth;

        private bool _isDead;

        public int Health => _currentHealth;

        public bool IsDead => _isDead;

        public PlayerData Data => _startStats;

        public event Action OnHit;
        public event Action OnDead;

        private void Awake() 
        {
            if (!_startStats) 
            {
                throw new NullReferenceException("start stats not seted");
            }

            _currentHealth = _startStats.Health;
        }

        public void Hit(int value)
        {
            _currentHealth = Mathf.Clamp(_currentHealth - value, 0, _startStats.Health);

            OnHit?.Invoke();

            if (_currentHealth == 0)
            {
                OnDead?.Invoke();

                _isDead = true;

                gameObject.SetActive(false);
            }
        }
    }
}