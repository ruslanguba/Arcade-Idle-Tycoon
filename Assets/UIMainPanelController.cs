using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainPanelController : MonoBehaviour
{
    [SerializeField] ResourcesController controller;
    [SerializeField] List<Text> textList;
    [SerializeField] Dictionary<ItemTypes, Text> textDictionary = new Dictionary<ItemTypes, Text>();

    void Start()
    {
        controller = GetComponentInParent<ResInit>().ResourcesController;
        if (controller != null)
        {
            Debug.Log("ControllrActive");
        }
        // ��������� ������� ������������ ItemTypes � Text ���������
        for (int i = 0; i < textList.Count; i++)
        {
            ItemTypes itemType = (ItemTypes)i; // �����������, ��� ���������� ����� ��������� � ItemTypes
            textDictionary[itemType] = textList[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var pair in textDictionary)
        {
            ItemTypes itemType = pair.Key;
            Text textElement = pair.Value;

            // �������� �������� ��� i-�� ���� ItemTypes �� controller
            int storageCount = controller.GetStorageCount(itemType);
            int playerCount = controller.GetPlayerCount(itemType);

            // ���������� ����� � ��������������� Text ����
            textElement.text = $"{itemType}: Storage: {storageCount}, Player: {playerCount}";
        }
    }
}
