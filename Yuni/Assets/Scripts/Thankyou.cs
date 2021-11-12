using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Thankyou : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("MMenu");
    }

    public void quittingGame()
    {
        
        Application.Quit();
    }
}
