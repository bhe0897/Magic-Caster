using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    public static int WingsCount, FlowersCount, ShieldCount;
    

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
        GameObject.FindGameObjectWithTag("WingText").GetComponent<Text>().text = WingsCount.ToString();
        GameObject.FindGameObjectWithTag("ShieldText").GetComponent<Text>().text = ShieldCount.ToString();
        GameObject.FindGameObjectWithTag("FlowerText").GetComponent<Text>().text = FlowersCount.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift)) moveSpeed = RunSpeed;
        else moveSpeed = WalkSpeed;

        float horizontalMoveMent = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(horizontalMoveMent * moveSpeed, rb.velocity.y);
        if (rb.velocity.x > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (rb.velocity.x < 0) transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetKeyDown(KeyCode.Space)) rb.AddForce(new Vector2(0, JumpSpeed));

        if (Input.GetMouseButtonDown(0))
        {
            Projectile fireBall = Instantiate(FireBallPrefab, transform.position, Quaternion.identity).GetComponent<Projectile>();
            fireBall.Activate(transform.localScale.x > 0 ? true : false);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Projectile fireBall = Instantiate(IceBallPrefab, transform.position, Quaternion.identity).GetComponent<Projectile>();
            fireBall.Activate(transform.localScale.x > 0 ? true : false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wing"))
        {
            WingsCount += 1;
            GameObject.FindGameObjectWithTag("WingText").GetComponent<Text>().text = WingsCount.ToString();
            Destroy(collision.gameObject);
            
        }else if (collision.CompareTag("Shield"))
        {
            ShieldCount += 1;
            GameObject.FindGameObjectWithTag("ShieldText").GetComponent<Text>().text = ShieldCount.ToString();
            Destroy(collision.gameObject);

        }
        else if (collision.CompareTag("Flower"))
        {
            FlowersCount += 1;
            GameObject.FindGameObjectWithTag("FlowerText").GetComponent<Text>().text = FlowersCount.ToString();
            Destroy(collision.gameObject);
        }
    }


}
