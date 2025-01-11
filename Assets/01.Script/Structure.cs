using UnityEngine;

public class Structure : Item
{
    public float durability;

    void Start()
    {
        Destroy(gameObject, durability);
    }

    void Update()
    {       
        coolTime = GetMultipliedCoolTime(itemData.coolTime);
        CoolTime();

        if(canUse)
        {
            Logic();
            canUse = false;
            timer = coolTime;
        }
    }

    public virtual void Logic()
    {
        Debug.Log("UpdateLogic");
    }
}
