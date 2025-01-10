using UnityEngine;
using UnityEngine.UI;
public class MoveItemData : MonoBehaviour
{
    [SerializeField]
    private GameObject itemImage;
    [SerializeField]
    Image explainDisplay;
    [SerializeField]
    private ArmData armData;

    public bool isSelect = false;

    private void Awake()
    {
        explainDisplay = GameObject.FindGameObjectWithTag("ItemDisplay").GetComponent<Image>();
    }
    public void OnDisplay(int id) // 0 = itemdisplay, 1 = class, 2= type, 3 = element
    {
        explainDisplay.enabled = true;
    }
    public void OffDisplay()
    {
        explainDisplay.enabled = false;
    }
    public void SelectItem()
    {
        if (!isSelect)
        {
            //item Image ���̶���Ʈ
            isSelect = true;
            armData.SelectItem();
        }
        else
        {
            // ���̶���Ʈ Ǯ��
            isSelect = false;
            armData.SelectItem();
        }
    }

    public void UndoHighlight()
    {
        // ���̶���Ʈ Ǯ��
        isSelect = false;
    }

}
