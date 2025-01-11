using UnityEngine;

public class SpecialArm : MonoBehaviour
{
    public GameObject currentItem;
    public ItemData.Type type;

    private bool buffEnabled;

    private int attackCount;
    private bool holySynergy;
    private bool fantasySynergy;
    public GameObject lightning;

    void Start()
    {
        
    }

    void Update()
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

        if(currentItem != null && currentItem.GetComponent<Item>().itemData.type == type)
        {
            if(type == ItemData.Type.Gothic)
            {
                if(PlayerController.instance.SynergyManager.synergyArray[9].firstBuffEnabled && !buffEnabled)
                {
                    if(currentItem.TryGetComponent(out MeleeWeapon melee))
                    {
                        melee.weaponData.area += 1.0f;
                    }
                    else if(currentItem.TryGetComponent(out RangedWeapon ranged))
                    {
                        ranged.weaponData.area += 1.0f;
                    }
                    buffEnabled = true;
                }
                else if (PlayerController.instance.SynergyManager.synergyArray[9].firstBuffEnabled == false && buffEnabled)
                {
                    if(currentItem.TryGetComponent(out MeleeWeapon melee))
                    {
                        melee.weaponData.area -= 1.0f;
                    }
                    else if(currentItem.TryGetComponent(out RangedWeapon ranged))
                    {
                        ranged.weaponData.area -= 1.0f;
                    }

                    buffEnabled = false;
                }
            }
            else if(type == ItemData.Type.Modern)
            {
                if(PlayerController.instance.SynergyManager.synergyArray[10].firstBuffEnabled && !buffEnabled)
                {
                    PlayerController.instance.SynergyManager.synergyArray[10].count++;
                    buffEnabled = true;
                }
                else if (PlayerController.instance.SynergyManager.synergyArray[10].firstBuffEnabled == false && buffEnabled)
                {
                    PlayerController.instance.SynergyManager.synergyArray[10].count--;
                    buffEnabled = false;
                }
            }
            else if(type == ItemData.Type.SF)
            {
                if(PlayerController.instance.SynergyManager.synergyArray[11].firstBuffEnabled && !buffEnabled)
                {
                    switch(currentItem.GetComponent<Item>().itemData.element)
                    {
                        case ItemData.Element.Poision:
                            PlayerController.instance.Stat.poisionMultiplier += 1.0f;
                            break;
                        case ItemData.Element.Water:
                            PlayerController.instance.Stat.waterMultiplier += 1.0f;
                            break;
                        case ItemData.Element.Grass:
                            PlayerController.instance.Stat.grassMultiplier += 1.0f;
                            break;
                        case ItemData.Element.Electric:
                            PlayerController.instance.Stat.electricMultiplier += 1.0f;
                            break;
                        case ItemData.Element.Metal:
                            PlayerController.instance.Stat.metalMultiplier += 1.0f;
                            break;
                        case ItemData.Element.Fire:
                            PlayerController.instance.Stat.fireMultiplier += 1.0f;
                            break;
                        case ItemData.Element.Mad:
                            PlayerController.instance.Stat.madMultiplier += 1.0f;
                            break;
                        case ItemData.Element.Light:
                            PlayerController.instance.Stat.lightMultiplier += 1.0f;
                            break;
                        case ItemData.Element.Physical:
                            PlayerController.instance.Stat.physicalMultiplier += 1.0f;
                            break;
                    }
                    buffEnabled = true;
                }
                else if (PlayerController.instance.SynergyManager.synergyArray[11].firstBuffEnabled == false && buffEnabled)
                {
                    switch(currentItem.GetComponent<Item>().itemData.element)
                    {
                        case ItemData.Element.Poision:
                            PlayerController.instance.Stat.poisionMultiplier -= 1.0f;
                            break;
                        case ItemData.Element.Water:
                            PlayerController.instance.Stat.waterMultiplier -= 1.0f;
                            break;
                        case ItemData.Element.Grass:
                            PlayerController.instance.Stat.grassMultiplier -= 1.0f;
                            break;
                        case ItemData.Element.Electric:
                            PlayerController.instance.Stat.electricMultiplier -= 1.0f;
                            break;
                        case ItemData.Element.Metal:
                            PlayerController.instance.Stat.metalMultiplier -= 1.0f;
                            break;
                        case ItemData.Element.Fire:
                            PlayerController.instance.Stat.fireMultiplier -= 1.0f;
                            break;
                        case ItemData.Element.Mad:
                            PlayerController.instance.Stat.madMultiplier -= 1.0f;
                            break;
                        case ItemData.Element.Light:
                            PlayerController.instance.Stat.lightMultiplier -= 1.0f;
                            break;
                        case ItemData.Element.Physical:
                            PlayerController.instance.Stat.physicalMultiplier -= 1.0f;
                            break;
                    }

                    buffEnabled = false;
                }
            }
            else if(type == ItemData.Type.Machine)
            {
                if(PlayerController.instance.SynergyManager.synergyArray[12].firstBuffEnabled && !buffEnabled)
                {
                    if(currentItem.TryGetComponent(out MeleeWeapon melee))
                    {
                        melee.weaponData.coolTime *= 0.5f;
                    }
                    else if(currentItem.TryGetComponent(out RangedWeapon ranged))
                    {
                        ranged.weaponData.coolTime *= 0.5f;
                    }
                    buffEnabled = true;
                }
                else if (PlayerController.instance.SynergyManager.synergyArray[12].firstBuffEnabled == false && buffEnabled)
                {
                    if(currentItem.TryGetComponent(out MeleeWeapon melee))
                    {
                        melee.weaponData.coolTime *= 2.0f;
                    }
                    else if(currentItem.TryGetComponent(out RangedWeapon ranged))
                    {
                        ranged.weaponData.coolTime *= 2.0f;
                    }

                    buffEnabled = false;
                }
            }
            else if(type == ItemData.Type.Holy)
            {
                if(PlayerController.instance.SynergyManager.synergyArray[13].firstBuffEnabled && !buffEnabled)
                {
                    holySynergy = true;
                    buffEnabled = true;
                }
                else if (PlayerController.instance.SynergyManager.synergyArray[13].firstBuffEnabled == false && buffEnabled)
                {
                    holySynergy = false;
                    buffEnabled = false;
                }
            }
            else if(type == ItemData.Type.Fantasy)
            {
                if(PlayerController.instance.SynergyManager.synergyArray[14].firstBuffEnabled && !buffEnabled)
                {
                    fantasySynergy = true;
                    buffEnabled = true;
                }
                else if (PlayerController.instance.SynergyManager.synergyArray[14].firstBuffEnabled == false && buffEnabled)
                {
                    fantasySynergy = false;
                    buffEnabled = false;
                }
            }
            else if(type == ItemData.Type.Military)
            {
                if(PlayerController.instance.SynergyManager.synergyArray[15].firstBuffEnabled && !buffEnabled)
                {
                    PlayerController.instance.Stat.militarySynergy = true;
                    buffEnabled = true;
                }
                else if (PlayerController.instance.SynergyManager.synergyArray[15].firstBuffEnabled == false && buffEnabled)
                {
                    PlayerController.instance.Stat.militarySynergy = false;
                    buffEnabled = false;
                }
            }
            else if(type == ItemData.Type.Culture)
            {
                if(PlayerController.instance.SynergyManager.synergyArray[16].firstBuffEnabled && !buffEnabled)
                {
                    if(currentItem.TryGetComponent(out MeleeWeapon melee))
                    {
                        //무기 2개 장착
                    }
                    else if(currentItem.TryGetComponent(out RangedWeapon ranged))
                    {
                        //무기 2개 장착
                    }
                    buffEnabled = true;
                }
                else if (PlayerController.instance.SynergyManager.synergyArray[16].firstBuffEnabled == false && buffEnabled)
                {
                    if(currentItem.TryGetComponent(out MeleeWeapon melee))
                    {

                    }
                    else if(currentItem.TryGetComponent(out RangedWeapon ranged))
                    {

                    }

                    buffEnabled = false;
                }
            }
            else if(type == ItemData.Type.Alcohol)
            {
                if(PlayerController.instance.SynergyManager.synergyArray[17].firstBuffEnabled && !buffEnabled)
                {
                    PlayerController.instance.Stat.damageMultiplier = 3.0f;
                    PlayerController.instance.Stat.rangedWeaponDamageMultiplier += 0.15f;
                    PlayerController.instance.Stat.meleeWeaponDamageMultiplier += 0.5f;
                    PlayerController.instance.Stat.fightDamageMultiplier += 1.0f;
                    PlayerController.instance.Stat.sojuDamageMultiplier += 3.0f;
                    buffEnabled = true;
                }
                else if (PlayerController.instance.SynergyManager.synergyArray[17].firstBuffEnabled == false && buffEnabled)
                {
                    PlayerController.instance.Stat.damageMultiplier = 1.0f;
                    PlayerController.instance.Stat.rangedWeaponDamageMultiplier -= 0.15f;
                    PlayerController.instance.Stat.meleeWeaponDamageMultiplier -= 0.5f;
                    PlayerController.instance.Stat.fightDamageMultiplier -= 1.0f;
                    PlayerController.instance.Stat.sojuDamageMultiplier -= 3.0f;
                    buffEnabled = false;
                }
            }
            else if(type == ItemData.Type.Buddhism)
            {
                if(PlayerController.instance.SynergyManager.synergyArray[18].firstBuffEnabled && !buffEnabled)
                {
                    //여래신장 추가
                    buffEnabled = true;
                }
                else if (PlayerController.instance.SynergyManager.synergyArray[18].firstBuffEnabled == false && buffEnabled)
                {

                    buffEnabled = false;
                }
            }
        }
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
            if(attackCount < 3)
            {
                attackCount++;
            }
            else
            {
                attackCount = 0;
                if(holySynergy)
                {
                    SummonLightning();
                }
            }
            currentItem.GetComponent<Item>().Use();
            if(fantasySynergy)
            {
                currentItem.GetComponent<Item>().Use();
            }
        }
    }

    private void SummonLightning()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Instantiate(lightning, mousePos, Quaternion.identity);
    }

}
