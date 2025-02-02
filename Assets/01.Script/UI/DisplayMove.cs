using UnityEngine;
using UnityEngine.UI;

public class DisplayMove : MonoBehaviour
{
    RectTransform racttrans;
    public Text text;
    public Image image;
    Vector2 pivot = Vector2.zero;
    private void Awake()
    {
        racttrans = GetComponent<RectTransform>();
    }
    private void FixedUpdate()
    {
        if (image.IsActive())
            text.enabled = true;
        else
            text.enabled = false;

        Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, -Camera.main.transform.position.z));
        transform.position = new Vector3(point.x, point.y, 0);

        if(point.x <= 0)
            pivot = new Vector2(0,pivot.y);
        else
            pivot = new Vector2(1, pivot.y);

        if (point.y <= 0)
            pivot = new Vector2(pivot.x, 0);
        else
            pivot = new Vector2(pivot.x, 1);

        racttrans.pivot = pivot;
    }
}
