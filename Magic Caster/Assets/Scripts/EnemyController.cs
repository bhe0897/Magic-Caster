using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyController : MonoBehaviour
{
    public float Health = 100;

    public float WalkingSpeed = 5;

    protected Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public abstract void TakeDamage(float damage);
    public abstract void Die();
}
