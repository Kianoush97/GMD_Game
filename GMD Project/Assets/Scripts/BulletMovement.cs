using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private Vector3 direction = Vector3.right;

    [SerializeField] private float bulletSpeed;
    private Rigidbody2D rb;

    private void Start()
    {
       rb = GetComponent<Rigidbody2D>();
        bulletSpeed = 8f;
    }

    private void Update()
    {
        rb.velocity = new Vector2(direction.x * bulletSpeed, rb.velocity.y);    
    }

    public void SetDirection(Vector3 dir) 
    {
        direction = dir;
    
    }
}
