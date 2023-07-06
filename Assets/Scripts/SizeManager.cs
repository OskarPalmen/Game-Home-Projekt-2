using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeManager : MonoBehaviour
{
    private float currentScale = 1f;

    void OnTriggerEnter2D(Collider2D other)
    {
        currentScale += 1f;

        transform.localScale = new Vector3(currentScale, currentScale, 1);
    }
}
