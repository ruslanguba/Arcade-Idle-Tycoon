using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StorageBase : MonoBehaviour
{
    [SerializeField] protected Transform firstPosition;
    [SerializeField] float offset = 0.7f;
    [SerializeField] protected Transform parrent;
    [SerializeField] protected List<Transform> transforms = new List<Transform>();
    protected List<Vector3> positions = new List<Vector3>();
    protected List<Item> items = new List<Item>();
    [SerializeField] int storageCapacity;

    void Start()
    {
        for (int i = 0; i < 3; i++)
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
                GameObject inboxObject = new GameObject();
                positions.Add(new Vector3(firstPosition.position.x + offset * x, firstPosition.position.y, firstPosition.position.z + offset * z));
                GameObject InboxPosition = Instantiate(inboxObject, positions[storageCapacity], Quaternion.identity, parrent);
                transforms.Add(InboxPosition.transform);
                storageCapacity++;
            }
        }
        firstPosition.position = new Vector3(firstPosition.position.x, firstPosition.position.y + offset, firstPosition.position.z);
    }

    public int StorageMaxCapacity()
    {
        return storageCapacity;
    }
}
