using System.Collections.Generic;
using UnityEngine;

public class ArmHolder : MonoBehaviour
{
    [SerializeField] private List<GameObject> armList = new List<GameObject>();

    [SerializeField] private GameObject obj_arm;

    Vector3 direction;

    private void Awake()
    {
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CreateArm();
        }
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = PlayerController.instance.transform.position.z;

        direction = (mouseWorldPosition - PlayerController.instance.transform.position).normalized;
    }

    public void CreateArm()
    {
        GameObject newArm = Instantiate(obj_arm, transform);
        armList.Add(newArm);

        for(int i = 0; i < armList.Count; i++)
        {
            float angle = (360f / armList.Count) * i * Mathf.Deg2Rad;
            armList[i].transform.localPosition = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle));
        }
        PlayerController.instance.OnAttack += newArm.GetComponent<Arm>().Use;
        PlayerController.instance.OnAttack += newArm.GetComponent<SpecialArm>().Use;
    }
}
