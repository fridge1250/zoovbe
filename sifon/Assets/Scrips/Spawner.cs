using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform SpawnPos;
    [SerializeField] private GameObject Enemy;
    void Start()
    {
        StartCoroutine(SpawnCD());
    }
    void Reaped()
    {
        StartCoroutine(SpawnCD());
    }
    IEnumerator SpawnCD()
    {
        yield return new WaitForSeconds(10f);
        Instantiate(Enemy, SpawnPos.position, Quaternion.identity);
        Reaped();
    }
}
