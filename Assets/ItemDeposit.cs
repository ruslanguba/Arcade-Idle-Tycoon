using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDeposit : MonoBehaviour
{
    public ItemTypes reqrequiredItem;
    private ItemMiner itemMiner;
    private ItemStorge storge;
    private ItemInboxStorage inboxStorage;
    private ItemOutStorage outStorage;
    [SerializeField] int inCurrentItemCount;
    [SerializeField] int inMaxItemCount;
    [SerializeField] int outCurrentItemCount;
    [SerializeField] int outMaxItemCount;

    private void Start()
    {
        if (GetComponent<ItemMiner>() != null)
        {
            itemMiner = GetComponent<ItemMiner>();
            StartCoroutine(CheckIfCanCreate());
        }
        //if (GetComponent<ItemStorge>() != null)
        //{
        //    storge = GetComponent<ItemStorge>();
        //}
        if (GetComponent<ItemInboxStorage>() != null)
        {
            inboxStorage = GetComponent<ItemInboxStorage>();
        }
        if (GetComponent<ItemOutStorage>() != null)
        {
            outStorage = GetComponent<ItemOutStorage>();
        }
    }

    public int requiredResources()
    {
        int requiredResources = inMaxItemCount - inCurrentItemCount;
        return requiredResources;
    }

    public void UzeResourses(int count)
    {
        Debug.Log("UseRes"+ count);
        inCurrentItemCount = inCurrentItemCount - count;
        inboxStorage.UseItem(count);
    }

    public void CreateItem(Item newItem)
    {
        outCurrentItemCount++;
        GetComponent<ItemOutStorage>().MoveItem(newItem);
    }

    public void GetItem(Item inboxItem)
    {       
        inCurrentItemCount++;
        inboxStorage.ResiveItem(inboxItem);
    }

    IEnumerator CheckIfCanCreate()
    {
        while (true)
        {
            if (inCurrentItemCount >= itemMiner.MineCost())
            {
                itemMiner.StartMine();
            }
            else
            {
                itemMiner.StopMine();
            }
            yield return new WaitForSeconds(1);
        }
    }
}
