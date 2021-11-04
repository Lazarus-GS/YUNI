using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    //Continue to current level
    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    //Quit Game
    public void QuitGame()
    {
        Debug.Log("QUIT!!");
        Application.Quit();
    }
}
