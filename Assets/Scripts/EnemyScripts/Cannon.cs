using UnityEngine;

public class Cannon : MonoBehaviour
{
    public Transform firePoint;  // The position where projectiles will be spawned
    public GameObject projectilePrefab;  // Prefab of the projectile to be fired

    public float fireRate = 1f;  // Rate at which the cannon will shoot (shots per second)
    public float projectileLifetime = 5f;  // Time before the projectile gets destroyed
    public float bulletSpeed = 10f;  // Speed of the projectile

    private float fireDelay;  // Delay between shots
    private float timer;  // Timer to keep track of fire rate

    private void Start()
    {
        fireDelay = 1f / fireRate;
        timer = 0f;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= fireDelay)
        {
            timer = 0f;
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        // Set the velocity of the projectile based on the shooting direction and bullet speed
        rb.velocity = firePoint.right * bulletSpeed;

        // Destroy the projectile after the specified lifetime
        Destroy(projectile, projectileLifetime);
    }
}