using System.Collections.Generic;
using UnityEngine;

public class Projectile1 : MonoBehaviour
{
    Vector3 direction;
    [SerializeField] private float speed;
    public float area;
    public float damage;
    void Start()
    {        
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = transform.position.z;

        direction = (mouseWorldPosition - transform.position).normalized;
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name.Contains("enemy"))
        {
            Collider2D[] areaHit = Physics2D.OverlapCircleAll(transform.position, area, LayerMask.GetMask("Enemy"));
            List<Collider2D> hasHit = new List<Collider2D>();   
            if(areaHit != null)
            {
                for(int i = 0; i < areaHit.Length; i++)
                {
                    if (!hasHit.Contains(areaHit[i]))
                    {
                        areaHit[i].GetComponent<Enemy>().Damage(damage);
                        hasHit.Add(areaHit[i]);
                    }
                }
            }
            Destroy(gameObject);
        }
    }
}
