using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSpawn: MonoBehaviour
{
    public Transform[] LifeSpawnPoints;
    public GameObject LifePrefab;


    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        int SpawnPointIndex = Random.Range(0, LifeSpawnPoints.Length);
        Instantiate(LifePrefab, LifeSpawnPoints[SpawnPointIndex].position, LifeSpawnPoints[SpawnPointIndex].rotation);
    }

}
