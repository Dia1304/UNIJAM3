using UnityEngine;
using UnityEngine.UI;

public class OnMouseEvent : MonoBehaviour
{
    [SerializeField]
    Image explainDisplay;
    public void OnDisplay(int id)
    {
        explainDisplay.enabled = true;
    }
    public void OffDisplay(int id)
    {
        explainDisplay.enabled = false;
    }
}
