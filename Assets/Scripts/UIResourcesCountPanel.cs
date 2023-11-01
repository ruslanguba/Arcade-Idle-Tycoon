using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIResourcesCountPanel : MonoBehaviour
{
    [SerializeField] public List<UIElementWithType> listResText = new List<UIElementWithType>();
    private ResourcesController resController = ResourcesController.Instance;

    void Start()
    {
        Transform[] childTransforms = GetComponentsInChildren<Transform>();
        foreach (Transform child in childTransforms)
        {
            UIElementWithType elements = child.GetComponent<UIElementWithType>();
            if (elements != null)
            {
                listResText.Add(elements);
            }
        }

        SetLinkForResPanelIcons();
    }

    public void SetLinkForResPanelIcons()
    {
        foreach (var itemText in listResText)
        {
            itemText.SetResController(resController);
        }
    }
}