using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlesBallGenerator : MonoBehaviour
{
    public GameObject[] Spawnables;
    public Vector2 BottomLeft, TopRight;
    public int SpawnablesCount;
    public float SpawnInterval; // The time interval between adding new spawnables
    public int SpawnAmount; // Number of spawnables to spawn after each interval
    public bool IsSpawning; // Flag to control spawning

    // Start is called before the first frame update
    void Start()
    {
        SpawnInitialObjects();
        StartCoroutine(SpawnObjectsWithDelay());
    }

    // Spawns the initial set of objects
    void SpawnInitialObjects()
    {
        for (int i = 0; i < SpawnablesCount; i++)
        {
            int spawnablesArrayIndex = Random.Range(0, Spawnables.Length);
            Vector2 pos = new Vector2(Random.Range(BottomLeft.x, TopRight.x), Random.Range(BottomLeft.y, TopRight.y));
            GameObject g = Instantiate(Spawnables[spawnablesArrayIndex], pos, Quaternion.identity);
            g.transform.parent = transform;
        }
    }

    // Coroutine to spawn objects with a delay
    IEnumerator SpawnObjectsWithDelay()
    {
        IsSpawning = true;
        while (IsSpawning)
        {
            yield return new WaitForSeconds(SpawnInterval);

            for (int i = 0; i < SpawnAmount; i++)
            {
                int spawnablesArrayIndex = Random.Range(0, Spawnables.Length);
                Vector2 pos = new Vector2(Random.Range(BottomLeft.x, TopRight.x), Random.Range(BottomLeft.y, TopRight.y));
                GameObject g = Instantiate(Spawnables[spawnablesArrayIndex], pos, Quaternion.identity);
                g.transform.parent = transform;
            }
        }
    }

    // Stops spawning objects
    public void StopSpawning()
    {
        IsSpawning = false;
    }

    // Set the number of spawnables to spawn after each interval
    public void SetSpawnAmount(int amount)
    {
        SpawnAmount = amount;
    }
}
