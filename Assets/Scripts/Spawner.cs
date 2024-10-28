using System;
using System.Collections;
using System.Collections.Generic;
using Features.OrderedEvents;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Vector2Int SpawnRange;
    public GameObject TempPrefab;
    public float SpawnInterval;
    
    public bool ShouldSpawn = true;
    
    private Vector3 RandomSpawnPosition => transform.position + new Vector3(UnityEngine.Random.Range(-SpawnRange.x,SpawnRange.x),UnityEngine.Random.Range(-SpawnRange.y,SpawnRange.y),transform.position.z);

    private void Awake()
    {
        GameEvents.OnRoundStart.AddListener(0,StartSpawn);
        GameEvents.OnRoundComplete.AddListener(0,EndSpawn);
        GameEvents.OnRoundFail.AddListener(0,EndSpawn);
    }

    private void EndSpawn()
    {
        ShouldSpawn = false;
    }

    private void StartSpawn()
    {
        ShouldSpawn = true;
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        var wait = new WaitForSeconds(SpawnInterval);
        while (ShouldSpawn)
        {
            Spawn();
            yield return wait;
        }
    }

    private void Spawn()
    {
        var newObj = Instantiate(TempPrefab,transform);
        newObj.transform.position = RandomSpawnPosition;
    }

    private void OnDestroy()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position,new Vector3(SpawnRange.x*2,SpawnRange.y*2,1));
    }
}
