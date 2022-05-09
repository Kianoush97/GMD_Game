using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject macePrefab;
    public GameObject sawPrefab;
    public GameObject circleMacePrefab;
    public float respawnTime = 5f;
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

        if (Player.score > 700)
        {            
            b = Instantiate(circleMacePrefab);
            b.transform.position = new Vector2(Random.Range(-screenBounds.x +3 , screenBounds.x -3), (float)(screenBounds.y * 2));
        } 

        if (Player.score > 700 && Player.score < 1100)
            respawnTime = 4f;

        if (Player.score > 1500)
            respawnTime = 2.5f;
    }

    IEnumerator enemy()
    {
        while (true)
        {
            if (Player.score > 20)
            {
                yield return new WaitForSeconds(respawnTime);
                spawnEnemy();
            }
            yield return null;
        }
        
    }
}
