using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheSummoner : MonoBehaviour
{
    public GameObject[] summonPrefabs; // Array of prefabs to summon
    public int summonCount = 5;  // Number of prefabs to summon
    public float summonRadius = 5f;  // Radius around the summoner to spawn prefabs
    public float aggroRange = 10f;  // Distance at which the summoner starts summoning enemies
    public Transform player;  // Reference to the player's transform

    private bool isAggro = false;  // Flag to track if the summoner is in aggro mode
    private List<GameObject> spawnedPrefabs = new List<GameObject>();  // List of spawned prefabs

    private void Start()
    {
        // Find the player if not assigned
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void Update()
    {
        // Check if the player is within the aggro range
        if (!isAggro && Vector2.Distance(transform.position, player.position) <= aggroRange)
        {
            isAggro = true;
            SummonPrefabs(summonCount - spawnedPrefabs.Count);
        }
        else if (isAggro && Vector2.Distance(transform.position, player.position) > aggroRange)
        {
            isAggro = false;
        }

        // Check if any prefab was destroyed
        for (int i = spawnedPrefabs.Count - 1; i >= 0; i--)
        {
            if (spawnedPrefabs[i] == null)
            {
                spawnedPrefabs.RemoveAt(i);
                if (isAggro)
                {
                    SummonPrefabs(1);
                }
            }
        }
    }

    private void SummonPrefabs(int count)
    {
        for (int i = 0; i < count; i++)
        {
            // Calculate a random position within the summon radius
            Vector2 randomPosition = (Vector2)transform.position + Random.insideUnitCircle * summonRadius;

            // Randomly select a prefab from the array
            GameObject randomPrefab = summonPrefabs[Random.Range(0, summonPrefabs.Length)];

            // Spawn the prefab at the random position
            GameObject spawnedPrefab = Instantiate(randomPrefab, randomPosition, Quaternion.identity);
            spawnedPrefabs.Add(spawnedPrefab);
        }
    }
}