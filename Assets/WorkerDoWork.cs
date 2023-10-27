using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorkerDoWork : MonoBehaviour
{
    public Transform resource;  // Ресурс, к которому должен идти работник
    public Transform storage;   // Склад, куда работник будет переносить ресурсы
    public float miningDelay = 2.0f; // Задержка перед каждой попыткой добычи
    public int maxMiningCount = 2;  // Максимальное количество попыток добычи
    public float waitTimeAtStorage = 3.0f;  // Время ожидания у склада
    private Coroutine workCoroutine;
    private NavMeshAgent agent;
    private int miningCount;
    private bool isMining;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        miningCount = 0;
        GoToResource();
    }

    public void SetLocations(Transform storge, Transform resorce)
    {
        this.storage = storge;
        this.resource = resorce;
    }
    private void GoToResource()
    {
        agent.SetDestination(resource.position);
        isMining = true;
    }

    private void GoToStorage()
    {
        agent.SetDestination(storage.position);
        isMining = false;
    }

    private void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            if (isMining)
            {
                TryMineResource();
            }
            else if (!isMining)
            {
                StartWaitingAtStorage();
            }
        }
    }

    private void TryMineResource()
    {
        if (miningCount < maxMiningCount)
        {
            if(workCoroutine == null)
            {
                workCoroutine = StartCoroutine(MineResource());
            }
        }
        else
        {
            GoToStorage();
        }
    }

    private IEnumerator MineResource()
    {
        while (miningCount < maxMiningCount)
        {
            yield return new WaitForSeconds(miningDelay);
            resource.GetComponent<CollectableResource>().Interaction();
            miningCount++;

            if(miningCount == maxMiningCount)
            {
                GoToStorage();
                StopCoroutine(MineResource());
                workCoroutine = null;
            }
        }
        
    }

    private void StartWaitingAtStorage()
    {
        StartCoroutine(WaitAtStorage());
    }

    private IEnumerator WaitAtStorage()
    {
        yield return new WaitForSeconds(waitTimeAtStorage);
        GoToResource();
        miningCount = 0;
    }
}
