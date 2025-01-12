using TMPro;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;
using System.Collections;

public class Enemy : PoolAble
{
    [SerializeField]
    public float hp = 1;
    public float speed = 0.1f;
    [SerializeField]
    private int damage = 1;
    [SerializeField] private float attackCoolTime;
    float timer;
    bool canAttack;
    bool inRange;
    [SerializeField] private float attackRange;
    private GameObject player;

    [SerializeField] private bool isRange;
    [SerializeField] private GameObject fireball;

    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private AudioSource AudioHit;
    [SerializeField] private AudioSource AudioDeath;
    [SerializeField] private AudioSource AudioShoot;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vTargetPos = player.transform.position;
        Vector3 vPos = transform.position;
        Vector3 vDist = vTargetPos - vPos;
        Vector3 vDir = vDist.normalized;
        float fDist = vDist.magnitude;
        
        if(vTargetPos.x < vPos.x)
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
        }

        if(fDist <= attackRange)
        {
            inRange = true;
        }
        else
        {
            transform.position += vDir * speed * Time.deltaTime;
            inRange = false;
        }

        if(timer > 0f)
        {
            timer -= Time.deltaTime;
            canAttack = false;
        }
        else
        {
            canAttack = true;
        }

        if(isRange)
        {
            if(canAttack && inRange)
            {
                float angle = Mathf.Atan2(vDist.y, vDist.x) * Mathf.Rad2Deg;
                Instantiate(fireball, transform.position, Quaternion.Euler(0, 0, angle-90));
                AudioShoot.Play();
                timer = attackCoolTime;
            }
        }
    }

    public void InitStat()
    {
        //hp = 3;
    }

    private IEnumerator FlashRed()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.white;
    }

    public void Damage(float damage)
    {
        hp -= damage;
        Debug.Log("Damaged");
        StartCoroutine(FlashRed());
        AudioHit.Play();
        if(hp <= 0)
        {
            AudioDeath.Play();
            Destroy(gameObject);
            //Destroy();
        }
    }
    public void Destroy()
    {
        ReleaseObject();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject == player)
        {
            Debug.Log("Detect Player");
            if(canAttack == true)
            {
                player.GetComponent<PlayerController>().Stat.currentHealth -= damage;
                collision.GetComponent<PlayerController>().Damage();
                timer = attackCoolTime;
            }
        }
    }
}
