using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : EnemyController
{
    public float ThrustSpeed = 10;
    public float ThrustRate = 1;
    private float lastThrust = Mathf.NegativeInfinity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lastThrust + ThrustRate < Time.fixedTime)
        {
            //rb.AddForce(Vector2.up * ThrustSpeed);
            rb.velocity = new Vector2(rb.velocity.x, ThrustSpeed);
            lastThrust = Time.fixedTime;
        }
    }

    public override void Die()
    {
        throw new System.NotImplementedException();
    }

    public override void TakeDamage(float damage)
    {
        throw new System.NotImplementedException();
    }
}
