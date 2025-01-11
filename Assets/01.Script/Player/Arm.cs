using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Arm : MonoBehaviour
{
    public GameObject currentItem;
    public AttackKey attackKey;

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
            AddSynergy(currentItem);
        }
        if(Input.GetKeyDown(KeyCode.I))
        {
            UnequipItem(currentItem);
        }
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

        AddSynergy(currentItem);
    }
    public void UnequipItem(GameObject item)
    {
        SubtractSynergy(item);
    }

    public void AddSynergy(GameObject item)
    {
        switch(item.GetComponent<Item>().itemData.classData)
        {
            case ItemData.Class.Blunt:
                PlayerController.instance.SynergyManager.AddSynergyCount("class_blunt", 1);
                break;
            case ItemData.Class.Blade:
                PlayerController.instance.SynergyManager.AddSynergyCount("class_blade", 1);
                break;
            case ItemData.Class.Gun:
                PlayerController.instance.SynergyManager.AddSynergyCount("class_gun", 1);
                break;
            case ItemData.Class.Magic:
                PlayerController.instance.SynergyManager.AddSynergyCount("class_magic", 1);
                break;
            case ItemData.Class.Fight:
                PlayerController.instance.SynergyManager.AddSynergyCount("class_fight", 1);
                break;
            case ItemData.Class.Tool:
                PlayerController.instance.SynergyManager.AddSynergyCount("class_tool", 1);
                break;
            case ItemData.Class.Buliding:
                PlayerController.instance.SynergyManager.AddSynergyCount("class_building", 1);
                break;
            case ItemData.Class.Machine:
                PlayerController.instance.SynergyManager.AddSynergyCount("class_machine", 1);
                break;
            case ItemData.Class.Food:
                PlayerController.instance.SynergyManager.AddSynergyCount("class_food", 1);
                break;
        }
        switch(item.GetComponent<Item>().itemData.type)
        {
            case ItemData.Type.Gothic:
                PlayerController.instance.SynergyManager.AddSynergyCount("type_gothic", 1);
                break;
            case ItemData.Type.Modern:
                PlayerController.instance.SynergyManager.AddSynergyCount("type_modern", 1);
                break;
            case ItemData.Type.SF:
                PlayerController.instance.SynergyManager.AddSynergyCount("type_SF", 1);
                break;
            case ItemData.Type.Machine:
                PlayerController.instance.SynergyManager.AddSynergyCount("type_machine", 1);
                break;
            case ItemData.Type.Holy:
                PlayerController.instance.SynergyManager.AddSynergyCount("type_holy", 1);
                break;
            case ItemData.Type.Military:
                PlayerController.instance.SynergyManager.AddSynergyCount("type_military", 1);
                break;
            case ItemData.Type.Culture:
                PlayerController.instance.SynergyManager.AddSynergyCount("type_culture", 1);
                break;
            case ItemData.Type.Alcohol:
                PlayerController.instance.SynergyManager.AddSynergyCount("type_alcohol", 1);
                break;
            case ItemData.Type.Buddhism:
                PlayerController.instance.SynergyManager.AddSynergyCount("type_buddism", 1);
                break;
        }
        switch(item.GetComponent<Item>().itemData.element)
        {
            case ItemData.Element.Poision:
                PlayerController.instance.SynergyManager.AddSynergyCount("element_poision", 1);
                break;
            case ItemData.Element.Water:
                PlayerController.instance.SynergyManager.AddSynergyCount("element_water", 1);
                break;
            case ItemData.Element.Grass:
                PlayerController.instance.SynergyManager.AddSynergyCount("element_grass", 1);
                break;
            case ItemData.Element.Electric:
                PlayerController.instance.SynergyManager.AddSynergyCount("element_electric", 1);
                break;
            case ItemData.Element.Metal:
                PlayerController.instance.SynergyManager.AddSynergyCount("element_metal", 1);
                break;
            case ItemData.Element.Fire:
                PlayerController.instance.SynergyManager.AddSynergyCount("element_fire", 1);
                break;
            case ItemData.Element.Mad:
                PlayerController.instance.SynergyManager.AddSynergyCount("element_mad", 1);
                break;
            case ItemData.Element.Light:
                PlayerController.instance.SynergyManager.AddSynergyCount("element_light", 1);
                break;
            case ItemData.Element.Physical:
                PlayerController.instance.SynergyManager.AddSynergyCount("element_physical", 1);
                break;
        }


    }
    public void SubtractSynergy(GameObject item)
    {
        switch(item.GetComponent<Item>().itemData.classData)
        {
            case ItemData.Class.Blunt:
                PlayerController.instance.SynergyManager.AddSynergyCount("class_blunt", -1);
                break;
            case ItemData.Class.Blade:
                PlayerController.instance.SynergyManager.AddSynergyCount("class_blade", -1);
                break;
            case ItemData.Class.Gun:
                PlayerController.instance.SynergyManager.AddSynergyCount("class_gun", -1);
                break;
            case ItemData.Class.Magic:
                PlayerController.instance.SynergyManager.AddSynergyCount("class_magic", -1);
                break;
            case ItemData.Class.Fight:
                PlayerController.instance.SynergyManager.AddSynergyCount("class_fight", -1);
                break;
            case ItemData.Class.Tool:
                PlayerController.instance.SynergyManager.AddSynergyCount("class_tool", -1);
                break;
            case ItemData.Class.Buliding:
                PlayerController.instance.SynergyManager.AddSynergyCount("class_building", -1);
                break;
            case ItemData.Class.Machine:
                PlayerController.instance.SynergyManager.AddSynergyCount("class_machine", -1);
                break;
            case ItemData.Class.Food:
                PlayerController.instance.SynergyManager.AddSynergyCount("class_food", -1);
                break;
        }
        switch(item.GetComponent<Item>().itemData.type)
        {
            case ItemData.Type.Gothic:
                PlayerController.instance.SynergyManager.AddSynergyCount("type_gothic", -1);
                break;
            case ItemData.Type.Modern:
                PlayerController.instance.SynergyManager.AddSynergyCount("type_modern", -1);
                break;
            case ItemData.Type.SF:
                PlayerController.instance.SynergyManager.AddSynergyCount("type_SF", -1);
                break;
            case ItemData.Type.Machine:
                PlayerController.instance.SynergyManager.AddSynergyCount("type_machine", -1);
                break;
            case ItemData.Type.Holy:
                PlayerController.instance.SynergyManager.AddSynergyCount("type_holy", -1);
                break;
            case ItemData.Type.Military:
                PlayerController.instance.SynergyManager.AddSynergyCount("type_military", -1);
                break;
            case ItemData.Type.Culture:
                PlayerController.instance.SynergyManager.AddSynergyCount("type_culture", -1);
                break;
            case ItemData.Type.Alcohol:
                PlayerController.instance.SynergyManager.AddSynergyCount("type_alcohol", -1);
                break;
            case ItemData.Type.Buddhism:
                PlayerController.instance.SynergyManager.AddSynergyCount("type_buddism", -1);
                break;
        }
        switch(item.GetComponent<Item>().itemData.element)
        {
            case ItemData.Element.Poision:
                PlayerController.instance.SynergyManager.AddSynergyCount("element_poision", -1);
                break;
            case ItemData.Element.Water:
                PlayerController.instance.SynergyManager.AddSynergyCount("element_water", -1);
                break;
            case ItemData.Element.Grass:
                PlayerController.instance.SynergyManager.AddSynergyCount("element_grass", -1);
                break;
            case ItemData.Element.Electric:
                PlayerController.instance.SynergyManager.AddSynergyCount("element_electric", -1);
                break;
            case ItemData.Element.Metal:
                PlayerController.instance.SynergyManager.AddSynergyCount("element_metal", -1);
                break;
            case ItemData.Element.Fire:
                PlayerController.instance.SynergyManager.AddSynergyCount("element_fire", -1);
                break;
            case ItemData.Element.Mad:
                PlayerController.instance.SynergyManager.AddSynergyCount("element_mad", -1);
                break;
            case ItemData.Element.Light:
                PlayerController.instance.SynergyManager.AddSynergyCount("element_light", -1);
                break;
            case ItemData.Element.Physical:
                PlayerController.instance.SynergyManager.AddSynergyCount("element_physical", -1);
                break;
        }

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
        LMB,
        RMB,
        MMB,
        Space,
        LShift,
    }
}
