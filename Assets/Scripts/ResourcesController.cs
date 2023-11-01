using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourcesController
{
    private static ResourcesController instance;

    public static ResourcesController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ResourcesController();
                instance.Initialize();
            }
            return instance;
        }
    }

    private Dictionary<ItemTypes, int> storageCounts = new Dictionary<ItemTypes, int>();
    private Dictionary<ItemTypes, int> playerCounts = new Dictionary<ItemTypes, int>();
    public static Action CountChanged;
    private int PlayerCapacity;
    private void Initialize()
    {
        //MainDeposit.ResourseCountChanged += StorageGetItem;
        CharacterStats.SetPlayerMaxCapacity += SetPlayerMaxCapacity;

        foreach (ItemTypes itemType in Enum.GetValues(typeof(ItemTypes)))
        {
            storageCounts[itemType] = 0;
            playerCounts[itemType] = 0;
        }
        Debug.Log("Initialised");
    }

    public void SetPlayerMaxCapacity(int capacity)
    {
        PlayerCapacity = capacity;
    }

    //public void SetStorageCount(ItemTypes itemType, int count)
    //{
    //    if (storageCounts.ContainsKey(itemType))
    //    {
    //        storageCounts[itemType] = count;
    //    }
    //    else
    //    {
    //        storageCounts.Add(itemType, count);
    //    }
    //}

    public void StorageGetItem(ItemTypes itemType)
    {
        if (storageCounts.ContainsKey(itemType))
        {
            storageCounts[itemType]++;
        }
        else
        {
            storageCounts.Add(itemType, 1);
        }
        CountChanged?.Invoke();
    }

    public void StogageGiveItem(ItemTypes itemType)
    {
        storageCounts[itemType]--;
    }

    public void PlayerCollectItem(ItemTypes itemType)
    {
        if (storageCounts.ContainsKey(itemType))
        {
            playerCounts[itemType]++;
        }
        CountChanged?.Invoke();
    }

    public void PlayerGivetItem(ItemTypes itemType)
    {
        playerCounts[itemType]--;
    }

    public int GetStorageCount(ItemTypes itemType)
    {
        return storageCounts.ContainsKey(itemType) ? storageCounts[itemType] : 0;
    }

    //public void SetPlayerCount(ItemTypes itemType, int count)
    //{
    //    if (playerCounts.ContainsKey(itemType))
    //    {
    //        playerCounts[itemType] = count;
    //    }
    //    else
    //    {
    //        playerCounts.Add(itemType, count);
    //    }
    //}

    public int GetPlayerCount(ItemTypes itemType)
    {
        return playerCounts.ContainsKey(itemType) ? playerCounts[itemType] : 0;
    }

    public int GetPlayerTotal()
    {
        int total = playerCounts.Values.Sum();
        return total;
    }

    //private int SetPlayerTotal()
    //{
    //    int total = playerCounts.Values.Sum();
    //    return total;
    //}

    public int GetPlayerMaxCapacity()
    {
        return PlayerCapacity;
    }
}
