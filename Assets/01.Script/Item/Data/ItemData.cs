using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{
    public int itemId;
    public int size = 1;
    public float coolTime;
    public Class classData;
    public Type type;
    public Element element;

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
        return (int)element;
    }

    public enum Class
    {
        Null = -1,
        Blunt = 0,
        Blade = 1,
        Gun = 2,
        Magic = 3,
        Fight = 4,
        Tool = 5,
        Buliding = 6,
        Machine = 7,
        Food = 8,
    }

    public enum Type
    {
        Null = -1,
        Gothic = 0,
        Modern = 1,
        SF = 2,
        Machine = 3,
        Holy = 4,
        Fantasy = 5,
        Military = 6,
        Culture = 7,
        Alcohol = 8,
        Buddhism = 9,
    }

    public enum Element
    {
        Null = -1,
        Poision = 0,
        Water = 1,
        Grass = 2,
        Electric = 3,
        Metal = 4,
        Fire = 5,
        Mad = 6,
        Light = 7,
        Physical = 8,
    }
   
}
