using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerCollector : ResourceCollector
{
    [SerializeField] ItemTypes itemToCollectType;

    public void SetItemToCollectType(ItemTypes type)
    {
        this.itemToCollectType = type;
    }
    protected override void CollectItem(Item itemToCollect)
    {
        
        if (itemToCollect.Type == itemToCollectType)
        {
            base.CollectItem(itemToCollect);
        }
    }
}
