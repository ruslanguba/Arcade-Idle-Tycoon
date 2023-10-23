using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDetector : MonoBehaviour
{
    public Transform startPoint;
    public float radius = 1.0f;
    public float angle = 90.0f;
    public Color rayColor = Color.red;

    void Update()
    {
        // Определите начальный угол для сегмента окружности.
        float startAngle = -angle / 2;
        float endAngle = angle / 2;

        // Вычислите начальное и конечное направление для Raycast.
        Vector3 startDirection = Quaternion.Euler(0, 0, startAngle) * startPoint.transform.right;
        Vector3 endDirection = Quaternion.Euler(0, 0, endAngle) * startPoint.transform.right;

        // Визуализируем сегмент окружности.
        Debug.DrawLine(startPoint.position, startPoint.position + startDirection * radius, rayColor);
        Debug.DrawLine(startPoint.position, startPoint.position + endDirection * radius, rayColor);

        // Выполняем Raycast для сегмента окружности.
        RaycastHit hit;
        if (Physics.Raycast(startPoint.position, startDirection, out hit, radius) ||
            Physics.Raycast(startPoint.position, endDirection, out hit, radius))
        {
            // Обработка пересечения с объектом.
            Debug.Log("Пересечение с объектом: " + hit.collider.name);
        }
    }
}
