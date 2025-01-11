using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int meleeCount;
    private int remainMeleeCount;
    [SerializeField] private int rangeCount;
    private int remainRangeCount;

    private List<GameObject> enemies = new List<GameObject>();

    private float timer;

    void Start()
    {
        remainMeleeCount = meleeCount;
        remainRangeCount = rangeCount;
    }

    void Update()
    {
        enemies.RemoveAll(item => item == null || item.Equals(null) || ReferenceEquals(item, null));

        if (remainRangeCount == 0 && remainMeleeCount == 0 && enemies.Count == 0)
        {
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
            timer = Random.Range(0f, 2f);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
