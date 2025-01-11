using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    public float damage;
    public float area;

    private void Start()
    {
        Destroy(gameObject, 0.2f);
    }
    private void Update()
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
    }
}
