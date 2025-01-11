using System.Collections.Generic;
using UnityEngine;

public class Projectile1 : MonoBehaviour
{
    [SerializeField] private float speed;
    public float damage;
    void Start()
    {        
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<PlayerController>().Stat.currentHealth -= damage;
            collision.GetComponent<PlayerController>().Damage();
            Destroy(gameObject);
        }
    }
}
