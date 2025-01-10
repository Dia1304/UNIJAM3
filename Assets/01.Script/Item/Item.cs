using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemData itemData;

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

    public virtual void Use()
    {

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

