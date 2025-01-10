using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    [SerializeField]
    private int hp = 1;
    private int speed = 1;
    private int damage = 1;
    private GameObject player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(gameObject.transform.position, player.transform.position, speed);
    }
}
