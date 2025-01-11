using UnityEngine;

public class PassiveItem : Item
{
    public bool equiped;

    public enum Passive
    {
        Null,
        Receipt,
        Incense,
        Kiteshield,
        Rattle,
        Document,
    }

    public Passive passive;

    private void Update()
    {
        if(!equiped && transform.parent.TryGetComponent(out Arm arm))
        {
            Buff();
            equiped = true;
        }
    }

    public void Buff()
    {
        Debug.Log("BUFF");
        if(passive == Passive.Incense)
        {
            PlayerController.instance.Stat.moveSpeed *= 1.2f;
            PlayerController.instance.Stat.attackSpeed *= 1.2f;
        }
    }
    public void Debuff()
    {
        Debug.Log("DEBUFF");
        if(passive == Passive.Incense) 
        {
            PlayerController.instance.Stat.moveSpeed /= 1.2f;
            PlayerController.instance.Stat.attackSpeed /= 1.2f;
        }
    }

    private void OnDestroy()
    {
        Debuff();
        equiped = false;
    }
}
