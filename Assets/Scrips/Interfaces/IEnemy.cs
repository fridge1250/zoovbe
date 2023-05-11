namespace ZombieTestProject.Interfaces
{
    public interface IEnemy : IHitObject
    {
         void Move();
         void Attack();
    }
}