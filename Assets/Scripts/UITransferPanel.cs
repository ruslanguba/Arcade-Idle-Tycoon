using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITransferPanel : MonoBehaviour
{
    private ResourcesController resController = ResourcesController.Instance;
    public static Action<ItemTypes, int> TransfetItemsToPlayer;
    [SerializeField] Text amountText;
    [SerializeField] Text playerCurrentItemText;
    [SerializeField] Text playerMaxCapacityText;
    [SerializeField] Text storageText;
    [SerializeField] Text playerCurrentCapacityText;
    [SerializeField] Slider slider;
    public ItemTypes itemType;
    int _inStorageCount;
    int _playerCurrentItemCount;
    int _playerMaxCapacity;
    int _playerCurrentCapacity;
    int _ammountToTransfer;

    public void OpernTransferPanel(ItemTypes type)
    {
        GetData(resController.GetStorageCount(type), resController.GetPlayerCount(type), resController.GetPlayerTotal(), resController.GetPlayerMaxCapacity());
    }

    public void GetData(
    int inStorageCount,
    int playerCurrentItemCount,
    int playerCurrentCapacity,
    int playerMaxCapacity)
        
    {
        this._inStorageCount = inStorageCount;
        this._playerCurrentItemCount = playerCurrentItemCount;
        this._playerCurrentCapacity = playerCurrentCapacity;
        this._playerMaxCapacity = playerMaxCapacity;
        SetPanelValues();
    }

    public void SetPanelValues()
    {
        slider.onValueChanged.AddListener(UpdateValueText);
        slider.maxValue = calcSliderValue();
        slider.minValue = -_playerCurrentItemCount;
        slider.value = 0;
        playerMaxCapacityText.text = _playerMaxCapacity.ToString();
        playerCurrentCapacityText.text = _playerCurrentCapacity.ToString();
        playerCurrentItemText.text = _playerCurrentItemCount.ToString();
        storageText.text = _inStorageCount.ToString();
        amountText.text = slider.value.ToString();
    }

    private void UpdateValueText(float value)
    {
        int amountItemToTransfer = Mathf.RoundToInt(value);
        int storageValue = _inStorageCount - amountItemToTransfer;
        int playerValue = _playerCurrentItemCount + amountItemToTransfer;
        int currenCapacity = _playerCurrentCapacity + amountItemToTransfer;
        amountText.text = amountItemToTransfer.ToString();
        playerCurrentItemText.text = playerValue.ToString();
        storageText.text = storageValue.ToString();
        playerCurrentCapacityText.text = currenCapacity.ToString();
    }

    private int calcSliderValue()
    {
        int sliderValue = 0;
        if (_inStorageCount < _playerMaxCapacity - _playerCurrentCapacity)
        {
            sliderValue = _inStorageCount;
        }
        else sliderValue = _playerMaxCapacity - _playerCurrentCapacity;
        return sliderValue;
    }

    public void OnClickTransfer()
    {
        _ammountToTransfer = Mathf.RoundToInt(slider.value);
        TransfetItemsToPlayer?.Invoke(itemType, _ammountToTransfer);
    }
}
