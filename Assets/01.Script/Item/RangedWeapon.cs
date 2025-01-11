using UnityEngine;


public class RangedWeapon : Weapon
{
    public RangedWeaponData weaponData;
    public RangedWeaponData data;
    public bool inInventory = false;
    private void Start()
    {
        weaponData = Instantiate(data);
        itemData = weaponData;
    }
    private void Update()
    {
        if (inInventory)
        {
            CoolTime();
        }
    }
    public void Init(RangedWeaponData inData)
    {
        weaponData = inData;
        data = inData;
        itemData = inData;
    }
    public override void Attack()
    {
        Debug.Log("Fire");
        GameObject _object = Instantiate(((RangedWeaponData)itemData).obj_projectile, transform.position, Quaternion.identity);
        _object.GetComponent<Projectile>().area = GetMultipliedArea(weaponData.area);
        _object.GetComponent<Projectile>().damage = weaponData.damage * GetDamageMultiplier() * PlayerController.instance.Stat.rangedWeaponDamageMultiplier;
        
        if(PlayerController.instance.Stat.militarySynergy && weaponData.type == ItemData.Type.Military)
        {
            if(_object.GetComponent<Projectile>().penetraction == false)
            {
                _object.GetComponent<Projectile>().penetraction = true;
            }
            else
            {
                _object.GetComponent<Projectile>().damage *= 1.5f;
            }
        }

        Destroy(_object, GetMultipliedRange(weaponData.range));
    }
}
