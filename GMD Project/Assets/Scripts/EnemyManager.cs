using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //RandomSpawner
    public GameObject macePrefab;
    public GameObject sawPrefab;
    public GameObject spikePrefab;
    public GameObject circleMacePrefab;

    public float respawnTime = 0.3f;
    private Vector2 screenBounds;

    private void Start()
    {
        StartCoroutine(enemy());
    }

    private void Update()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void spawnEnemy()
    {
        GameObject a;
        GameObject b;

        if (Random.Range(1, 6)%2 == 0)
        {
            a = Instantiate(macePrefab);
        }
        else
        {
            a = Instantiate(sawPrefab);
        }
        a.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), (float)(screenBounds.y * 1.5));

        //if(a.name.Equals("macePrefab"))
        //    StartCoroutine(enemyShoot(a));

        if (Player.score > 60)
        {
            if (Random.Range(1, 6) % 2 == 0)
            {
                b = Instantiate(spikePrefab);
            }
            else
            {
                b = Instantiate(circleMacePrefab);
            }
         
            b.transform.position = new Vector2(Random.Range(-screenBounds.x +3 , screenBounds.x -3), (float)(screenBounds.y * 2));
        }    
    }



    IEnumerator enemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
        
    }





    //void spawnEnemySpike(GameObject enemy)
    //{
    //    GameObject a;
    //    a = Instantiate(spikePrefab);
    //    a.transform.position = enemy.transform.position;
    //}

    //IEnumerator enemyShoot(GameObject enemy)
    //{        
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(respawnTime);
    //        if (enemy == null)
    //            yield break;
    //        spawnEnemySpike(enemy);
    //    }

    //}
}
