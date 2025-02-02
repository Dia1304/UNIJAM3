using System;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    private Vector2 m_direction;

    public Action OnAttack1;
    public Action OnAttack2;
    public Action OnAttack3;
    public Action OnAttack4;
    public Action OnAttack5;

    //Reference
    //public PlayerStat statData;
    public PlayerStat Stat;
    public PlayerStat statData;
    public SynergyManager SynergyManager;
    [SerializeField] private SpriteRenderer sprite;

    [SerializeField] private Image barImage;

    private void ChangeHealthBarAmount(float amount) //* HP ������ ���� 
    {
        barImage.fillAmount = amount;
    }
    private void Awake()
    {
        m_direction = Vector2.zero;
        instance = this;
        Stat.currentHealth = Stat.maxHealth;

        Stat = Instantiate(statData);
        SynergyManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SynergyManager>();
    }

    private void Update()
    {
        ChangeHealthBarAmount(Stat.currentHealth / Stat.maxHealth);
        if (Stat.currentHealth <= 0)
        {
            Debug.Log("GameOver");
            Stat.currentHealth = Stat.maxHealth;
            SceneManager.LoadScene(5);
        }   
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Time.timeScale = 0.5f;
        }
        if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            Time.timeScale = 1.0f;
        }
    }

    public void Damage()
    {
        StartCoroutine(FlashRed());
    }

    private IEnumerator FlashRed()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.white;
    }

    public void Movement(InputAction.CallbackContext context)
    {
        Vector2 dir = context.ReadValue<Vector2>();
        m_direction = dir;
    }
    public void Attack1(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            OnAttack1?.Invoke();
        }
    }
    public void Attack2(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            OnAttack2?.Invoke();
        }
    }
    public void Attack3(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            OnAttack3?.Invoke();
        }
    }
    public void Attack4(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            OnAttack4?.Invoke();
        }
    }
    public void Attack5(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            OnAttack5?.Invoke();
        }
    }

    public Vector2 GetDirection() => m_direction;
}
