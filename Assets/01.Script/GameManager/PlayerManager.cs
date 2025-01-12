using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerManager : MonoBehaviour
{
    // 싱글톤 인스턴스를 보관할 정적 변수
    public static PlayerManager Instance { get; private set; }
    [SerializeField]
    public List<int> armItemList = new List<int>();  // 장착중인 아이템 리스트
    public List<int> armAttackKeyList = new List<int>();  // 장착중인 아이템의 공격키 리스트
    public List<int> armATypeList = new List<int>();  //arm type -1 = normal
    public List<GameObject> weaponPrefab = new List<GameObject>(); 
    public List<MeleeWeaponData> meleeItemList = new List<MeleeWeaponData>(); // index 0 = NULL
    public List<RangedWeaponData> rangeItemList = new List<RangedWeaponData>();
    public List<int> itemIdList = new List<int>();
    public GameObject rangedItemPrefab;
    public GameObject meleeItemPrefab;
    public SynergyManager synergyManager;
    public int armstage = 0;
    public int stage = 0;
    public int difficulty = 1;


    private bool isMelee = true;
    private int itemIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        // 기존 인스턴스가 있으면 새로 생성된 오브젝트를 파괴
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // 인스턴스 설정
        Instance = this;

        // 이 오브젝트가 다른 씬에서도 유지되도록 설정 (필요할 경우)
        DontDestroyOnLoad(gameObject);
        for (int i = 0; i < meleeItemList.Count; i++)
        {
            itemIdList.Add(meleeItemList[i].itemId);
        }
        for (int i = 0; i < rangeItemList.Count; i++)
        {
            itemIdList.Add(rangeItemList[i].itemId);
        }
        itemIdList.Sort();
        synergyManager = GetComponent<SynergyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(armItemList.Count < 4)
        {
            if (armstage == 1)
            {
                AddArm(0, 0, -1);
                armstage = 0;
            }
        }
        else
        {
            if (armstage == 2)
            {
                AddArm(0, 0, -1);
                armstage = 0;
            }
        }
    }

    public void AddArm(int id, int keyId, int typeId)
    {
        armItemList.Add(id);
        armAttackKeyList.Add(keyId);
        armATypeList.Add(typeId);   
    }
    public void RemoveArm()
    {
        armItemList.RemoveAt(armItemList.Count - 1);
        armAttackKeyList.RemoveAt(armAttackKeyList.Count - 1);
        armATypeList.RemoveAt(armATypeList.Count - 1);
    }
    public void GetData(List<ArmData> armDatas) // armData 리스트를 받아와 기존에 있던 data를 덮어쓰는 함수
    {
        armItemList = new List<int>();
        armAttackKeyList = new List<int>();
        for (int i = 0; i < armDatas.Count; i++)
        {
            armItemList.Add(armDatas[i].haveItemId);
            armAttackKeyList.Add(armDatas[i].attackButton);
        }
    }

    public ItemData findItem(int id)
    {
        for (int i = 0; i < meleeItemList.Count; i++)
        {
            if (meleeItemList[i].itemId == id)
            {
                isMelee = true;
                itemIndex = i;
            }
        }
        for (int i = 0; i < rangeItemList.Count; i++)
        {
            if (rangeItemList[i].itemId == id)
            {
                isMelee = false;
                itemIndex = i;
            }
        }
        if (isMelee)
        {
            return meleeItemList[itemIndex];

        }
        else
        {
            return rangeItemList[itemIndex];
        }
    }
    public GameObject WeaponGeneration(int id)
    {
        GameObject temp;
        for (int i = 0; i < weaponPrefab.Count; i++)
        {
            if (weaponPrefab[i].GetComponent<Weapon>().itemData.itemId == id)
            {
                itemIndex = i;
            }
        }
        temp = Instantiate(weaponPrefab[itemIndex], new Vector3(0, 0, 0), Quaternion.identity);
        return temp;
    }
}
