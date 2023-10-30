using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCreator : MonoBehaviour
{
    public List<ItemTypes> requiredResources = new List<ItemTypes>();

    [SerializeField] protected GameObject building;
    [SerializeField] GameObject buildingBody;
    [SerializeField] int requiredResourcesCount;
    [SerializeField] List<int> currentResourcesCounts;
    [SerializeField] protected ItemInboxStorage storage;
    Coroutine buildingCreation;

    [SerializeField] Dictionary<ItemTypes, int> Required = new Dictionary<ItemTypes, int>();
    private Dictionary<ItemTypes, int> requiredItemsDiff = new Dictionary<ItemTypes, int>();
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
        currentResourcesCounts = new List<int>();

        foreach (ItemTypes itemType in requiredResources)
        {
            currentResourcesCounts.Add(0);
        }
    }
    private void CalculateRequiredItemsDiff()
    {
        for (int i = 0; i < requiredResources.Count; i++)
        {
            ItemTypes itemType = requiredResources[i];
            int currentCount = currentResourcesCounts[i];
            int diff = requiredResourcesCount - currentCount;
            requiredItemsDiff[itemType] = diff;
        }
    }

    public Dictionary<ItemTypes, int> GetRequiredItemsDiff()
    {
        CalculateRequiredItemsDiff();
        return requiredItemsDiff;
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
            currentResourcesCounts[index]++;
            CheckIfCanStartCreation();
        }
    }

    private void CheckIfCanStartCreation()
    {
        bool canStartCreation = true;

        foreach (int requiredCounts in currentResourcesCounts)
        {
            if (requiredCounts < requiredResourcesCount)
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

    protected virtual void StartCreation()
    {
        if(buildingCreation == null)
        {
            buildingCreation = StartCoroutine(BuildingConstruction());
        }
    }

    IEnumerator BuildingConstruction()
    {
        building.gameObject.SetActive(true);
        buildingBody.transform.localScale = Vector3.one * 0.1f;
        if(building.GetComponent<Collider>() != null )
        {
            building.GetComponent<Collider>().enabled = false;
        }

        for (int i = 0; i <= 5; i++)
        {
            yield return new WaitForSeconds(1);
            storage.UseItem(i);
            buildingBody.transform.localScale = Vector3.one * i * 0.2f;

        }

        gameObject.SetActive(false);
        if (building.GetComponent<Collider>() != null)
        {
            building.GetComponent<Collider>().enabled = true;
        }
        storage.UseItem(1000);
    }
}
