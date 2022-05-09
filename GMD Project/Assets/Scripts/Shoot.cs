using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private float respawnTime;
    [SerializeField] private GameObject shootRightPrefab;
    [SerializeField] private GameObject shootLeftPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(enemyShoot(gameObject));
    }

    void spawnEnemySpike(GameObject enemy)
    {
        GameObject a;
        GameObject b;

        if (Player.score > 300 && Player.score < 500)
        {
            respawnTime = 3f;
            print("respawn time" + respawnTime);
        }
        else if (Player.score > 500 && Player.score < 700)
        {
            respawnTime = 2.8f;
            print("respawn time" + respawnTime);
        }
        else if (Player.score > 700 && Player.score < 1000)
        {
            respawnTime = 2f;
            print("respawn time" + respawnTime);
        }
        else if (Player.score > 1000)
        {
            respawnTime = 1.8f;
            print("respawn time" + respawnTime);
        }

        a = Instantiate(shootRightPrefab);
        b = Instantiate(shootLeftPrefab);
        a.transform.position = enemy.transform.position;
        b.transform.position = enemy.transform.position;
        a.GetComponent<SpikeMovement>().setDirection(Vector3.right);
        b.GetComponent<SpikeMovement>().setDirection(Vector3.left);       
    }

    IEnumerator enemyShoot(GameObject enemy)
    {
        while (true)
        {
            //Only Mace will shoot
            if (Player.score > 350 && Player.score < 1000 && gameObject.name.Contains("Mace"))
            {
                yield return new WaitForSeconds(respawnTime);
                spawnEnemySpike(enemy);
            }
            else if (Player.score > 1000)
            {
                // Both mace and saw will shoot
                yield return new WaitForSeconds(respawnTime);
                spawnEnemySpike(enemy);
            }
            yield return null;
        }

    }
}
