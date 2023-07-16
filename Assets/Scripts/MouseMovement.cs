using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public Camera cam;
    public float speed = 1f;



    // Update is called once per frame
    void Update()
    {
        Vector2 input = input = Input.mousePosition;

        Vector3 worldInput = cam.ScreenToWorldPoint(input);

        Vector3 newPosition = Vector3.MoveTowards(transform.position, worldInput, speed * Time.deltaTime);

        newPosition.z = transform.position.z;

        transform.position = newPosition;
    }
}
