using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenController : MonoBehaviour
{
    public void restart()
    {
        SceneManager.LoadScene("Dono Workspace");
    }

    public void endGame()
    {
        Application.Quit();
    }
}