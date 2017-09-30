using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChasingControl : MonoBehaviour {

    public float speed;
    public float acceleration;
    public Text GameOverText;
    private Rigidbody2D rb2d;

    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(0, speed);
    }
	
	void FixedUpdate () {
        speed += acceleration;

        rb2d.velocity = new Vector2(0, speed);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Debug.Log("You lose");
            Time.timeScale = 0;
            GameOverText.gameObject.SetActive(true);
        }
    }
}
