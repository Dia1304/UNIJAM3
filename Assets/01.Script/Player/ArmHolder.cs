using System.Collections.Generic;
using UnityEngine;

public class ArmHolder : MonoBehaviour
{
    [SerializeField] private List<GameObject> armList = new List<GameObject>();

    [SerializeField] private GameObject obj_arm;

    [SerializeField] private PlayerController controller;

    private void Awake()
    {

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CreateArm();
        }
    }

    public void Test()
    {

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
        controller.OnAttack += newArm.GetComponent<Arm>().Use;
    }
}
