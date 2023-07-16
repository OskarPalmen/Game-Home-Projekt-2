using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform targetDestination;
    GameObject targetGameobject;
    [SerializeField] float speed;
    
    Rigidbody2D rgdbd2d;

    [SerializeField] int hp = 4;

    private void Awake()
    {
        rgdbd2d = GetComponent<Rigidbody2D>(); //q: why error? a: because you didn't add the Rigidbody2D component to the Enemy prefab
        targetGameobject = targetDestination.gameObject; //q: why error?
    }

    private void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rgdbd2d.velocity = direction * speed;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == targetGameobject)
        {
            Attack();
        }
    }

    private void Attack()
    {
        Debug.Log("Attacking the Player!");
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if(hp <= 1)
        {
            Destroy(gameObject);
        }
    }
}
