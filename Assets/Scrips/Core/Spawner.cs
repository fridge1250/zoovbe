using System.Collections;
using Siphoin.Pooling;
using UnityEngine;
using Zenject;
using ZombieTestProject.Extensions;
using System;
using ZombieTestProject.SO;
namespace ZombieTestProject.Core
{
public class Spawner : MonoInstaller
{
    private PoolMono<Enemy> _pool;

    private Enemy _prefab;

    [SerializeField] private SpawnerParams _params;
    
    public override void InstallBindings() 
    {
        if (!_params) 
        {
            throw new NullReferenceException("spawner params not seted");
        }

        if (!_params.Prefab.TryGetComponent(out _prefab)) 
        {
            throw new NullReferenceException($"invalid prefab on {_params.name}");
        }

        Transform container = new GameObject("ZombieContainer").transform;


        Enemy[] enemies = new Enemy[_params.StartCount];
        

        for (int i = 0; i < _params.StartCount; i++)
        {
            enemies[i] = Container.InstantiatePrefabForComponent<Enemy>(_prefab);
        }

        _pool = new PoolMono<Enemy>(_prefab, enemies, container);
    }

    private void Start()
    {

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
            yield return new WaitForSeconds(_params.Time);

            var newPrefab = _pool.GetFreeElement();

            newPrefab.transform.position = Camera.main.GetRandomPosition(50);

            

            
        }

        
    }
}
}
