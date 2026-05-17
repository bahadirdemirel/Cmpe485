using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public int objectCount = 100; // Parametre: 100, 1000, 5000, 10000 
    public float spawnRange = 50f;

    void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPos = new Vector3(
                Random.Range(-spawnRange, spawnRange),
                Random.Range(-spawnRange, spawnRange),
                Random.Range(-spawnRange, spawnRange)
            );
            Instantiate(prefabToSpawn, randomPos, Quaternion.identity);
        }
    }
}