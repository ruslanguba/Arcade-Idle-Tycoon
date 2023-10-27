using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCreator : MonoBehaviour
{
    public List<ItemTypes> requiredResources = new List<ItemTypes>();
    [SerializeField] GameObject building;
    [SerializeField] int resourcesCount;
    [SerializeField] List<int> requiredResourcesCounts;
    [SerializeField] ItemInboxStorage storage;
    Coroutine buildingCreation;

    private void Start()
    {
        InitializeRequiredResourcesCounts();
        if(GetComponent<ItemInboxStorage>() != null)
        {
            storage = GetComponent<ItemInboxStorage>();
        }
    }

    private void InitializeRequiredResourcesCounts()
    {
        requiredResourcesCounts = new List<int>();

        foreach (ItemTypes itemType in requiredResources)
        {
            requiredResourcesCounts.Add(0);
        }
    }

    public void GetItem(Item item)
    {
        if(storage != null)
        {
            storage.ResiveItem(item);
        }
    }

    public void IncreaseItemCount(ItemTypes itemType)
    {
        int index = requiredResources.IndexOf(itemType);

        if (index != -1)
        {
            requiredResourcesCounts[index]++;
            CheckIfCanStartCreation();
        }
    }

    private void CheckIfCanStartCreation()
    {
        bool canStartCreation = true;

        foreach (int requiredCounts in requiredResourcesCounts)
        {
            if (requiredCounts < resourcesCount)
            {
                canStartCreation = false;
                break;
            }
        }

        if (canStartCreation)
        {
            StartCreation();
        }
    }

    private void StartCreation()
    {
        if(buildingCreation == null)
        {
            buildingCreation = StartCoroutine(BuildingConstruction());
        }
    }

    IEnumerator BuildingConstruction()
    {
        building.gameObject.SetActive(true);
        building.transform.localScale = Vector3.one * 0.1f;
        if(building.GetComponent<Collider>() != null )
        {
            building.GetComponent<Collider>().enabled = false;
        }

        for (int i = 0; i <= 5; i++)
        {
            yield return new WaitForSeconds(1);
            storage.UseItem(i);
            building.transform.localScale = Vector3.one * i * 0.2f;

        }

        gameObject.SetActive(false);
        if (building.GetComponent<Collider>() != null)
        {
            building.GetComponent<Collider>().enabled = true;
        }
    }
}
