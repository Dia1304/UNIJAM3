using UnityEngine;

public class Item : MonoBehaviour
{
    public int itemId;
    public int damage;
    public int size = 1;
    [SerializeField]
    private Weapon weapon;
    private Type type;
    private Property Property;

    public int getWeaponData()
    {
        return (int)weapon;
    }

    public int getTypeData()
    {
        return (int)type;
    }

    public int getProperty()
    {
        return (int)Property;
    }
    
}
enum Weapon
{
    Null = -1,
    ColdWeapon = 0,
    Blunt = 1,
    Gun = 2,
    Magic = 3
}

enum Type
{
    Null = -1,
    Gothic = 0,
    Modern = 1,
    Sf = 2,
    Antique = 3,
    Holy = 4,
    Fantasy = 5
}

enum Property
{
    Null = -1,
    Light = 0,
    Fire = 1,
    Poision = 2
}

