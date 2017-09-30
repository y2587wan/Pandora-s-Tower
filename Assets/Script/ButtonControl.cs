using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{

    private bool isPressByPlayer = false;
    public Text GameWinText;
    public GameObject ClearObject;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            isPressByPlayer = true;
            //Time.timeScale = 0;
            Debug.Log("You win!");
            GameWinText.gameObject.SetActive(true);
            ClearObject.SetActive(true);
        }
    }
}