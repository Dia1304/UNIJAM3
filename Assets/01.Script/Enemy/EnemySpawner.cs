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
            var enemyGo = ObjectPoolManager.instance.GetGo("enemy");

            enemyGo.transform.position = new Vector3(Random.Range(-10, 10), Random.Range(-5, 5), 0);
        }
    }
}
