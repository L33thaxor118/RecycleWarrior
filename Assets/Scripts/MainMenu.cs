using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
<<<<<<< HEAD
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
=======
        SceneManager.LoadScene("Game");
>>>>>>> 4c0d247e229fac5299665c76fff8e0fcf4c228de
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
<<<<<<< HEAD
=======

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
>>>>>>> 4c0d247e229fac5299665c76fff8e0fcf4c228de
}
