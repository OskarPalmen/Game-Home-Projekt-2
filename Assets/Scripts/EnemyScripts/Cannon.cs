using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectilePrefab;

    public float fireRate = 1f;
    public float projectileLifetime = 5f;
    public float bulletSpeed = 10f;

    private float fireDelay;
    private float timer;

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

        rb.velocity = firePoint.right * bulletSpeed;

        // Attach a script to the projectile to handle destruction events
        Projectile projectileScript = projectile.AddComponent<Projectile>();

        Destroy(projectile, projectileLifetime);
    }

}