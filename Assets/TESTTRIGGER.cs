using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTTRIGGER : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger");
    }
}
