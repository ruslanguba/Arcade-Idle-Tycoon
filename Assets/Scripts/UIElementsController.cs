using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIElementsController : MonoBehaviour
{
    [SerializeField] UIDepositPanel depositPanel;
    [SerializeField] UIResourcesCountPanel resourcesPanel;
    [SerializeField] UITransferPanel transferPanel;
    [SerializeField] CharMovement charMovement;
    private ResourcesController resController = ResourcesController.Instance;
    [SerializeField] public List<UIElementWithType> itemCountTexts = new List<UIElementWithType>();

    void Start()
    {
        depositPanel.gameObject.SetActive(false);
        resourcesPanel.gameObject.SetActive(true);
    }

    public void ClickOpenDepositPanel()
    {
        depositPanel.gameObject.SetActive(true);
        depositPanel.OpenDepositPunel();
        charMovement.enabled = false;
    }

    public void ConttinueGame()
    {
        depositPanel.gameObject.SetActive(false);
        charMovement.enabled = true;
    }
}
