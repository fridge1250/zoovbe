using ZombieTestProject.SO;

namespace ZombieTestProject.Interfaces
{
    public interface IPlayer : IHitObject
    {
        PlayerData Data { get; }
    }
}