using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.EventSystems;


public class MenuManager : MonoBehaviour
{

    public CinemachineBrain mainCamera;
    public CinemachineVirtualCamera frame0_cam;
    public CinemachineVirtualCamera frame1_cam;
  //public CinemachineVirtualCamera frame2_cam;

    public GameObject[] frame;
    public GameObject startButton;
    public EventSystem ES;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && frame[0].activeInHierarchy)
        {
            frame[0].SetActive(false);
            frame[1].SetActive(true);
            ES.SetSelectedGameObject(startButton);
            frame0_cam.gameObject.SetActive(false);
            frame1_cam.gameObject.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.Escape) && !frame[0].activeInHierarchy)
        {
            frame[1].SetActive(false);
          //frame[2].SetActive(false);
            frame[0].SetActive(true);
            frame1_cam.gameObject.SetActive(false);
            //frame2_cam.gameObject.SetActive(false);
            frame0_cam.gameObject.SetActive(true);
        }
    }

    /*public void Credits()
    {
        frame[1].SetActive(false);
        frame[2].SetActive(true);
        frame1_cam.gameObject.SetActive(false);
        frame2_cam.gameObject.SetActive(true);
    }*/
}
