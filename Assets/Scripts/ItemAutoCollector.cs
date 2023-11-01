using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAutoCollector : MonoBehaviour
{  
    [SerializeField] ItemTypes ResourcceTypeToCollect;
    [SerializeField] GameObject workerPrefab;
    [SerializeField] List<CollectableResource> resources = new List<CollectableResource>();
    [SerializeField] List<WorkerDoWork> workers = new List<WorkerDoWork>();
    private int workersCount;

    void Awake()
    {
        FindResourses();
    }

    private void FindResourses()
    {
        Collider[] resourceToCollect = Physics.OverlapSphere(transform.position, 7);
        foreach (Collider collider in resourceToCollect)
        {
            if (collider.gameObject.GetComponent<CollectableResource>() != null)
            {
                CollectableResource collectableResource = collider.gameObject.GetComponent<CollectableResource>();
                if (collectableResource.Type == ResourcceTypeToCollect)
                {
                    if(!resources.Contains(collectableResource))
                    resources.Add(collectableResource);
                }
            }
        }
    }

    public void CreateWorker()
    {
        FindResourses();
        GameObject worker = Instantiate(workerPrefab, transform.position, Quaternion.identity);
        worker.GetComponent<WorkerDoWork>().SetLocations(transform ,resources[workersCount].transform);
        worker.GetComponent<WorkerCollector>().SetItemToCollectType(ResourcceTypeToCollect);
        workers.Add(worker.GetComponent<WorkerDoWork>());
        workersCount++;
    }
}
