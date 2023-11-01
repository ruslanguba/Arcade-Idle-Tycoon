using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBuildinCreator : MonoBehaviour
{
    [SerializeField] Text itemType;
    [SerializeField] Text ammount;

    public void RefreshText(ItemTypes type,int count)
    {
        ammount.text = count.ToString();
        itemType.text = type.ToString();
    }
}
