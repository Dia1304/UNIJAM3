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
    public GameObject buddaPalm;
    public SynergyManager synergyManager;

    public Arm.AttackKey attackKey;
    private void Awake()
    {
        synergyManager = PlayerController.instance.SynergyManager;
    }
    void Start()
    {
        ChangeAttackKey(Arm.AttackKey.LMB);
    }

    void Update()
    {
        if(transform.childCount >= 1)
        {
            currentItem = transform.GetChild(0).gameObject;
        }
        if(Input.GetKeyDown(KeyCode.O))
        {
            synergyManager.AddSynergy(currentItem.GetComponent<ItemData>());
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
                        //¹«±â 2°³ ÀåÂø
                    }
                    else if(currentItem.TryGetComponent(out RangedWeapon ranged))
                    {
                        //¹«±â 2°³ ÀåÂø
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
        }
        if(type == ItemData.Type.Buddhism)
        {
            if(PlayerController.instance.SynergyManager.synergyArray[18].firstBuffEnabled && !buffEnabled)
            {
                GameObject _palm = Instantiate(buddaPalm, transform);
                EquipItem(_palm);
                buffEnabled = true;
            }
            else if (PlayerController.instance.SynergyManager.synergyArray[18].firstBuffEnabled == false && buffEnabled)
            {

                buffEnabled = false;
            }
        }
    }
    public void ChangeAttackKey(Arm.AttackKey attackKey)
    {
        this.attackKey = attackKey;
        UnsubscribeOnAttack();

        switch(attackKey)
        {
            case Arm.AttackKey.LMB:
                PlayerController.instance.OnAttack1 += Use;
                break;
            case Arm.AttackKey.RMB:
                PlayerController.instance.OnAttack2 += Use;
                break;
            case Arm.AttackKey.MMB:
                PlayerController.instance.OnAttack3 += Use;
                break;
            case Arm.AttackKey.Space:
                PlayerController.instance.OnAttack4 += Use;
                break;
            case Arm.AttackKey.LShift:
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
        if (currentItem != null)
        {
            UnequipItem(currentItem);
        }
        currentItem = item;
        item.transform.SetParent(transform, false);
        item.GetComponent<Weapon>().inInventory = true;

    }
    public void UnequipItem(GameObject item)
    {
        synergyManager.SubtractSynergy(item.GetComponent<ItemData>());
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
