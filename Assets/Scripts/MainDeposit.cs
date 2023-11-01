using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDeposit : ItemDeposit
{
    private ResourceCollector character;
    public static Action<ItemTypes> ResourseCountChanged;
    public static Action<int> SetPlayerMaxCapacity;
    ResourcesController resController = ResourcesController.Instance;

    public void FindCharacter(ResourceCollector characterCollector)
    {
        character = characterCollector;
    }

    protected override void Start()
    {
        base.Start();
        UITransferPanel.TransfetItemsToPlayer += TransferItemsToCharacter;
    }

    public override void GetItem(Item inboxItem)
    {
        base.GetItem(inboxItem);
        resController.StorageGetItem(inboxItem.Type);
        //ResourseCountChanged(inboxItem.Type);
    }

    public void TransferItemsToCharacter(ItemTypes type, int count)
    {
        inboxStorage.TransferItemsToPlayer(character, type, count);
    }
}
