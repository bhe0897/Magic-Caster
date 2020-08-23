using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float WalkSpeed = 5;
    public float RunSpeed = 10;
    private float moveSpeed;

    public float JumpSpeed = 10;
    private Rigidbody2D rb;

    public GameObject FireBallPrefab, IceBallPrefab;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift)) moveSpeed = RunSpeed;
        else moveSpeed = WalkSpeed;

        float horizontalMoveMent = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(horizontalMoveMent * moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space)) rb.AddForce(new Vector2(0, JumpSpeed));

        if (Input.GetMouseButtonDown(0))
        {
            Projectile fireBall = Instantiate(FireBallPrefab, transform.position, Quaternion.identity).GetComponent<Projectile>();
            fireBall.Activate(transform.localScale.x > 0 ? true : false);
        }

        if (Input.GetButtonDown(1))
        {
            Projectile fireBall = Instantiate(IceBallPrefab, transform.position, Quaternion.identity).GetComponent<Projectile>();
            fireBall.Activate(transform.localScale.x > 0 ? true : false);
        }

    }
}
