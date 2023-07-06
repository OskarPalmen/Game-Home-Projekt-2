using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeManager : MonoBehaviour
{
    private float scaleSpeed = 5f;
    private float currentScale = 1f;

    void OnTriggerEnter2D(Collider2D other)
    {
        currentScale += 1f;
        
        Destroy(other.gameObject);
    }

    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(currentScale, currentScale, 1), Time.deltaTime * scaleSpeed);
    }
}
