using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMovement : MonoBehaviour
{
    Vector3 direction = Vector3.right;

    [SerializeField] private float speed = .5f;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += direction * Time.deltaTime * speed;
    }

    public void setDirection(Vector3 dir) 
    {
        direction = dir;
    
    }
}
