using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMiner : MonoBehaviour
{
    [SerializeField] GameObject itemToCreate;
    [SerializeField] int mineCost;
    [SerializeField] float creationTime;
    private ItemDeposit deposit;
    private Coroutine mineItem;

    private void Start()
    {
        deposit = GetComponent<ItemDeposit>();
    }
    public int MineCost()
    {
        return mineCost;
    }

    public void StartMine()
    {
        if (mineItem == null)
        {
            mineItem = StartCoroutine(MineItem());
        }
    }

    public void StopMine()
    {
        StopCoroutine(MineItem());
        mineItem = null;
    }

    IEnumerator MineItem()
    {
        Debug.Log("StartMine");
        deposit.UzeResourses(mineCost);
        yield return new WaitForSeconds(creationTime);
        GameObject newItem = Instantiate(itemToCreate, transform.position, Quaternion.identity);
        deposit.CreateItem(newItem.GetComponent<Item>());
        mineItem = null;
    }

    public void CreationTimeDecreace()
    {
        creationTime = creationTime * 0.9f;
    }
 
}
