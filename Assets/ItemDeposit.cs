using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDeposit : MonoBehaviour
{
    public ItemTypes reqrequiredItem;
    private ItemMiner itemMiner;
    private ItemStorge storge;
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
        if (GetComponent<ItemStorge>() != null)
        {
            storge = GetComponent<ItemStorge>();
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
        if (storge != null)
        {
            storge.UseItem(count);
        }
    }

    public void CreateItem(Item newItem)
    {
        outCurrentItemCount++;
        storge.MoveNewItem(newItem);
    }

    public void GetItem(Item inboxItem)
    {
        inCurrentItemCount++;
        if (storge != null)
        {
            storge.ResiveItem(inboxItem);
        }
        else if (GetComponent<ItemOutStorage>() != null)
        {
            GetComponent<ItemOutStorage>().MoveItem(inboxItem);
        }
        else
            inboxItem.Transfer(transform);
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
