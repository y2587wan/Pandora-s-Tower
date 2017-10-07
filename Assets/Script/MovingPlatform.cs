using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour
{

    public float speed = 1f;
    public float mapWidth = 25f;
    public float timeDuration = 100f;

    private float timePass = 0;
    private float x;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {

        if (timePass < timeDuration)
            x = speed;
        else if (timePass < 2 * timeDuration)
            x = -speed;
        else
            timePass = 0;
        Vector2 newPosition = rb.position + Vector2.right * x;

        newPosition.x = Mathf.Clamp(newPosition.x, -mapWidth, mapWidth);

        rb.MovePosition(newPosition);
        timePass++;
    }
}