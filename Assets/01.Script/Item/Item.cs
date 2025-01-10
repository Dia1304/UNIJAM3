using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemData itemData;

    protected float timer;
    protected bool canUse;
    public float coolTime;

    public int getClassData()
    {
        return (int)itemData.classData;
    }

    public int getTypeData()
    {
        return (int)itemData.type;
    }

    public int getElementData()
    {
        return (int)itemData.element;
    }

    private void Awake()
    {
        canUse = true;
        coolTime = itemData.coolTime;
        timer = coolTime;
    }

    public void CoolTime()
    {
        if(timer >= 0 && canUse == false)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            canUse = true;
        }
    }
    public float GetMultipliedCoolTime(float originCoolTime)
    {
        float result = originCoolTime;
        switch(itemData.classData)
        {
            case ItemData.Class.Blunt:
                result *= (1f - PlayerController.instance.Stat.bluntCoolTimeMultiplier);
                break;
            case ItemData.Class.Blade:
                result *= (1f - PlayerController.instance.Stat.bladeCoolTimeMultiplier);
                break;
            case ItemData.Class.Gun:
                result *= (1f - PlayerController.instance.Stat.gunCoolTimeMultiplier);
                break;
            case ItemData.Class.Magic:
                result *= (1f - PlayerController.instance.Stat.magicCoolTimeMultiplier);
                break;
            case ItemData.Class.Fight:
                result *= (1f - PlayerController.instance.Stat.fightCoolTimeMultiplier);
                break;
            case ItemData.Class.Tool:
                result *= (1f - PlayerController.instance.Stat.toolCoolTimeMultiplier);
                break;
            case ItemData.Class.Buliding:
                result *= (1f - PlayerController.instance.Stat.buildingCoolTimeMultiplier);
                break;
            case ItemData.Class.Machine:
                result *= (1f - PlayerController.instance.Stat.machineCoolTimeMultiplier);
                break;
            case ItemData.Class.Food:
                result *= (1f - PlayerController.instance.Stat.foodCoolTimeMultiplier);
                break;
            default:
                Debug.Log("으어어");
                break;
        }
        return result;
    }
    public float GetDamageMultiplier()
    {
        float result = 1.0f;
        switch(itemData.classData)
        {
            case ItemData.Class.Blunt:
                result *= (1f + PlayerController.instance.Stat.bluntDamageMultiplier);
                break;
            case ItemData.Class.Blade:
                result *= (1f + PlayerController.instance.Stat.bladeDamageMultiplier);
                break;
            case ItemData.Class.Gun:
                result *= (1f + PlayerController.instance.Stat.gunDamageMultiplier);
                break;
            case ItemData.Class.Magic:
                result *= (1f + PlayerController.instance.Stat.magicDamageMultiplier);
                break;
            case ItemData.Class.Fight:
                result *= (1f + PlayerController.instance.Stat.fightDamageMultiplier);
                break;
            case ItemData.Class.Tool:
                result *= (1f + PlayerController.instance.Stat.toolDamageMultiplier);
                break;
            case ItemData.Class.Buliding:
                result *= (1f + PlayerController.instance.Stat.buildingDamageMultiplier);
                break;
            case ItemData.Class.Machine:
                result *= (1f + PlayerController.instance.Stat.machineDamageMultiplier);
                break;
            case ItemData.Class.Food:
                result *= (1f + PlayerController.instance.Stat.foodDamageMultiplier);
                break;
            default:
                Debug.Log("으어어");
                break;
        }
        switch(itemData.element)
        {
            case ItemData.Element.Poision:
                result *= (1f + PlayerController.instance.Stat.positionMultiplier);
                break;
            case ItemData.Element.Water:
                result *= (1f + PlayerController.instance.Stat.waterMultiplier);
                break;
            case ItemData.Element.Grass:
                result *= (1f + PlayerController.instance.Stat.grassMultiplier);
                break;
            case ItemData.Element.Electric:
                result *= (1f + PlayerController.instance.Stat.electricMultiplier);
                break;
            case ItemData.Element.Metal:
                result *= (1f + PlayerController.instance.Stat.metalMultiplier);
                break;
            case ItemData.Element.Fire:
                result *= (1f + PlayerController.instance.Stat.fireMultiplier);
                break;
            case ItemData.Element.Mad:
                result *= (1f + PlayerController.instance.Stat.madMultiplier);
                break;
            case ItemData.Element.Light:
                result *= (1f + PlayerController.instance.Stat.lightMultiplier);
                break;
            case ItemData.Element.Physical:
                result *= (1f + PlayerController.instance.Stat.physicalMultiplier);
                break;
            default:
                Debug.Log("으어어");
                break;
        }

        Debug.Log(result);

        return result;
    }
    public float GetMultipliedRange(float originRange)
    {
        float result = originRange;

        switch(itemData.classData)
        {
            case ItemData.Class.Blunt:
                result += PlayerController.instance.Stat.bluntRangeMultiplier;
                break;
            case ItemData.Class.Blade:
                result += PlayerController.instance.Stat.bladeRangeMultiplier;
                break;
            case ItemData.Class.Gun:
                result += PlayerController.instance.Stat.gunRangeMultiplier;
                break;
            case ItemData.Class.Magic:
                result += PlayerController.instance.Stat.magicRangeMultiplier;
                break;
            case ItemData.Class.Fight:
                result += PlayerController.instance.Stat.fightRangeMultiplier;
                break;
            case ItemData.Class.Tool:
                result += PlayerController.instance.Stat.toolRangeMultiplier;
                break;
            case ItemData.Class.Buliding:
                result += PlayerController.instance.Stat.buildingRangeMultiplier;
                break;
            case ItemData.Class.Machine:
                result += PlayerController.instance.Stat.machineRangeMultiplier;
                break;
            case ItemData.Class.Food:
                result += PlayerController.instance.Stat.foodRangeMultiplier;
                break;
            default:
                Debug.Log("으어어");
                break;
        }

        return result;
    }

    public virtual bool Use()
    {
        if(canUse == false)
        {
            return false;
        }
        else
        {
            canUse = false;
            timer = coolTime;
            return true;
        }
    }

    public enum Class
    {
        Null = -1,
        ColdWeapon = 0,
        Blunt = 1,
        Gun = 2,
        Magic = 3
    }

    public enum Type
    {
        Null = -1,
        Gothic = 0,
        Modern = 1,
        Sf = 2,
        Antique = 3,
        Holy = 4,
        Fantasy = 5
    }

    public enum Element
    {
        Null = -1,
        Light = 0,
        Fire = 1,
        Poision = 2
    }
}

