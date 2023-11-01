using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCanvasActivator: MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] private bool isActive = true;
    void Start()
    {
        if (GetComponentInChildren<Canvas>() != null)
            canvas = GetComponentInChildren<Canvas>().gameObject;
        canvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isActive)
        {
            if (other.gameObject.GetComponent<CharMovement>())
            {
                canvas.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isActive)
        {
            if (other.gameObject.GetComponent<CharMovement>())
            {
                canvas.SetActive(false);
            }
        }
    }

    public void CanvasOn()
    {
        isActive = true;
    }

    public void CanvasOff()
    {
        isActive = false;
    }
}
