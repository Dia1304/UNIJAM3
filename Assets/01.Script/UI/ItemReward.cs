using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ItemReward : MonoBehaviour
{
    [SerializeField]
    Image explainDisplay;

    
    public List<GameObject> rewardItems = new List<GameObject>(); // 3°³
    int[] rewardItemId = new int[3];
    int selectRewardNum = 0;

    public GameObject selectedReward;
    public GameObject selectedInventory;
    public int selectedArmNum;
    public ArmManager armManager;


    private void Awake()
    {
        explainDisplay = GameObject.FindGameObjectWithTag("ItemDisplay").GetComponent<Image>();
    }
    public void OnDisplay(int id) // 0 = selectReward, 1 ~ 3 = rewardItems, 4 = selectInvnetory
    {
        explainDisplay.enabled = true;
    }
    public void OffDisplay()
    {
        explainDisplay.enabled = false;
    }
    public void SelectRewardItem(int num)
    {
        // selectedReward to rewardItems[num]
    }

    public void ChangeItem()
    {
        armManager.armDatas[selectedArmNum].haveItemId = rewardItemId[selectRewardNum];
    }

    private void Update()
    {
        selectedArmNum = armManager.selectInventorySlot;
    }

}
