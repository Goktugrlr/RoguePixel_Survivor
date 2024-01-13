using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);  //This code in Scene0 (Main Menu)
    }

    public void ExitGame()
    {
        Application.Quit();  //This code in Scene0 (Main Menu)
    }
}