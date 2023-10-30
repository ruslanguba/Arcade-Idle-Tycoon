using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static Action<ItemTypes> ItemCountsChanged; // Используйте правильное имя ItemCountsChanged

    public static void ItemCountChanged(ItemTypes type) // Используйте правильное имя ItemCountChanged
    {
        if (ItemCountsChanged != null)
        {
            ItemCountsChanged.Invoke(type);
        }
    }
}
