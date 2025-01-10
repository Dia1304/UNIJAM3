using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerController controller;

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
    }

    private void Update()
    {
        transform.position += (Vector3)controller.GetDirection() * controller.Stat.moveSpeed * Time.deltaTime;
    }
}
