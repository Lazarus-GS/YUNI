using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class videoPlayer : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("MMenu");
        }
    }

}
