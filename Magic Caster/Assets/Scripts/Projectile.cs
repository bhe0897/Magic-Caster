using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{


    public enum ProjectileTypes
    {
        fire,
        ice
    }

    public ProjectileTypes ProjectileType;

    public float Speed = 20, Strength = 1; //Strength is damage for fire and duration for ice
    private int bounceCount = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {


        }
        else
        {
            if(bounceCount > 0)
            {
                bounceCount -= 1;
                GetComponent<Rigidbody2D>().velocity = -GetComponent<Rigidbody2D>().velocity;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    public void Activate(bool fireRight)
    {
        if (fireRight) GetComponent<Rigidbody2D>().velocity = Speed * Vector2.right;
        else
        {
            GetComponent<Rigidbody2D>().velocity = -Speed * Vector2.right;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }
}