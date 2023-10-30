using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInboxStorage : StorageBase
{
    int id = 0;

    public void ResiveItem(Item inboxItem)
    {
        for (int i = 0; i < transforms.Count; i++)
        {
            if (transforms[i].transform.childCount == 0)
            {
                inboxItem.Transfer(transforms[i]);
                items.Add(inboxItem);
                id++;
                return;
            }
        }
    }

    public void UseItem(int count)
    {
        for (int x = 0; x < count; x++)
        {
            if (id > 0)
            {
                id--;
                GameObject ToDestroy = items[id].gameObject;
                items[id].Transfer(transform);
                items.RemoveAt(id);
                Debug.Log("Resourse Used " + id);
            }
        }
    }

    public void TransferItemsToPlayer(ResourceCollector character, ItemTypes type, int itemToTransferCount)
    {
        List<Item> itemsToTransfer = new List<Item>();
        int count = itemToTransferCount;
        foreach (Item item in items)
        {
            if(count >= 0)
            {
                if(item.Type == type)
                {
                    itemsToTransfer.Add(item);
                    items.Remove(item);
                    count--;
                }
            }
        }
        StartCoroutine(TransferToPlaerCor(character, itemsToTransfer));
    }

    IEnumerator TransferToPlaerCor(ResourceCollector character, List<Item> itemsToTransfer)
    {
        for(int i = 0; i < itemsToTransfer.Count; i++)
        {
            character.CollectItem(itemsToTransfer[i]);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
