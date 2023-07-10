using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject particleEffect; // The particle effect prefab to instantiate upon destruction

    private void OnDestroy()
    {
        if (particleEffect != null)
        {
            GameObject effectInstance = Instantiate(particleEffect, transform.position, transform.rotation);
            ParticleSystem particleSystem = effectInstance.GetComponent<ParticleSystem>();
            Destroy(effectInstance, particleSystem.main.duration);
        }
    }

}
