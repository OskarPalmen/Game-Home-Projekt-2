using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheSummoner : MonoBehaviour
{
    public GameObject[] summonPrefabs;  // Array of prefabs to summon
    public int summonCount = 5;  // Number of prefabs to summon
    public float summonRadius = 5f;  // Radius around the summoner to spawn prefabs
    public float aggroRange = 10f;  // Distance at which the summoner starts summoning enemies
    public Transform player;  // Reference to the player's transform

    private bool isAggro = false;  // Flag to track if the summoner is in aggro mode

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
            SummonPrefabs();
        }
    }

    private void SummonPrefabs()
    {
        for (int i = 0; i < summonCount; i++)
        {
            // Calculate a random position within the summon radius
            Vector2 randomPosition = (Vector2)transform.position + Random.insideUnitCircle * summonRadius;

            // Randomly select a prefab from the array
            GameObject randomPrefab = summonPrefabs[Random.Range(0, summonPrefabs.Length)];

            // Spawn the prefab at the random position
            Instantiate(randomPrefab, randomPosition, Quaternion.identity);
        }
    }
}