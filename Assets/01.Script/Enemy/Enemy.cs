using TMPro;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;

public class Enemy : PoolAble
{
    [SerializeField]
    private float hp = 1;
    [SerializeField]
    private float speed = 0.1f;
    [SerializeField]
    private int damage = 1;
    [SerializeField] private float attackCoolTime;
    float timer;
    bool canAttack;
    private GameObject player;

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
        if (fDist > speed * Time.deltaTime)
        {
            transform.position += vDir * speed * Time.deltaTime;
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
    }

    public void InitStat()
    {
        hp = 3;
    }

    public void Damage(float damage)
    {
        hp -= damage;
        Debug.Log("Damaged");
        if(hp <= 0)
        {
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
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Detect Player");
            if(canAttack == true)
            {
                player.GetComponent<PlayerController>().Stat.currentHealth -= damage;
                timer = attackCoolTime;
            }
        }
    }
}
