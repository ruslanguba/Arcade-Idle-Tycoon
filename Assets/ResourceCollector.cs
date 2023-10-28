using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCollector : MonoBehaviour
{
    [SerializeField] private int maxItems;
    [SerializeField] private int currentItems;
    [SerializeField] private Transform deposit;
    [SerializeField] private List<Item> items = new List<Item>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Item>() != null)
        {
            TryCollectItem(other.GetComponent<Item>());
        }

        if (other.GetComponent<ItemDeposit>() != null)
        {
            CheckRequiredResources(other.gameObject);
        }

        if (other.GetComponent<BuildingCreator>() != null)
        {
            TransferItemsToBuilding(other.GetComponent<BuildingCreator>());
        }
    }

    private void TryCollectItem(Item item)
    {
        if (currentItems < maxItems)
        {
            CollectItem(item);
        }
    }

    private void CheckRequiredResources(GameObject currentObject)
    {
        ItemDeposit itemDeposit = currentObject.GetComponent<ItemDeposit>();
        ItemTypes depositRequiredItem = itemDeposit.reqrequiredItem;
        StartCoroutine(TransferItemsWithDelay(depositRequiredItem, itemDeposit));
    }

    protected virtual void CollectItem(Item itemToCollect)
    {
        itemToCollect.Transfer(deposit);
        items.Add(itemToCollect);
        currentItems++;
    }

    private void TransferItemsToBuilding(BuildingCreator buildingCreator)
    {
        foreach (ItemTypes itemType in buildingCreator.requiredResources)
        {
            List<Item> itemsToTransfer = new List<Item>();

            for (int i = items.Count - 1; i >= 0; i--)
            {
                if (items[i].Type == itemType)
                {
                    itemsToTransfer.Add(items[i]);
                }
            }

            StartCoroutine(TransferItemToNewBuilding(itemsToTransfer, buildingCreator));
        }
    }

    IEnumerator TransferItemsWithDelay(ItemTypes requiredItem, ItemDeposit itemDeposit)
    {
        int count = itemDeposit.requiredResources();
        for (int i = items.Count - 1; i >= 0; i--)
        {
            if (count != 0)
            {
                if (items[i].Type == requiredItem)
                {
                    itemDeposit.GetItem(items[i]);
                    items.RemoveAt(i);
                    currentItems--;
                    count--;
                    yield return new WaitForSeconds(0.1f);
                }
            }
        }
    }

    IEnumerator TransferItemToNewBuilding(List<Item> itemsToTransfer, BuildingCreator buildingCreator)
    {
        for (int i = itemsToTransfer.Count - 1; i >= 0; i--)
        {
            buildingCreator.GetItem(itemsToTransfer[i]);
            buildingCreator.IncreaseItemCount(itemsToTransfer[i].Type);
            itemsToTransfer.Remove(itemsToTransfer[i]);
            items.RemoveAt(i);
            currentItems = items.Count;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public int GetCapacity()
    {
        return maxItems;
    }

    public void IncreaseCapacity()
    {
        maxItems++;
    }
    public int SetCApacityToWorker()
    {
        return this.maxItems;
    }
}
