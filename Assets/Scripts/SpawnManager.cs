using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefabs;
    private float spawnRange = 9.0f; 
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject powerupPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrefabs, GenerateSpawnPosition(), powerupPrefabs.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefabs, GenerateSpawnPosition(), powerupPrefabs.transform.rotation);
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefabs, GenerateSpawnPosition() , enemyPrefabs.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawPosX = Random.Range(-spawnRange, spawnRange);
        float spawPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3 (spawPosX, 0 , spawPosZ);

        return randomPos;
    }
}
