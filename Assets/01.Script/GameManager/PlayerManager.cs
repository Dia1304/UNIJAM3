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
}
