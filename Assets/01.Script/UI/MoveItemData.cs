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
    private ArmData armData; // item id 보유
    private PlayerManager playerManager;
    private SynergyManager synergyManager;

    public bool isSelect = false;
    public UnityEngine.UI.Image highlight;
    public UnityEngine.UI.Image itemSprite;
    public UnityEngine.UI.Image[] synergySprites = new UnityEngine.UI.Image[3];
    public ItemData itemData;
    private void Awake()
    {
        GameObject temp = GameObject.FindGameObjectWithTag("ItemDisplay");
        explainDisplay = temp.GetComponent<UnityEngine.UI.Image>();
        explainText = temp.GetComponentInChildren<Text>();
        playerManager = armData.armManager.playerManager;
        synergyManager = playerManager.synergyManager;
    }
    private void Start()
    {
        itemData = playerManager.findItem(armData.haveItemId);
        weaponName.text = itemData.itemName;
        if (playerManager.findItem(armData.haveItemId).itemImage != null)
            itemSprite.sprite = playerManager.findItem(armData.haveItemId).itemImage;
        SynergySpriteInsert();
    }

    public void init()
    {
        itemData = playerManager.findItem(armData.haveItemId);
        weaponName.text = itemData.itemName;
        if (itemData.itemImage != null)
            itemSprite.sprite = itemData.itemImage;
        else
            itemSprite.sprite = null;
        SynergySpriteInsert();
    }

    public void SynergySpriteInsert()
    {
        if ((int)itemData.classData != -1) 
        {
            if (synergyManager.synergySprite[(int)itemData.classData] != null)
                synergySprites[0].sprite = synergyManager.synergySprite[(int)itemData.classData];
            else
                synergySprites[0].sprite = null;
        }
        else
            synergySprites[0].sprite = null;
        if ((int)itemData.type != -1)
        {
            if (synergyManager.synergySprite[(int)itemData.type +9] != null)
                synergySprites[1].sprite = synergyManager.synergySprite[(int)itemData.type+9];
            else
                synergySprites[1].sprite = null;
        }
        else
            synergySprites[1].sprite = null;
        if ((int)itemData.element != -1)
        {
            if (synergyManager.synergySprite[(int)itemData.element + 19] != null)
                synergySprites[2].sprite = synergyManager.synergySprite[(int)itemData.element + 19];
            else
                synergySprites[2].sprite = null;
        }
        else
            synergySprites[2].sprite = null;
    }
    public void OnDisplay(int id) // 0 = itemdisplay, 1 = class, 2= type, 3 = element
    {
        if (armData.haveItemId == 0)
            return;
        explainDisplay.enabled = true;
        if (id == 0)
        {
            itemData = playerManager.findItem(armData.haveItemId);
            string explain = itemData.itemDesc + "\n" + itemData.Mechanism;
            explainText.text = explain;
        }
        else if (id == 1)
        {
            itemData = playerManager.findItem(armData.haveItemId);
            string explain = synergyManager.synergyName[(int)itemData.classData];
            explain = explain.Replace("\\n", "\n");
            explainText.text = explain;
        }
        else if (id == 2)
        {
            itemData = playerManager.findItem(armData.haveItemId);
            string explain = synergyManager.synergyName[(int)itemData.type + 9];
            explain = explain.Replace("\\n", "\n");
            explainText.text = explain;
        }
        else if (id == 3)
        {
            itemData = playerManager.findItem(armData.haveItemId);
            string explain = synergyManager.synergyName[(int)itemData.element + 19];
            explain = explain.Replace("\\n", "\n");
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
        else
        {
            armData.armManager.SelectInventory(armData.armNum);
        }
    }

    public void UndoHighlight()
    {
        highlight.enabled = false;
        isSelect = false;
    }

}
