using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemTypes Type;
    private bool isMoving = false;
    [SerializeField] private Transform targetTransform;

    private void Update()
    {
        if (isMoving == true)
            MoveToDeposit();
    }

    public void Transfer(Transform Banc)
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        targetTransform = Banc;
        transform.parent = Banc;
        isMoving = true;
    }

    public void MoveToDeposit()
    {
        if (isMoving == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetTransform.position, 10 * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetTransform.position) < 0.1)
            {
                isMoving = false;
            }
        }
    }
}
