using UnityEngine;

public class Projectile : MonoBehaviour
{
    Vector3 direction;
    [SerializeField] private float speed;
    void Start()
    {        
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = PlayerController.instance.transform.position.z;

        direction = (mouseWorldPosition - PlayerController.instance.transform.position).normalized;
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
