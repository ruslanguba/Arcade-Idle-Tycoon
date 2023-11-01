using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingStock
{
    [SerializeField] Transform firstPosition;
    [SerializeField] Transform InParrent;
    [SerializeField] List<Transform> inboxTransforms = new List<Transform>();
    [SerializeField] List<Vector3> inboxPositions = new List<Vector3>();
    [SerializeField] List<Item> inboxItems = new List<Item>();


    int index = 0;
    [SerializeField] int id = 0;

    public BuildingStock(Transform firstPos)
    {
        this.firstPosition = firstPos;

            
    }
    public void GenerateTransformsForStorge()
    {
        for (int x = 0; x < 3; x++)
        {
            for (int z = 0; z < 3; z++)
            {
                GameObject inboxPosition = new GameObject(); // Создание нового пустого GameObject
                inboxPositions.Add(new Vector3(firstPosition.position.x + 0.5f * x, firstPosition.position.y, firstPosition.position.z + 0.5f * z));
                inboxPosition.transform.position = inboxPositions[index];
                inboxTransforms.Add(inboxPosition.transform);
                index++;
            }
        }
        firstPosition.position = new Vector3(firstPosition.position.x, firstPosition.position.y + 0.5f, firstPosition.position.z);
    }

    public void ResiveItem(Item inboxItem)
    {
        for (int i = 0; i < inboxTransforms.Count; i++)
        {
            if (inboxTransforms[i].transform.childCount == 0)
            {
                inboxItem.Transfer(inboxTransforms[i]);
                inboxItems.Add(inboxItem);
                id++;
                return;
            }
        }
    }

    public void UseItem(int count)
    {
        for (int x = 0; x < count; x++)
        {
            if (id > 0)
            {
                id--;
                GameObject ToDestroy = inboxItems[id].gameObject;
                inboxItems[id].Transfer(InParrent);
                inboxItems.RemoveAt(id);
                Debug.Log("Resourse Used " + id);
            }
        }
    }
}
