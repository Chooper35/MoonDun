using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Player playerH;
    public Transform[] SpawnPoints;
    public GameObject EnemyPrefab;
    public float spawnTime = 3f;
    public float spawnRepeatTime = 5f;

    public void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnRepeatTime);
    }
    public void Update()
    {
             
    }
    void Spawn()
    {
        if(playerH.playerHealth<=0f)
        {
            return;
        }
        int spawnPointIndex = Random.Range(0, SpawnPoints.Length);
        Instantiate(EnemyPrefab, SpawnPoints[spawnPointIndex].position, SpawnPoints[spawnPointIndex].rotation);
    }
}
