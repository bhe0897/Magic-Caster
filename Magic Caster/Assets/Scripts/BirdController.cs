using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : EnemyController
{
    public float FlightSpeed = 5;
    public float ThrustSpeed = 10;
    public float ThrustRate = 1;
    private float lastThrust = Mathf.NegativeInfinity;

    public LayerMask Mask;
    public float HoverHeight = 5;

    public float AttackProximity = 5;

    private float startingX;
    public float Range = 10;
    private Vector3 scaleFactor;
    // Start is called before the first frame update
    void Start()
    {
        startingX = transform.position.x;
        scaleFactor = transform.localScale;
        rb.velocity = new Vector3(FlightSpeed, 0, 0);
    }
    private void FixedUpdate()
    {
        float thrust = rb.velocity.y;
        float flight = rb.velocity.x;
        if (lastThrust + ThrustRate < Time.fixedTime)
        {
            float addedThrust = 0;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 10, Mask);
            if (hit)
            {
                float height = Vector2.Distance(transform.position, hit.point);
                addedThrust = Mathf.Clamp((HoverHeight - height), 0, Mathf.Infinity) * ThrustSpeed;
            }
            //rb.AddForce(Vector2.up * ThrustSpeed);
            thrust = ThrustSpeed + addedThrust;
            
            lastThrust = Time.fixedTime;
        }

        float offset = 0;
        if(transform.localScale.x < 0) //moving to the left
        {
            if (Range < 0) offset = Range;
            if(transform.position.x < startingX + offset)
            {
                //turn to the right
                transform.localScale = scaleFactor;
                flight = FlightSpeed;
            }
        }
        else
        {
            if (Range > 0) offset = Range;
            if(transform.position.x > startingX + offset)
            {
                transform.localScale = new Vector3(-scaleFactor.x, scaleFactor.y, scaleFactor.z);
                flight = -FlightSpeed;
            }
        }

        rb.velocity = new Vector2(flight, thrust);
        
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
