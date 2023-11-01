using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class ResourceCollector : MonoBehaviour
{
    [SerializeField] private int maxItems;
    [SerializeField] private int currentItems;
    [SerializeField] private Transform deposit;
    [SerializeField] private List<Item> items = new List<Item>();
    ResourcesController resController = ResourcesController.Instance;
    
    private void Start()
    {
        CharacterStats.SetPlayerMaxCapacity += SetPlayerMaxCapacity;
    }

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

        if(other.GetComponent<MainDeposit>() != null)
        {
            other.GetComponent<MainDeposit>().FindCharacter(this);
        }
    }

    private void TryCollectItem(Item item)
    {
        if (currentItems < maxItems)
        {
            CollectItem(item);
        }
    }

    public virtual void CollectItem(Item itemToCollect)
    {
        itemToCollect.Transfer(deposit);
        items.Add(itemToCollect);
        currentItems++;
        resController.PlayerCollectItem(itemToCollect.Type);
    }

    private void CheckRequiredResources(GameObject currentObject)
    {
        ItemDeposit itemDeposit = currentObject.GetComponent<ItemDeposit>();
        StartCoroutine(TransferItemsWithDelay(itemDeposit));   
    }

    private void TransferItemsToBuilding(BuildingCreator buildingCreator)
    {
        Dictionary<ItemTypes, int> requiredItemsDiff = buildingCreator.GetRequiredItemsDiff();
        List<Item> itemsToTransfer = new List<Item>();

        foreach (ItemTypes itemType in buildingCreator.requiredResources)
        {
            for (int i = items.Count - 1; i >= 0; i--)
            {
                if (items[i].Type == itemType)
                {
                    if (requiredItemsDiff.ContainsKey(itemType) && requiredItemsDiff[itemType] > 0)
                    {
                        itemsToTransfer.Add(items[i]);
                        requiredItemsDiff[itemType]--;
                    }
                }
            }
            StartCoroutine(TransferItemToNewBuilding(itemsToTransfer, buildingCreator));
        }
        foreach(Item item in itemsToTransfer)
        {
            items.Remove(item);
        }
    }

    IEnumerator TransferItemsWithDelay(ItemDeposit itemDeposit)
    {
        int count = itemDeposit.requiredResources();
        for (int i = items.Count - 1; i >= 0; i--)
        {
            if (count != 0)
            {
                if(itemDeposit.itemTypes.Contains(items[i].Type))
                {
                    itemDeposit.GetItem(items[i]);
                    resController.PlayerGivetItem(items[i].Type);
                    items.Remove(items[i]);
                    currentItems--;
                    count--;
                    yield return new WaitForSeconds(0.1f);
                }
            }
        }
    }

    IEnumerator TransferItemToNewBuilding(List<Item> itemsToTransfer, BuildingCreator buildingCreator)
    {
        yield return new WaitForSeconds(0.1f);
        for (int i = itemsToTransfer.Count - 1; i >= 0; i--)
        {
            buildingCreator.GetItem(itemsToTransfer[i]);
            buildingCreator.IncreaseItemCount(itemsToTransfer[i].Type);
            resController.PlayerGivetItem(itemsToTransfer[i].Type);
            itemsToTransfer.Remove(itemsToTransfer[i]);
            currentItems--;
            yield return new WaitForSeconds(0.1f);
        }

    }

    public void SetPlayerMaxCapacity(int capacity)
    {
        maxItems = capacity;
    }

    public void CharacterReciveItemFromStorage(ItemTypes type)
    {
        resController.PlayerCollectItem(type);
        resController.StogageGiveItem(type);
    }
}
