using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemStorge : MonoBehaviour
{
    [SerializeField] Transform firstPosition;
    [SerializeField] Transform firstOutputPosition;
    [SerializeField] Transform InParrent;
    [SerializeField] Transform OutParrent;
    [SerializeField] List<Transform> inboxTransforms = new List<Transform>();
    [SerializeField] List<Transform> outboxTransforms = new List<Transform>();
    [SerializeField] List<Vector3> inboxPositions = new List<Vector3>();
    [SerializeField] List<Vector3> outboxPositions = new List<Vector3>();
    [SerializeField] List<Item> inboxItems = new List<Item>();
    [SerializeField] GameObject storgePlase;
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
        if(Input.GetKeyUp(KeyCode.S))
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
                inboxPositions.Add(new Vector3(firstPosition.position.x + 0.5f * x, firstPosition.position.y, firstPosition.position.z + 0.5f * z));
                outboxPositions.Add(new Vector3(firstOutputPosition.position.x + 0.5f * x, firstOutputPosition.position.y, firstOutputPosition.position.z - 0.5f * z));
                GameObject InboxPosition = Instantiate(storgePlase, inboxPositions[index], Quaternion.identity, InParrent);
                GameObject OutboxPosition = Instantiate(storgePlase, outboxPositions[index], Quaternion.identity, OutParrent);
                inboxTransforms.Add(InboxPosition.transform);
                outboxTransforms.Add(OutboxPosition.transform);
                index++;
            }
            
        }
        firstPosition.position = new Vector3(firstPosition.position.x, firstPosition.position.y + 0.5f, firstPosition.position.z);
        firstOutputPosition.position = new Vector3(firstOutputPosition.position.x, firstOutputPosition.position.y + 0.5f, firstOutputPosition.position.z);
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

    public void MoveNewItem(Item outboxItem)
    {
        for (int i = 0; i < outboxTransforms.Count; i++)
        {
            if (outboxTransforms[i].transform.childCount == 0)
            {
                outboxItem.Transfer(outboxTransforms[i]);
                outboxItem.GetComponent<Collider>().enabled = true;
                break;
            }
        }
    }

    public void UseItem(int count)
    {
        for(int x = 0 ; x < count; x++)
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
