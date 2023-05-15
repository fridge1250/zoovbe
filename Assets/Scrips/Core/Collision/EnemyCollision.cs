namespace ZombieTestProject.Core.Collision
{
using UnityEngine;
using ZombieTestProject.Interfaces;

    [RequireComponent(typeof(Enemy))]
    public class EnemyCollision : MonoBehaviour 
    {
        private void OnTriggerEnter2D(Collider2D other) 
        {
            if (other.TryGetComponent(out IBullet _)) 
            {
                gameObject.SetActive(false);
            }
        }
    }
}