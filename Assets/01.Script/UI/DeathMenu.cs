using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public void EnterGame()
    {
        SceneManager.LoadScene(2);
    }
    public void EnterMenu()
    {
        SceneManager.LoadScene(0);
    }
}
