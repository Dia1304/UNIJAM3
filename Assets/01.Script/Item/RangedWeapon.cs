using UnityEngine;


public class RangedWeapon : Weapon
{
    public RangedWeaponData weaponData;
    public RangedWeaponData data;
    Vector3 direction;

    private void Start()
    {
        weaponData = Instantiate(data);
        itemData = weaponData;
        GetComponent<AudioSource>().clip = itemData.sound;
    }
    private void Update()
    {
        if (inInventory)
        {
            CoolTime();
        }

        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = PlayerController.instance.transform.position.z;

        direction = (mouseWorldPosition - PlayerController.instance.transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle-90);
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
        GameObject _object = Instantiate(((RangedWeaponData)itemData).obj_projectile, transform.position, transform.rotation);
        _object.GetComponent<Projectile>().area = GetMultipliedArea(weaponData.area);
        _object.GetComponent<Projectile>().damage = weaponData.damage * GetDamageMultiplier() * PlayerController.instance.Stat.rangedWeaponDamageMultiplier;
        
        GetComponent<AudioSource>().PlayOneShot(itemData.sound, 1);

        if(PlayerController.instance.Stat.militarySynergy && weaponData.type == ItemData.Type.Military)
        {
            if(_object.GetComponent<Projectile>().penetration == false)
            {
                _object.GetComponent<Projectile>().penetration = true;
            }
            else
            {
                _object.GetComponent<Projectile>().damage *= 1.5f;
            }
        }

        Destroy(_object, GetMultipliedRange(weaponData.range));
    }
}
