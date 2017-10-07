using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    public Text GameWinText;
    public GameObject ClearObject;

    private Animator animator;
    private bool isPressByPlayer = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            animator.SetBool("press", true);
            isPressByPlayer = true;
            GameWinText.gameObject.SetActive(true);
            ClearObject.SetActive(true);
        }
    }
}