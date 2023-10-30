using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDeposit : ItemDeposit
{
    private ResourceCollector character;
    public static Action<ItemTypes> ResourseCountChanged;

    public void FindCharacter(ResourceCollector characterCollector)
    {
        character = characterCollector;
    }

    protected override void Start()
    {
        base.Start();
    }

    public override void GetItem(Item inboxItem)
    {
        base.GetItem(inboxItem);
        ResourseCountChanged(inboxItem.Type);
    }

    public void TransferItemsToCharacter(ItemTypes type, int count)
    {
        inboxStorage.TransferItemsToPlayer(character, type, count);
    }
}
