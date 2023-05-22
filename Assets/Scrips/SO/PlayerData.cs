namespace ZombieTestProject.SO
{
using UnityEngine;
    
    [CreateAssetMenu(fileName = "PlayerData")]
    public class PlayerData : ScriptableObject 
    {
        [SerializeField, Min(1)] private int _health = 1;

        [SerializeField, Min(0.1f)] private float _speed = 0.1f;

        public int Health => _health;
        public float Speed => _speed;
    }
}