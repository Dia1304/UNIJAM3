using UnityEngine;

public class Projectile : MonoBehaviour
{
    Vector3 direction;
    [SerializeField] private float speed;
    void Start()
    {
       direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized; 
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name.Contains("enemy"))
        {
            collision.GetComponent<Enemy>().Damage(1);
            Destroy(gameObject);
        }
    }
}
