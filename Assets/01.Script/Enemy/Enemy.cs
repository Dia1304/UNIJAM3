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
        if (fDist > speed * Time.deltaTime) {
            transform.position += vDir * speed * Time.deltaTime;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == player)
        {
            //todo
            //player 데미지 주기
        }
    }
}
