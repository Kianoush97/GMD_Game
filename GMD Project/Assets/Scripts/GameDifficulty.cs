using UnityEngine;

public class GameDifficulty : MonoBehaviour
{   
    public int difficaltyLevel = 1;
    private readonly int maxDifficaltyLevel = 8;
    private int nextLevelDifficalty = 250;
    private readonly float respawnTime = .2f;
    private float speed =0;

    void Update()
    {
        if (Player.score >= nextLevelDifficalty)
            LevelUpDifficalty();
    }

    private void LevelUpDifficalty() 
    {
        if (difficaltyLevel == maxDifficaltyLevel)
        {
            return;
        }
        else
        {
            nextLevelDifficalty *= 2;         
            difficaltyLevel+=1;
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
            
            print("Difficalty Level: " + difficaltyLevel);
        }

    }
}
