namespace ZombieTestProject.Core
{
using UnityEngine;
using System;
using ZombieTestProject.Interfaces;
using ZombieTestProject.SO;
    using ZombieTestProject.Exceptions;

    public abstract class Enemy : MonoBehaviour, IEnemy, IReceiverData<EnemyData>
    {
        private Vector2 _movement;
        private Player _player;
        private Rigidbody2D _rigidbody;
        private EnemyData _currentData;
        private float _speed = 5f;

        private int _health;
        private bool _isDead;

        public event Action OnHit;
        public event Action OnDead;

        public int Health => _health;

        public bool IsDead => _isDead;

        public float Speed => _speed;

        protected void SetPlayer(Player player) => _player = player;

    private void Start()
    {
        if (!TryGetComponent(out _rigidbody)) 
        {
            throw new NullReferenceException("enemy must have component Rigidbody2D");
        }

        
    }
    private void FixedUpdate()
    {
        
        if (_player && Vector2.Distance(_player.transform.position, transform.position) > 1f) 
        {
            if (_player.IsDead)
            {
                return;
            }

            Vector2 playerPosition = _player.transform.position;

            Vector3 direction = _player.transform.position - transform.position;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            direction.Normalize();

            _movement = direction;

            Move(_movement);

            _rigidbody.rotation = angle;
        }
    }
    private void Move(Vector2 direction)
    {
        _rigidbody.MovePosition((Vector2)transform.position + (direction * _speed * Time.deltaTime));

    }

    public void SetData (EnemyData data) 
    {
        if (data is null)
        {
            throw new ArgumentNullException("data enemy SO is null");
        }

        if (_currentData != null)
        {
            throw new GameLogicException("enemy data before seted");
        }

        _currentData = data;

        _health = data.Health;

        _speed = data.Speed;


    }

        public void Hit(int value)
        {
            _health = Mathf.Clamp(Health - value, 0, _currentData.Health);

            OnHit?.Invoke();
            
            if (_health == 0) 
            {
                OnDead?.Invoke();
                
                gameObject.SetActive(false);
            }
        }
    }

}
