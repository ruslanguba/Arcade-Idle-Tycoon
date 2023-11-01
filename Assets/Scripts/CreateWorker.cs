using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWorker : BuildingCreator
{
    [SerializeField] ItemAutoCollector autoCollector;

    protected override void Start()
    {
        base.Start();
            autoCollector = building.GetComponent<ItemAutoCollector>();
    }

    protected override void StartCreation()
    {
        WorkerCreation();
    }

    public void WorkerCreation()
    {
        StartCoroutine(WorkerCreationCor());
    }

    IEnumerator WorkerCreationCor()
    {
        for (int i = 0; i <= 5; i++)
        {
            yield return new WaitForSeconds(1);
            storage.UseItem(i);
        }
        canvas.CanvasOn();
        autoCollector.CreateWorker();
        gameObject.SetActive(false);
    }
}
