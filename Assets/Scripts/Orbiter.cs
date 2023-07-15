using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbiter : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float orbitRadius = 2f;
    public float orbitSpeed = 1f;

    private GameObject orbiterInstance;
    private float angle = 0f;

    private void Start()
    {
        // Spawn the orbiter prefab
        orbiterInstance = Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
    }

    private void Update()
    {
        // Calculate the orbiter's position based on the angle
        float x = Mathf.Sin(angle) * orbitRadius;
        float y = Mathf.Cos(angle) * orbitRadius;
        Vector3 orbiterPosition = transform.position + new Vector3(x, y, 0f);

        // Update the orbiter's position
        orbiterInstance.transform.position = orbiterPosition;

        // Increase the angle based on the orbit speed
        angle += orbitSpeed * Time.deltaTime;
    }
}
