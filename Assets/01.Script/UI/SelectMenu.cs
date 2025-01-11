using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMenu : MonoBehaviour
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
