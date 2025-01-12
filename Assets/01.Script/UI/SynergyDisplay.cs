using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework.Interfaces;
using Unity.VisualScripting;
using UnityEngine.PlayerLoop;

public class SynergyDisplay : MonoBehaviour
{
    private PlayerManager playerManager;
    private SynergyManager synergyManager;
    public GameObject[] synergyList = new GameObject[28];
    public GameObject synergyPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerManager>();
        synergyManager = playerManager.synergyManager;
    }

    private void Start()
    {
        for(int i = 0; i < synergyManager.synergyCnt.Length; i++)
        {
            if (synergyManager.synergyCnt[i] > 0)
            {
                if (synergyList[i] == null)
                {
                    GameObject instantiatedObject = Instantiate(synergyPrefab, transform.position, Quaternion.identity);
                    instantiatedObject.transform.SetParent(transform,false); // 부모를 현재 오브젝트로 설정
                    instantiatedObject.GetComponent<RectTransform>().localScale = Vector3.one;
                    synergyList[i] = instantiatedObject;
                    synergyList[i].GetComponentInChildren<Text>().text =  synergyManager.synergyCnt[i].ToString();
                    synergyList[i].GetComponent<ItemDescription>().id = i;
                    if (synergyManager.synergySprite[i] != null)
                        synergyList[i].GetComponentInChildren<Image>().sprite = synergyManager.synergySprite[i];
                }
                else
                {
                    synergyList[i].GetComponentInChildren<Text>().text = synergyManager.synergyCnt[i].ToString();
                }
            }
            else
            {
                if(synergyList[i] != null)
                {
                    Destroy(synergyList[i]);
                }

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < synergyManager.synergyCnt.Length; i++)
        {
            if (synergyManager.synergyCnt[i] != 0)
            {
                if (synergyList[i] == null)
                {
                    GameObject instantiatedObject = Instantiate(synergyPrefab, transform.position, Quaternion.identity);
                    instantiatedObject.transform.SetParent(transform, false); // 부모를 현재 오브젝트로 설정
                    instantiatedObject.GetComponent<RectTransform>().localScale = Vector3.one;
                    synergyList[i] = instantiatedObject;
                    synergyList[i].GetComponentInChildren<Text>().text = synergyManager.synergyCnt[i].ToString();
                    synergyList[i].GetComponent<ItemDescription>().id = i;
                    if (synergyManager.synergySprite[i] != null)
                        synergyList[i].GetComponentInChildren<Image>().sprite = synergyManager.synergySprite[i];
                }
                else
                {
                    synergyList[i].GetComponentInChildren<Text>().text = synergyManager.synergyCnt[i].ToString();
                }
            }
            else
            {
                if (synergyList[i] != null)
                {
                    Destroy(synergyList[i]);
                }

            }
        }
    }
}
