using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MeleeWeapon : Weapon
{
    Vector3 direction;
    Vector3 startPos;
    RaycastHit2D hit;
    public MeleeWeaponData weaponData;
    public MeleeWeaponData data;

    private bool isMoving;


    private void Start()
    {
        weaponData = Instantiate(data);
        itemData = weaponData;
        GetComponent<AudioSource>().clip = itemData.sound;
        if(itemData.itemImage != null)
        {
           transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = itemData.itemImage;
        }
    }

    public void Init(MeleeWeaponData inData)
    {
        weaponData = inData;
        data = inData;
        itemData = inData;
    }
    private void Update()
    {
        if (inInventory)
        {
            coolTime = GetMultipliedCoolTime(itemData.coolTime);
            CoolTime();

            startPos = transform.parent.position;


            if (weaponData.area <= 0)
            {
                Debug.DrawRay(PlayerController.instance.transform.position, direction * GetMultipliedRange(weaponData.range), Color.red);
            }
        }

        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = PlayerController.instance.transform.position.z;

        direction = (mouseWorldPosition - PlayerController.instance.transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle-90);
    }
    public override void Attack()
    {
        hit = Physics2D.Raycast(PlayerController.instance.transform.position, direction, GetMultipliedRange(weaponData.range), LayerMask.GetMask("Enemy"));

        GetComponent<AudioSource>().PlayOneShot(itemData.sound, 1);

        if(!isMoving)
        {
            if(hit.collider != null)
            {
                StartCoroutine(SwingWeapon(hit.transform.position));
            }
            else
            {
                StartCoroutine(SwingWeapon(PlayerController.instance.transform.position + direction * GetMultipliedRange(weaponData.range)));
            }
        }
    }

    private IEnumerator SwingWeapon(Vector3 target)
    {
        isMoving = true;
        yield return StartCoroutine(MoveToPosition(target, 20f));

        float damage = weaponData.damage;
        if(weaponData.type == ItemData.Type.Alcohol)
        {
            damage *= PlayerController.instance.Stat.sojuDamageMultiplier;
        }
        if(weaponData.area <= 0)
        {
            if(hit.collider != null)
            {
                hit.collider.gameObject.GetComponent<Enemy>().Damage(damage * GetDamageMultiplier() * PlayerController.instance.Stat.meleeWeaponDamageMultiplier);
            }
        }
        else
        {
            Collider2D[] areaHit = Physics2D.OverlapCircleAll(transform.position, GetMultipliedArea(weaponData.area), LayerMask.GetMask("Enemy"));
            List<Collider2D> hasHit = new List<Collider2D>();   
            if(areaHit != null)
            {
                for(int i = 0; i < areaHit.Length; i++)
                {
                    if (!hasHit.Contains(areaHit[i]))
                    {
                        areaHit[i].GetComponent<Enemy>().Damage(damage * GetDamageMultiplier() * PlayerController.instance.Stat.meleeWeaponDamageMultiplier);
                        hasHit.Add(areaHit[i]);
                    }
                }
            }
        }
        Debug.Log("Slash");

        yield return StartCoroutine(MoveBack(10f));
        transform.position = startPos;
        isMoving = false;
    }

    private IEnumerator MoveToPosition(Vector3 target, float moveSpeed)
    {
        while (Vector3.Distance(transform.position, target) >= 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.fixedDeltaTime);
            yield return null;
        }
    }
    private IEnumerator MoveBack(float moveSpeed)
    {
        while (Vector3.Distance(transform.position, startPos) >= 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, moveSpeed * Time.fixedDeltaTime);
            yield return null;
        }
    }

    private void OnDrawGizmos()
    {
        try
        {
            if(weaponData.area > 0)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(transform.position, weaponData.area);
            }
        }
        catch { }
    }
}
