using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{

    public CinemachineBrain mainCamera;
    public CinemachineVirtualCamera frame0_cam;
    public CinemachineVirtualCamera frame1_cam;
    public CinemachineVirtualCamera frame2_cam;
    public CinemachineVirtualCamera frame3_cam;

    public GameObject[] frame;
    public GameObject startButton;
    public EventSystem ES;

    // Start is called before the first frame update
    void Start()
    {
        /*frame[0].SetActive(true);
        frame[1].SetActive(false);
        frame[2].SetActive(false);
        frame[3].SetActive(false);
        //ES.SetSelectedGameObject(startButton);
        frame0_cam.gameObject.SetActive(true);
        frame1_cam.gameObject.SetActive(false);
        frame2_cam.gameObject.SetActive(false);
        frame3_cam.gameObject.SetActive(false);*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && frame[0].activeInHierarchy)
        {
            frame[0].SetActive(false);
            frame[1].SetActive(true);
            frame[2].SetActive(false);
            frame[3].SetActive(false);
            ES.SetSelectedGameObject(startButton);
            frame0_cam.gameObject.SetActive(false);
            frame1_cam.gameObject.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.Escape) && !frame[0].activeInHierarchy)
        {
            frame[1].SetActive(false);
            frame[2].SetActive(false);
            frame[0].SetActive(true);
            frame[3].SetActive(false);
            frame1_cam.gameObject.SetActive(false);
            frame2_cam.gameObject.SetActive(false);
            frame0_cam.gameObject.SetActive(true);
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //New Game
    /*public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }*/
    //Quit Game
    public void QuitGame()
    {
        Debug.Log("QUIT!!");
        Application.Quit();
    }
    public void Extras()
    {
        frame[1].SetActive(false);
        frame[2].SetActive(true);
        frame[3].SetActive(false);
        frame[0].SetActive(false);
        frame1_cam.gameObject.SetActive(false);
        frame2_cam.gameObject.SetActive(true);
    }

    public void Launch()
    {
        frame[1].SetActive(false);
        frame[2].SetActive(false);
        frame[0].SetActive(true);
        frame[3].SetActive(false);
        frame1_cam.gameObject.SetActive(false);
        frame2_cam.gameObject.SetActive(false);
        frame0_cam.gameObject.SetActive(true);
    }

    public void Options()
    {
        frame[1].SetActive(false);
        frame[2].SetActive(false);
        frame[0].SetActive(false);
        frame[3].SetActive(true);
        frame1_cam.gameObject.SetActive(false);
        frame2_cam.gameObject.SetActive(false);
        frame0_cam.gameObject.SetActive(false);
        frame3_cam.gameObject.SetActive(true);
    }
    public void Back()
    {
        frame[0].SetActive(false);
        frame[2].SetActive(false);
        frame[1].SetActive(true);
        frame[3].SetActive(false);
        ES.SetSelectedGameObject(startButton);
        frame0_cam.gameObject.SetActive(false);
        frame1_cam.gameObject.SetActive(true);
        frame3_cam.gameObject.SetActive(false);
        frame2_cam.gameObject.SetActive(false);
    }
}


