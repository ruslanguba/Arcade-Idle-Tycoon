using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCollector : MonoBehaviour
{
    [SerializeField] private int maxItems;
    [SerializeField] private int currentItems;
    [SerializeField] private Transform deposit;
    [SerializeField] private List<Item> items = new List<Item>();
    public int Trigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Item>() != null)
        {
            if (currentItems < maxItems)
            {
                CollectItem(other.GetComponent<Item>());
            }
        }

        if (other.GetComponent<ItemDeposit>() != null)
        {
            ItemTypes depositReqrequiredItem = other.GetComponent<ItemDeposit>().reqrequiredItem;
            StartCoroutine(TransferItemsWithDelay(depositReqrequiredItem, other.transform));
        }
    }

    private void CollectItem(Item itemToCollect)
    {
        itemToCollect.GetComponent<Item>().Collect(deposit);
        items.Add(itemToCollect);
        currentItems++;
    }

    IEnumerator TransferItemsWithDelay(ItemTypes requiredItem, Transform target)
    {
        for (int i = items.Count - 1; i >= 0; i--)
        {
            if (items[i].Type == requiredItem)
            {
                items[i].Collect(target);
                items.RemoveAt(i);
                currentItems--;
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
