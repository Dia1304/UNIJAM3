using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private void Update()
    {
        transform.position += (Vector3)PlayerController.instance.GetDirection() * PlayerController.instance.Stat.moveSpeed * Time.unscaledDeltaTime;
    }
}
