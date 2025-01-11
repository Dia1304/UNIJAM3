using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
public class ArmManager : MonoBehaviour
{
    [SerializeField]
    private GameObject armPreFab;

    [SerializeField]
    public List<ArmData> armDatas = new List<ArmData>();
    public PlayerManager playerManager;
    private int[] selectArm = { -1, -1 };
    public int rewardState = 0; // 0 = reward, 1 = map select
    public int selectInventorySlot = 0;
    private void Awake()
    {
        playerManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerManager>();
    }
    void Start()
    {
        for(int i = 0; i < playerManager.armItemList.Count; i++)
        {
            GameObject instantiatedObject = Instantiate(armPreFab, transform.position, Quaternion.identity);
            instantiatedObject.transform.SetParent(transform); // 부모를 현재 오브젝트로 설정
            instantiatedObject.GetComponent<RectTransform>().localScale = Vector3.one;
            armDatas.Add(instantiatedObject.GetComponent<ArmData>());
            armDatas[armDatas.Count - 1].haveItemId = playerManager.armItemList[armDatas.Count - 1];
            armDatas[armDatas.Count - 1].attackButton = playerManager.armAttackKeyList[armDatas.Count - 1];
            armDatas[armDatas.Count - 1].armType = playerManager.armATypeList[armDatas.Count - 1];
            armDatas[armDatas.Count - 1].SetButton();
            armDatas[armDatas.Count - 1].armNum = i;
        }
    }
    
    void generateArm(int id, int keyId, int type)
    {
        GameObject instantiatedObject = Instantiate(armPreFab, transform.position, Quaternion.identity);
        instantiatedObject.transform.SetParent(transform); // 부모를 현재 오브젝트로 설정
        instantiatedObject.GetComponent<RectTransform>().localScale = Vector3.one;
        armDatas.Add(instantiatedObject.GetComponent<ArmData>());
        armDatas[armDatas.Count - 1].haveItemId = id;
        armDatas[armDatas.Count - 1].attackButton = keyId;
        armDatas[armDatas.Count - 1].armType = type;
        armDatas[armDatas.Count - 1].SetButton();
        armDatas[armDatas.Count - 1].armNum = armDatas.Count - 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(armDatas.Count < playerManager.armItemList.Count) 
        {
            int cnt = playerManager.armItemList.Count - 1;
            generateArm(playerManager.armItemList[cnt], playerManager.armAttackKeyList[cnt], playerManager.armATypeList[cnt]);
        }
    }

    void GiveData() // 호출시 가지고 있는 데이터를 playerManager에게 넘겨줌
    {
        playerManager.GetData(armDatas);
    }

    public void SelectInventory(int id)
    {
        selectInventorySlot = id;
    }
    public void selectNum(int id)
    {
        for (int i = 0; i < 2; i++)
        {
            if (selectArm[i] == -1)
            {
                selectArm[i] = id;
                if (i == 1)
                {
                    Switchdata(selectArm[0], selectArm[1]);
                    armDatas[selectArm[0]].UndoHighlight();
                    selectArm[0] = -1;
                    armDatas[selectArm[1]].UndoHighlight();
                    selectArm[1] = -1;
                }
                return;
            }
            else if (selectArm[i] == id)
            {
                selectArm[0] = -1;
                return;
            }
        }
    }
    void Switchdata(int first, int second)
    {
        // 값 교환
        int temp = armDatas[first].haveItemId;
        armDatas[first].haveItemId = armDatas[second].haveItemId;
        armDatas[second].haveItemId = temp;

        temp = armDatas[first].attackButton;
        armDatas[first].attackButton = armDatas[second].attackButton;
        armDatas[first].SetButton();
        armDatas[second].attackButton = temp;
        armDatas[second].SetButton();
    }
}
