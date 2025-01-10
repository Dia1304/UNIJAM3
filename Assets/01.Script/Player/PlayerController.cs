using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 m_direction;

    //Reference
    public PlayerStat Stat;

    private void Awake()
    {
        m_direction = Vector2.zero;
    }

    public void Movement(InputAction.CallbackContext context)
    {
        Vector2 dir = context.ReadValue<Vector2>();
        m_direction = dir;
    }

    public Vector2 GetDirection() => m_direction;
}
