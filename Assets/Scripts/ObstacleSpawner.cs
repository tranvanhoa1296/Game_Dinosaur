using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform spawnPoint; 
    public float minSpawnInterval = 1.5f;
    public float maxSpawnInterval = 3.5f;
    private float timer = 0f;
    private float spawnInterval;

    void Start()
    {
       
        spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0f;
            
            spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
        }
    }

    void SpawnObstacle()
    {
        
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity);
    }
}
