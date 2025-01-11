using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    public List<int> armItemList = new List<int>();  // 장착중인 아이템 리스트
    public List<int> armAttackKeyList = new List<int>();  // 장착중인 아이템의 공격키 리스트
    public List<GameObject> weaponPrefab = new List<GameObject>(); 
    public List<MeleeWeaponData> meleeItemList = new List<MeleeWeaponData>(); // index 0 = NULL
    public List<RangedWeaponData> rangeItemList = new List<RangedWeaponData>();
    public List<int> itemIdList = new List<int>();
    public GameObject rangedItemPrefab;
    public GameObject meleeItemPrefab;

    private bool isMelee = true;
    private int itemIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        for (int i = 0; i < meleeItemList.Count; i++)
        {
            itemIdList.Add(meleeItemList[i].itemId);
        }
        for (int i = 0; i < rangeItemList.Count; i++)
        {
            itemIdList.Add(rangeItemList[i].itemId);
        }
        itemIdList.Sort();
    }

    // Update is called once per frame
    void Update()
    {

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
