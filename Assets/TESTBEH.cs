using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TESTBEH : MonoBehaviour
{
    [SerializeField] Text Show;
    [SerializeField] private TESTABS testAbs = new TESTABS();
    void Start()
    {
        Show.text = testAbs.ToShowInt();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            testAbs.Click();
            Show.text = testAbs.ToShowInt();
        }
    }
    
}
