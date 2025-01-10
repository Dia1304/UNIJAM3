using UnityEngine;

public abstract class Weapon : Item
{
    public override void Use()
    {
        Attack();
    }
    public virtual void Attack()
    {

    }
}
