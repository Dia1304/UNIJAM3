using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    Vector3 direction;
    Vector3 startPos;
    RaycastHit2D hit;
    public MeleeWeaponData weaponData;

    private void Start()
    {
        itemData = weaponData;
    }
    private void Update()
    {  
        if(timer >= 0 && canUse == false)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            canUse = true;
        }

        startPos = transform.parent.position;

        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = PlayerController.instance.transform.position.z;

        direction = (mouseWorldPosition - PlayerController.instance.transform.position).normalized;

        if(weaponData.area <= 0)
        {
            Debug.DrawRay(PlayerController.instance.transform.position, direction * 3, Color.red);
        }
    }
    public override void Attack()
    {
        hit = Physics2D.Raycast(PlayerController.instance.transform.position, direction, 3, LayerMask.GetMask("Enemy"));

        if(hit.collider != null)
        {
            StartCoroutine(SwingWeapon(hit.transform.position));
        }
        else
        {
            StartCoroutine(SwingWeapon(PlayerController.instance.transform.position + direction * 3));
        }
    }

    private IEnumerator SwingWeapon(Vector3 target)
    {
        yield return StartCoroutine(MoveToPosition(target, 100f));

        if(weaponData.area <= 0)
        {
            if(hit.collider != null)
            {
                hit.collider.gameObject.GetComponent<Enemy>().Damage(weaponData.damage);
            }
        }
        else
        {
            Collider2D[] areaHit = Physics2D.OverlapCircleAll(transform.position, weaponData.area, LayerMask.GetMask("Enemy"));
            List<Collider2D> hasHit = new List<Collider2D>();   
            if(areaHit != null)
            {
                for(int i = 0; i < areaHit.Length; i++)
                {
                    if (!hasHit.Contains(areaHit[i]))
                    {
                        areaHit[i].GetComponent<Enemy>().Damage(weaponData.damage);
                        hasHit.Add(areaHit[i]);
                    }
                }
            }
        }
        Debug.Log("Slash");

        yield return StartCoroutine(MoveToPosition(startPos, 50f));
        transform.position = startPos;
    }

    private IEnumerator MoveToPosition(Vector3 target, float moveSpeed)
    {
        while (Vector3.Distance(transform.position,target) >= 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private void OnDrawGizmos()
    {
        if(weaponData.area > 0)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, weaponData.area);
        }
    }
}
