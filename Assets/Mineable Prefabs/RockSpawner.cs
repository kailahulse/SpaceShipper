using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject[] rockPrefabs; // Array of different rock prefabs
    public int numberOfRocksToSpawn = 5; // Number of rocks to spawn

    [Header("Spawn Position Range")]
    public float minX;// = -10f;
    public float maxX;// = 10f;
    public float minY;// = 0f;
    public float maxY;// = 1f;
    public float minZ;// = -10f;
    public float maxZ;// = 10f;

    public void Init(float minX,float maxX, float minY, float maxY, float minZ, float maxZ){
        this.minX = minX;
        this.maxX = maxX;
        this.minY = minY;
        this.maxY = maxY;
        this.minZ = minZ;
        this.maxZ = maxZ;
    }

    public void SpawnRocks(int numRocks)
    {
        if (rockPrefabs.Length == 0)
        {
            Debug.LogError("No rock prefabs assigned to the RockSpawner!");
            return;
        }

        for (int i = 0; i < numRocks; i++)
        {
            int randomRockIndex = Random.Range(0, rockPrefabs.Length);

            float spawnPointX = Random.Range(minX, maxX);
            float spawnPointY = Random.Range(minY, maxY);
            float spawnPointZ = Random.Range(minZ, maxZ);

            Vector3 spawnPosition = new Vector3(spawnPointX, spawnPointY, spawnPointZ);

            GameObject rockToSpawn = rockPrefabs[randomRockIndex];

            Instantiate(rockToSpawn, spawnPosition, Quaternion.identity, gameObject.transform);
        }
    }

    public void WipeRocks()
    {
    foreach (Transform child in transform) {
        Destroy(child.gameObject);
    }
    }


}
