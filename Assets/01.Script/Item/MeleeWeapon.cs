using UnityEngine;

public class MeleeWeapon : Weapon
{
    Vector3 direction;
    private void Update()
    {
        direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = transform.position.z; // 2D ���ӿ����� Z�� ����

        // �÷��̾�� ���콺 ��ġ�� ���ϴ� ���� ���
        Vector3 directionToMouse = (mouseWorldPosition - transform.position).normalized;

        // Ray�� �׸���
        Debug.DrawRay(transform.position, directionToMouse * 3, Color.red);
    }
    public override void Attack()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 3);
        if(hit.collider != null)
        {
            hit.collider.gameObject.GetComponent<Enemy>().Damage(1);
        }

        Debug.Log("Slash");
    }
}
