using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOutStorage : StorageBase
{
    public void MoveItem(Item outboxItem)
    {
        for (int i = 0; i < transforms.Count; i++)
        {
            if (transforms[i].transform.childCount == 0)
            {
                outboxItem.Transfer(transforms[i]);
                StartCoroutine(ActivateCollider(outboxItem));
                break;
            }
        }
    }

    IEnumerator ActivateCollider(Item outboxItem)
    {
        yield return new WaitForSeconds(2);
        outboxItem.GetComponent<Collider>().enabled = true;
    }
}
