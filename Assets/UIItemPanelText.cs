using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItemPanelText : MonoBehaviour
{
    [SerializeField] ResInit resInit;
    [SerializeField] ItemTypes itemType;
    [SerializeField] Text itemCountText;
    ResourcesController resController;

    void Start()
    {
        resController = resInit.ResourcesController;
        MainDeposit.ResourseCountChanged += RefreshText;
    }

    public void RefreshText(ItemTypes type)
    {
        int currentCount = resController.GetStorageCount(itemType);
        itemCountText.text = currentCount.ToString();
    }
}
