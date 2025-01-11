using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = true;
    }

    public void EnterGame()
    {
        SceneManager.LoadScene(3);
    }
    public void EnterMenu()
    {
        SceneManager.LoadScene(0);
    }
}
