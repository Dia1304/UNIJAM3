using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class ArmHolder : MonoBehaviour
{
    public List<GameObject> armList = new List<GameObject>();
    private List<LineRenderer> lineRenderers = new List<LineRenderer>();
    public PlayerManager playerManager;
    public GameObject obj_arm;

    Vector3 direction;

    private void Awake()
    {
        playerManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerManager>();
    }
    private void Start()
    {
        for(int i = 0; i < playerManager.armItemList.Count; i++) 
        {
            CreateArm(playerManager.armItemList[i], playerManager.armAttackKeyList[i]);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            CreateArm();
        }
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = PlayerController.instance.transform.position.z;

        direction = (mouseWorldPosition - PlayerController.instance.transform.position).normalized;
    }

    public void CreateArm(int id = 0, int keyId = 0)
    {
        GameObject newArm = Instantiate(obj_arm, transform);
        armList.Add(newArm);
        GameObject weapon = playerManager.WeaponGeneration(id);
        newArm.GetComponent<Arm>().EquipItem(weapon);

        for(int i = 0; i < armList.Count; i++)
        {
            float angle = (360f / armList.Count) * i * Mathf.Deg2Rad;
            armList[i].transform.localPosition = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle));
        }
        PlayerController.instance.OnAttack1 += newArm.GetComponent<Arm>().Use;
        PlayerController.instance.OnAttack1 += newArm.GetComponent<SpecialArm>().Use;
        newArm.GetComponent<Arm>().ChangeAttackKey((Arm.AttackKey)keyId);
    }
}
