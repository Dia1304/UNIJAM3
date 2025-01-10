using UnityEngine;

public class Aim : MonoBehaviour
{
    Vector2 mousePos;

    private void Awake()
    {
        Cursor.visible = false;
    }
    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
    }
}
