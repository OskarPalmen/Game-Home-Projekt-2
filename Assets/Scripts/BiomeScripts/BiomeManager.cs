using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiomeManager : MonoBehaviour
{

    public Sprite greenGroundSprite;

    public void ChangeGroundToGreen(GameObject groundObject)
    {
        SpriteRenderer spriteRenderer = groundObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = greenGroundSprite;
    }

    public static BiomeManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
