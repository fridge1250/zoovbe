namespace ZombieTestProject.Core
{
using UnityEngine;
using System;
using ZombieTestProject.Interfaces;

    public abstract class Enemy : MonoBehaviour, IEnemy
    {
    [SerializeField] private Player _player;
    private Rigidbody2D _rigidbody;
    [SerializeField] private Vector2 _movement;
    [SerializeField, Min(0.1f)] private float _speed = 5f;

        private int _health;
        private bool _isDead;

        public event Action OnHit;
        public event Action OnDead;

        public int Health => _health;

        public bool IsDead => _isDead;

        public float Speed { get => _speed; protected set => _speed = value; }

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

        public virtual void Hit(int value)
        {
            OnHit?.Invoke();
            
            if (_health == 0) 
            {
                gameObject.SetActive(false);
            }
        }
    }

}
