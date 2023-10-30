using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDeposit : MonoBehaviour
{
    //public ItemTypes reqrequiredItem;

    public List<ItemTypes> itemTypes = new List<ItemTypes>();

    private ItemMiner itemMiner;
    protected ItemInboxStorage inboxStorage;
    private ItemOutStorage outStorage;
    [SerializeField] protected int inCurrentItemCount;
    [SerializeField] protected int MaxItemCount;
    [SerializeField] protected int outCurrentItemCount;
    [SerializeField] protected int iMaxItemCount;

    protected virtual void Start()
    {
        if (GetComponent<ItemMiner>() != null)
        {
            itemMiner = GetComponent<ItemMiner>();
            StartCoroutine(CheckIfCanCreate());
        }
        if (GetComponent<ItemInboxStorage>() != null)
        {
            inboxStorage = GetComponent<ItemInboxStorage>();
            Invoke("SetCapaciity", 3);
        }
        if (GetComponent<ItemOutStorage>() != null)
        {
            outStorage = GetComponent<ItemOutStorage>();
        }
    }

    private void SetCapaciity()
    {
        MaxItemCount = inboxStorage.StorageMaxCapacity();
    }

    public int requiredResources()
    {
        int requiredResources = MaxItemCount - inCurrentItemCount;
        return requiredResources;
    }

    public void UzeResourses(int count)
    {
        inCurrentItemCount = inCurrentItemCount - count;
        inboxStorage.UseItem(count);
    }

    public void CreateItem(Item newItem)
    {
        outCurrentItemCount++;
        outStorage.MoveItem(newItem);
    }

    public virtual void GetItem(Item inboxItem)
    {       
        inCurrentItemCount++;
        inboxStorage.ResiveItem(inboxItem);
        if(inCurrentItemCount >= inboxStorage.StorageMaxCapacity())
        {
            inboxStorage.GenerateTransformsForStorge();
            SetCapaciity();
        }
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
