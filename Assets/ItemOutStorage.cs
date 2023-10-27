using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOutStorage : MonoBehaviour
{
    [SerializeField] Transform firstOutputPosition;
    [SerializeField] Transform OutParrent;
    [SerializeField] List<Transform> outboxTransforms = new List<Transform>();
    [SerializeField] List<Vector3> outboxPositions = new List<Vector3>();
    [SerializeField] GameObject storgePlase;
    int index = 0;

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
                outboxPositions.Add(new Vector3(firstOutputPosition.position.x + 0.5f * x, firstOutputPosition.position.y, firstOutputPosition.position.z - 0.5f * z));
                GameObject OutboxPosition = Instantiate(storgePlase, outboxPositions[index], Quaternion.identity, OutParrent);
                outboxTransforms.Add(OutboxPosition.transform);
                index++;
            }

        }
        firstOutputPosition.position = new Vector3(firstOutputPosition.position.x, firstOutputPosition.position.y + 0.5f, firstOutputPosition.position.z);
    }

    public void MoveItem(Item outboxItem)
    {
        for (int i = 0; i < outboxTransforms.Count; i++)
        {
            if (outboxTransforms[i].transform.childCount == 0)
            {
                outboxItem.Transfer(outboxTransforms[i]);
                //outboxItem.GetComponent<Collider>().enabled = true;
                StartCoroutine(ActivateCollider(outboxItem));
                break;
            }
        }
    }

    IEnumerator ActivateCollider(Item outboxItem)
    {
        yield return new WaitForSeconds(2);
        outboxItem.GetComponent<Collider>().enabled = true;
    }
}
