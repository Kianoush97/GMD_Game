using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform targetToFollow;
    [SerializeField]
    public Transform background1;
    [SerializeField]
    public Transform background2;


    private void LateUpdate()
    {
        if(targetToFollow.position.y > transform.position.y)
        {
            Vector3 newPosition = new Vector3(transform.position.x,
            targetToFollow.position.y, transform.position.z);
            transform.position = newPosition;
        }

        if (targetToFollow.position.y + 17 < transform.position.y)
        {
            LoadGameOverScene();
        }

        if (transform.position.y >= background2.position.y)
        {
            background1.position = new Vector3(background1.position.x, background2.position.y + 55, background1.position.z);
            switchBackground();

        }
    }

    private void switchBackground()
    {
        Transform tmp = background1;
        background1 = background2;
        background2 = tmp;
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
