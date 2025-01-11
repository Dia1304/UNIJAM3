using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveNextMap : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void EasyMap()
    {
        GameObject.FindGameObjectWithTag("ArmManager").GetComponent<ArmManager>().GiveData();
        SceneManager.LoadScene(4);
    }
}
