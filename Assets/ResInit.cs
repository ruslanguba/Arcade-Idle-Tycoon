using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResInit : MonoBehaviour
{
    public ResourcesController ResourcesController;
    void Awake()
    {
        ResourcesController = new ResourcesController();
        Debug.Log("Inicialised");
    }
}
