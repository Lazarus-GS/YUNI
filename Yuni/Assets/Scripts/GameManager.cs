using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public void deathScreen()
    {
        Debug.Log("Hit");
        SceneManager.LoadScene("deathScreen");
    }
    public void restartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        
    }


    






}
