using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int meleeCount;
    private int realmeleeCount;
    private int remainMeleeCount;
    [SerializeField] private int rangeCount;
    private int realrangeCount;
    private int remainRangeCount;
    public PlayerManager playerManager;

    private List<GameObject> enemies = new List<GameObject>();
    public Text textLeft;
    public Text textFloor;
    private float timer;
    private void Awake()
    {
        
        playerManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerManager>();
        realmeleeCount = (int)Mathf.Ceil(meleeCount * (1 + (playerManager.stage+1) * 0.2f) * (1 + playerManager.difficulty * 0.5f));
        realrangeCount = (int)Mathf.Ceil(rangeCount * (1 + (playerManager.stage+1) * 0.2f) * (1 + playerManager.difficulty * 0.5f));
    }
    void Start()
    {
        remainMeleeCount = realmeleeCount;
        remainRangeCount = realrangeCount;
        textFloor.text = (playerManager.stage + 1) + "Ãþ";
    }

    void Update()
    {
        enemies.RemoveAll(item => item == null || item.Equals(null) || ReferenceEquals(item, null));
        textLeft.text = enemies.Count + "³²À½";
        if (remainRangeCount == 0 && remainMeleeCount == 0 && enemies.Count == 0)
        {
            playerManager.armstage++;
            playerManager.stage++;
            SceneManager.LoadScene(3);
            Debug.Log("Clear");
        }

        if(timer < 0) 
        {
            int index = Random.Range(0, 4);
            switch(index)
            {
                case 0:
                case 1:
                    if(remainMeleeCount > 0)
                    {
                        remainMeleeCount--;
                    }
                    else
                    {
                        return;
                    }
                    break;
                case 2:
                case 3:
                    if(remainRangeCount > 0)
                    {
                        remainRangeCount--;
                    }
                    else
                    {
                        return;
                    }
                    break;
            }
            var enemyGo = ObjectPoolManager.instance.GetGo(index.ToString());
            enemyGo.GetComponent<Enemy>().speed += Random.Range(-0.2f, 0.2f);

            enemyGo.transform.position = PlayerController.instance.transform.position + new Vector3(Random.Range(-20,20), Random.Range(-10, 10), 0);
            enemies.Add(enemyGo);
            timer = Random.Range(0f, 1f);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
