using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{
    public int itemId;
    public int size = 1;
    public Class classData;
    public Type type;
    public Element Property;

    public int getClassData()
    {
        return (int)classData;
    }

    public int getTypeData()
    {
        return (int)type;
    }

    public int getElementData()
    {
        return (int)Property;
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
