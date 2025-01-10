using UnityEngine;

public class Arm : MonoBehaviour
{
    public GameObject currentItem;

    private void Start()
    {

    }
    public void Use()
    {
        if(currentItem != null)
        {
            //Debug.Log("Use current item");
            currentItem.GetComponent<Item>().Use();
        }
    }
}
