using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemTypes Type;
    private bool isColected = false;
    private bool isMoving = false;
    [SerializeField] private Transform depositTransform;

    private void Update()
    {
        if (isColected == true)
            MoveToDeposit();
    }

    public void Collect(Transform Banc)
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        depositTransform = Banc;
        isColected = true;
        isMoving = true;
    }

    public void MoveToDeposit()
    {
        if (isMoving == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, depositTransform.position, 10 * Time.deltaTime);
            if (Vector3.Distance(transform.position, depositTransform.position) < 0.1)
            {
                transform.parent = depositTransform;
                isMoving = false;
            }
        }
    }
}
