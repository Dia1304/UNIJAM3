using UnityEngine;

public class Projectile : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.position += transform.right * 5 * Time.deltaTime;
        Destroy(gameObject, 5f);
    }
}
