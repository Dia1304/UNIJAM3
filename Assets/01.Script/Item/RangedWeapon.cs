using UnityEngine;


public class RangedWeapon : Weapon
{

    public override void Attack()
    {
        Debug.Log("Fire");
        Instantiate(((RangedWeaponData)itemData).obj_projectile, transform.position, Quaternion.identity);
    }
}
