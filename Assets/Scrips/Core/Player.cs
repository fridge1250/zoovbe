namespace ZombieTestProject.Core
{
    using System;
    using UnityEngine;
using ZombieTestProject.Interfaces;

    public class Player : MonoBehaviour, IHitObject
    {
        public int Health => 3;

        public event Action OnHit;

        public void Hit(int value)
        {
            OnHit?.Invoke();
        }
    }
}