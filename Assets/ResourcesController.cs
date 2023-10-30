using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesController
{
    public ResourcesController()
    {
        Initialize();
    }
        
    private Dictionary<ItemTypes, int> storageCounts = new Dictionary<ItemTypes, int>();
    private Dictionary<ItemTypes, int> playerCounts = new Dictionary<ItemTypes, int>();

    private void Initialize()
    {
        MainDeposit.ResourseCountChanged += GetItem;
        foreach (ItemTypes itemType in Enum.GetValues(typeof(ItemTypes)))
        {
            storageCounts[itemType] = 0; // Устанавливаем начальное значение для каждого элемента enum
            playerCounts[itemType] = 0;
        }

    }

    public void SetStorageCount(ItemTypes itemType, int count)
    {
        if (storageCounts.ContainsKey(itemType))
        {
            storageCounts[itemType] = count;
        }
        else
        {
            storageCounts.Add(itemType, count);
        }
    }

    public void GetItem(ItemTypes itemType)
    {
        if (storageCounts.ContainsKey(itemType))
        {
            storageCounts[itemType]++;
            //playerCounts[itemType]--;
        }
        else
        {
            storageCounts.Add(itemType, 1);
        }
    }

    public void PlayerTakeItem(ItemTypes itemType, int count)
    {
        if (storageCounts.ContainsKey(itemType))
        {
            storageCounts[itemType] -= count;
            playerCounts[itemType] += count;
        }
    }

    public int GetStorageCount(ItemTypes itemType)
    {
        return storageCounts.ContainsKey(itemType) ? storageCounts[itemType] : 0;
    }

    public void SetPlayerCount(ItemTypes itemType, int count)
    {
        if (playerCounts.ContainsKey(itemType))
        {
            playerCounts[itemType] = count;
        }
        else
        {
            playerCounts.Add(itemType, count);
        }
    }

    public int GetPlayerCount(ItemTypes itemType)
    {
        return playerCounts.ContainsKey(itemType) ? playerCounts[itemType] : 0;
    }
}
