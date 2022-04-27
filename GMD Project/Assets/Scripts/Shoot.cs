using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float respawnTime = 10f;
    public GameObject spikeRightPrefab;
    public GameObject spikeLeftPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(enemyShoot(gameObject));
    }

    void spawnEnemySpike(GameObject enemy)
    {
        GameObject a;
        GameObject b;
        
        a = Instantiate(spikeRightPrefab);
        b = Instantiate(spikeLeftPrefab);
        a.transform.position = enemy.transform.position;
        b.transform.position = enemy.transform.position;
        a.GetComponent<SpikeMovement>().setDirection(Vector3.right);
        b.GetComponent<SpikeMovement>().setDirection(Vector3.left);       
    }

    IEnumerator enemyShoot(GameObject enemy)
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemySpike(enemy);
        }

    }
}
