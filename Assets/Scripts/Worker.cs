using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Worker : MonoBehaviour
{
    [SerializeField] public Transform storge;
    [SerializeField] public Transform resource;
    [SerializeField] float waitTime = 6.0f;

    [SerializeField] int MaxCapacity;
    [SerializeField] int currentCapacity;

    private NavMeshAgent agent;
    private Transform currentDestination;
    [SerializeField] private bool isWaiting;
    private float waitTimer;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetDestination(resource);
        isWaiting = true;
    }

    private void Update()
    {
        WorkerMove();
    }

    public void SetLocations(Transform storge, Transform resorce)
    {
        this.storge = storge;
        this.resource = resorce;
    }

    private void WorkerMove()
    {
        if (isWaiting)
        {
            waitTimer -= Time.deltaTime;
            if (waitTimer <= 0)
            {
                isWaiting = false;
                ToggleDestination();
            }
        }
    }
    private void SetDestination(Transform destination)
    {
        if (destination != null)
        {
            agent.SetDestination(destination.position);
            currentDestination = destination;
        }
    }

    private void ToggleDestination()
    {
        if (currentDestination == resource)
        {
            currentCapacity = MaxCapacity;
            SetDestination(storge);
        }

        else if (currentDestination == storge)
        {
            SetDestination(resource);
            currentCapacity = 0;
        }
        Debug.Log(currentDestination.name);
        isWaiting = true;
        waitTimer = waitTime;
    }
}
