namespace ZombieTestProject.Interfaces
{
using UnityEngine;
    public interface IBullet
    {
        void Activate();

        void SetRotation(Quaternion quaternion);

        void SetPosition(Vector3 position);
    }
}