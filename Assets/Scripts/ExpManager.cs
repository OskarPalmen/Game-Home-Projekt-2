using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpManager : MonoBehaviour
{
    public ProgressBar progressBar; // Reference to the ProgressBar script
    void OnTriggerEnter2D(Collider2D other)
    {     
        Destroy(other.gameObject);
        progressBar.current++; // Increment the current variable of the ProgressBar script
    }

    void Update()
    {
        
    }
}
