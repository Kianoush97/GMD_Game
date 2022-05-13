using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float enemySpeed;
    private float xDirection;
    private Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        xDirection = -1;
        enemySpeed = 10f;
        print("Enemy movement: " + enemySpeed);
    }

    private void Update()
    {
        rb.velocity = new Vector2(xDirection * enemySpeed, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SideWall"))
        {
            xDirection *= -1;
        }
    }

    public void SetSpeed(float speed)
    {
        enemySpeed = 10f + speed;

        print("Enemy movement: " + enemySpeed);
    }

}
