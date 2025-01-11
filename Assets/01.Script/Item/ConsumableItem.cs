using UnityEngine;

public class ConsumableItem : Item
{
    public int currentUsableCount = 0;
    public int maxUsablecount = 1;

    public void Charge()
    {
        if (currentUsableCount < maxUsablecount)
        {
            currentUsableCount++;
        }
    }

    public void ResetCount()
    {
        currentUsableCount = maxUsablecount;
    }

    public override bool Use()
    {
        if(base.Use())
        {
            if(currentUsableCount > 0)
            {
                currentUsableCount -= 1;
                UseItem();
                if(currentUsableCount == 0)
                {
                    //Destroy(gameObject);
                }
            }
        }
        return true;
    }
    public virtual void UseItem()
    {

    }
}
