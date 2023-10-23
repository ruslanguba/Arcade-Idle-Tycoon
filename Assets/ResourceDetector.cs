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
        // ���������� ��������� ���� ��� �������� ����������.
        float startAngle = -angle / 2;
        float endAngle = angle / 2;

        // ��������� ��������� � �������� ����������� ��� Raycast.
        Vector3 startDirection = Quaternion.Euler(0, 0, startAngle) * startPoint.transform.right;
        Vector3 endDirection = Quaternion.Euler(0, 0, endAngle) * startPoint.transform.right;

        // ������������� ������� ����������.
        Debug.DrawLine(startPoint.position, startPoint.position + startDirection * radius, rayColor);
        Debug.DrawLine(startPoint.position, startPoint.position + endDirection * radius, rayColor);

        // ��������� Raycast ��� �������� ����������.
        RaycastHit hit;
        if (Physics.Raycast(startPoint.position, startDirection, out hit, radius) ||
            Physics.Raycast(startPoint.position, endDirection, out hit, radius))
        {
            // ��������� ����������� � ��������.
            Debug.Log("����������� � ��������: " + hit.collider.name);
        }
    }
}
