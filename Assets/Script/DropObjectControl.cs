using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObjectControl : MonoBehaviour {

    public float speedHorizontal;
    Rigidbody2D rb2d;

	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        Acceration();
    }

    private void Update()
    {
        if (rb2d.velocity.x == 0)
        {
            Acceration();
        }
    }

    private void Acceration()
    {
        float direction = Random.Range(-1.0f, 1.0f);
        while (direction == 0)
        {
            direction = Random.Range(-1.0f, 1.0f);
        }
        Vector2 movement = new Vector2(speedHorizontal * direction, 0);
        rb2d.velocity = movement;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "ChasingObject")
        {
            Destroy(gameObject);
        }
    }

}
