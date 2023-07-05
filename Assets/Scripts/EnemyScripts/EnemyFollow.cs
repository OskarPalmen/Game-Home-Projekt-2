using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public string playerTag = "Player";
    public float speed = 3f;
    public float aggroRange = 5f;

    private Transform player;

    private void Start()
    {
        // Find the player object using the player tag
        GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);

        if (playerObject != null)
        {
            // Get the player's transform component
            player = playerObject.transform;
        }
        else
        {
            Debug.LogWarning("Player object not found with tag: " + playerTag);
        }
    }

    private void Update()
    {
        if (player != null)
        {
            // Calculate the distance to the player
            float distance = Vector3.Distance(transform.position, player.position);

            // Check if the player is within aggro range
            if (distance <= aggroRange)
            {
                // Calculate the direction towards the player
                Vector3 direction = player.position - transform.position;
                direction.Normalize();

                // Move towards the player
                transform.Translate(direction * speed * Time.deltaTime);
            }
        }
    }
}