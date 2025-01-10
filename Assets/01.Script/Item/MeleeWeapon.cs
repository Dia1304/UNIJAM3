using UnityEngine;

public class MeleeWeapon : Weapon
{
    Vector3 direction;
    private void Update()
    {
        direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = transform.position.z; // 2D 게임에서는 Z축 고정

        // 플레이어에서 마우스 위치를 향하는 방향 계산
        Vector3 directionToMouse = (mouseWorldPosition - transform.position).normalized;

        // Ray를 그리기
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
