using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemTransferPanel : MonoBehaviour
{
    [SerializeField] Text amountText;
    [SerializeField] Text playerText;
    [SerializeField] Text storageText;
    [SerializeField] Slider slider;
    public ItemTypes itemType;
    int inStorageCount;
    int playerCurrentItemCount;
    int playerMaxCapacity;

    public void GetData(
    int inStorageCount,
    int playerCurrentItemCount,
    int playerMaxCapacity)
    {
        this.inStorageCount = inStorageCount;
        this.playerCurrentItemCount = playerCurrentItemCount;
        this.playerMaxCapacity = playerMaxCapacity;
        SetPanelValues();
    }

    public void SetPanelValues()
    {
        int currentCount = playerMaxCapacity - playerCurrentItemCount;
        slider.onValueChanged.AddListener(UpdateValueText);
        slider.maxValue = playerMaxCapacity;
        slider.minValue = 0;
        slider.value = currentCount;
    }

    private void UpdateValueText(float value)
    {
        int roundedValue = Mathf.RoundToInt(value);
        int storageValue = inStorageCount + roundedValue;
        int playerValue = playerMaxCapacity - roundedValue;
        amountText.text = roundedValue.ToString();
        playerText.text = playerValue.ToString();
        storageText.text = storageValue.ToString();

    }
}
