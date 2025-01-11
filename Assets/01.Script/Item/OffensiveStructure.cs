using UnityEditor;
using UnityEngine;

public class OffensiveStructure : Structure
{
    public RangedWeaponData weaponData;
    public RangedWeaponData data;

    public void Start()
    {
        Destroy(gameObject, durability);
        weaponData = Instantiate(data);
        itemData = weaponData;
    }

    public override void Logic()
    {
        Debug.Log("Fire");
        GameObject _object = Instantiate(((RangedWeaponData)itemData).obj_projectile, transform.position, Quaternion.identity);
        _object.GetComponent<Projectile1>().area = GetMultipliedArea(weaponData.area);
        _object.GetComponent<Projectile1>().damage = weaponData.damage * GetDamageMultiplier();
        Destroy(_object, GetMultipliedRange(weaponData.range));
    }
}
