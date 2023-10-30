using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITEST : MonoBehaviour
{
    [SerializeField] Text ammount;
    [SerializeField] Slider slider;
    [SerializeField] GameObject transferCanvas;
    void Start()
    {
        //slider.onValueChanged.AddListener(UpdateValueText);
        //transferCanvas.enabled = false;
    }

    private void UpdateValueText(float value)
    {
        int roundedValue = Mathf.RoundToInt(value); // Округляем значение до ближайшего целого числа
        ammount.text = roundedValue.ToString(); // Отображаем округленное значение в текстовом поле
    }

    public void ClickOpenTransferCanvas()
    {
        transferCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClickСloseTransferCanvas()
    {
        Time.timeScale = 1;
        transferCanvas.SetActive(false);
    }
}
