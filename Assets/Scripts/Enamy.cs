using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enamy : MonoBehaviour
{
    public float Speed = 1.0f;
    public float Offset;

    private Vector3 playerPos;
    private bool dirRight = true;

    public void Start()
    {
        playerPos = transform.position;
    }


    void Update()
    {
        if (dirRight)
            transform.Translate(Vector2.right * Speed * Time.deltaTime);
        else
            transform.Translate(-Vector2.right * Speed * Time.deltaTime);

        if (transform.position.x >= playerPos.x + Offset)
        {
            dirRight = false;
        }

        if (transform.position.x <= playerPos.x - Offset)
        {
            dirRight = true;
        }
    }
}
