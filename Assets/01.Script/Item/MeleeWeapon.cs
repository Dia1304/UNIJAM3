using UnityEngine;

public class MeleeWeapon : Weapon
{
    Vector3 direction;
    private void Update()
    {  
        if(timer >= 0 && canUse == false)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            canUse = true;
        }

        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = PlayerController.instance.transform.position.z;

        direction = (mouseWorldPosition - PlayerController.instance.transform.position).normalized;

        Debug.DrawRay(PlayerController.instance.transform.position, direction * 3, Color.red);
    }
    public override void Attack()
    {
        RaycastHit2D hit = Physics2D.Raycast(PlayerController.instance.transform.position, direction, 3, LayerMask.GetMask("Enemy"));
        if(hit.collider != null)
        {
            hit.collider.gameObject.GetComponent<Enemy>().Damage(((WeaponData)itemData).damage);
        }

        Debug.Log("Slash");
    }
}
