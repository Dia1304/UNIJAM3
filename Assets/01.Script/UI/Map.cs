using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField]
    List<GameObject> mapPerfab = new List<GameObject>();

    [SerializeField]
    int[] mapData = {0,0,1,0,0,1,0,0 };// 첫번째 인덱스가 지금 고를 맵, 그 이후 인덱스는 다음에 고를 맵들, 0은 쉬움, 노말, 하드중 1택, 1은 상점or 이벤트, 추후에 맵 데이터는 게임 매니저로 부터 받아올 예정ㄴ

    private void Awake()
    {
        for(int i = 0; i < 4; i++)
        {

            GameObject instantiatedObject = Instantiate(mapPerfab[mapData[i]], transform.position, Quaternion.identity);
            instantiatedObject.transform.SetParent(transform); // 부모를 현재 오브젝트로 설정
            instantiatedObject.transform.localPosition = new Vector3(0, 2 * i, 0);
        }
    }

}
