using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableResource : MonoBehaviour
{

    [SerializeField] private int maxQuantity;
    [SerializeField] private int currentQuantity;
    [SerializeField] private float respownTime;
    [SerializeField] private ItemSpawn itemSpawner;

    private Coroutine collectionCoroutine;
    private Coroutine respawnCoroutine;

    private void Start()
    {
        itemSpawner = GetComponent<ItemSpawn>();
    }
    public void StartCollection(float collectSpeed)
    {
        Debug.Log("StartColection");
        if (currentQuantity > 0)
        {
            if (collectionCoroutine == null)
            {
                collectionCoroutine = StartCoroutine(CollectionProcess(collectSpeed));
            }
        }
    }

    public void StopCollection()
    {
        Debug.Log("StopColection");
        if (collectionCoroutine != null)
        {
            StopCoroutine(collectionCoroutine);
            collectionCoroutine = null;
            StartCoroutine(RespawnResource());
        }
    }

    private IEnumerator CollectionProcess(float collectSpeed)
    {
        while (currentQuantity > 0)
        {
            yield return new WaitForSeconds(collectSpeed);
            Interaction();
        }
    }

    public void Interaction()
    {
        if (currentQuantity > 0)
        {
            currentQuantity--;
            transform.localScale = transform.localScale * 0.9f;
            itemSpawner.CreateAndThrowObject();

            if (currentQuantity == 0)
            {
                StartCoroutine(RespawnResource());
                GetComponent<CapsuleCollider>().enabled = false;
                foreach (Transform child in transform)
                {
                    child.gameObject.SetActive(false);
                }
                collectionCoroutine = null;
            }
        }
    }

    private IEnumerator RespawnResource()
    {
        yield return new WaitForSeconds(respownTime);
        currentQuantity = maxQuantity;
        transform.localScale = Vector3.one;
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
        GetComponent<CapsuleCollider>().enabled = true;
    }
}
