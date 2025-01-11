using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator anim;
    private bool isFacingRight;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        transform.position += (Vector3)PlayerController.instance.GetDirection() * PlayerController.instance.Stat.moveSpeed * Time.unscaledDeltaTime;
        if (PlayerController.instance.GetDirection() != Vector2.zero )
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }

        if(!isFacingRight && PlayerController.instance.GetDirection().x > 0)
        {
            Flip();
        }
        else if(isFacingRight && PlayerController.instance.GetDirection().x < 0)
        {
            Flip();
        }
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}
