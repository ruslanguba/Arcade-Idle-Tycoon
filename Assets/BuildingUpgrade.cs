using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingUpgrade : BuildingCreator
{
    private ItemMiner miner;

    protected override void StartCreation()
    {
        UpgradeBuilding();
        Debug.Log("!!!");
    } 

    public void UpgradeBuilding()
    {
        StartCoroutine(BuildingConstruction());
    }

    IEnumerator BuildingConstruction()
    {
        for (int i = 0; i <= 5; i++)
        {
            yield return new WaitForSeconds(1);
            storage.UseItem(i);
        }
        building.GetComponent<ItemMiner>().CreationTimeDecreace();
    }
}
