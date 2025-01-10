using UnityEngine;


public class RangedWeapon : Weapon
{
    [SerializeField]
    private GameObject obj_projectile;

    public override void Attack()
    {
        Debug.Log("Fire");
        Instantiate(obj_projectile, transform.position, Quaternion.identity);
    }
}
