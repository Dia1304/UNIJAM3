using UnityEngine;

public abstract class Weapon : Item
{
    public override bool Use()
    {
        if(base.Use())
        {
            Attack();
        }
        return true;
    }
    public virtual void Attack()
    {

    }
}
