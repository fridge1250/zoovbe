namespace ZombieTestProject.Core.Collision
{
using UnityEngine;
using ZombieTestProject.Interfaces;

    [RequireComponent(typeof(Bullet))]
    public class BulletCollision : MonoBehaviour 
    {
        private void OnTriggerEnter2D(Collider2D other) 
        {
            if (other.TryGetComponent(out IEnemy _)) 
            {
                gameObject.SetActive(false);
            }
        }
    }
}