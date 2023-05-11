namespace ZombieTestProject.Core
{
using UnityEngine;
using Siphoin.Pooling;
using ZombieTestProject.SO;

    public class Shooting : MonoBehaviour
   {
    private PoolMono<Bullet> _pool;

    [SerializeField] private Transform _firePoint;

    [SerializeField] private ShootingSettings _settings;

    [SerializeField] private KeyCode _keyShooting = KeyCode.Mouse0;

    private void Start() 
    {
         Transform containerShooting = new GameObject("ContainerShooting").transform;

         _pool = new PoolMono<Bullet>(_settings.Bullet, containerShooting, 10, true);
    }
    
    private void Update()
    {
        if(Input.GetKeyDown(_keyShooting))
        {
            Shoot();
        }
    }


    private void Shoot()
    {
        Bullet bullet = _pool.GetFreeElement();

        bullet.transform.position = _firePoint.position;

        bullet.transform.rotation = _firePoint.rotation;
    }
}

}