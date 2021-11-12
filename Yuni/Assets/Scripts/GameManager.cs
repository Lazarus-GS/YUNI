using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public void deathScreen()
    {
        //SceneManager.LoadScene("deathScreen");
    }
    /*public void RestartLevel()
    {
        SceneManager.LoadScene("deathScreen");
    }*/
    public void restartGame()
    {
        //SceneManager.LoadScene("Level1");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MMenu");      
    }


    






}
