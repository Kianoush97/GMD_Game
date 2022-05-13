using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject macePrefab;
    [SerializeField] private GameObject sawPrefab;
    [SerializeField] private GameObject circleMacePrefab;
    [SerializeField] private float respawnTime = 4f;
    private Vector2 screenBounds;

    private void Start()
    {
        StartCoroutine(Enemy());
    }

    private void Update()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void SpawnEnemy()
    {
        GameObject a;
        GameObject b;

        if (Random.Range(0, 3)%2 == 0)
        {
            a = Instantiate(macePrefab);
        }
        else
        {
            a = Instantiate(sawPrefab);
        }
        a.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), (float)(screenBounds.y * 1.5));

        if (Player.score > 1000)
        {            
            b = Instantiate(circleMacePrefab);
            b.transform.position = new Vector2(Random.Range(-screenBounds.x +3 , screenBounds.x -3), (float)(screenBounds.y * 2));
        } 
    }

    private IEnumerator Enemy()
    {
        while (true)
        {
            if (Player.score > 20)
            {
                yield return new WaitForSeconds(respawnTime);
                SpawnEnemy();
            }
            yield return null;
        }
        
    }

    public void SetRespawnTime(float time)
    {
        respawnTime -= time;
        print("Enemy respawn time: " + respawnTime);
    }
}
