using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public GameObject player;
    public float aggroRange;
    public float movementAggroRange;
    public float movementSpeed;

    public GameObject bulletPrefab;
    public float bulletSpeed;
    public float bulletSpreadAngle;
    public Transform bulletSpawnPoint;
    public float burstCooldown;
    private bool canShoot = true;
    public int bulletCount;

    public float recoilForce;
    private Rigidbody2D enemyRigidbody;
    private bool recoilActive = false;

    private void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    public void FireBullets()
    {
        // Check if the enemy can shoot
        if (!canShoot)
        {
            return;
        }

        // Calculate the angle between each bullet
        float angleIncrement = bulletSpreadAngle / (bulletCount - 1);

        // Get the rotation of the bullet spawn point
        Quaternion bulletSpawnRotation = bulletSpawnPoint.rotation;

        // Instantiate bullets with different directions
        for (int i = 0; i < bulletCount; i++)
        {
            // Calculate the direction of the bullet based on the enemy rotation
            Quaternion bulletRotation = Quaternion.Euler(0f, 0f, -angleIncrement * (bulletCount - 1) / 2f + (angleIncrement * i));
            Vector2 bulletDirection = bulletSpawnRotation * bulletRotation * Vector2.right;

            // Instantiate the bullet and set its position, rotation, direction, and speed
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = bulletDirection * bulletSpeed;
        }

        // Apply recoil force to the enemy
        enemyRigidbody.AddForce(-transform.up * recoilForce, ForceMode2D.Impulse);
        recoilActive = true;

        // Start the cooldown timer
        StartCoroutine(BurstCooldownTimer());
    }

    private IEnumerator BurstCooldownTimer()
    {
        // Disable shooting
        canShoot = false;

        // Wait for the recoil duration
        yield return new WaitForSeconds(0.1f); // Adjust the duration as needed

        recoilActive = false;

        // Wait for the remaining cooldown duration
        yield return new WaitForSeconds(burstCooldown - 0.1f);

        // Enable shooting again
        canShoot = true;
    }

    private void Update()
    {
        // Find the player GameObject using the player tag
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            // Calculate the direction towards the player
            Vector2 directionToPlayer = playerObject.transform.position - transform.position;

            // Calculate the angle towards the player
            float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;

            // Rotate the enemy towards the player if not experiencing recoil
            if (!recoilActive)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
            }

            // Calculate the distance between the enemy and the player
            float distanceToPlayer = directionToPlayer.magnitude;

            // Check if the player is within the aggro range and the enemy can shoot
            if (distanceToPlayer <= aggroRange && canShoot)
            {
                FireBullets();
            }

            // Check if the player is within the movement aggro range and not experiencing recoil
            if (distanceToPlayer <= movementAggroRange && !recoilActive)
            {
                // Move towards the player
                enemyRigidbody.velocity = directionToPlayer.normalized * movementSpeed;
            }
            else
            {
                // Stop the movement if not experiencing recoil
                if (!recoilActive)
                {
                    enemyRigidbody.velocity = Vector2.zero;
                }
            }
        }
    }
}