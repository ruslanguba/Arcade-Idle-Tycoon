using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInboxStorage : MonoBehaviour
{
    [SerializeField] Transform firstPosition;
    [SerializeField] Transform InParrent;
    [SerializeField] List<Transform> inboxTransforms = new List<Transform>();
    [SerializeField] List<Vector3> inboxPositions = new List<Vector3>();
    [SerializeField] List<Item> inboxItems = new List<Item>();

    int index = 0;
    [SerializeField] int id = 0;
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            GenerateTransformsForStorge();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            GenerateTransformsForStorge();
        }
    }

    public void GenerateTransformsForStorge()
    {
        for (int x = 0; x < 3; x++)
        {
            for (int z = 0; z < 3; z++)
            {
                GameObject inboxObject = new GameObject(); // Создание нового пустого GameObject
                inboxPositions.Add(new Vector3(firstPosition.position.x + 0.5f * x, firstPosition.position.y, firstPosition.position.z + 0.5f * z));
                GameObject InboxPosition = Instantiate(inboxObject, inboxPositions[index], Quaternion.identity, InParrent);
                inboxTransforms.Add(InboxPosition.transform);
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
                inboxItems[id].Transfer(transform);
                inboxItems.RemoveAt(id);
                Debug.Log("Resourse Used " + id);
            }
        }
    }
}
