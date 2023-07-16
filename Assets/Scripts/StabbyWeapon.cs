using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabbyWeapon : MonoBehaviour
{
    [SerializeField] float timeToAttack = 4f;
    float timer;

    [SerializeField] GameObject leftStabbyObject;
    [SerializeField] GameObject rightStabbyObject;
    [SerializeField] Vector2 stabbyAttackRadius = new Vector2(4f, 2f);
    [SerializeField] int stabbyDamage = 2;
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            Attack();
        }
    }

    private void Attack()
    {
        timer = timeToAttack;

        // Get the current mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mousePosition.x < transform.position.x)
        {
            // If the mouse is to the left of the player
            leftStabbyObject.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(leftStabbyObject.transform.position, stabbyAttackRadius, 0f);
            ApplyDamage(colliders);
        }
        else
        {
            // If the mouse is to the right of the player
            rightStabbyObject.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(rightStabbyObject.transform.position, stabbyAttackRadius, 0f);
            ApplyDamage(colliders);
        }
    }

    private void ApplyDamage(Collider2D[] colliders)
    {
        for(int i = 0; i < colliders.Length; i++)
        {
            Enemy e = colliders[i].GetComponent<Enemy>();
            if (e != null)
            {
                colliders[i].GetComponent<Enemy>().TakeDamage(stabbyDamage);
            }
            //Debug.Log(colliders[i].gameObject.name);
        }
    }
}
