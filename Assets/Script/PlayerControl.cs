using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {


    public float speed;
    public float vertialSpeed;

    private Rigidbody2D rb2d;
    private bool isGround = true;
    private float moveVertical;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MovementControl();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.transform.name);
        if (collision.transform.tag == "Ground")
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
    }

    private void MovementControl()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        if (isGround && Input.GetKeyDown("space"))
        {
            moveVertical = vertialSpeed;
            Debug.Log("Jump");
            isGround = false;
        }
        else
        {
            moveVertical = 0;
        }
        
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }


}
