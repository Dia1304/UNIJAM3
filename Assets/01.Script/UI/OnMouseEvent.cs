using UnityEngine;

public class OnMouseEvent : MonoBehaviour
{
    [SerializeField]
    GameObject explainDisplay;
    public void OnDisplay(int id)
    {
        explainDisplay.SetActive(true);
    }
    public void OffDisplay(int id)
    {
        explainDisplay.SetActive(false);
    }
}
