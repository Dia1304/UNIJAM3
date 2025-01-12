using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;
using static UnityEngine.GraphicsBuffer;

public class MeleeWeapon : Weapon
{
    Vector3 direction;
    Vector3 startPos;
    RaycastHit2D hit;
    public MeleeWeaponData weaponData;
    public MeleeWeaponData data;

    private bool isMoving;

    public float swingSpeed = 1000;

    private bool isSwinging = false; // �ֵθ��� ������ ����

    private void Start()
    {
        weaponData = Instantiate(data);
        itemData = weaponData;
        GetComponent<AudioSource>().clip = itemData.attackSound;
        if(itemData.itemImage != null && transform.childCount > 0)
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

        if(!isSwinging)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        }
    }
    public void Swing()
    {
        if (!isSwinging)
        {
            StartCoroutine(SwingRoutine());
        }
    }
    private IEnumerator SwingRoutine()
    {
        isSwinging = true;

        // ���� ������ �����ɴϴ�
        float currentAngle = transform.eulerAngles.z;

        // ���������� �ֵθ���
        float targetAngle = currentAngle + weaponData.swingAngle;
        transform.rotation = Quaternion.Euler(0, 0, currentAngle - weaponData.swingAngle / 2);
        while (currentAngle < targetAngle)
        {
            float step = swingSpeed * Time.deltaTime;
            if (currentAngle + step > targetAngle) step = targetAngle - currentAngle;

            transform.RotateAround(transform.position, Vector3.forward, step);
            currentAngle += step;

            yield return null; // ���� �����ӱ��� ���
        }
        isSwinging = false; // �ֵθ��� ����
    }
    public override void Attack()
    {
        hit = Physics2D.Raycast(PlayerController.instance.transform.position, direction, GetMultipliedRange(weaponData.range), LayerMask.GetMask("Enemy"));

        GetComponent<AudioSource>().PlayOneShot(itemData.attackSound, 1);

        if(!isMoving)
        {
            //if(hit.collider != null)
            //{
            //    StartCoroutine(SwingWeapon(hit.transform.position));
            //}
            //else
            {
                if(GetMultipliedRange(weaponData.range) > Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), PlayerController.instance.transform.position))
                {
                    StartCoroutine(SwingWeapon(Camera.main.ScreenToWorldPoint(Input.mousePosition) - direction.normalized));
                }
                else
                {
                    StartCoroutine(SwingWeapon(PlayerController.instance.transform.position + direction * GetMultipliedRange(weaponData.range) - direction.normalized));
                }
            }
        }
    }

    private IEnumerator SwingWeapon(Vector3 target)
    {
        isMoving = true;
        target = new Vector3(target.x, target.y, 0);
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
                    Vector3 directionToTarget = areaHit[i].transform.position - transform.position;

                    // ���� �ٶ󺸴� ����� �浹ü�� ���� ���� ������ ���
                    float angleToTarget = Vector3.Angle(transform.up, directionToTarget);

                    // ���� angleToTarget�� ������ ���� ���� ������
                    if (angleToTarget <= weaponData.swingAngle / 2f)
                    {
                        // ��ä�� ���� ���� �ִ� �浹ü�� �߰ߵǾ��� �� ������ �ڵ�
                        if (!hasHit.Contains(areaHit[i]))
                        {
                            areaHit[i].GetComponent<Enemy>().Damage(damage * GetDamageMultiplier() * PlayerController.instance.Stat.meleeWeaponDamageMultiplier);
                            hasHit.Add(areaHit[i]);
                        }
                    }
                }
            }
            yield return StartCoroutine(SwingRoutine());
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
