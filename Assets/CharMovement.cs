using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class CharMovement : MonoBehaviour
{
    [SerializeField] private GameObject pointToMove;
    private Camera mCamera;
    private NavMeshAgent agent;
    [SerializeField] private bool isMoving = false;
    private ItemCollector collector;

    void Start()
    {
        mCamera = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        collector = GetComponent<ItemCollector>();
    }

    void Update()
    {
        HandleInput();
        MoveToTarget();
    }

    public void HandleInput()
    {
        RaycastHit hit;

        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(mCamera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                pointToMove.transform.position = hit.point;
                isMoving = true;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            pointToMove.transform.position = transform.position;
            isMoving = false;
        }
    }

    public void MoveToTarget()
    {
        agent.destination = pointToMove.transform.position;
    } 
}
