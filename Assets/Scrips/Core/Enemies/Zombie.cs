namespace ZombieTestProject.Core.Enemies
{
    using UnityEngine;
    using ZombieTestProject.Interfaces;

    public class Zombie : MonoBehaviour, IEnemy
    {
        public void Attack()
        {
            throw new System.NotImplementedException();
        }

        public void Hit(int value)
        {
            throw new System.NotImplementedException();
        }

        public void Move()
        {
            throw new System.NotImplementedException();
        }
    }
}