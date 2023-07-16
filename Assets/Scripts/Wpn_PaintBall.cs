using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wpn_PaintBall : MonoBehaviour
{
    [SerializeField] float timeToAttack;
    float timer;

    MouseMovement mouseMovement;

    [SerializeField] GameObject paintBallPrefab;

    private void Start()
    {
        mouseMovement = GetComponentInParent<MouseMovement>(); //this line is getting the MouseMovement component from the parent of the object this script is attached to
    }
    
    private void Update()
    {
        if(timer < timeToAttack)
        {
            timer += Time.deltaTime;
            return;
        }

        timer = 0;

        SpawnPaintBall();
    }

    private void SpawnPaintBall()
    {
        GameObject paintBall = Instantiate(paintBallPrefab);
        paintBall.transform.position = transform.position; // this line is setting the position of the paintBall to the position of the object this script is attached to
        paintBall.GetComponent<PaintBallProjectile>();
    }
}
