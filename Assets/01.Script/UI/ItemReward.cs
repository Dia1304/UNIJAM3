using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework.Interfaces;

public class ItemReward : MonoBehaviour
{
    [SerializeField]
    Image explainDisplay;
    public PlayerManager playerManager;

    public List<GameObject> rewardItems = new List<GameObject>(); // 3°³
    public int[] rewardItemId = new int[3];
    int selectRewardNum = 0;

    public GameObject selectedReward;
    public GameObject selectedInventory;
    public int selectedArmNum;
    public ArmManager armManager;
    public ItemData itemData;
    public ArmData selecteArmData;
    [SerializeField]
    Text explainText;

    private void Awake()
    {
        playerManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerManager>();
        GameObject temp = GameObject.FindGameObjectWithTag("ItemDisplay");
        explainDisplay = temp.GetComponent<UnityEngine.UI.Image>();
        explainText = temp.GetComponentInChildren<Text>();
    }

    private void Start()
    {
        rewardItemGenerate();
    }

    private void rewardItemGenerate()
    {
        int i= 0;
        int randNum,randId;
        bool fail = false;
        while (i < 3)
        {
            fail = false;
            randNum = Random.Range(1, playerManager.itemIdList.Count);
            randId = playerManager.itemIdList[randNum];
            for (int j=0;j < armManager.armDatas.Count + i;j++)
            {
                
                if(j >= armManager.armDatas.Count)
                {
                    if (rewardItemId[j- armManager.armDatas.Count] == randId)
                    {
                        fail = true;
                        break;
                    }
                }
                else if (armManager.armDatas[j].haveItemId == randId)
                {
                    fail = true;
                    break;
                }
            }
            if (!fail)
            {
                rewardItemId[i] = randId;
                i++;
            }
        }
    }
    public void OnDisplay(int id) // 0 = selectReward, 1 ~ 3 = rewardItems, 4 = selectInvnetory
    {
        
        if (id == 0)
        {
            if (selectRewardNum == 0)
                return;
            itemData = playerManager.findItem(selectRewardNum);
            string explain = itemData.itemDesc + "\n" + itemData.Mechanism;
            explainText.text = explain;
        }
        else if(id == 4)
        {
            itemData = playerManager.findItem(selecteArmData.haveItemId);
            string explain = itemData.itemDesc + "\n" + itemData.Mechanism;
            explainText.text = explain;
        }
        else
        {
            itemData = playerManager.findItem(rewardItemId[id-1]);
            string explain = itemData.itemDesc + "\n" + itemData.Mechanism;
            explainText.text = explain;
        }
        explainDisplay.enabled = true;
    }
    public void OffDisplay()
    {
        explainDisplay.enabled = false;
    }
    public void SelectRewardItem(int num)
    {
        selectRewardNum = rewardItemId[num];
    }

    public void ChangeItem()
    {
        selecteArmData.haveItemId = selectRewardNum;
        selecteArmData.SetButton();
    }

    private void Update()
    {
        selecteArmData = armManager.armDatas[armManager.selectInventorySlot];
    }

}
