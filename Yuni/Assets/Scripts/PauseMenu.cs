using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        pauseMenuUI.SetActive(false);       
    }

    public static bool IsPaused = false;
    public GameObject pauseMenuUI;
    

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }
    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void Restart()
    {
        Debug.Log("Restarting");
        //FindObjectOfType<GameManager>().restartGame();
        //SceneManager.LoadScene("Level1");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        Debug.Log("Loading Menu...");
        FindObjectOfType<GameManager>().mainMenu();
    }

    public void quittingGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    public AudioMixer audioMixer;
    public void changeVolume(float Volume)
    {
        audioMixer.SetFloat("masterVolume", Volume);
    }


}
