namespace ZombieTestProject.Core.Collision
{
using UnityEngine;
using ZombieTestProject.Interfaces;
using System;

    [RequireComponent(typeof(Enemy))]
    public class EnemyCollision : MonoBehaviour 
    {
        private IEnemy _enemyComponent;

        private void Start() 
        {
            if (!TryGetComponent(out _enemyComponent))
            {
                throw new NullReferenceException("enemy collision must have component Enemy");
            }
        }
        private void OnTriggerEnter2D(Collider2D other) 
        {
            if (other.TryGetComponent(out IBullet bullet)) 
            {
                _enemyComponent.Hit(bullet.Damage);
            }
        }
    }
}