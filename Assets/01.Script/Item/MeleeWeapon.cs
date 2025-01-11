using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    Vector3 direction;
    Vector3 startPos;
    RaycastHit2D hit;
    public MeleeWeaponData weaponData;
    public MeleeWeaponData data;

    private void Start()
    {
        weaponData = Instantiate(data);
        itemData = weaponData;
    }

    public void Init(MeleeWeaponData inData)
    {
        weaponData = inData;
        data = inData;
        itemData = inData;
    }
    private void Update()
    {
        coolTime = GetMultipliedCoolTime(itemData.coolTime);
        CoolTime();

        startPos = transform.parent.position;

        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = PlayerController.instance.transform.position.z;

        direction = (mouseWorldPosition - PlayerController.instance.transform.position).normalized;

        if(weaponData.area <= 0)
        {
            Debug.DrawRay(PlayerController.instance.transform.position, direction * GetMultipliedRange(weaponData.range), Color.red);
        }
    }
    public override void Attack()
    {
        hit = Physics2D.Raycast(PlayerController.instance.transform.position, direction, GetMultipliedRange(weaponData.range), LayerMask.GetMask("Enemy"));

        if(hit.collider != null)
        {
            StartCoroutine(SwingWeapon(hit.transform.position));
        }
        else
        {
            StartCoroutine(SwingWeapon(PlayerController.instance.transform.position + direction * GetMultipliedRange(weaponData.range)));
        }
    }

    private IEnumerator SwingWeapon(Vector3 target)
    {
        yield return StartCoroutine(MoveToPosition(target, 20f / weaponData.coolTime));

        if(weaponData.area <= 0)
        {
            if(hit.collider != null)
            {
                hit.collider.gameObject.GetComponent<Enemy>().Damage(weaponData.damage * GetDamageMultiplier());
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
                        areaHit[i].GetComponent<Enemy>().Damage(weaponData.damage * GetDamageMultiplier());
                        hasHit.Add(areaHit[i]);
                    }
                }
            }
        }
        Debug.Log("Slash");

        yield return StartCoroutine(MoveBack(10f / weaponData.coolTime));
        transform.position = startPos;
    }

    private IEnumerator MoveToPosition(Vector3 target, float moveSpeed)
    {
        while (Vector3.Distance(transform.position, target) >= 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
    private IEnumerator MoveBack(float moveSpeed)
    {
        while (Vector3.Distance(transform.position, startPos) >= 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, moveSpeed * Time.deltaTime);
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
