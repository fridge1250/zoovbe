namespace ZombieTestProject.SO
{
using UnityEngine;
    
    public abstract class EnemyData : ScriptableObject 
    {
        [SerializeField, Min(1)] private int _health = 1;

        [SerializeField, Min(0.1f)] private float _speed = 0.1f;

        [SerializeField, Min(0.01f)] private float _distanceAttack = 0.1f;

        public int Health => _health;
        public float Speed => _speed;
        public float DistanceAttack => _distanceAttack;
    }
}