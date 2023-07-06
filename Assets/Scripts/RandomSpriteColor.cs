using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpriteColor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Change the sprite color initially
        ChangeSpriteColor();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collider belongs to the player or any other object that should trigger the color change
        if (collision.CompareTag("Player") || collision.CompareTag("ColorChanger"))
        {
            // Change the sprite color
            ChangeSpriteColor();
        }
    }

    private void ChangeSpriteColor()
    {
        // Generate random RGB values
        float r = Random.value;
        float g = Random.value;
        float b = Random.value;

        // Set the sprite color
        spriteRenderer.color = new Color(r, g, b);
    }
}
