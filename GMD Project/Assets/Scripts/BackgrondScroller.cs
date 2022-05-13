using UnityEngine;

public class BackgrondScroller : MonoBehaviour
{
    void Update()
    {
        transform.position += new Vector3(0, -5 * Time.deltaTime);

        if (transform.position.y < -10)
        {
            transform.position = new Vector3(transform.position.x, 10f);
        }
    }
}
