using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveNextMap : MonoBehaviour
{
    public PlayerManager playerManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void EasyMap(int difficult)
    {
        playerManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerManager>();
        playerManager.difficulty = difficult;
        GameObject.FindGameObjectWithTag("ArmManager").GetComponent<ArmManager>().GiveData();
        SceneManager.LoadScene(4);
    }
}
