namespace ZombieTestProject.SO
{
using UnityEngine;
    
    [CreateAssetMenu(fileName = "SpawnerParams")]
    public class SpawnerParams : ScriptableObject 
    {
        [SerializeField] private GameObject _prefab;

        [SerializeField, Min(1)] private int _startCount = 1;

        [SerializeField, Min(0.1f)] private float _time = 0.1f;

        [SerializeField, Min(0.01f)] private float _offset = 0.01f;

        public GameObject Prefab => _prefab;

        public int StartCount => _startCount;
        public float Time => _time;
        public float Offset => _offset;
    }
}