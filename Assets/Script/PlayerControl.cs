using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{


    public float speed;
    public float addForce = 800;
    public float jumpForce;
    public Text scoreText;
    public KeyCode jump;
    public KeyCode moveLeft;
    public KeyCode moveRight;
    public float startForce = 100;

    private Animator animator;
    private Vector2 force;
    private int score = 0;
    private Rigidbody2D rb2d;
    private bool onGround = true;
    private float moveHorizontal;
    private bool canJump = true;
    private bool faceRight = true;
    private bool isWalking = false;
    private bool isJumpingUp = false;
    private bool isJumpingDown = false;
    private bool isReachedHighest = false;
    private bool isCollided = false;


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
        animator = GetComponent<Animator>();
        jumpForce = startForce;
        SetCountText();
    }

    void Update()
    {
        Jump();
        MovementControl();
        JumpAnimation();
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
            isCollided = true;
            animator.SetBool("IsCollided", isCollided);
        }
    }


    private void OnCollisionExit2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Ground")
        {
            onGround = false;
            isCollided = false;
            animator.SetBool("IsCollided", isCollided);
        }
    }

    private void MovementControl()
    {
        if (Input.GetKey(moveLeft))
        {
            moveHorizontal = -1;
        }
        else if (Input.GetKey(moveRight))
        {
            moveHorizontal = 1;
        }
        else
            moveHorizontal = 0;

        FlipDecider();
        Vector2 movement = new Vector2(moveHorizontal * speed, 0);
        rb2d.AddForce(movement);
        WalkAnimation();
        
    }

    private void FlipDecider()
    {
        if (moveHorizontal > 0 && !faceRight)
        {
            Flip();
        }
        else if (moveHorizontal < 0 && faceRight)
        {
            Flip();
        }
    }

    private void WalkAnimation()
    {
        if (rb2d.velocity != Vector2.zero && onGround)
            isWalking = true;
        else
            isWalking = false;
        animator.SetBool("Walking", isWalking);
    }

    private void JumpAnimation()
    {
        if (rb2d.velocity.y > 0.1)
        {
            isJumpingUp = true;
        }
        if (rb2d.velocity.y < -0.1)
        {
            isJumpingDown = true;
        }
        if (rb2d.velocity.y > -0.1  && rb2d.velocity.y < 0.1 && !onGround)
        {
            isReachedHighest = true;
        }
        animator.SetFloat("MovingSpeed", rb2d.velocity.y);
        animator.SetBool("JumpUp", isJumpingUp);
        animator.SetBool("JumpHighest", isReachedHighest);
        animator.SetBool("JumpDown", isJumpingDown);
        isJumpingDown = false;
        isJumpingUp = false;
        isReachedHighest = false;
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

    private void Flip()
    {
        faceRight = !faceRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}