using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform targetToFollow;
    [SerializeField] private Transform background1;
    [SerializeField] private Transform background2;

    private void LateUpdate()
    {
        if(targetToFollow.position.y + 9 > transform.position.y)
        {
            Vector3 newPosition = new Vector3(transform.position.x,
            targetToFollow.position.y + 9, transform.position.z);
            transform.position = newPosition;
        }

        if (targetToFollow.position.y + 17 < transform.position.y)
        {
            SceneManager.LoadScene("GameOverScene");
        }

        if (transform.position.y >= background2.position.y)
        {
            background1.position = new Vector2(background1.position.x, background2.position.y + 55);
            (background2, background1) = (background1, background2);

        }
    }
}
