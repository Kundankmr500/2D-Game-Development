using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamraFollow : MonoBehaviour
{
    public Transform Target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void LateUpdate ()
    {
        if (Target != null)
        {
            Vector3 newPosition = Target.position;
            //newPosition.z = -10;
            transform.position = Vector3.Slerp(transform.position, newPosition + offset, smoothSpeed * Time.deltaTime);
        }
        
    }
}
