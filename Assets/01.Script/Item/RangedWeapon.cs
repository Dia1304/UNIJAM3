using UnityEngine;


public class RangedWeapon : Weapon
{
    public RangedWeaponData weaponData;
    public RangedWeaponData data;
    private void Start()
    {
        weaponData = Instantiate(data);
        itemData = weaponData;
    }
    private void Update()
    {
        CoolTime();
    }

    public override void Attack()
    {
        Debug.Log("Fire");
        GameObject _object = Instantiate(((RangedWeaponData)itemData).obj_projectile, transform.position, Quaternion.identity);
        _object.GetComponent<Projectile>().area = GetMultipliedArea(weaponData.area);
        _object.GetComponent<Projectile>().damage = weaponData.damage * GetDamageMultiplier();
        Destroy(_object, GetMultipliedRange(weaponData.range));
    }
}
