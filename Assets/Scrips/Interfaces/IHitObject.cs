namespace ZombieTestProject.Interfaces
{
using System;
    public interface IHitObject
    {
        int Health { get; }
        bool IsDead { get; }
        event Action OnHit;
        event Action OnDead;
        void Hit(int value);
    }
}