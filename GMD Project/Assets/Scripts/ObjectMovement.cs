using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] private float speed = .5f;
    private Vector2 pos1;
    private Vector2 pos2;

    private void Update()
    {
        pos1 = new Vector2(-18, transform.position.y);
        pos2 = new Vector2(18, transform.position.y);

        transform.position = Vector2.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));
        
    }
}
