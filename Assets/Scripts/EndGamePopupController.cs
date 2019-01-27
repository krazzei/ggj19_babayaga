using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGamePopupController : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene("TheScene");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
