using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {


    public float speed;
    public float vertialSpeed;
    public Text scoreText;
    public KeyCode jump;
    public KeyCode moveLeft;
    public KeyCode moveRight;

    private int score = 0;
    private Rigidbody2D rb2d;
    private bool isGround = true;
    private float moveVertical;
    private float moveHorizontal;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        SetCountText();
    }

    void Update()
    {
        MovementControl();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
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
        

        if (Input.GetKey(moveLeft))
            moveHorizontal = -1;
        else if (Input.GetKey(moveRight))
            moveHorizontal = 1;
        else
            moveHorizontal = 0;

        if (isGround && Input.GetKeyDown(jump))
        {
            moveVertical = vertialSpeed;
            isGround = false;
        }
        else
        {
            moveVertical = 0;
        }
        
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
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
