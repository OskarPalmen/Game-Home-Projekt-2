using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCannon : MonoBehaviour
{
    public Transform firePoint;
    public string playerTag = "Player";
    public GameObject projectilePrefab;

    public float fireRate = 1f;
    public float projectileLifetime = 5f;
    public float bulletSpeed = 10f;

    private float fireDelay;
    private float timer;

    public float speed = 3f;
    public float aggroRange = 5f;

    private Transform player;

    private bool isAggroed = false; // Flag to indicate if the player is within aggro range

    private void Start()
    {
        fireDelay = 1f / fireRate;
        timer = fireDelay; // Set the timer to fire immediately on start

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
        timer += Time.deltaTime;

        if (isAggroed && timer >= fireDelay)
        {
            timer = 0f;
            Shoot();
        }

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

                // Rotate the enemy to face the player's direction
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                // Calculate the angle between the enemy's forward vector and the direction towards the player
                float angleDifference = Vector3.SignedAngle(transform.up, direction, Vector3.forward);

                // Adjust the movement based on the angle difference
                if (Mathf.Abs(angleDifference) > 5f)
                {
                    // Rotate the enemy towards the player more accurately
                    transform.Rotate(Vector3.forward, Mathf.Sign(angleDifference) * speed * Time.deltaTime);
                }
                else
                {
                    // Move towards the player
                    //transform.Translate(Vector3.up * speed * Time.deltaTime);
                }

                isAggroed = true; // Set the flag to indicate the player is within aggro range
            }
            else
            {
                isAggroed = false; // Set the flag to indicate the player is outside aggro range
            }
        }
    }

    private void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        rb.velocity = firePoint.up * bulletSpeed;

        // Attach a script to the projectile to handle destruction events
        Projectile projectileScript = projectile.AddComponent<Projectile>();

        Destroy(projectile, projectileLifetime);
    }
}