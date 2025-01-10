using TMPro;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;

public class Enemy : PoolAble
{ 
    [SerializeField]
    private int hp = 1;
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
        transform.position = Vector3.MoveTowards(gameObject.transform.position, player.transform.position, speed);
    }

    public void Damage(int damage)
    {
        if(hp <= 0)
        {
            Destroy();
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
