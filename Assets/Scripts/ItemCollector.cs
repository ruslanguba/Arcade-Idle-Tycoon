using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private List<CollectableResource> resources = new List<CollectableResource>();
    [SerializeField] float collectSpeed;

    private void OnTriggerEnter(Collider other)
    {
        CollectableResource newResource = other.GetComponent<CollectableResource>();
        if (newResource != null)
        {
            resources.Add(newResource);
            newResource.StartCollection(collectSpeed);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        CollectableResource exitedResource = other.GetComponent<CollectableResource>();
        if (exitedResource != null)
        {
            exitedResource.StopCollection();
            resources.Remove(exitedResource);
        }
    }
}
