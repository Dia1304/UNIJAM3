using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
public class ArmManager : MonoBehaviour
{
    [SerializeField]
    private GameObject armPreFab;
    List<ArmData> armDatas = new List<ArmData>();
    public PlayerManager playerManager;

    private void Awake()
    {
        playerManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerManager>();
    }
    void Start()
    {
        for(int i = 0; i < playerManager.armItemList.Count; i++)
        {
            GameObject instantiatedObject = Instantiate(armPreFab, transform.position, Quaternion.identity);
            instantiatedObject.transform.SetParent(transform); // 부모를 현재 오브젝트로 설정
            instantiatedObject.GetComponent<RectTransform>().localScale = Vector3.one;
            armDatas.Add(instantiatedObject.GetComponent<ArmData>());
            armDatas[armDatas.Count - 1].haveItemId = playerManager.armItemList[armDatas.Count - 1];
            armDatas[armDatas.Count - 1].attackButton = playerManager.armAttackKeyList[armDatas.Count - 1];
            armDatas[armDatas.Count - 1].SetButton();
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
