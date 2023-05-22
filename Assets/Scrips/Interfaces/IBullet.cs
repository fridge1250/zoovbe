namespace ZombieTestProject.Interfaces
{
using UnityEngine;
    public interface IBullet
    {
        float Force { get; }
        int Damage { get; }
        
        void Activate();

        void SetRotation(Quaternion quaternion);

        void SetPosition(Vector3 position);
    }
}