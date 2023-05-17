namespace ZombieTestProject.Interfaces
{
using System;
    public interface IHitObject
    {
        int Health { get; }
        event Action OnHit;
        void Hit(int value);
    }
}