using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonType : UIElementWithType
{
    [SerializeField] GameObject transferPanelObject;
    [SerializeField] UITransferPanel transferPanel;
    [SerializeField] GameObject ResPunel;

    public void OnClick()
    {
        transferPanelObject.SetActive(true);
        transferPanel.OpernTransferPanel(_type);
        ResPunel.SetActive(false);
        transferPanel.itemType = _type;
    }
}
