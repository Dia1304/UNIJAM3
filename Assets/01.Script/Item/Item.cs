using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemData itemData;

    protected float timer;
    protected bool canUse;

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
        return (int)itemData.Property;
    }

    private void Awake()
    {
        canUse = true;
        timer = itemData.coolTime;
    }

    private void Update()
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

    public virtual bool Use()
    {
        if(canUse == false)
        {
            return false;
        }
        else
        {
            canUse = false;
            timer = itemData.coolTime;
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

