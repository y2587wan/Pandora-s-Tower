using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Help()
    {
        SceneManager.LoadScene(2);
    }
    public void ReturnMain()
    {
        SceneManager.LoadScene(0);
    }
}
