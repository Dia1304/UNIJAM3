using UnityEngine;

public class PassiveItem : Item
{
    public bool equiped;

    private void Update()
    {
        if(!equiped && transform.parent.TryGetComponent(out Arm arm))
        {
            Buff();
            equiped = true;
        }
    }

    private void Buff()
    {
        Debug.Log("BUFF");
    }

    private void OnDestroy()
    {
        equiped = false;
    }
}
