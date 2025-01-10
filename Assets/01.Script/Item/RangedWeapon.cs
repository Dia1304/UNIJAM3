using UnityEngine;


public class RangedWeapon : Weapon
{

    public RangedWeaponData weaponData;
    private void Start()
    {
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
        Destroy(_object, GetMultipliedRange(weaponData.range));
    }
}
