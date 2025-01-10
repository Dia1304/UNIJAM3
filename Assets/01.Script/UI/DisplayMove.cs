using UnityEngine;

public class DisplayMove : MonoBehaviour
{
    private void FixedUpdate()
    {
        Vector3 mPosition = Input.mousePosition;
        Vector3 target = Camera.main.ScreenToViewportPoint(mPosition);
        transform.position = target;
        Debug.Log(target);
    }
}
