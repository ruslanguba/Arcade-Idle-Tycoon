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

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.W))
        {
            CreateWorker();
        }
    }

    void Awake()
    {
        Collider[] resourceToCollect = Physics.OverlapSphere(transform.position, 7);
        foreach (Collider collider in resourceToCollect)
        {
            if (collider.gameObject.GetComponent<CollectableResource>() != null)
            {
                if(collider.gameObject.GetComponent<CollectableResource>().Type == ResourcceTypeToCollect)
                {
                    resources.Add(collider.gameObject.GetComponent<CollectableResource>());
                }
            }
        }
    }

    public void CreateWorker()
    {
        GameObject worker = Instantiate(workerPrefab, transform.position, Quaternion.identity);
        worker.GetComponent<WorkerDoWork>().SetLocations(transform ,resources[workersCount].transform);
        worker.GetComponent<WorkerCollector>().SetItemToCollectType(ResourcceTypeToCollect);
        workers.Add(worker.GetComponent<WorkerDoWork>());
        workersCount++;
    }

    public void IncreaceWorkerSpeed()
    {

    }

    public void IncreaceWorkerCapacity()
    {

    }

    public void CreateNewWorker()
    {

    }
}
