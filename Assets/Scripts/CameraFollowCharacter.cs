using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowCharacter : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0.0f, 20, 0);

    void Update()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position;
            Vector3 newPosition = targetPosition + offset;
            transform.position = newPosition;
        }
    }
}
