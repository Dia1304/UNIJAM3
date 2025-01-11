using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void EnterGame()
    {
        SceneManager.LoadScene(2);
    }
    public void EnterSettings()
    {
        SceneManager.LoadScene(1);
    }
}
