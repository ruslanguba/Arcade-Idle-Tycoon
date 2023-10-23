using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{

    public GameObject objectPrefab;
    public Transform throwPosition;
    public float throwForce = 0.5f;
    public float maxHorizontalForce = 0.1f; // Максимальная горизонтальная сила.

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateAndThrowObject();
        }
    }

    public void CreateAndThrowObject()
    {
        GameObject newObject = Instantiate(objectPrefab, throwPosition.position, Quaternion.identity);
        Rigidbody rb = newObject.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // Генерируем случайную горизонтальную силу от -maxHorizontalForce до maxHorizontalForce.
            float horizontalForceX = Random.Range(-maxHorizontalForce, maxHorizontalForce);
            float horizontalForceZ = Random.Range(-maxHorizontalForce, maxHorizontalForce);

            // Создаем вектор силы с горизонтальными и вертикальными компонентами.
            Vector3 throwForceVector = new Vector3(horizontalForceX, throwForce, horizontalForceZ);

            // Применяем силу.
            rb.AddForce(throwForceVector, ForceMode.Impulse);
        }
    }
}
