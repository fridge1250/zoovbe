namespace ZombieTestProject.SO
{
    using UnityEngine;
    using ZombieTestProject.Core;
    
    [CreateAssetMenu(fileName = "ShootingSettings")]
    public class ShootingSettings : ScriptableObject 
    {
        [SerializeField] private Bullet _bullet;

        public Bullet Bullet => _bullet;
    }
}