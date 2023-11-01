using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDepositPanel : MonoBehaviour
{
    [SerializeField] public List<UIElementWithType> buttonTypes = new List<UIElementWithType>();
    private ResourcesController resController =  ResourcesController.Instance;

    public void OpenDepositPunel()
    {
        foreach (var buttonType in buttonTypes)
        {
            if(resController == null)
            {
                buttonType.SetResController(resController);
            }
            buttonType.RefreshText();
        }
    }

    

}
