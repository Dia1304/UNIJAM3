using System.Collections.Generic;
using UnityEngine;

public class ArmHolder : MonoBehaviour
{
    private List<GameObject> armList;

    [SerializeField] private GameObject obj_arm;

    [SerializeField] private PlayerController controller;

    private void Awake()
    {
        armList = new List<GameObject>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
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
}
