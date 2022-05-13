using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horizontalDirection = 0f;
    private SpriteRenderer sprite;
    public static int score = 0;
    [SerializeField] private float playerSpeed = 15f;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private Animator animator;
    [SerializeField] private int topScore = 0;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text topScoreText;
    [SerializeField] private Text currentDifficaltyLevel;
    [SerializeField] private AudioSource jumpSound;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        topScore = PlayerPrefs.GetInt("topScore", topScore);
    }

    private void Update()
    {
        horizontalDirection = Input.GetAxisRaw("Horizontal");
        transform.rotation = Quaternion.Euler(0, 0, 0);
        currentDifficaltyLevel.text = "Level: " + GetComponent<GameDifficulty>().difficaltyLevel.ToString();

        PlayerMovement();
        UpdateAnimation();
        UpdateScore();
    }

    private void PlayerMovement()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpSound.Play();
        }

        if (horizontalDirection > 0f)
        {
            sprite.flipX = false;
        }
        else if (horizontalDirection < 0f)
        {
            sprite.flipX = true;
        }
        rb.velocity = new Vector2(horizontalDirection * playerSpeed, rb.velocity.y);
    }

    private void UpdateAnimation()
    {
        if (rb.velocity.y > .5f)
        {
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }

        animator.SetFloat("Speed", Mathf.Abs(horizontalDirection));
    }

    private void UpdateScore()
    {
        if(PlayerPrefs.GetInt("topScore") <= score)
        {
            topScore = score;
            PlayerPrefs.SetInt("topScore", topScore);
        }

        if (rb.velocity.y > 0 && transform.position.y > score)
        {
            score = (int)transform.position.y;
        }
        scoreText.text = "Your Score: " + Mathf.Round(score).ToString();
        topScoreText.text = "Top Score: " + Mathf.Round(topScore).ToString();
        TextManager.totalScore = scoreText.text;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyBullet"))
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    public void SetSpeed(float speed) 
    {
        jumpForce = 15f + speed;
        playerSpeed = 15f + speed;

        print("jumpForce: " + jumpForce);
        print("velocity: " + playerSpeed);
    }
}