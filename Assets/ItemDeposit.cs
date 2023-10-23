using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDeposit : MonoBehaviour
{
    private int currentItem;
    public ItemTypes reqrequiredItem;
    
    public void GetItem(Item item)
    {
        item.transform.parent = null;
        
    }
}
