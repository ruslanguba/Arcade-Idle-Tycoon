using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIElementWithType : MonoBehaviour
{
    [SerializeField] public ItemTypes _type;
    [SerializeField] protected ResourcesController resController = ResourcesController.Instance;
    [SerializeField] protected Text itemCountText;

    protected virtual void Start()
    {
        itemCountText = GetComponentInChildren<Text>();
        ResourcesController.CountChanged += RefreshText;
        //MainDeposit.ResourseCountChanged += RefreshText;
    }

    public virtual void RefreshText()
    {
        int currentCount = resController.GetStorageCount(_type);
        itemCountText.text = currentCount.ToString();
    }

    public void SetResController(ResourcesController controller)
    {
        resController = controller;
    }
}
