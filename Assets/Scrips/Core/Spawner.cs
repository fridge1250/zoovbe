using System.Collections;
using Siphoin.Pooling;
using UnityEngine;
using ZombieTestProject.Extensions;
namespace ZombieTestProject.Core
{
public class Spawner : MonoBehaviour
{
    private PoolMono<Enemy> _pool;

    [SerializeField] private Enemy _prefab;

    [SerializeField, Min(0.5f)] private float _time = 0.5f;

    [SerializeField, Min(0.01f)] private float _offset = 0.01f;


    void Start()
    {
        Transform container = new GameObject("ZombieContainer").transform;

        _pool = new PoolMono<Enemy>(_prefab, container, 30, true);

        

        ActivateSpawn();
    }

    private void OnDisable() 
    {
        StopAllCoroutines();
    }

    private void OnEnable() 
    {
        ActivateSpawn();
    }

    private void ActivateSpawn () 
    {
        StopAllCoroutines();

        StartCoroutine(Spawn());
    }

    
    private IEnumerator Spawn()
    {

        while (true)
        {
            yield return new WaitForSeconds(_time);

            var newPrefab = _pool.GetFreeElement();

            newPrefab.transform.position = Camera.main.GetRandomPosition(20);

            
        }

        
    }
}
}
