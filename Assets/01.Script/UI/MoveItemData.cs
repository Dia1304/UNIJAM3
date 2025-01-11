using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
public class MoveItemData : MonoBehaviour
{
    [SerializeField]
    private GameObject itemImage;
    [SerializeField]
    UnityEngine.UI.Image explainDisplay;
    [SerializeField]
    Text explainText;
    [SerializeField]
    Text weaponName;
    [SerializeField]
    private ArmData armData; // item id º¸À¯
    private PlayerManager playerManager;

    public bool isSelect = false;
    public UnityEngine.UI.Image highlight;
    public ItemData itemData;
    private void Awake()
    {
        GameObject temp = GameObject.FindGameObjectWithTag("ItemDisplay");
        explainDisplay = temp.GetComponent<UnityEngine.UI.Image>();
        explainText = temp.GetComponentInChildren<Text>();
        playerManager = armData.armManager.playerManager;
    }
    private void Start()
    {
        itemData = playerManager.findItem(armData.haveItemId);
        weaponName.text = itemData.itemName;
    }

    public void init()
    {
        itemData = playerManager.findItem(armData.haveItemId);
        weaponName.text = itemData.itemName;
    }
    public void OnDisplay(int id) // 0 = itemdisplay, 1 = class, 2= type, 3 = element
    {
        explainDisplay.enabled = true;
        if(id == 0)
        {
            itemData = playerManager.findItem(armData.haveItemId);
            string explain = itemData.itemDesc + "\n" + itemData.Mechanism;
            explainText.text = explain;
        }
        
    }
    public void OffDisplay()
    {
        explainDisplay.enabled = false;
    }
    public void SelectItem()
    {
        if (armData.armManager.rewardState == 1)
        {
            if (!isSelect)
            {
                highlight.enabled = true;
                isSelect = true;
                armData.SelectItem();
            }
            else
            {
                highlight.enabled = false;
                isSelect = false;
                armData.SelectItem();
            }
            explainDisplay.enabled = false;
        }
    }

    public void UndoHighlight()
    {
        highlight.enabled = false;
        isSelect = false;
    }

}
