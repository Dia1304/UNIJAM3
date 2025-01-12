using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{

    public PlayerManager playerManager;
    public SynergyManager synergyManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerManager>();
        synergyManager = playerManager.synergyManager;
        Cursor.visible = true;
        for (int i = 0; i < synergyManager.synergyCnt.Length; i++)
            synergyManager.synergyArray[i].count = 0;
        playerManager.stage = 0;
        playerManager.armstage = 0;
        playerManager.armItemList = new List<int>();
        playerManager.armAttackKeyList = new List<int>();
        playerManager.armATypeList = new List<int>();
        playerManager.AddArm(0, 0, -1);


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
