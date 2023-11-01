using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowCharacter : MonoBehaviour
{
    public Transform target; // Объект, за которым нужно двигаться
    public Vector3 offset = new Vector3(0.0f, 20, 0); // Смещение относительно цели

    void Update()
    {
        if (target != null)
        {
            // Получаем позицию цели
            Vector3 targetPosition = target.position;

            // Добавляем смещение к позиции цели
            Vector3 newPosition = targetPosition + offset;

            // Устанавливаем новую позицию для объекта
            transform.position = newPosition;
        }
    }
}
