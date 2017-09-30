using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {


    public float speed;
    public float addForce = 800;
    public float jumpForce;
    public Text scoreText;
    public KeyCode jump;
    public KeyCode moveLeft;
    public KeyCode moveRight;
    public float startForce = 100;

    private Vector2 force;
    private int score = 0;
    private Rigidbody2D rb2d;
    private bool onGround = true;
    private float moveHorizontal;
    private bool canJump = true;

    float JumpForce
    {
        get { return jumpForce; }
        set
        {
            if (value <= 0)
                jumpForce = 0;
            else
                jumpForce = value;
        }
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        jumpForce = startForce;
        SetCountText();
    }

    void Update()
    {
        Jump();
        MovementControl();
    }

    void Jump()
    {
        if (Input.GetKey(jump) && canJump)
        {
            JumpForce -= Time.deltaTime * addForce;
            PlayerJump();
        }

        if (Input.GetKeyUp(jump) && !onGround)
        {
            canJump = false;
        }
    }

    void PlayerJump()
    {
        force = new Vector2(0, jumpForce);
        rb2d.AddForce(force);
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Ground")
        {
            JumpForce = startForce;
            canJump = true;
            onGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Ground")
            onGround = false;
    }

    private void MovementControl()
    {
        

        if (Input.GetKey(moveLeft))
            moveHorizontal = -1;
        else if (Input.GetKey(moveRight))
            moveHorizontal = 1;
        else
            moveHorizontal = 0;

        Vector2 movement = new Vector2(moveHorizontal * speed, 0);
        rb2d.AddForce(movement);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "PickUp")
        {
            collision.gameObject.SetActive(false);
            score++;
        }

        SetCountText();
    }

    private void SetCountText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
