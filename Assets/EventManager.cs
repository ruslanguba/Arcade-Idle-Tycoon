using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static Action<ItemTypes> ItemCountsChanged; // ����������� ���������� ��� ItemCountsChanged

    public static void ItemCountChanged(ItemTypes type) // ����������� ���������� ��� ItemCountChanged
    {
        if (ItemCountsChanged != null)
        {
            ItemCountsChanged.Invoke(type);
        }
    }
}
