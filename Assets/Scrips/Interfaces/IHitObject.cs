namespace ZombieTestProject.Interfaces
{
    public interface IHitObject
    {
        int Health { get; }
        void Hit(int value);
    }
}