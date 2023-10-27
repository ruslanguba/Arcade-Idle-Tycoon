using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public GameObject objectPrefab;
    public Transform throwPosition;
    public float throwForce = 0.5f;
    public float maxHorizontalForce = 0.1f;

    public void CreateAndThrowObject()
    {
        GameObject newObject = Instantiate(objectPrefab, throwPosition.position, Quaternion.identity);
        Rigidbody rb = newObject.GetComponent<Rigidbody>();

        if (rb != null)
        {
            float horizontalForceX = Random.Range(-maxHorizontalForce, maxHorizontalForce);
            float horizontalForceZ = Random.Range(-maxHorizontalForce, maxHorizontalForce);
            Vector3 throwForceVector = new Vector3(horizontalForceX, throwForce, horizontalForceZ);
            rb.AddForce(throwForceVector, ForceMode.Impulse);
        }
    }

    public GameObject SetItemToWorker()
    {
        return objectPrefab;
    }
}
