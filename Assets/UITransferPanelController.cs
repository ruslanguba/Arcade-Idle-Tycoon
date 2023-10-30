using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class UITransferPanelController : MonoBehaviour
{
    [SerializeField] private ResourcesController resourceManager;
    [SerializeField] private ItemTransferPanel panel;

    public void OnButtonClicked(ItemTypes itemType)
    {
        int storageCount = resourceManager.GetStorageCount(itemType);
        int playerCount = resourceManager.GetPlayerCount(itemType);
        int requiredCount = 0; // ¬ычислите количество, которое нужно передать
        panel.GetData(storageCount, playerCount, requiredCount);
    }
}
