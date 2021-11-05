
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathScreen : MonoBehaviour
{
    public void Restart()
    {
        FindObjectOfType<GameManager>().restartGame();
        
    }

    public void MainMenu()
    {
        FindObjectOfType<GameManager>().mainMenu();
    }

}
