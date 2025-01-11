using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Arm : MonoBehaviour
{
    public GameObject currentItem;
    public AttackKey attackKey;
    public SynergyManager synergyManager;

    private void Awake()
    {
        synergyManager = PlayerController.instance.SynergyManager;
    }
    private void Start()
    {
        ChangeAttackKey(Arm.AttackKey.LMB); 
    }
    private void Update()
    {
        if(transform.childCount >= 1)
        {
            currentItem = transform.GetChild(0).gameObject;
        }
        if(Input.GetKeyDown(KeyCode.O))
        {
            synergyManager.AddSynergy(currentItem);
        }
        if(Input.GetKeyDown(KeyCode.I))
        {
            UnequipItem(currentItem);
        }

        if(transform.childCount == 1)
        {
            GetComponent<LineRenderer>().SetPosition(0, transform.GetChild(0).position);
        }
        else
        {
            GetComponent<LineRenderer>().SetPosition(0, transform.position);
        }
        GetComponent<LineRenderer>().SetPosition(1, transform.parent.position);
    }

    public void ChangeAttackKey(AttackKey attackKey)
    {
        this.attackKey = attackKey;
        UnsubscribeOnAttack();

        switch(attackKey)
        {
            case AttackKey.LMB:
                PlayerController.instance.OnAttack1 += Use;
                break;
            case AttackKey.RMB:
                PlayerController.instance.OnAttack2 += Use;
                break;
            case AttackKey.MMB:
                PlayerController.instance.OnAttack3 += Use;
                break;
            case AttackKey.Space:
                PlayerController.instance.OnAttack4 += Use;
                break;
            case AttackKey.LShift:
                PlayerController.instance.OnAttack5 += Use;
                break;
        }
    }

    private void UnsubscribeOnAttack()
    {
        PlayerController.instance.OnAttack1 -= Use;
        PlayerController.instance.OnAttack2 -= Use;
        PlayerController.instance.OnAttack3 -= Use;
        PlayerController.instance.OnAttack4 -= Use;
        PlayerController.instance.OnAttack5 -= Use;
    }

    public void EquipItem(GameObject item)
    {
        if(currentItem != null)
        {
            UnequipItem(currentItem);
        }
        currentItem = item;
        item.transform.SetParent(transform);
        item.GetComponent<Weapon>().inInventory = true;

        synergyManager.AddSynergy(currentItem);
    }
    public void UnequipItem(GameObject item)
    {
        synergyManager.SubtractSynergy(item);
    }

    public void Use()
    {
        if(currentItem != null)
        {
            //Debug.Log("Use current item");
            currentItem.GetComponent<Item>().Use();
        }
    }

    public enum AttackKey
    {
        LMB = 0,
        RMB = 1,
        MMB = 2,
        Space = 3,
        LShift = 4,
    }
}
