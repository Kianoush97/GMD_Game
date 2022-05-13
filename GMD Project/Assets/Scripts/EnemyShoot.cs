using System.Collections;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private float respawnTime;
    [SerializeField] private GameObject shootRightPrefab;
    [SerializeField] private GameObject shootLeftPrefab;

    void Start()
    {
        StartCoroutine(enemyShoot(gameObject));
    }

    void spawnEnemySpike(GameObject enemy)
    {
        GameObject a;
        GameObject b;

        a = Instantiate(shootRightPrefab);
        b = Instantiate(shootLeftPrefab);
        a.transform.position = enemy.transform.position;
        b.transform.position = enemy.transform.position;
        a.GetComponent<BulletMovement>().SetDirection(Vector3.right);
        b.GetComponent<BulletMovement>().SetDirection(Vector3.left);       
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

    public void SetRespawnTime(float time)
    {
        respawnTime -= time;
        print("EnemyShoot Respawn time:" + respawnTime);
    }
}
