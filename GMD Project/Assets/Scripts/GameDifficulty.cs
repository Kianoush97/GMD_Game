using UnityEngine;

public class GameDifficulty : MonoBehaviour
{   
    public int level = 1;
    private readonly int maxLevel = 8;
    private int levelUpScore = 250;
    private readonly float respawnTime = .2f;
    private float speed =0;

    void Update()
    {
        if (Player.score >= levelUpScore)
            LevelUpDifficalty();
    }

    private void LevelUpDifficalty() 
    {
        if (level == maxLevel)
        {
            return;
        }
        else
        {
            levelUpScore *= 2;         
            level+=1;
            speed += 2f;

            if(gameObject.CompareTag("Player"))
                gameObject.GetComponent<Player>().SetSpeed(speed);

            if (gameObject.CompareTag("Enemy")) 
            {               
                gameObject.GetComponent<EnemyMovement>().SetSpeed(speed);
                gameObject.GetComponent<EnemyShoot>().SetRespawnTime(respawnTime);
            }

            if (gameObject.CompareTag("MainCamera"))
                gameObject.GetComponent<EnemyManager>().SetRespawnTime(respawnTime);            
        }

    }
}
