using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonType : MonoBehaviour
{
    [SerializeField] ItemTypes ButtonItemType;
    ResourcesController ResourcesController;
    [SerializeField] GameObject transferPanelObject;
    [SerializeField] ItemTransferPanel transferPanel;
    [SerializeField] GameObject ResPunel;
    void Start()
    {
        ResourcesController = GetComponentInParent<ResInit>().ResourcesController;
        Debug.Log(ResourcesController.GetPlayerCount(ButtonItemType));
    }

    public void OnClick()
    {
        transferPanelObject.SetActive(true);
        transferPanel.GetData(ResourcesController.GetStorageCount(ButtonItemType), ResourcesController.GetPlayerCount(ButtonItemType), 10);
        ResPunel.SetActive(false);
    }
}
