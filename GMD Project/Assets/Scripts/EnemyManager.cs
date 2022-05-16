using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject macePrefab;
    [SerializeField] private GameObject sawPrefab;
    [SerializeField] private GameObject circleMacePrefab;
    [SerializeField] private GameObject maceWithChainPrefab;
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

        if (Random.Range(0, 3) == 1)
            a = Instantiate(macePrefab);
        else
            a = Instantiate(sawPrefab);

        a.transform.position = new Vector2(Random.Range(-screenBounds.x + 3, screenBounds.x - 3), (float)(screenBounds.y + 80));

        if (Player.score > 800)
        {   
            if(Random.Range(1,3) == 1)
                b = Instantiate(circleMacePrefab);
            else 
                b = Instantiate(maceWithChainPrefab);

            b.transform.position = new Vector2(Random.Range(-screenBounds.x +3 , screenBounds.x -3), (float)(screenBounds.y + 300));
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
    }
}
