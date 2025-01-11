using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)) 
        {
            int index = Random.Range(0, 2);
            var enemyGo = ObjectPoolManager.instance.GetGo(index.ToString());

            enemyGo.transform.position = PlayerController.instance.transform.position + new Vector3(Random.Range(-20,20), Random.Range(-10, 10), 0);
        }
    }
}
