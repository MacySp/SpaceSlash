using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private GameObject[] EnemyPrefabs;
    //[SerializeField] private GameObject E1_Asteroid;
    //[SerializeField] private GameObject E2_Ship;
    //[SerializeField] private GameObject E3_Ship;
    [SerializeField] private float spawnRangeX = 26;
    [SerializeField] private float spawnPosZ = 20;
    private float E1StartDelay = 2f;
    //private float E2StartDelay = 20f;
    //private float E3StartDelay = 50f;
    public float MinInterval = 10f;
    public float MaxInterval = 20f;
    public bool IsActive = true;
    public int EnemyMaxIndex = 0;


    void Start()
    {
        //float randomInterval = UnityEngine.Random.Range(MinInterval, MaxInterval);

        Invoke(nameof(SpawnRandomEnemy),E1StartDelay);
        //InvokeRepeating(nameof(Spawn1Enemy),E1StartDelay,3f);
       // InvokeRepeating(nameof(Spawn2Enemy), E2StartDelay, 5f);
        //InvokeRepeating(nameof(Spawn3Enemy), E3StartDelay,10f);

    }

    void SpawnRandomEnemy()
    {
        if (IsActive)

        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

            int enemyIndex = Random.Range(0, EnemyMaxIndex);
            float randomInterval = UnityEngine.Random.Range(MinInterval, MaxInterval);

            //Spawn from array
            Instantiate(EnemyPrefabs[enemyIndex], spawnPos, EnemyPrefabs[enemyIndex].transform.rotation);

            Invoke(nameof(SpawnRandomEnemy), randomInterval);
        }
    }

    /*void Spawn1Enemy()
    {
        if (IsActive)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            Instantiate(E1_Asteroid, spawnPos, E1_Asteroid.transform.rotation);
            Invoke(nameof(Spawn1Enemy), E1StartDelay);
        }
        }

    void Spawn2Enemy()
    {
        if (IsActive)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            Instantiate(E2_Ship, spawnPos, E2_Ship.transform.rotation);
        }
    }

    void Spawn3Enemy()
    {
        if (IsActive)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            Instantiate(E3_Ship, spawnPos, E3_Ship.transform.rotation);
        }
    }
    */
    //Difficulty changer
    public void ChangeSpawnRate(float changeSpawnRate)
    {
        MaxInterval -= changeSpawnRate;
    }
}
