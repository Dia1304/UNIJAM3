using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ArmData : MonoBehaviour
{
    public int attackButton = 0; // 0 = leftbutton, 1 = rightbutton, 2 = middlebutton, 3 = space, 4 = shift
    public int haveItemId = 0; // 0 = Null
    public int armNum;
    public ArmManager armManager;
    public Toggle[] attackButtonToggle = new Toggle[5];
    [SerializeField]
    private MoveItemData moveItemData;


    private void Awake()
    {
        armManager = GameObject.Find("ArmManager").GetComponent<ArmManager>();
    }
    public void AttackButtonChange(int buttonId)
    {
        attackButton = buttonId;
    }

    public void SetButton()
    {
        attackButtonToggle[attackButton].isOn = true;
        moveItemData.init();
    }

    public void SelectItem()
    {
        armManager.selectNum(armNum);
    }

    public void UndoHighlight()
    {
        moveItemData.UndoHighlight();
    }
}
