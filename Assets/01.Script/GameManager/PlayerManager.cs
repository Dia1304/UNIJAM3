using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    public List<int> armItemList = new List<int>(); // item1 = item data, item2 = attack key
    public List<int> armAttackKeyList = new List<int>(); // item1 = item data, item2 = attack key
    public List<Item> ItemList = new List<Item>(); // index 0 = NULL
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //아이템 리스트 가져오기?
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetData(List<ArmData> armDatas) // armData 리스트를 받아와 기존에 있던 data를 덮어쓰는 함수
    {
        armItemList = new List<int>();
        armAttackKeyList = new List<int>();
        for(int i = 0; i < armDatas.Count; i++)
        {
            armItemList.Add(armDatas[i].haveItemId);
            armAttackKeyList.Add(armDatas[i].attackButton);
        }
    }
}
