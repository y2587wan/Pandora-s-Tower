using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryStone : MonoBehaviour {

    // Use this for initialization
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
        
    }
}
